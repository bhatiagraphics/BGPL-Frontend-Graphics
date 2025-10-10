

Sys.Application.add_load(function () {
    $('.SearchableGrid').prepend($("<thead></thead>").append($(".SearchableGrid").find("tr:first"))).DataTable({
        "bInfo": false,
        oLanguage: {
            sLengthMenu: "Page Size_MENU_",
            "sInfo": "Showing START to END of TOTAL entries"
        }
    })

});