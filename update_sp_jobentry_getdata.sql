ALTER PROCEDURE [dbo].[Sp_jobentry_GetData]
    @jobid nvarchar(100) = NULL,
    @jobname nvarchar(100) = NULL,
    @intcode nvarchar(100) = NULL,
    @prioirty nvarchar(100) = NULL,
    @assignedto nvarchar(100) = NULL,
    @cuscode nvarchar(100) = NULL,
    @jobcreatedt nvarchar(100) = NULL,
    @ticketno nvarchar(100) = NULL,
    @Flag nchar(1) = NULL,
    @empcd nvarchar(100) = NULL,
    @status nvarchar(100) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 10,
    @TotalRecords INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @sql nvarchar(max), @sqlWhere nvarchar(max), @paramDefinition nvarchar(max);

    SET @sqlWhere = N' WHERE 1=1 ';
    IF NULLIF(@jobid, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.jobid LIKE ''%'' + @p_jobid + ''%''';
    IF NULLIF(@jobname, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.jobname LIKE ''%'' + @p_jobname + ''%''';
    IF NULLIF(@intcode, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.intcode LIKE ''%'' + @p_intcode + ''%''';
    IF NULLIF(@prioirty, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.prioirty = @p_prioirty';
    IF NULLIF(@assignedto, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.assignedto = @p_assignedto';
    IF NULLIF(@cuscode, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.cuscode = @p_cuscode';
    IF NULLIF(@jobcreatedt, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.jobcreatedt = @p_jobcreatedt';
    IF NULLIF(@ticketno, '') IS NOT NULL SET @sqlWhere = @sqlWhere + N' AND j.ticketno = @p_ticketno';

    SET @paramDefinition = N'
        @p_jobid nvarchar(100),
        @p_jobname nvarchar(100),
        @p_intcode nvarchar(100),
        @p_prioirty nvarchar(100),
        @p_assignedto nvarchar(100),
        @p_cuscode nvarchar(100),
        @p_jobcreatedt nvarchar(100),
        @p_ticketno nvarchar(100),
        @p_TotalRecords INT OUTPUT';

    DECLARE @countSql nvarchar(max) = N'SELECT @p_TotalRecords = COUNT(*) FROM jobentry j ' + @sqlWhere;

    EXEC sp_executesql @countSql, @paramDefinition,
        @p_jobid = @jobid,
        @p_jobname = @jobname,
        @p_intcode = @intcode,
        @p_prioirty = @prioirty,
        @p_assignedto = @assignedto,
        @p_cuscode = @cuscode,
        @p_jobcreatedt = @jobcreatedt,
        @p_ticketno = @ticketno,
        @p_TotalRecords = @TotalRecords OUTPUT;

    IF @PageSize > 0
    BEGIN
        SET @sql = N'
        SELECT j.*, c.cusname, p.printname, u.u_name as assignedname, ug.u_name as assignedname_appfromgraphics, up.u_name as assignedname_apptoprepress,
        CASE
            WHEN j.billing_close_flag=1 THEN ''Billing Close''
            WHEN j.dispatch_close_flag=1 THEN ''Dispatch Close''
            WHEN j.qc_check_flag=1 THEN ''QC Check''
            WHEN j.approve_sendforprepress_flag=1 THEN ''Send For Prepress''
            WHEN j.sendtographics_flag=1 THEN ''Send To Graphics''
            ELSE ''Job Created''
        END as status
        FROM jobentry j
        LEFT JOIN customer c ON j.cuscode = c.cuscode
        LEFT JOIN printing p ON j.printcd = p.printcd
        LEFT JOIN users u ON j.assignedto = u.u_id
        LEFT JOIN users ug ON j.assignedto_appformgraphic = ug.u_id
        LEFT JOIN users up ON j.assignedto_prepress = up.u_id
        ' + @sqlWhere + N'
        ORDER BY j.jobid
        OFFSET (@p_PageNumber - 1) * @p_PageSize ROWS
        FETCH NEXT @p_PageSize ROWS ONLY;';

        DECLARE @pageParamDefinition nvarchar(max) = @paramDefinition + N', @p_PageNumber INT, @p_PageSize INT';

        EXEC sp_executesql @sql, @pageParamDefinition,
            @p_jobid = @jobid,
            @p_jobname = @jobname,
            @p_intcode = @intcode,
            @p_prioirty = @prioirty,
            @p_assignedto = @assignedto,
            @p_cuscode = @cuscode,
            @p_jobcreatedt = @jobcreatedt,
            @p_ticketno = @ticketno,
            @p_TotalRecords = @TotalRecords OUTPUT,
            @p_PageNumber = @PageNumber,
            @p_PageSize = @PageSize;
    END
END