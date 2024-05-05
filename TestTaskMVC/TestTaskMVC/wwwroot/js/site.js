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

//функции для работы с напитками
function getEditProduct(productId) {

    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditProduct',
        data: { "id": productId },
        success: function (response) {
            $("#x").html($(response))
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};

function editProduct(productId, productName, productPrice, productQuantity, productImgLink) {

    let Product = {
        id: productId,
        name: productName,
        price: productPrice,
        quantity: productQuantity,
        imgLink: productImgLink
    };

    $.ajax({
        type: 'PUT',
        url: '/Admin/EditProduct',
        data: { "product": Product },
        success: function (response) {
            if (!response.error) location.reload(true);
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};

function deleteProduct(productId) {
    let ProductId = {
        id: productId
    }
    $.ajax({
        type: 'DELETE',
        url: '/Admin/DeleteProduct',
        data: { "id": ProductId },
        success: function (response) {
            if (!response.error) location.reload(true);
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });

}

function getCreateProduct() {

    $.ajax({
        type: 'GET',
        url: '/Admin/GetCreateProduct',
        data: { },
        success: function (response) {
            $("#x").html($(response))
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};

function createProduct( productName, productPrice, productQuantity, productImgLink) {

    let Product = {
        name: productName,
        price: productPrice,
        quantity: productQuantity,
        imgLink: productImgLink
    };

    $.ajax({
        type: 'POST',
        url: '/Admin/CreateProduct',
        data: { "product": Product },
        success: function (response) {
            if (!response.error) location.reload(true);
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};


//функции для работы с монетами

function getEditCoin(coinId) {

    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditCoin',
        data: { "id": coinId },
        success: function (response) {
            $("#x").html($(response))
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};

function editCoin(coinId, coinValue, coinQuantity) {

    let Coin = {
        id: coinId,
        value: coinValue,
        quantity: coinQuantity,
        access: document.getElementById('Checkbox').checked
    };

    $.ajax({
        type: 'PUT',
        url: '/Admin/EditCoin',
        data: { "coin": Coin },
        success: function (response) {
            if (!response.error) location.reload(true);
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};

function deleteCoin(coinId) {
    let CoinId = {
        id: coinId
    }
    $.ajax({
        type: 'DELETE',
        url: '/Admin/DeleteCoin',
        data: { "id": CoinId },
        success: function (response) {
            if (!response.error) location.reload(true);
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });

}

function getCreateCoin() {

    $.ajax({
        type: 'GET',
        url: '/Admin/GetCreateCoin',
        data: {},
        success: function (response) {
            $("#x").html($(response))
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};



function createCoin(coinValue, coinQuantity,) {
    
    let Coin = {
        value: coinValue,
        quantity: coinQuantity,
        access: document.getElementById('Checkbox').checked
    };

    $.ajax({
        type: 'POST',
        url: '/Admin/CreateCoin',
        data: { "coin": Coin },
        success: function (response) {
            if (!response.error) location.reload(true);
        },
        failure: function () {
            alert("failure");
        },
        error: function (response) {
            alert("ошибка");
        }
    });
};



function editClose() {
    $("#x").html("")
}

