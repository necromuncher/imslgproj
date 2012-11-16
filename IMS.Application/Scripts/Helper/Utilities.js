if (!ISMSite) var ISMSite = {};

ISMSite.Utilities = {
    TruncateString: function (currentString, numberOfCharacters) {
        return currentString.substr(0, numberOfCharacters - 1) + (currentString.length > numberOfCharacters ? '&hellip;' : '');
    },
    TruncateStringWithBoundary: function (currentString, numberOfCharacters, useWordBoundary) {
        var toLong = currentString.length > numberOfCharacters,
        s_ = toLong ? currentString.substr(0, numberOfCharacters - 1) : this;
        s_ = useWordBoundary && toLong ? s_.substr(0, s_.lastIndexOf(' ')) : s_;
        return toLong ? s_ + '&hellip;' : s_;
    },
    IsValidEmail: function (emailAddress) {
        $.ajax({
            url: "/admin/site/IsValidEmail",
            type: "GET",
            data: { "email": emailAddress },
            global: false,
            success: function (data) {
                console.log("call: " + data);
                return data;
            },
            error: function (x, t, e) {
                return false;
            }
        });
    },
    ChangeSiteModeRedirect: function (mode) {
        var currenturl = window.location.protocol + "//" + window.location.host + window.location.pathname;

        if (mode == "edit") {
            window.location.href = currenturl + "?mode=" + mode;
        }
        else {
            window.location.href = currenturl;
        }
    },
    QueryString: function (name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.search);
        if (results == null)
            return "";
        else
            return decodeURIComponent(results[1].replace(/\+/g, " "));
    },
    AppendString: function () {
        for (var i = 1; i < arguments.length; i++) {
            var exp = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
            arguments[0] = arguments[0].replace(exp, arguments[i]);
        }

        return arguments[0];
    }
}