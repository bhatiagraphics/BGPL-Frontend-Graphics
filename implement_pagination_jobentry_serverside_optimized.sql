USE GRAPHICPPC_NEW;
GO

PRINT 'Creating optimized Sp_jobentry_GetData with server-side pagination...';
PRINT 'Uses JOINs + CASE WHEN instead of temp tables + UPDATEs';
PRINT '';

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_jobentry_GetData]') AND type in (N'P', N'PC'))
BEGIN
    PRINT 'Dropping existing Sp_jobentry_GetData procedure...';
    DROP PROCEDURE [dbo].[Sp_jobentry_GetData];
    PRINT '✓ Dropped existing procedure';
END
GO

CREATE PROCEDURE [dbo].[Sp_jobentry_GetData]            
    @jobid nvarchar(20),            
    @jobname nvarchar(60),            
    @intcode nvarchar(60),            
    @prioirty nvarchar(60),            
    @assignedto nvarchar(20),          
    @cuscode nvarchar(7),          
    @jobcreatedt char(20),          
    @ticketno nvarchar(60),          
    @Flag Char(1),          
    @empcd char(7),          
    @status char(1),
    @PageNumber int = 1,
    @PageSize int = 15,
    @TotalRecords int OUTPUT
AS            

SET NOCOUNT ON;
            
Declare @fdt as smalldatetime 
Set @fdt = convert(smalldatetime,@jobcreatedt,103)            
          
declare @administrator as char(1)  
set @administrator = (select administrator from users where u_id = @empcd)            
            
if @Flag ='A'            
Begin            
          
create table #user           
(           
  srno int identity(1,1),           
  u_id char(60),           
  empname char(60),           
  alevel int          
)           
            
;WITH UserHierarchy AS (
    SELECT 
        u_id,
        u_name as empname,
        0 as alevel,
        CAST(u_id AS VARCHAR(1000)) as HierarchyPath
    FROM users 
    WHERE u_id = @empcd
    
    UNION ALL
    
    SELECT 
        u.u_id,
        u.u_name as empname,
        uh.alevel + 1,
        CAST(uh.HierarchyPath + '|' + u.u_id AS VARCHAR(1000))
    FROM users u
    INNER JOIN UserHierarchy uh ON u.ReportingTo = uh.u_id
)
INSERT INTO #user (u_id, empname, alevel)
SELECT u_id, empname, alevel
FROM UserHierarchy
OPTION (MAXRECURSION 0);

SELECT @TotalRecords = COUNT(*)
FROM jobentry e
WHERE 
    (@administrator = '1' OR e.assignedto_appformgraphic IN (SELECT u_id FROM #user))
    AND (@jobid = '' OR e.jobid LIKE '%' + @jobid + '%')
    AND (@jobname = '' OR e.jobname LIKE '%' + @jobname + '%')
    AND (@intcode = '' OR e.intcode LIKE '%' + @intcode + '%')
    AND (@prioirty = '' OR e.prioirty = @prioirty)
    AND (@assignedto = '' OR e.assignedto = @assignedto)
    AND (@cuscode = '' OR e.cuscode = @cuscode)
    AND (@jobcreatedt = '' OR e.startdate = @fdt)
    AND (@ticketno = '' OR e.ticketno LIKE '%' + @ticketno + '%');

;WITH FilteredData AS (
    SELECT 
        e.jobid,
        e.jobname,
        e.cuscode,
        ISNULL(c.cusname, '') as cusname,
        e.intcode,
        e.revno,
        e.prioirty,
        e.printcd,
        ISNULL(p.printname, '') as printname,
        e.startdate as jobcreatedt,
        CONVERT(char(10), e.startdate, 103) as jobcreatedt1,
        e.assignedto,
        ISNULL(u1.u_name, '') as assignedname,
        e.assignedto_appformgraphic,
        ISNULL(u2.u_name, '') as assignedname_appfromgraphics,
        e.assignedto_prepress,
        ISNULL(u3.u_name, '') as assignedname_apptoprepress,
        e.ticketno,
        CASE 
            WHEN ISNULL(e.cancelflag, '0') = '1' THEN 'Cancelled'
            WHEN ISNULL(e.dispatch_close_flag, '0') = '1' THEN 'Billing Done & Job Close'
            WHEN ISNULL(e.sendfor_billing_flag, '0') = '1' THEN 'Send To Billing'
            WHEN ISNULL(e.sendfor_dispatch_flag, '0') = '1' THEN 'Send To Dispatch'
            WHEN ISNULL(e.sendfor_challan_flag, '0') = '1' THEN 'Send To Challan'
            WHEN ISNULL(e.qc_check_flag, '0') = '1' THEN 'Send To QC'
            WHEN ISNULL(e.sendfor_reproduction_flag, '0') = '1' THEN 'Send To Material Production'
            WHEN ISNULL(e.approve_sendforprepress_flag, '0') = '1' THEN 'Send To Prepress'
            WHEN ISNULL(e.approve_sendtocustomerforapprval_flag, '0') = '1' THEN 'Send To Customer For Approval'
            WHEN ISNULL(e.customer_approval_flag, '0') = '1' THEN 'Approval Form Send To Customer '
            WHEN ISNULL(e.sento_customer_flag, '0') = '1' THEN 'Send To Customer'
            WHEN ISNULL(e.sendtographics_flag, '0') = '1' THEN 'Send To Graphics'
            ELSE 'Pending'
        END as status,
        ROW_NUMBER() OVER (ORDER BY e.startdate DESC) as RowNum
    FROM jobentry e
    LEFT JOIN customer c ON e.cuscode = c.cuscode
    LEFT JOIN printing p ON e.printcd = p.printcd
    LEFT JOIN users u1 ON e.assignedto = u1.u_id
    LEFT JOIN users u2 ON e.assignedto_appformgraphic = u2.u_id
    LEFT JOIN users u3 ON e.assignedto_prepress = u3.u_id
    WHERE 
        (@administrator = '1' OR e.assignedto_appformgraphic IN (SELECT u_id FROM #user))
        AND (@jobid = '' OR e.jobid LIKE '%' + @jobid + '%')
        AND (@jobname = '' OR e.jobname LIKE '%' + @jobname + '%')
        AND (@intcode = '' OR e.intcode LIKE '%' + @intcode + '%')
        AND (@prioirty = '' OR e.prioirty = @prioirty)
        AND (@assignedto = '' OR e.assignedto = @assignedto)
        AND (@cuscode = '' OR e.cuscode = @cuscode)
        AND (@jobcreatedt = '' OR e.startdate = @fdt)
        AND (@ticketno = '' OR e.ticketno LIKE '%' + @ticketno + '%')
)
SELECT 
    jobid, jobname, cuscode, cusname, intcode, revno, prioirty, printcd, printname,
    jobcreatedt, jobcreatedt1, assignedto, assignedname, assignedto_appformgraphic,
    assignedname_appfromgraphics, assignedto_prepress, assignedname_apptoprepress, ticketno, status
FROM FilteredData
WHERE RowNum BETWEEN ((@PageNumber - 1) * @PageSize + 1) AND (@PageNumber * @PageSize)
ORDER BY RowNum;

DROP TABLE #user;

End            
            
Else            
            
if @Flag ='B'            
Begin            
    SELECT * FROM jobentry Where jobid = @jobid            
End
GO

PRINT '';
PRINT '================================================================================';
PRINT 'Optimized Stored Procedure Created Successfully';
PRINT '================================================================================';
PRINT '';
PRINT 'Key Optimizations:';
PRINT '  1. ✓ Server-side pagination (returns only @PageSize rows per request)';
PRINT '  2. ✓ JOINs instead of temp table + 5 UPDATE statements';
PRINT '  3. ✓ CASE WHEN instead of 13 UPDATE statements';
PRINT '  4. ✓ Filters applied in WHERE clause (not DELETE after loading)';
PRINT '  5. ✓ COUNT(*) calculated separately for @TotalRecords OUTPUT';
PRINT '  6. ✓ Recursive CTE for user hierarchy (already optimized)';
PRINT '';
PRINT 'Expected Performance:';
PRINT '  - Page load (15 rows): <1 second';
PRINT '  - Total count calculation: <2 seconds';
PRINT '  - Combined: <3 seconds per page';
PRINT '';
PRINT '================================================================================';
GO
