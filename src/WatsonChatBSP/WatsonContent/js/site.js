$('.chatButton').click(function () {
    $('#chatDrawer').toggleClass("open").toggleClass("close");
});

$(document).ready(function () {
    setTimeout(function () {
        $("#preload_container").removeClass("preload");
    }, 500);
});