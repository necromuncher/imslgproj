//On Dom Load
$(document).ready(function () {
    HideUpdateButton(true);
});

//Hide update control
function HideUpdateButton(isHide) {
    if (isHide) {
        $('#cmdUpdate').hide();
    }
    else
        $('#cmdUpdate').show();
}

//Show active selection
$('#agent-list tr').live('click', function () {
    var agentName = $(this).find("td:first-child").text().trim();
    var agentAddress = $(this).find("td:first-child + td").text().trim();
    var agentIsActive = $(this).find("td:first-child + td + td").context.cells[2].childNodes[1].checked
    var agentPkey = $(this).find("td:first-child + td + td + td").text().toString().trim();
    agentIsActive = agentIsActive.toString() == "false" ? "False" : "True";

    if (agentName != "Agent Name") {
        $('#CurrentAgent_Name').val(agentName);
        $('#CurrentAgent_Address').val(agentAddress);
        $('#isValidOption').val(agentIsActive);
        $('#PkeyForView').val(agentPkey);
        HideUpdateButton(false);
    }
});

//Clear inputs value after any actions
function ClearField() {
    $("#CurrentAgent_Name").val("").focus();
    $("#CurrentAgent_Address").val("");
    $("#isValidOption").val("False");
    $('#PkeyForView').val("");
    HideUpdateButton(true);
}

//Adding
$('#cmdAdd').live('click', function () {
    var agentName = $('#CurrentAgent_Name').val();
    var agentAddress = $('#CurrentAgent_Address').val();
    var agentIsActive = $('#isValidOption').val();
    $("#CurrentAgent_IsActive").val(agentIsActive);
    var messagetext = "";
    if (agentName.length > 0 && agentAddress.length > 0) {
        var isRecordExists = false;
        $('table#agent-list tbody tr:not(:first-child)').each(function () {
            var gridAgentName = $(this).find('td:first-child').text().trim();
            if (gridAgentName == agentName) {
                isRecordExists = true;
            }
        });

        if (!isRecordExists) {
            $.ajax({
                url: '/Admin/CreateAgent',
                type: "POST",
                global: false,
                async: false,
                data: $("#input-form").serialize(),
                dataType: "json",
                success: function (data) {
                    if (data.status == "Success") {
                        AddRecordRow();
                        ClearField();
                    }
                    else {
                        messagetext = "Saving failed!";
                        AlertMessage(messagetext);
                    }
                },
                error: function () {
                    messagetext = "Saving failed!";
                    AlertMessage(messagetext);
                }
            });
        }
        else {
            messagetext = "Sorry, record already exist!";
            AlertMessage(messagetext);
        }

    } else {
        messagetext = "Please enter at least 1 characters for your Agent Name.";
        AlertMessage(messagetext);
    }

    function AddRecordRow() {
        $('#agent-list tbody').append(
		ISMSite.Utilities.AppendString("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
		agentName, agentAddress, agentIsActive));
    }
});

//Updating
$('#cmdUpdate').live('click', function () {
    var agentName = $('#CurrentAgent_Name').val();
    var agentAddress = $('#CurrentAgent_Address').val();
    var agentIsActive = $('#isValidOption').val();
    var agentKey = $('#PkeyForView').val();
    $("#CurrentAgent_IsActive").val(agentIsActive);

    $.ajax({
        url: '/Admin/EditAgent',
        type: "POST",
        global: false,
        async: false,
        data: $("#input-form").serialize(),
        dataType: "json",
        success: function (data) {
            if (data.status == "Success") {
                UpdateGridRows();
            }
            else {
                messagetext = "Updating failed!";
                AlertMessage(messagetext);
            }
        },
        error: function () {
            messagetext = "Updating failed!";
            humaneError(messagetext);
        }
    });

    function UpdateGridRows() {
        $('#agent-list tbody tr').each(function () {
            $('#store-hours-listing tr').each(function () {
                var agentNameInList = $(this).find("td:first-child").text();
                var agentKeyInList = $(this).find("td:first-child + td + td + td").text();
                if (agentKey == agentKeyInList) {
                    $(this).find("td:first-child").text(agentName);
                    $(this).find("td:first-child + td").text(agentAddress);
                    $(this).find("td:first-child + td + td").text(agentIsActive);
                    $(this).find("td:first-child + td + td").text(agentKey);
                    ClearField();
                }
            });
        });
    }
});

//Removing
$('#cmdRemove').live('click', function () {
    var agentName = $('#CurrentAgent_Name').val();
    var agentAddress = $('#CurrentAgent_Address').val();
    var agentIsActive = $('#isValidOption').val();
    var agentKey = $('#PkeyForView').val();
    $("#CurrentAgent_IsActive").val(agentIsActive);
    if (agentKey != "") {

        $.ajax({
            url: '/Admin/DeleteAgent',
            type: "POST",
            global: false,
            async: false,
            data: $("#input-form").serialize(),
            dataType: "json",
            success: function (data) {
                if (data.status == "Success") {
                    DeleteGridRow();
                }
                else {
                    messagetext = "Deleting failed!";
                    AlertMessage(messagetext);
                }
            },
            error: function () {
                messagetext = "Deleting failed!";
                AlertMessage(messagetext);
            }
        });
    }

    function DeleteGridRow() {
        $('#agent-list tbody tr').each(function () {
            var agentKeyInList = $(this).find("td:first-child + td + td + td").text();
            if (agentKey.toString() == agentKeyInList.toString()) {
                $(this).remove();
                ClearField();
                var reportCount = $('#agent-list tr').size();
                if (reportCount <= 1) {
                    $('#email-listing').hide();
                    $('#email-listing').parent().append("<div class=\"no-data\" id=\"agent-list-no-data\">No agent listed</div>");
                }
            }
        });
    }
});

function AlertMessage(message) {
    alert(message);
}