if (!ISMSite) var ISMSite = {};

ISMSite.Success = "success.png";
ISMSite.Failed = "failed.png";
ISMSite.Warning = "warning.png";
ISMSite.Information = "question.png";

ISMSite.CustomDialog = {
    DwsPopMessage: function (options) {
        var defaults = {
            container: $('.default-dialog-content'),
            content: "default content",
            width: "100%",
            status: ISMSite.Success
        }

        var options = $.extend(defaults, options);

        var backgroundColor = "#DFF0D8";
        var borderColor = "#D6E9C6";
        var fontColor = "#468847";
        switch (options.status) {
            case ISMSite.Warning:
                backgroundColor = "#FCF8E3";
                borderColor = "#FBEED5";
                fontColor = "#C09853";
                break;
            case ISMSite.Information:
                backgroundColor = "#D9EDF7";
                borderColor = "#BCE8F1";
                fontColor = "#3A87AD";
                break;
            case ISMSite.Failed:
                backgroundColor = "#F2DEDE";
                borderColor = "#EED3D7";
                fontColor = "#B94A48";
                break;
        }

        var content = ISMSite.Utilities.AppendString("<div style=\"border:1px solid {0};background-color:{1};color:{2};width:{3};padding:10px;\" ",
			borderColor, backgroundColor, fontColor, options.width);
        content += ISMSite.Utilities.AppendString("class=\"ui-corner-all\"><img src=\"/Content/images/indicatorNo.png\" class=\"close-pop-message\" style=\"float:right\" />{0}</div>", options.content);

        options.container.empty().append(content).slideDown(500, function () {
            setTimeout(function () { options.container.fadeOut(500) }, 1500);
        }); ;

        $('.close-pop-message').live('click', function () {
            options.container.hide();
        });
    },
    DwsGrowl: function (options) {
        var defaults = {
            text: "My notification",
            status: ISMSite.Success,
            topOffset: -25,
            closedCallback: null,
            completedCallback: null,
            autoHide: true,
            minWidth: 200
        }

        var presetOptions = {
            autoHide: options.autoHide,
            clickOverlay: false,
            MinWidth: options.midWidth,
            TimeShown: 2500,
            ShowTimeEffect: 300,
            HideTimeEffect: 200,
            LongTrip: 20,
            HorizontalPosition: 'right',
            VerticalPosition: 'top',
            ShowOverlay: true,
            ColorOverlay: '#000',
            OpacityOverlay: 0.3,
            TopOffset: options.topOffset,
            onClosed: options.closedCallback,
            onCompleted: options.completedCallback
        };

        switch (options.status) {
            case ISMSite.Success: jSuccess(options.text, presetOptions); break;
            case ISMSite.Information: jNotify(options.text, presetOptions); break;
            case ISMSite.Failed: jError(options.text, presetOptions); break;
        }
    },
    DwsNotify: function (options) {
        var defaults = {
            text: "My notification",
            textFont: "bold 12px arial",
            fadeIn: 700,
            fadeOut: 700,
            timeout: 2000,
            showOverlay: false,
            centerY: false,
            width: '200px',
            height: '60px',
            top: '45px',
            left: '',
            right: '8px',
            border: 'none',
            padding: '5px',
            opacity: .8,
            baseZ: 80,
            color: '#fff',
            status: ISMSite.Success
        }

        var options = $.extend(defaults, options);
        var content = "<table style=\"margin-top:3px;margin-left:3px;\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
        content += ISMSite.Utilities.AppendString("<tr><td><img src=\"/Content/images/{0}\" style=\"width:48px;height:48px;float:left;\" /></td>", options.status);
        content += ISMSite.Utilities.AppendString("<td valign=\"middle\" style=\"text-align:center;color:#fff;font:{0};\">{1}</td></tr>", options.textFont, options.text);
        content += "</table>";

        $.blockUI.defaults.css = {
            width: options.width,
            height: options.height,
            top: options.top,
            left: options.left,
            right: options.right,
            border: options.border,
            padding: options.padding,
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: options.opacity,
            color: options.color
        }

        $.blockUI.defaults.baseZ = options.baseZ;
        $.blockUI({
            message: content,
            fadeIn: options.fadeIn,
            fadeOut: options.fadeOut,
            timeout: options.timeout,
            showOverlay: options.showOverlay,
            centerY: options.centerY
        });
    },
    DwsDialog: function (options) {
        var defaults = {
            content: $('.default-dialog-content'),
            title: "dialog title",
            padding: 0,
            margin: 0,
            width: "30%",
            height: "30%",
            top: "35%",
            left: "35%",
            textAlign: "left",
            color: "#000",
            border: "2px solid #aaa",
            backgroundColor: "#fff",
            cursor: "default",
            baseZ: 20,
            fadeIn: 200,
            fadeOut: 400,
            blockMsgClass: {}
        }

        var options = $.extend(defaults, options);
        $.blockUI.defaults.css = {
            padding: options.padding,
            margin: options.margin,
            width: options.width,
            height: options.height,
            top: options.top,
            left: options.left,
            textAlign: options.textAlign,
            color: options.color,
            border: options.border,
            backgroundColor: options.backgroundColor,
            cursor: options.cursor
        };

        $.blockUI.defaults.baseZ = options.baseZ;
        $.blockUI.defaults.fadeIn = options.fadeIn;
        $.blockUI.defaults.fadeOut = options.fadeOut;
        $.blockUI.defaults.overlayCSS = {
            backgroundColor: "#000",
            opacity: 0.7,
            cursor: "default"
        }

        var container = "<div style=\"width:100%;height:35px;position:absolute;top:0;background-color:#25A3CC\">";
        container += ISMSite.Utilities.AppendString("<div class=\"dialog-content-title\">{0}</div>", options.title);
        container += "<img src=\"/Content/images/blockclose.jpg\" style=\"float:right;margin-top:3px;margin-right:3px;\" ";

        if ($('.site-settings').is(':visible')) {
            container += "class=\"dialog-button\" id=\"block-exit-all\" />";
        }
        else {
            container += "class=\"dialog-button\" id=\"block-close\" />";
        }
        container += "</div>";

        var content = options.content.add(container);

        $.blockUI.defaults.blockMsgClass = options.blockMsgClass;
        $.blockUI({ message: content });

        $('#block-close-site-settings, #block-close, #block-cancel').live('click', function () {

            if ($('.site-settings').is(':visible')) {
                var content = "<div>Are you sure you want to exit?</div><div style=\"margin-top:5px;\">";
                content += "<div id=\"site-settings-exit-yes\" style=\"text-align:center;float:left;padding:3px;";
                content += "margin-right:5px;width:30px;height:15px;background-color:green;color:#fff;cursor:pointer\">Yes</div>";
                content += "<div id=\"site-settings-exit-no\" style=\"text-align:center;width:30px;height:15px;";
                content += "background-color:#333;color:#fff;padding:3px;float:left;cursor:pointer\">No</div></div>";
                ISMSite.CustomDialog.DwsGrowl({
                    text: content,
                    status: ISMSite.Information,
                    topOffset: -13,
                    autoHide: false,
                    midWidth: 185
                });
            }
            else {
                ISMSite.SiteSettings.ClearControlPanel();
            }
            $("#Wrap").css("position", "");
            $(".blockPage").css("position", "");
        });
    }
}

function SetDialog(elementId, forCarousel) {
    var overlay = "div[class='ui-widget-overlay']";
    var buttonPane = "div[class*='ui-dialog-buttonpane']";
    var titleBar = "div[class*='ui-dialog-titlebar']";

    $(elementId).css("background-color", "white");
    $(elementId).css("background-image", "url(images/ui-bg_gloss-wave_16_121212_500x100.png)");
    $(elementId).css("background-repeat", "50%");
    $(elementId).css("background-attachment", "top");
    $(elementId).css("background-position", "repeat-x");
    $(elementId).css("color", "black");
    $(elementId).css("font-style", "normal");
    $(elementId).css("font-variant", "normal");
    $(elementId).css("font-weight", "normal");
    $(elementId).css("font-size", "12px");
    $(elementId).css("line-height", "1.2");
    $(elementId).css("font-family", "Verdana, sans-serif");
    $(elementId).css("border-width", "10px");
    $(elementId).css("border-style", "solid");
    $(elementId).css("border-color", "#121212");
    $(elementId).css("padding", "none");
    if (!forCarousel) { $(elementId).css("border-bottom-style", "none"); }

    $(titleBar).remove();

    $(overlay).css("background", "none");
    $(overlay).css("background-image", "url(/Content/images/overlay.png)");
    $(overlay).css("background-repeat-x", "repeat");
    $(overlay).css("background-repeat-y", "no-repeat");
    $(overlay).css("background-attachment", "initial");
    $(overlay).css("background-position-x", "50%");
    $(overlay).css("background-position-y", "50%");
    $(overlay).css("background-origin", "initial");
    $(overlay).css("background-clip", "initial");
    $(overlay).css("background-color", "#121212");
    $(overlay).css("opacity", "0.9");

    $(buttonPane).css("background-color", "#121212");
    $(buttonPane).css("border-style", "none");
    $(buttonPane).css("border-color", "#404040");
    $(buttonPane).css("font", "normal 9px arial");
    $(buttonPane).attr("class", "admin " + $(elementId).parent("div").find(buttonPane).attr("class"))
    $(buttonPane).find("div").find("button").find("span").css({ "font": "normal 9px arial", "letter-spacing": "1px", "font-weight": "100" });

    $(elementId).parent().parent().children("div[class*='ui-dialog']").css("background", "none");
    $(elementId).parent().parent().children("div[class*='ui-dialog']").css("background-color", "#121212");
    $(elementId).parent().parent().children("div[class*='ui-dialog']").css("border-style", "none");

    $(overlay).css("background-image", "url(/Content/images/overlay.png)");
    $(overlay).click(function () {
        $("#dialog-close-button" + elementId.replace("#", "")).remove();
        $(elementId).wijdialog("close");
    });

    if ($("#dialog-close-button" + elementId.replace("#", "")).length == 0) {
        if (elementId == "#overlayDialog") {
            $("#dialog-close-buttoneditDialog").css("z-index", "1");
        }
        var dialogCloseButton = $("<div id='dialog-close-button" + elementId.replace("#", "") + "' style='cursor:pointer;width:32px;height:32px;z-index:1111;background-image:url(/Content/images/dialog-close.png);position:absolute;'></div>");
        $("body").append(dialogCloseButton);
        dialogCloseButton.position({
            my: "right top",
            at: "right top",
            offset: "8 -8",
            of: $(elementId)
        });

        dialogCloseButton.click(function () {
            dialogCloseButton.remove();
            $(elementId).wijdialog("close");
        });


    }
    else {
        $("#dialog-close-button" + elementId.replace("#", "")).position({
            my: "right top",
            at: "right top",
            offset: "8 -8",
            of: $(elementId)
        });
    }
}
