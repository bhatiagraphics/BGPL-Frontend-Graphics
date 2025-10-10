
$(function () {
    $("#Horizontal").dxChart({
        rotated: true,
        dataSource: dataSource,
//        dataSource: "https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/data/simpleJSON.json",
        series: {
            label: {
                visible: true,
                backgroundColor: "#c18e92"
            },
            color: "#79cac4",
            type: "bar",
            argumentField: "city",
            valueField: "sales"
        },
        title: "Areawise Sales",
        argumentAxis: {
            label: {
                customizeText: function () {
                    return "" + this.valueText;
                }
            }
        },
        valueAxis: {
            label: {
                visible: false
            }
        },
        "export": {
            enabled: false
        },
        legend: {
            visible: false
        }
    });
});