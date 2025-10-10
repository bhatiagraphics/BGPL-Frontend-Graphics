$(function () {
    $("#SideBar").dxChart({
        dataSource: dataSource,
        commonSeriesSettings: {
            argumentField: "month",
            type: "bar",
            hoverMode: "allArgumentPoints",
            selectionMode: "allArgumentPoints",
            label: {
                visible: true,
                format: {
                    type: "fixedPoint",
                    precision: 0
                }
            }
        },
        series: [
            { valueField: "sale", name: "Sales" }
        ],
        title: "Monthly Sales",
        legend: {
            verticalAlignment: "bottom",
            horizontalAlignment: "center"
        },
        "export": {
            enabled: false
        },
        onPointClick: function (e) {
            e.target.select();
        }
    });
});