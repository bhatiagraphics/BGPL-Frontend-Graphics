-- =============================================
-- Description: Optimized version of the Summary_Pending_Jobs_ApprovalformGraphics_sp stored procedure.
--
-- This script replaces the original procedure with a more efficient version that:
-- 1. Uses a recursive Common Table Expression (CTE) instead of cursors to build the user hierarchy.
-- 2. Combines multiple UPDATE statements into a single SELECT with a CASE expression.
-- 3. Removes unnecessary temporary tables.
-- This should significantly improve performance and resolve the timeout issue.
--
-- How to use:
-- 1. Connect to your Azure SQL database (GRAPHICPPC_NEW) using SQL Server Management Studio (SSMS) or Azure Data Studio.
-- 2. Open a new query window.
-- 3. Copy and paste the entire content of this file into the query window.
-- 4. Execute the script. This will update the existing stored procedure.
-- =============================================

ALTER PROC Summary_Pending_Jobs_ApprovalformGraphics_sp
    @fromdt CHAR(20),
    @todt CHAR(20),
    @empcd CHAR(7),
    @printcd CHAR(7)
AS
BEGIN
    -- Disables the count of rows affected messages for performance
    SET NOCOUNT ON;

    -- Convert input date strings to smalldatetime
    DECLARE @fdt AS SMALLDATETIME = CONVERT(SMALLDATETIME, @fromdt, 103);
    DECLARE @tdt AS SMALLDATETIME = CONVERT(SMALLDATETIME, @todt, 103);
    DECLARE @administrator AS CHAR(1);

    -- Check if the user is an administrator
    SELECT @administrator = administrator FROM users WHERE u_id = @empcd;

    -- Use two different execution paths for administrators and regular users for better performance
    IF @administrator = '1'
    BEGIN
        -- Logic for administrator: Fetches data for all users
        SELECT
            j.assignedto_appformgraphic AS assignedto,
            u_assigned.u_name AS assignedname,
            u_assigned.ReportingTo AS reportingto,
            u_reporting.u_name AS reportingtoname,
            COUNT(*) AS cnt
        FROM
            jobentry j
        LEFT JOIN
            users u_assigned ON j.assignedto_appformgraphic = u_assigned.u_id
        LEFT JOIN
            users u_reporting ON u_assigned.ReportingTo = u_reporting.u_id
        WHERE
            j.jobcreatedt BETWEEN @fdt AND @tdt
            -- Efficiently calculate status on-the-fly and filter
            AND
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
            END = 'Send To Graphics'
            -- Handle optional parameter efficiently
            AND (@printcd = '' OR ISNULL(j.printcd, '') = @printcd)
        GROUP BY
            j.assignedto_appformgraphic,
            u_assigned.u_name,
            u_assigned.ReportingTo,
            u_reporting.u_name
        ORDER BY
            assignedname;
    END
    ELSE
    BEGIN
        -- Logic for non-administrators: Fetches data for the user and their subordinates
        -- A recursive CTE to build the user hierarchy, which is much faster than cursors.
        WITH UserHierarchy AS
        (
            -- Anchor member: the starting user
            SELECT u_id FROM users WHERE u_id = @empcd
            UNION ALL
            -- Recursive member: find users reporting to the previous level
            SELECT u.u_id FROM users u INNER JOIN UserHierarchy uh ON u.ReportingTo = uh.u_id
        )
        SELECT
            j.assignedto_appformgraphic AS assignedto,
            u_assigned.u_name AS assignedname,
            u_assigned.ReportingTo AS reportingto,
            u_reporting.u_name AS reportingtoname,
            COUNT(*) AS cnt
        FROM
            jobentry j
        -- Filter jobs based on the user hierarchy
        INNER JOIN
            UserHierarchy uh ON j.assignedto_appformgraphic = uh.u_id
        LEFT JOIN
            users u_assigned ON j.assignedto_appformgraphic = u_assigned.u_id
        LEFT JOIN
            users u_reporting ON u_assigned.ReportingTo = u_reporting.u_id
        WHERE
            j.jobcreatedt BETWEEN @fdt AND @tdt
            AND
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
            END = 'Send To Graphics'
            AND (@printcd = '' OR ISNULL(j.printcd, '') = @printcd)
        GROUP BY
            j.assignedto_appformgraphic,
            u_assigned.u_name,
            u_assigned.ReportingTo,
            u_reporting.u_name
        ORDER BY
            assignedname
        -- Option to allow for hierarchies deeper than the default 100 levels
		OPTION (MAXRECURSION 0);
    END
END;