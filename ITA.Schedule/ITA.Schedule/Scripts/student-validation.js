function validateAddStudentForm(groups) {
    groups = JSON.parse(groups);

    $.each(groups, function (key, value) {
        if (value["GroupId"] === $("#groupSelect").val()) {

            $("#SubgroupId").remove();
            $("#btn-submit").attr("disabled", true);
            $("#subgroup").css("display", "block");

            var select = $("<select></select>").attr("id", "SubgroupId").attr("name", "SubgroupId").attr("class", "form-control");
            $.each(value["Subgroups"], function (objKey, objValue) {
                select.append($("<option></option>").attr("value", objKey).text(objValue));
            });
            $("#subgroup").append(select);

            $("#SubgroupId option").each(function () {
                console.log("Works");
                if ($(this).is(":selected") ) {
                    $("#btn-submit").attr("disabled", false);
                    return;
                }
            });
        }
    });
}

function checkEmpty(obj) {
    var name = $(obj).attr("name");
    $("." + name + "-validation").html("");
    $(obj).css("border", "");
    var nameVal = $.trim($(obj).val());

    if (nameVal === "" || nameVal.length > 400) {
        $(obj).css("border", "#FF0000 1px solid");
        $("." + name + "-validation").html("Required");
        return false;
    }

    return true;
}

function validateStudentName() {
    if (!checkEmpty($("#Name"))) {
        $("#btn-submit").attr("disabled", true);
    }
    else if ($("#SubgroupId").length !== 0 && $("#SubgroupId").val()) {
        $("#btn-submit").attr("disabled", false);
    }
}