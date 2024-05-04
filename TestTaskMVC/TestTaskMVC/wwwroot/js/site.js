// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let totalSum = 0;
let totalSumPay = 0;



function CoinChange(coinId, coinValue, coinQuantity, coinAccess) {
    
    totalSum += parseInt(coinValue);
    document.getElementById("totalSum").textContent = totalSum;
    document.getElementById("changeSum").textContent = parseInt(totalSum) - parseInt(totalSumPay);

    let Coin = {
        id: coinId,
        value: coinValue,
        access: coinAccess,
        quantity: parseInt(coinQuantity) + 1
    };
   
    $.ajax({
        type: 'PUT',
        url: '/Home/UpdateCoin',
        data: {
            "coin": Coin,
        },
        success: function (response) {
            $("#CoinPanel").html($(response))
        },
        failure: function () {
            alert("failure");
            modal.modal('hide');
        },
        error: function (response) {
            console.error(xhr.responseText);
            alert("ошибка");
        }
    });
}





function ProductChange(productId, productName, productPrice, productQuantity, productImgLink) {
    if (totalSum < totalSumPay + parseInt(productPrice)) {

        alert("недостаточно средств");
    }
    else if (productQuantity == 0) {
        alert("Товар закончился");
    }
    else {
        
    totalSumPay += parseInt(productPrice);
    document.getElementById("totalSumPay").textContent = totalSumPay;
    document.getElementById("changeSum").textContent = parseInt(totalSum) - parseInt(totalSumPay);
             
    let Product = {
        id: productId,
        name: productName,
        price: productPrice,
        quantity: parseInt(productQuantity) - 1,
        imgLink: productImgLink
    };
        $.ajax({
            type: 'PUT',
            url: '/Home/UpdateProduct',
            data: {
                "product": Product,
            },
            success: function (response) {
               
                $("#ProductPanel").html($(response))
            },
            failure: function () {
                alert("failure");
                modal.modal('hide');
            },
            error: function (response) {
                console.error(xhr.responseText);
                alert("ошибка");
            }
        });
    }
}

function giveChange() {
    let changeSum = document.getElementById("changeSum").textContent;
    $.ajax({
        type: 'GET',
        url: '/Home/GiveChange',
        data: {
            "totalChange": parseInt(changeSum),
        },
        success: function (response) {

            alert("ваша сдача: "+response);
        },
        failure: function () {
            alert("failure");
            modal.modal('hide');
        },
        error: function (response) {
            console.error(xhr.responseText);
            alert("ошибка");
        }
    });
    totalSum = 0;
    totalSumPay = 0;
    document.getElementById("totalSumPay").textContent = 0;
    document.getElementById("changeSum").textContent = 0;
    document.getElementById("totalSum").textContent = 0;
}