$(document).ready(
    () => {
        console.log("document is initialized");

        $("#btnShow").click(() => {
            console.log("button Show is clicked....");
            $("#para").show();
        });


        $("#btnHide").click(() => {
            console.log("button  Hide is clicked....");
            $("#para").hide();
        });

    });