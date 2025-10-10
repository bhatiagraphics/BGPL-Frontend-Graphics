$(function () {
    $("#pie").dxPieChart({
        palette: "bright",
        dataSource: dataSource,
        title: "Areawise Sales",
        tooltip: {
            enabled: true,
//            format: "millions",
            customizeTooltip: function (arg) {
                var percentText = Globalize.formatNumber(arg.percent, {
                    style: "percent",
                    minimumFractionDigits: 2,
                    maximumFractionDigits: 2
                });

                return {
                    text: arg.valueText + " - " + percentText
                };
            }
        },
        legend: {
            horizontalAlignment: "right",
            verticalAlignment: "top",
            margin: 0
        },
        "export": {
            enabled: false
        },
        series: [{
            argumentField: "region",
            label: {
                visible: true,
//                format: "millions",
                connector: {
                    visible: true
                }
            }
        }]
    });
});