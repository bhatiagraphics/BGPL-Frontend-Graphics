USE GRAPHICPPC_NEW;
GO

PRINT 'Implementing pagination for Sp_jobentry_log_GetData...';
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_jobentry_log_GetData]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[Sp_jobentry_log_GetData];
GO

CREATE PROCEDURE [dbo].[Sp_jobentry_log_GetData]
    @jobid nvarchar(20),
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @TotalRecords INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @TotalRecords = COUNT(*)
    FROM jobentry_log
    WHERE jobid = @jobid;

    WITH PagedResults AS (
        SELECT
            *,
            ROW_NUMBER() OVER (ORDER BY logdate DESC) AS RowNum
        FROM jobentry_log
        WHERE jobid = @jobid
    )
    SELECT *
    FROM PagedResults
    WHERE RowNum BETWEEN ((@PageNumber - 1) * @PageSize + 1) AND (@PageNumber * @PageSize)
    ORDER BY logdate DESC;
END
GO

PRINT 'Pagination implemented for Sp_jobentry_log_GetData successfully.';
GO