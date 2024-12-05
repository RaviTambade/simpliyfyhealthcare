$(document).ready(
    () => {

        $("#btnpay").click(() => {
            let user = JSON.parse(localStorage.getItem("payers"));

            let name = $("#name").val();
            let cnumber = $("#cardnumber").val();
            let expirymonth = $("#expirymonth").val();
            let expiryyear = $("#expiryyear").val();

            let cvv = $("#cvv").val();
            let payamount = $("#amount").val();




            if (expirymonth > 12) {
                console.log("Invalid input ");
                alert("invalid input ");
            }
            else {

                let obj = {
                    name: name,
                    number: cnumber,
                    month: expirymonth,
                    year: expiryyear,
                    cvv: cvv,
                    amount: payamount,

                }

                if (!user) {
                    user = [];

                }
                user.push(obj);
                localStorage.setItem("payers", JSON.stringify(user));
                console.log("Payment Initialised");
            }

        }

        )

    }
)