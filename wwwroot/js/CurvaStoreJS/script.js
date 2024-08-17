var priceSlider = document.getElementById('price-slider');
noUiSlider.create(priceSlider, {
    start: [20, 80],
    connect: true,
    range: {
        'min': 0,
        'max': 100
    },
    tooltips: true,
    format: {
        to: function (value) {
            return '$' + parseInt(value); // Add a dollar sign to the tooltip value
        },
        from: function (value) {
            return value.replace('$', '');
        }
    }
});

var minPrice = document.getElementById('min-price');
var maxPrice = document.getElementById('max-price');

priceSlider.noUiSlider.on('update', function (values, handle) {
    if (handle === 0) {
        minPrice.value = values[0];
    } else {
        maxPrice.value = values[1];
    }
});

function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}
// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var openDropdown = dropdowns;
        if (openDropdown.classList.contains('show')) {
            openDropdown.classList.remove('show');
        }
    }
}
