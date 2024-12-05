
//Local Storage functionality
function onSetData() {

    if (typeof (Storage) !== "undefined") {
        // Code for localStorage/sessionStorage.
        var txtEmail = document.getElementById("txtemail");
        var email = txtEmail.value;
        localStorage.setItem("useremail", email);

    } else {
        // Sorry! No Web Storage support..
    }
}

function onGetData() {
    if (typeof (Storage) !== "undefined") {
        // Code for localStorage/sessionStorage.
        var lblResult = doucment.getElementById("lblresult");
        var result = localStorage.getItem("useremail");
        lblResult.innerHTML(result);
    } else {
        // Sorry! No Web Storage support..
    }
}