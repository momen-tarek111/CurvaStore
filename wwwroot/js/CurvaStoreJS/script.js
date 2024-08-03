var links = document.querySelector(".aa");
links.forEach(m => m.addEventListener("click", function () {
    links.forEach(n => {
        if (n.classList.contains("router-link-active")) {
            n.classList.remove("router-link-active");
        }
    })
    m.classList.add("router-link-active");
}))
var linksfooter = document.querySelector(".footer-ul1 li a");
linksfooter.forEach(m => m.addEventListener("click", function () {
    linksfooter.forEach(n => {
        if (n.classList.contains("active-link-footer")) {
            n.classList.remove("active-link-footer")
        }
    })
    m.classList.add("active-link-footer");
}))
var ss = document.querySelector(".link-name")
var dd = document.querySelector(".router-link-exact-active")
ss.addEventListener("click", function () {
    linksfooter.forEach(n => {
        if (n.classList.contains("active-link-footer")) {
            n.classList.remove("active-link-footer")
        }
    })
    dd.classList.add("router-link-active");
})
var hearts = document.querySelectorAll(".far");
hearts.forEach(item => {
    if (!(item.classList.contains("ar"))) {
        item.addEventListener("click", (event) => {
            if (event.target.classList.contains("fav-color")) {
                event.target.classList.remove("fav-color");
                event.target.classList.remove("fas");
                event.target.classList.toggle("far");
            }
            else {
                event.target.classList.add("fav-color")
                event.target.classList.remove("far");
                event.target.classList.toggle("fas");
            }
        })
    }
})
/*const listGroup = document.querySelector(".list-group");
listGroup.addEventListener("click", (event) => {
    if (event.target.classList.contains("list-group-item")) {
        // Remove active class from all items
        document.querySelectorAll(".list-group-item").forEach(item => {
            item.classList.remove("active-all");
        });
        // Add active class to the clicked item
        event.target.classList.add("active-all");
    }
});*/
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
