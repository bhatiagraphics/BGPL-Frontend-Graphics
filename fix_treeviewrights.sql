
USE GRAPHICPPC_NEW;
GO

SELECT COUNT(*) as TotalRows FROM TreeviewRights;
GO

SELECT DISTINCT u_id, COUNT(*) as MenuItemCount 
FROM TreeviewRights 
GROUP BY u_id 
ORDER BY u_id;
GO


/*
INSERT INTO TreeviewRights (module_id, module_name, NavigateUrl, u_id, Allow, parent_module, ssrno, MenuIcon)
VALUES 
(1, 'Open Job', '/WorkFlowManagment/OpenJobSearch.aspx', 'admin', '1', 0, 1, 'icon-people'),
(2, 'Cancelled Jobs', '/WorkFlowManagment/CancelJobSearch.aspx', 'admin', '1', 0, 2, 'icon-people'),
(3, 'Job Entry', '/WorkFlowManagment/JobEntrySearch.aspx', 'admin', '1', 0, 3, 'icon-people'),
(4, 'Approval Form (Graphics)', '/WorkFlowManagment/OpenJobGrpahicsSearch.aspx', 'admin', '1', 0, 4, 'fa fa-bank'),
(5, 'Approval Form Graphics (Jobs on Hold)', '/WorkFlowManagment/OpenJobGrpahicsSearch_Hold.aspx', 'admin', '1', 0, 5, 'fa fa-bank'),
(6, 'Approval Form (Send To Customer)', '/WorkFlowManagment/OpenJobSendToCustomerSearch.aspx', 'admin', '1', 0, 6, 'fa fa-calendar-alt'),
(7, 'Sent To Customer for Approval', '/WorkFlowManagment/SentToCustomerForApprovalSearch.aspx', 'admin', '1', 0, 7, 'fa fa-user-secret'),
(8, 'Prepress Form Production', '/WorkFlowManagment/PrePressProductionSearch.aspx', 'admin', '1', 0, 8, 'fa fa-codepen'),
(9, 'Prepress Form Production (Jobs on Hold)', '/WorkFlowManagment/PrePressProductionSearch_Hold.aspx', 'admin', '1', 0, 9, 'fa fa-codepen');

INSERT INTO TreeviewRights (module_id, module_name, NavigateUrl, u_id, Allow, parent_module, ssrno, MenuIcon)
VALUES 
(10, 'Open Job', '/WorkFlowManagment/OpenJobSearch.aspx', 'DEVINTEST', '1', 0, 1, 'icon-people'),
(11, 'Cancelled Jobs', '/WorkFlowManagment/CancelJobSearch.aspx', 'DEVINTEST', '1', 0, 2, 'icon-people'),
(12, 'Job Entry', '/WorkFlowManagment/JobEntrySearch.aspx', 'DEVINTEST', '1', 0, 3, 'icon-people'),
(13, 'Approval Form (Graphics)', '/WorkFlowManagment/OpenJobGrpahicsSearch.aspx', 'DEVINTEST', '1', 0, 4, 'fa fa-bank'),
(14, 'Approval Form Graphics (Jobs on Hold)', '/WorkFlowManagment/OpenJobGrpahicsSearch_Hold.aspx', 'DEVINTEST', '1', 0, 5, 'fa fa-bank'),
(15, 'Approval Form (Send To Customer)', '/WorkFlowManagment/OpenJobSendToCustomerSearch.aspx', 'DEVINTEST', '1', 0, 6, 'fa fa-calendar-alt'),
(16, 'Sent To Customer for Approval', '/WorkFlowManagment/SentToCustomerForApprovalSearch.aspx', 'DEVINTEST', '1', 0, 7, 'fa fa-user-secret'),
(17, 'Prepress Form Production', '/WorkFlowManagment/PrePressProductionSearch.aspx', 'DEVINTEST', '1', 0, 8, 'fa fa-codepen'),
(18, 'Prepress Form Production (Jobs on Hold)', '/WorkFlowManagment/PrePressProductionSearch_Hold.aspx', 'DEVINTEST', '1', 0, 9, 'fa fa-codepen');
*/


/*
UPDATE TreeviewRights SET NavigateUrl = '/WorkFlowManagment/OpenJobSearch.aspx' 
WHERE module_name = 'Open Job' AND (NavigateUrl IS NULL OR NavigateUrl = '');

UPDATE TreeviewRights SET NavigateUrl = '/WorkFlowManagment/CancelJobSearch.aspx' 
WHERE module_name LIKE '%Cancelled%Job%' AND (NavigateUrl IS NULL OR NavigateUrl = '');

UPDATE TreeviewRights SET NavigateUrl = '/WorkFlowManagment/JobEntrySearch.aspx' 
WHERE module_name = 'Job Entry' AND (NavigateUrl IS NULL OR NavigateUrl = '');

UPDATE TreeviewRights SET NavigateUrl = '/WorkFlowManagment/OpenJobGrpahicsSearch.aspx' 
WHERE module_name LIKE '%Approval%Graphics%' AND module_name NOT LIKE '%Hold%' AND (NavigateUrl IS NULL OR NavigateUrl = '');

UPDATE TreeviewRights SET NavigateUrl = '/WorkFlowManagment/OpenJobSendToCustomerSearch.aspx' 
WHERE module_name LIKE '%Send%Customer%' AND (NavigateUrl IS NULL OR NavigateUrl = '');

UPDATE TreeviewRights SET NavigateUrl = '/WorkFlowManagment/PrePressProductionSearch.aspx' 
WHERE module_name LIKE '%Prepress%' AND module_name NOT LIKE '%Hold%' AND (NavigateUrl IS NULL OR NavigateUrl = '');
*/


/*
UPDATE TreeviewRights SET Allow = '1' 
WHERE u_id IN ('admin', 'DEVINTEST') AND (Allow IS NULL OR Allow = '0');
*/

SELECT TOP 20 module_id, module_name, NavigateUrl, u_id, Allow, parent_module, ssrno 
FROM TreeviewRights 
ORDER BY u_id, parent_module, ssrno;
GO
