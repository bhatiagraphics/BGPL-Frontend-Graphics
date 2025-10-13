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
    @status nvarchar(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Flag = 'A'
    BEGIN
        SELECT j.*, c.cusname, p.printname, u.u_name as assignedname, ug.u_name as assignedname_appfromgraphics, up.u_name as assignedname_apptoprepress,
        CASE
            WHEN j.billing_close_flag=1 THEN 'Billing Close'
            WHEN j.dispatch_close_flag=1 THEN 'Dispatch Close'
            WHEN j.qc_check_flag=1 THEN 'QC Check'
            WHEN j.approve_sendforprepress_flag=1 THEN 'Send For Prepress'
            WHEN j.sendtographics_flag=1 THEN 'Send To Graphics'
            ELSE 'Job Created'
        END as status
        FROM jobentry j
        LEFT JOIN customer c ON j.cuscode = c.cuscode
        LEFT JOIN printing p ON j.printcd = p.printcd
        LEFT JOIN users u ON j.assignedto = u.u_id
        LEFT JOIN users ug ON j.assignedto_appformgraphic = ug.u_id
        LEFT JOIN users up ON j.assignedto_prepress = up.u_id
        WHERE (j.jobid LIKE '%' + @jobid + '%' OR @jobid IS NULL OR @jobid = '')
            AND (j.jobname LIKE '%' + @jobname + '%' OR @jobname IS NULL OR @jobname = '')
            AND (j.intcode LIKE '%' + @intcode + '%' OR @intcode IS NULL OR @intcode = '')
            AND (j.prioirty = @prioirty OR @prioirty IS NULL OR @prioirty = '')
            AND (j.assignedto = @assignedto OR @assignedto IS NULL OR @assignedto = '')
            AND (j.cuscode = @cuscode OR @cuscode IS NULL OR @cuscode = '')
            AND (j.jobcreatedt = @jobcreatedt OR @jobcreatedt IS NULL OR @jobcreatedt = '')
            AND (j.ticketno = @ticketno OR @ticketno IS NULL OR @ticketno = '')
    END
    ELSE IF @Flag = 'B'
    BEGIN
        SELECT j.*, c.cusname, p.printname, u.u_name as assignedname, ug.u_name as assignedname_appfromgraphics, up.u_name as assignedname_apptoprepress,
        CASE
            WHEN j.billing_close_flag=1 THEN 'Billing Close'
            WHEN j.dispatch_close_flag=1 THEN 'Dispatch Close'
            WHEN j.qc_check_flag=1 THEN 'QC Check'
            WHEN j.approve_sendforprepress_flag=1 THEN 'Send For Prepress'
            WHEN j.sendtographics_flag=1 THEN 'Send To Graphics'
            ELSE 'Job Created'
        END as status
        FROM jobentry j
        LEFT JOIN customer c ON j.cuscode = c.cuscode
        LEFT JOIN printing p ON j.printcd = p.printcd
        LEFT JOIN users u ON j.assignedto = u.u_id
        LEFT JOIN users ug ON j.assignedto_appformgraphic = ug.u_id
        LEFT JOIN users up ON j.assignedto_prepress = up.u_id
        WHERE j.jobid = @jobid
    END
END