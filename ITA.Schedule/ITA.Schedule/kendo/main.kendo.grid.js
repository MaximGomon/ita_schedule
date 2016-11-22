function resizeGrid() {

    var gridElement = $(".k-grid"),
        dataArea = gridElement.find(".k-grid-content");
    dataArea.height(0);
    if (typeof kendoGridHeightPadding != 'undefined')
        dataArea.height($(document).height() - 250 + kendoGridHeightPadding);
    else
        dataArea.height($(document).height() - 250);
}
$(function () {
    resizeGrid();
    
})
$(window).resize(function () {
    resizeGrid();
});



function filterGrid(field, val) {
    var grid = $("#grid").data("kendoGrid");
    $filter = new Array();
    $filter.push({ field: field, operator: "eq", value: val });
    grid.dataSource.filter($filter);

}
function filterClear() {
    var grid = $("#grid").data("kendoGrid");
    grid.dataSource.filter([]);
}