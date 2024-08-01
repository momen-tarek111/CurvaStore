
const body = document.querySelector("body"),
      modeToggle = body.querySelector(".mode-toggle");
      sidebar = body.querySelector("nav");
      sidebarToggle = body.querySelector(".sidebar-toggle");

let getMode = localStorage.getItem("mode");
if(getMode && getMode ==="dark"){
    body.classList.toggle("dark");
}

let getStatus = localStorage.getItem("status");
if(getStatus && getStatus ==="close"){
    sidebar.classList.toggle("close");
}

modeToggle.addEventListener("click", () =>{
    body.classList.toggle("dark");
    if(body.classList.contains("dark")){
        localStorage.setItem("mode", "dark");
    }else{
        localStorage.setItem("mode", "light");
    }
});

sidebarToggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
    if(sidebar.classList.contains("close")){
        localStorage.setItem("status", "close");
    }else{
        localStorage.setItem("status", "open");
    }
})

var id = 0;
if (performance.navigation.type == performance.navigation.TYPE_RELOAD) {

    id = 0
 }
function addColor() {
    id++;
    var divColor=document.createElement("div");
    divColor.setAttribute("class","col-lg-2");
    var labelColor=document.createElement("label");
    labelColor.setAttribute("class","form-label");
    labelColor.innerText = "color of product";
    labelColor.setAttribute("asp-for", "colorSize.color");
    var div1=document.createElement("div");
    div1.setAttribute("class","row");
    var div2=document.createElement("div");
    div2.setAttribute("class","col-lg-6");
    var inputColor=document.createElement("input");
    inputColor.setAttribute("type","color");
    inputColor.setAttribute("class", "form-control");
    inputColor.setAttribute("asp-for", "colorSize.color");
    div2.insertAdjacentElement('afterbegin',inputColor);
    div1.insertAdjacentElement('afterbegin',div2);
    divColor.insertAdjacentElement('afterbegin',labelColor);
    divColor.insertAdjacentElement('beforeend',div1);
    

    var divQuantity=document.createElement("div");
    divQuantity.setAttribute("class","col-lg-2");
    var labelQuantity=document.createElement("label");
    labelQuantity.setAttribute("class","form-label");
    labelQuantity.innerText = "Product Quantity";
    labelQuantity.setAttribute("asp-for", "colorSize.Quantity");
    var div3=document.createElement("div");
    div3.setAttribute("class","row");
    var div4=document.createElement("div");
    div4.setAttribute("class","col-lg-8");
    var inputQuantity=document.createElement("input");
    inputQuantity.setAttribute("type","number");
    inputQuantity.setAttribute("class", "form-control");
    inputQuantity.setAttribute("asp-for", "colorSize.Quantity");
    div4.insertAdjacentElement('afterbegin',inputQuantity);
    div3.insertAdjacentElement('afterbegin',div4);
    divQuantity.insertAdjacentElement('afterbegin',labelQuantity);
    divQuantity.insertAdjacentElement('beforeend',div3);



    var divSize=document.createElement("div");
    divSize.setAttribute("class","col-lg-2");
    var labelSize=document.createElement("label");
    labelSize.setAttribute("class","form-label");
    labelSize.innerText = "Size of product";
    labelSize.setAttribute("asp-for", "colorSize.Size");
    var div5=document.createElement("div");
    div5.setAttribute("class","row");
    var div6=document.createElement("div");
    div6.setAttribute("class","col-lg-8");
    var inputSize=document.createElement("input");
    inputSize.setAttribute("type","text");
    inputSize.setAttribute("class", "form-control");
    inputSize.setAttribute("asp-for", "colorSize.Size");
    div6.insertAdjacentElement('afterbegin',inputSize);
    div5.insertAdjacentElement('afterbegin',div6);
    divSize.insertAdjacentElement('afterbegin',labelSize);
    divSize.insertAdjacentElement('beforeend',div5);



    
    var parentColor=document.getElementById("parentDiv");
    parentColor.insertAdjacentElement('beforeend',divColor);
    parentColor.insertAdjacentElement('beforeend',divSize);
    parentColor.insertAdjacentElement('beforeend',divQuantity);
}

// function addSize(){
//     var divSize=document.createElement("div");
//     divSize.setAttribute("class","col-lg-2");
//     var labelSize=document.createElement("label");
//     labelSize.setAttribute("class","form-label");
//     labelSize.innerText="Size of product";
//     var div5=document.createElement("div");
//     div5.setAttribute("class","row");
//     var div6=document.createElement("div");
//     div6.setAttribute("class","col-lg-6");
//     var inputSize=document.createElement("input");
//     inputSize.setAttribute("type","text");
//     inputSize.setAttribute("class","form-control");
//     div5.insertAdjacentElement('afterbegin',inputSize);
//     div6.insertAdjacentElement('afterbegin',div5);
//     divSize.insertAdjacentElement('afterbegin',labelSize);
//     divSize.insertAdjacentElement('beforeend',div6);
    

//     var divQuantity2=document.createElement("div");
//     divQuantity2.setAttribute("class","col-lg-2");
//     var labelQuantity2=document.createElement("label");
//     labelQuantity2.setAttribute("class","form-label");
//     labelQuantity2.innerText="Product Quantity";
//     var div7=document.createElement("div");
//     div7.setAttribute("class","row");
//     var div8=document.createElement("div");
//     div8.setAttribute("class","col-lg-6");
//     var inputQuantity2=document.createElement("input");
//     inputQuantity2.setAttribute("type","number");
//     inputQuantity2.setAttribute("class","form-control");
//     div8.insertAdjacentElement('afterbegin',inputQuantity2);
//     div7.insertAdjacentElement('afterbegin',div8);
//     divQuantity2.insertAdjacentElement('afterbegin',labelQuantity2);
//     divQuantity2.insertAdjacentElement('beforeend',div7);

//     var parentSize=document.getElementById("parentDiv2");
//     parentSize.insertAdjacentElement('beforeend',divSize);
//     parentSize.insertAdjacentElement('beforeend',divQuantity2);
// }