// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let totalSum = 0;
document.addEventListener('DOMContentLoaded', function () {
    // Находим все кнопки с монетами
    var coinButtons = document.querySelectorAll('.coin-button');
    
    // Добавляем обработчик события 'click' для каждой кнопки
    coinButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            totalSum += parseInt(this.value);

            document.getElementById("totalSum").textContent = totalSum;
            document.getElementById("changeSum").textContent = parseInt(totalSum) - parseInt(totalSumPay);
        });
    });
});

let totalSumPay = 0;
function myFunction(id, sum) {
    
    if (totalSum < totalSumPay+parseInt(sum)) {

        alert("недостаточно средств");
    }
    else {
        totalSumPay += parseInt(sum);
        let quant = parseInt(document.getElementById(id).textContent);
        quant++;
        document.getElementById(id).textContent = quant;
        document.getElementById("totalSumPay").textContent = totalSumPay;
        document.getElementById("changeSum").textContent = parseInt(totalSum) - parseInt(totalSumPay);
    }
}