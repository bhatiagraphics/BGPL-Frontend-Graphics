--

USE GRAPHICPPC_NEW;
GO

-- 
--
--
--
--

PRINT 'Checking for existing index IX_users_active...';

IF NOT EXISTS (
    SELECT 1 
    FROM sys.indexes 
    WHERE name = 'IX_users_active' 
    AND object_id = OBJECT_ID('users')
)
BEGIN
    PRINT 'Creating filtered non-clustered index IX_users_active on users table...';
    
    CREATE NONCLUSTERED INDEX IX_users_active 
    ON users(active) 
    INCLUDE (u_id, u_name, pass)
    WHERE active = '1';
    
    PRINT 'Index IX_users_active created successfully!';
    PRINT 'Expected improvement: 50-90% faster login query execution.';
END
ELSE
BEGIN
    PRINT 'Index IX_users_active already exists. No action needed.';
END
GO


PRINT '';
PRINT '============================================================================';
PRINT 'Index Verification Report';
PRINT '============================================================================';

SELECT 
    i.name AS IndexName,
    i.type_desc AS IndexType,
    COL_NAME(ic.object_id, ic.column_id) AS ColumnName,
    ic.key_ordinal AS KeyOrdinal,
    ic.is_included_column AS IsIncludedColumn,
    i.has_filter AS HasFilter,
    i.filter_definition AS FilterDefinition
FROM sys.indexes i
INNER JOIN sys.index_columns ic 
    ON i.object_id = ic.object_id 
    AND i.index_id = ic.index_id
WHERE i.object_id = OBJECT_ID('users')
    AND i.name = 'IX_users_active'
ORDER BY ic.key_ordinal, ic.is_included_column;

PRINT '';
PRINT '============================================================================';
PRINT 'Optimization script completed successfully!';
PRINT '============================================================================';
PRINT '';
PRINT 'Next Steps:';
PRINT '1. Test login performance at https://bgpl-frontend-graphics.azurewebsites.net/Login.aspx';
PRINT '2. Monitor query execution plans to verify index usage';
PRINT '3. Review application logs for any connection timeout errors';
PRINT '';
PRINT 'For support, contact @bhatiagraphics or refer to DATABASE_SCHEMA.md';
PRINT '============================================================================';
GO
