USE GRAPHICPPC_NEW;
GO

PRINT 'Starting optimization for Pending_Jobs_Sentto_Graphic_sp...';
PRINT '';

-- Index for filtering by assignedto_appformgraphic and startdate
IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = 'IX_jobentry_assignedto_appformgraphic_startdate'
               AND object_id = OBJECT_ID('jobentry'))
BEGIN
    PRINT 'Creating index IX_jobentry_assignedto_appformgraphic_startdate on jobentry(assignedto_appformgraphic, startdate)...';
    CREATE NONCLUSTERED INDEX IX_jobentry_assignedto_appformgraphic_startdate
    ON jobentry(assignedto_appformgraphic, startdate)
    INCLUDE (jobid, jobname, cuscode, intcode, revno, prioirty, printcd, assignedto, ticketno);
    PRINT '✓ Index IX_jobentry_assignedto_appformgraphic_startdate created successfully.';
    PRINT '  Expected improvement: 70-90% faster filtering for Pending_Jobs_Sentto_Graphic_sp';
END
ELSE
BEGIN
    PRINT '✓ Index IX_jobentry_assignedto_appformgraphic_startdate already exists.';
END
GO

PRINT '';
PRINT '================================================================================';
PRINT 'Index Creation Complete - Verification';
PRINT '================================================================================';
PRINT '';

SELECT
    t.name AS TableName,
    i.name AS IndexName,
    i.type_desc AS IndexType,
    CASE
        WHEN i.has_filter = 1 THEN 'Yes (Filtered)'
        ELSE 'No'
    END AS IsFiltered,
    COL_NAME(ic.object_id, ic.column_id) AS ColumnName,
    CASE WHEN ic.is_included_column = 1 THEN 'Yes' ELSE 'No' END AS IsIncluded
FROM sys.indexes i
INNER JOIN sys.tables t ON i.object_id = t.object_id
INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
WHERE t.name IN ('jobentry')
  AND i.name IN (
    'IX_jobentry_assignedto_appformgraphic_startdate'
  )
ORDER BY t.name, i.name, ic.key_ordinal, ic.is_included_column;

PRINT '';
PRINT '================================================================================';
PRINT 'Optimization Summary';
PRINT '================================================================================';
PRINT 'Total indexes created: 1';
PRINT '';
PRINT 'Critical Indexes:';
PRINT '  1. jobentry.assignedto_appformgraphic, startdate - Speeds up Pending_Jobs_Sentto_Graphic_sp';
PRINT '';
PRINT 'Expected Overall Improvement: 70-90% reduction in query execution time';
PRINT 'Expected Module Load Time: From >30s timeout to <5s';
PRINT '';
PRINT '================================================================================';
PRINT 'Next Steps:';
PRINT '1. Run this script against the GRAPHICPPC_NEW database.';
PRINT '2. Test the "Pending jobs - Approval form Graphics" report.';
PRINT '3. Expected result: The report loads in <5 seconds without a timeout.';
PRINT '================================================================================';

GO