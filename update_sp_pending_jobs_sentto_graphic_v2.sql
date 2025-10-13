-- =============================================
-- Description: Corrected and optimized version of the Pending_Jobs_Sentto_Graphic_sp stored procedure.
--
-- This script fixes a syntax error in the previous version and maintains performance optimizations.
--
-- Changes in this version:
-- 1. Corrected a syntax error related to the placement of the Common Table Expression (CTE).
-- 2. The recursive CTE now populates a table variable `@UserHierarchy` first.
-- 3. This table variable is then used to filter the main query, which is a more compatible syntax.
--
-- How to use:
-- 1. Connect to your Azure SQL database (GRAPHICPPC_NEW) using SQL Server Management Studio (SSMS) or Azure Data Studio.
-- 2. Open a new query window.
-- 3. Copy and paste the entire content of this file into the query window.
-- 4. Execute the script. This will update the existing stored procedure.
-- =============================================

ALTER PROC Pending_Jobs_Sentto_Graphic_sp
    @fromdt CHAR(20),
    @todt CHAR(20),
    @empcd CHAR(7),
    @printcd CHAR(7),
    @assignedto CHAR(7)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @fdt AS SMALLDATETIME = CONVERT(SMALLDATETIME, @fromdt, 103);
    DECLARE @tdt AS SMALLDATETIME = CONVERT(SMALLDATETIME, @todt, 103);
    DECLARE @administrator AS CHAR(1);

    SELECT @administrator = administrator FROM users WHERE u_id = @empcd;

    -- Declare a table variable to hold the hierarchy of users
    DECLARE @UserHierarchy TABLE (u_id CHAR(7));

    -- If the user is not an administrator, populate the hierarchy table
    IF @administrator <> '1'
    BEGIN
        -- Use a recursive CTE to build the user hierarchy and insert it into the table variable
        WITH UserCTE AS
        (
            -- Anchor member: the starting user
            SELECT u_id FROM users WHERE u_id = @empcd
            UNION ALL
            -- Recursive member: find users reporting to the previous level
            SELECT u.u_id FROM users u INNER JOIN UserCTE uh ON u.ReportingTo = uh.u_id
        )
        INSERT INTO @UserHierarchy (u_id)
        SELECT u_id FROM UserCTE
        OPTION (MAXRECURSION 0); -- Allow for deep hierarchies
    END

    -- Using a CTE for the main query to improve readability
    WITH JobData AS
    (
        SELECT
            j.jobid,
            j.jobname,
            j.cuscode,
            c.cusname,
            j.intcode,
            j.revno,
            j.prioirty,
            j.printcd,
            p.printname,
            j.sentographic_dt AS jobcreatedt,
            j.assignedto_appformgraphic AS assignedto,
            u.u_name AS assignedname,
            j.ticketno,
            -- Calculate status in a single expression
            CASE
                WHEN ISNULL(j.cancelflag, '0') = '1' THEN 'Cancelled'
                WHEN ISNULL(j.dispatch_close_flag, '0') = '1' THEN 'Billing Done & Job Close'
                WHEN ISNULL(j.sendfor_billing_flag, '0') = '1' THEN 'Send To Billing'
                WHEN ISNULL(j.sendfor_dispatch_flag, '0') = '1' THEN 'Send To Dispatch'
                WHEN ISNULL(j.sendfor_challan_flag, '0') = '1' THEN 'Send To Challan'
                WHEN ISNULL(j.qc_check_flag, '0') = '1' THEN 'Send To QC'
                WHEN ISNULL(j.sendfor_reproduction_flag, '0') = '1' THEN 'Send To Material Production'
                WHEN ISNULL(j.approve_sendforprepress_flag, '0') = '1' THEN 'Send To Prepress'
                WHEN ISNULL(j.approve_sendtocustomerforapprval_flag, '0') = '1' THEN 'Send To Customer For Approval'
                WHEN ISNULL(j.customer_approval_flag, '0') = '1' THEN 'Approval Form Send To Customer '
                WHEN ISNULL(j.sento_customer_flag, '0') = '1' THEN 'Send To Customer'
                WHEN ISNULL(j.sendtographics_flag, '0') = '1' THEN 'Send To Graphics'
                ELSE 'Pending'
            END AS status
        FROM
            jobentry j
        LEFT JOIN
            customer c ON j.cuscode = c.cuscode
        LEFT JOIN
            printing p ON j.printcd = p.printcd
        LEFT JOIN
            users u ON j.assignedto_appformgraphic = u.u_id
        WHERE
            -- Make the date filter SARGable by not using CAST on the column
            j.sentographic_dt >= @fdt AND j.sentographic_dt < DATEADD(day, 1, @tdt)
    )
    -- Final SELECT from the CTE
    SELECT *
    FROM JobData
    WHERE
        status = 'Send To Graphics'
        AND (@printcd = '' OR ISNULL(printcd, '') = @printcd)
        AND (@assignedto = '' OR ISNULL(assignedto, '') = @assignedto)
        AND (
            -- If user is an admin, the condition is true.
            -- If not, check if the assigned user is in the hierarchy table.
            @administrator = '1' OR assignedto IN (SELECT u_id FROM @UserHierarchy)
        )
    ORDER BY jobcreatedt DESC;

END;