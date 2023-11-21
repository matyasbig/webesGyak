window.onload = function () {
    createRows();
}
    
function createRows() {
    var parentDiv = document.createElement("div");
    parentDiv.id = "pascal";
    document.body.appendChild(parentDiv);

    // rows
    for (var n = 0; n < 10; n++) {
        var row = document.createElement("div");

        row.classList.add("row");

        parentDiv.appendChild(row);

        // values
        for (var k = 0; k <= n; k++) {
            var value = document.createElement("div");

            value.classList.add("value");
            value.innerHTML = binomial(n, k);

            row.appendChild(value);
        }
    }
}

function factorial(n) {
    if (n == 0) return 1;

    product = n;

    for (var i = n - 1; i >= 1; i--) {
        product *= i;
    }

    return product;
}

function binomial(n, k) {
    return (factorial(n)) / (factorial(k) * factorial(n - k));
}
