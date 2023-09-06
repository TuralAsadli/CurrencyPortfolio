

// Get references to the modal and the button that triggers it
const modal = document.getElementById("myModal");
const showModalButton = document.getElementById("showModalButton");
const closeModalButton = modal.querySelector(".close");
const submitModalButton = document.getElementById("submitModalButton");

const diagramModal = document.getElementById("DiagramModal");
const showDiagramModal = document.getElementById("showDiagramModal");
const closeDiagramModalButton = diagramModal.querySelector(".close");

const getListurl = "https://localhost:7192/api/Wallet/GetWallet?UserId=";

function renderAllCrypto(response){
  var listItem = document.getElementById("list-item");
  var list = document.getElementById("list");
  
  for (let index = 0; index < response["walletItems"].length; index++) {
    const newItem = listItem.cloneNode(true); // Clone the listItem element
    const currencyCode = newItem.querySelector("#currencyCode");
    currencyCode.innerHTML = response["walletItems"][index]["currencyCode"];

    const currencyName = newItem.querySelector("#currencyName");
    currencyName.innerHTML = response["walletItems"][index]["currencyName"];

    const buyPrice = newItem.querySelector("#buyPrice");
    buyPrice.innerHTML = response["walletItems"][index]["buyPrice"];

    const amount = newItem.querySelector("#amount");
    amount.innerHTML = "amount: " + response["walletItems"][index]["amount"];

    list.appendChild(newItem); // Append the cloned and modified element to the list
  }

  list.removeChild(listItem)
}


function renderDiagram(response){
  const data = []; // You can customize the data as needed
  
  var sum = 0;
  response.walletItems.forEach(element => {
    sum += parseFloat(element.buyPrice) * parseFloat(element.amount) 
  });

  response.walletItems.forEach(newItem => {
    data.push({name:newItem.currencyCode, value: newItem.amount * newItem.buyPrice / sum * 100})
  });
  console.log(data)
// Chart dimensions
const width = 300;
const height = 300;
const radius = Math.min(width, height) / 2;

const colors = []

response.walletItems.forEach(element => {
  colors.push("#" + ((1 << 24) * Math.random() | 0).toString(16).padStart(6, "0"))
});
// Define a color scale
const color = d3.scaleOrdinal()
    .range(colors); // Colors for different segments

// Create a D3.js SVG canvas
const svg = d3.select("#chart-container")
    .append("svg")
    .attr("width", width)
    .attr("height", height)
    .append("g")
    .attr("transform", `translate(${width / 2},${height / 2})`);

// Create an arc generator
const arc = d3.arc()
    .outerRadius(radius - 10)
    .innerRadius(0);

// Create a pie layout
const pie = d3.pie()
    .sort(null)
    .value(d => d.value);

// Create the chart segments
const g = svg.selectAll(".arc")
    .data(pie(data))
    .enter()
    .append("g")
    .attr("class", "arc");

// Add the animated chart segments
g.append("path")
    .attr("d", arc)
    .style("fill", d => color(d.data))
    .transition()
    .duration(1000)
    .attrTween("d", function(d) {
        const interpolate = d3.interpolate({ startAngle: 0, endAngle: 0 }, d);
        return function(t) {
            return arc(interpolate(t));
        };
    });

// Add text labels to the slices
g.append("text")
    .attr("transform", d => `translate(${arc.centroid(d)})`)
    .attr("dy", "0.35em")
    .text(d => d.data.name);
}

function getJwt(name) {
  const cookies = document.cookie.split(";");

  for (const cookie of cookies) {
    const [cookieName, cookieValue] = cookie.trim().split("=");
    if (cookieName === name) {
      return cookieValue;
    }
  }
  return null; // Return null if cookie not found
}



async function getAllCryptos(){
  var id = getCookie("userId")
    const response = await axios.get(getListurl + id, {headers});
  renderAllCrypto(response.data)
}

async function getDiagram(){
  var id = getCookie("userId")
    const response = await axios.get(getListurl + id, {headers});
    console.log(response.data)
    renderDiagram(response.data)
}

function openModal() {
    modal.style.display = "block";
    //modal.classList.add("show");
  }

  function openDiagramModal() {
    diagramModal.style.display = "block";
    //modal.classList.add("show");
  }



  // Function to close the modal
  function closeModal() {
    modal.style.display = "none";
    //modal.classList.remove("show")
  }

  function closeDiagramModal() {
    diagramModal.style.display = "none";
    //modal.classList.remove("show")
  }

  document.addEventListener('DOMContentLoaded', getAllCryptos);
  document.addEventListener("DOMContentLoaded", getDiagram)

showModalButton.addEventListener("click", openModal);
closeModalButton.addEventListener("click", closeModal);

showDiagramModal.addEventListener("click", openDiagramModal)
closeDiagramModalButton.addEventListener("click", closeDiagramModal)