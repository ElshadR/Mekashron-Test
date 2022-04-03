(function ($) {
    "use strict";
    $(function () {
        window.setTimeout(function () {
            $('#alert-fadeout-close').fadeOut(500, function () { $("#alert-fadeout-close").remove(); });
        }, 5000);
    });
})(jQuery);

//# sourceMappingURL=main.js.map