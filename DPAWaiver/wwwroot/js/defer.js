function defer(method) {
    if (window.jQuery) {
        method();
    } else {
        setTimeout(function () {
            defer(method)
        }, 150);
    }
} // defer execution till the jquery becomes available