<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Dashboard_chart_Month.aspx.vb" Inherits="Dashboard_chart_Month" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DevExtreme Demo</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <script>        window.jQuery || document.write(decodeURIComponent('%3Cscript src="js/jquery-3.1.0.min.js"%3E%3C/script%3E'))</script>
    
    <script src="GraphScripts/jquery.min.js"></script>
    <script src="GraphScripts/cldr.min.js" type="text/javascript"></script>
    <script src="GraphScripts/event.min.js" type="text/javascript"></script>
    <script src="GraphScripts/supplemental.min.js" type="text/javascript"></script>
    <script src="GraphScripts/unresolved.min.js" type="text/javascript"></script>
    <script src="GraphScripts/globalize.min.js" type="text/javascript"></script>
    <script src="GraphScripts/message.min.js" type="text/javascript"></script>
    <script src="GraphScripts/number.min.js" type="text/javascript"></script>
    <script src="GraphScripts/currency.min.js" type="text/javascript"></script>
    <script src="GraphScripts/date.min.js" type="text/javascript"></script>
    <script src="GraphScripts/dx.all.js" type="text/javascript"></script>

    <link href="GraphStyles/dx.common.css" rel="stylesheet" type="text/css" />
    <link href="GraphStyles/dx.light.css" rel="stylesheet" type="text/css" />
    <link href="GraphStyles/dx.spa.css" rel="stylesheet" type="text/css" />
    <link href="GraphStyles/StylesGraph.css" rel="stylesheet" type="text/css" />

    
     <script type="text/javascript" >
//         function LoadChart() {
             $(function () {


                 $.ajax({
                     type: 'POST',
                     dataType: 'json',
                     contentType: 'application/json; charset=utf-8',
                     url: 'Dashboard_chart_Month.aspx/GetChartData',
                     success:
                        function (response) {
                            drawchart(response.d);
                        },
                     error: function () {
                         alert("Error loading data! Please try again.");
                     }
                 });
             })

             function drawchart(dataValues) {



                 $(function () {
                    
                     var d = new Date();

                     var m = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];
                     var y = d.getFullYear();
                     $("#chart").dxChart({
                         dataSource: dataValues,
                         palette: "soft",
                         title: {
                             text: "Monthwise Sales"
                         },
                         commonSeriesSettings: {
                             type: "bar",
                             valueField: "amt",
                             argumentField: "name",
                             ignoreEmptyPoints: true
                         },
                         seriesTemplate: {
                                  nameField:"name"
                                 },
                         onPointClick: function (e) {
                             e.target.select();
                         }
                     });
                 })

             }



//         }
     </script>

    
 
</head>
<body>
    <table style="width:100%;">
                <tr>
                    <td align="center">
                        
                            <div id="chart" style="height:255px; background-color:#EEEEEE;"></div>
                     
                        </td>
                </tr>
            </table>
</body>
</html>
