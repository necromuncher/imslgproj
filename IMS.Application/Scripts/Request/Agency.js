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
    var agentName = $(this).find("td:first-child").text();
    var agentAddress = $(this).find("td:first-child + td").text();
    var agentIsActive = $(this).find("td:first-child + td + td").attr('value');

    if (dealerAddressDisplayOrder != "#") {
        $('#CurrentAgent_Name').val(dealerAddressLabel);
        $('#CurrentAgent_Address').val(dealerAddressStreet1);
        $('#CurrentAgent_IsActive').val(dealerAddressStreet2);
        HideUpdateButton(false);
    }
});

//Clear inputs value after any actions
function ClearField() {
    $("#CurrentAgent_Name").val("").focus();
    $("#CurrentAgent_Address").val("");
    $("#CurrentAgent_IsActive").val("False");
    HideUpdateButton(true);
}

//Adding
$('#cmdAdd').live('click', function () {
    var agentName = $('#CurrentAgent_Name').val();
    var agentAddress = $('#CurrentAgent_Address').val();
    var agentIsActive = $('#CurrentAgent_IsActive').val();
    if (agentName.length > 0 && agentAddress.length > 0) {
        var isRecordExists = false;
        $('table#agent-list tbody tr:not(:first-child)').each(function () {
            var gridAgentName = $(this).find('td:first-child').text().trim();
            if (gridAgentName  == agentName) {
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
                        ISMSite.CustomDialog.DwsGrowl({
                            text: "Agent is successfully saved!",
                            status: ISMSite.Success,
                            topOffset: 15
                        });

                        ClearField();
                    }
                    else {
                        ISMSite.CustomDialog.DwsGrowl({
                            text: "Saving failed!",
                            status: ISMSite.Failed,
                            topOffset: 15
                        });
                    }
                },
                error: function () {
                    ISMSite.CustomDialog.DwsGrowl({
                        text: "Saving failed!",
                        status: ISMSite.Failed,
                        topOffset: 15
                    });
                }
            });

            $('#agent-list tbody').append(
						ISMSite.Utilities.AppendString("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
						agentName, agentAddress, agentIsActive));
        }
        else {
            ISMSite.CustomDialog.DwsGrowl({
                text: "Sorry, record already exist!",
                status: ISMSite.Failed
            });
        }
        
    } else {
        ISMSite.CustomDialog.DwsGrowl({
            text: "Please enter at least 1 characters for your Agent Name.",
            status: ISMSite.Failed
        });
    }
});

//Updating
$('#cmdUpdate').live('click', function () {
    var agentName = $('#CurrentAgent_Name').val();
    var agentAddress = $('#CurrentAgent_Address').val();
    var agentIsActive = $('#CurrentAgent_IsActive').val();
    var agentKey = $('#CurrentAgent_PK_MstrAgency').val();

    $.ajax({
        url: '/Admin/EditAgent',
        type: "POST",
        global: false,
        async: false,
        data: $("#input-form").serialize(),
        dataType: "json",
        success: function (data) {
            if (data.status == "Success") {
                ISMSite.CustomDialog.DwsGrowl({
                    text: "Agent is successfully Updated!",
                    status: ISMSite.Success,
                    topOffset: 15
                });

                UpdateGridRows();
                ClearField();
            }
            else {
                ISMSite.CustomDialog.DwsGrowl({
                    text: "Saving failed!",
                    status: ISMSite.Failed,
                    topOffset: 15
                });
            }
        },
        error: function () {
            ISMSite.CustomDialog.DwsGrowl({
                text: "Saving failed!",
                status: ISMSite.Failed,
                topOffset: 15
            });
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
$('#remove-email').live('click', function () {
    var emailLabel = $('#email-label').val();
    var emailAddress = $('#email-address').val();
    var emailDisplayOrder = $('#email-display-order option:selected').text();

    if (emailLabel != "") {
        $('#email-listing tr').each(function () {
            var current = $(this).find("td:first-child");

            if (emailDisplayOrder == current.text()) {
                $(this).remove();

                ClearField();

                var reportCount = $('#email-listing tr').size();
                if (reportCount <= 1) {
                    $('#email-listing').hide();
                    $('#email-listing').parent().append("<div class=\"no-data\" id=\"email-address-no-data\">No email address listed</div>");
                }
            }
        });
    }
});