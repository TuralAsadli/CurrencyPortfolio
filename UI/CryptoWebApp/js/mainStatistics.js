

const sendModal = document.getElementById("sendModal");
const showSendModalButton = document.getElementById("showSendModalButton");
const closeSendModalButton = sendModal.querySelector(".close");
const submitSendModalButtons = document.getElementById("submitModalButton");

const AddBalanceModal = document.getElementById("AddBalanceModal");
const showAddBalanceModalButton = document.getElementById("showAddBalanceModalButton");
const closeAddBalanceModalButton = AddBalanceModal.querySelector(".close");
const submitAddBalanceModalButton = document.querySelectorAll(".addBalanceSubmitButton");


const recomendationModal = document.getElementById("recomendationModal");
const showRecomendationModalButton = document.getElementById("showRecomendationModalButton");
const closeRecomendationModalButton = recomendationModal.querySelector(".close");
const submitRecomendationModalButton = document.getElementById("submitModalButton");

const searchModal = document.getElementById("registerModal");
const showSearchModalButton = document.getElementById("showSearchModalButton");
const closeSearchModalButton = searchModal.querySelector(".close");
const submitShowModalButton = document.getElementById("submitModalButton")

function openModal() {
    sendModal.style.display = "block";
    //modal.classList.add("show");
}

// Function to close the modal
function closeModal() {
    sendModal.style.display = "none";
    //modal.classList.remove("show")
}

function openAddBalanceModal() {
    AddBalanceModal.style.display = "block";
    //modal.classList.add("show");
}

// Function to close the modal
function closeAddBalanceModal() {
    AddBalanceModal.style.display = "none";
    //modal.classList.remove("show")
}

function openRecomendationModal() {
    recomendationModal.style.display = "block";
    //modal.classList.add("show");
}

function closeRecomendationModal() {
    recomendationModal.style.display = "none";
    //modal.classList.remove("show")
}

function openSearchModal(){
    searchModal.style.display = "block";
}

function closeSearchModal(){
    searchModal.style.display = "none";
}

const url = 'https://localhost:7192/api/Wallet/GetWalletStatistics?UserId=';
const recomendationsUrl = 'https://localhost:7192/api/Wallet/RecomendationList'
const cryptoListUrl = "https://localhost:7192/Crypto/GetCryptoList"
const walletItemsUrl = "https://localhost:7192/api/Wallet/GetWallet?UserId="
const addBalanceRequestUrl = "https://localhost:7192/api/WalletItem/AddWalletItemBalace"
const addNewCryptoUrl = "https://localhost:7192/api/Wallet/AddWalletItem";

function renderStatistics(statistics) {
    const fullBalance = document.getElementById("fullBalance");
    const recivedBalance = document.getElementById("recivedBalance");
    const profit = document.getElementById("profit");
    const bestAssetName = document.getElementById("bestAssetName");
    const bestScoreInPercentages = document.getElementById("bestScoreInPercentages")
    const profitInPercentages = document.getElementById("profitInPercentages");

    fullBalance.innerHTML = "$" + statistics["fullBalance"];
    recivedBalance.innerHTML = "$" + statistics["recivedBalance"];
    profit.innerHTML = "$" + statistics["profit"];
    bestAssetName.innerHTML = statistics["bestAssetName"];
    bestScoreInPercentages.innerHTML = parseFloat(statistics["bestScoreInPercentages"]).toFixed(3) + "%";
    profitInPercentages.innerHTML = parseFloat(statistics["profitInPercentages"]).toFixed(3) + "%";


}

async function renderaddBalanceModal(response){
    var listItem = document.getElementById("balance-item");
    var list = document.getElementById("balance-list"); 


    for (let index = 0; index < response["walletItems"].length; index++) {
        const newItem = listItem.cloneNode(true); // Clone the listItem element
        
        const symbol = newItem.querySelector("#currencyCode");
        symbol.innerHTML = response["walletItems"][index]["currencyCode"];
        

        const name = newItem.querySelector("#currencyName");
        name.innerHTML = response["walletItems"][index]["currencyName"];

        const priceUsd = newItem.querySelector("#amount");
        priceUsd.innerHTML = response["walletItems"][index]["amount"];

        const changePercent24Hr = newItem.querySelector("#buyPrice");
        changePercent24Hr.innerHTML = response["walletItems"][index]["buyPrice"];


        list.appendChild(newItem); // Append the cloned and modified element to the list
    }

    list.removeChild(listItem);
}

async function renderAddNewCryptoModal(response){
    var listItem = document.getElementById("new-crypto-item");
    var list = document.getElementById("crypto-list"); 


    for (let index = 0; index < response["data"].length; index++) {
        const newItem = listItem.cloneNode(true); // Clone the listItem element
        const symbol = newItem.querySelector("#symbol");
        symbol.innerHTML = response["data"][index]["symbol"];
        

        const name = newItem.querySelector("#name");
        name.innerHTML = response["data"][index]["name"];

        const priceUsd = newItem.querySelector("#priceUsd");
        priceUsd.innerHTML = parseFloat(response["data"][index]["priceUsd"]).toFixed(4);

        const changePercent24Hr = newItem.querySelector("#changePercent24Hr");
        changePercent24Hr.innerHTML = parseFloat(response["data"][index]["changePercent24Hr"]).toFixed(4);


        list.appendChild(newItem); // Append the cloned and modified element to the list
    }

    list.removeChild(listItem); // Remove the original template item
}

async function renderAllRecomendations(response) {
    var listItem = document.getElementById("all-recomendation-item");
    var list = document.getElementById("all-recomendation-list");

    for (let index = 0; index < response.length; index++) {
        const newItem = listItem.cloneNode(true); // Clone the listItem element

        const symbol = newItem.querySelector("#symbol");
        symbol.innerHTML = response[index]["symbol"];

        const name = newItem.querySelector("#name");
        name.innerHTML = response[index]["name"];

        const priceUsd = newItem.querySelector("#priceUsd");
        priceUsd.innerHTML = response[index]["priceUsd"];

        const changePercent24Hr = newItem.querySelector("#changePercent24Hr");
        changePercent24Hr.innerHTML = response[index]["changePercent24Hr"];


        list.appendChild(newItem); // Append the cloned and modified element to the list
    }

    list.removeChild(listItem); // Remove the original template item
}

async function renderRecomendations(response) {

    const elements = document.getElementsByClassName("recomendation-item");

    for (let index = 0; index < 4; index++) {
        const element = elements[index];
        const crypto = element.querySelector("#crypto");
        const cryptoName = element.querySelector("#cryptoName");
        const cryptoprice = element.querySelector("#cryptoprice");
        const cryptoProfite = element.querySelector("#cryptoProfite");


        crypto.innerHTML = response[index]["symbol"]
        cryptoName.innerHTML = response[index]["name"]
        cryptoprice.innerHTML = parseFloat(response[index]["priceUsd"]).toFixed(4)
        cryptoProfite.innerHTML = parseFloat(response[index]["changePercent24Hr"]).toFixed(4)

        if (parseFloat(response[index]["changePercent24Hr"]) < 0) {
            cryptoProfite.classList.add("orange-color");
            cryptoProfite.classList.remove("purple-color-2");
        }
    }

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

const headers = {
    
    Authorization: `Bearer ${getJwt("jwt")}`
    
  };

async function getStatistics() {

    var id = getCookie("userId")
    const response = await axios.get(url +id, {headers});
    renderStatistics(response.data)
}

async function getCryptoRate(){
    const response = await axios.get(cryptoListUrl, {headers});
    renderAddNewCryptoModal(response.data)
}

async function getBalanceItems(){
    var id = getCookie("userId")
    const response = await axios.get(walletItemsUrl + id, {headers})
    renderaddBalanceModal(response.data)
}

async function getRecomendations() {
    const response = await axios.get(recomendationsUrl, {headers})
    renderRecomendations(response.data)
}

async function getAllRecomendations() {
    const response = await axios.get(recomendationsUrl, {headers})
    renderAllRecomendations(response.data)
}



window.addEventListener("click", (event) => {
    if (event.target === sendModal) {
        closeModal();
    }
  });

  window.addEventListener("click", (event) => {
    if (event.target === AddBalanceModal) {
        closeAddBalanceModal();
    }
  });


  window.addEventListener("click", (event) => {
    if (event.target === recomendationModal) {
        closeRecomendationModal();
    }
  });

document.addEventListener('DOMContentLoaded', getStatistics);
document.addEventListener("DOMContentLoaded", getRecomendations)
document.addEventListener("DOMContentLoaded", getAllRecomendations)
document.addEventListener("DOMContentLoaded",getCryptoRate)
document.addEventListener("DOMContentLoaded", getBalanceItems)
document.addEventListener("DOMContentLoaded", getelements)

showSendModalButton.addEventListener("click", openModal);
closeSendModalButton.addEventListener("click", closeModal);

showAddBalanceModalButton.addEventListener("click", openAddBalanceModal);
closeAddBalanceModalButton.addEventListener("click", closeAddBalanceModal);

async function getelements() {
    const submitAddBalanceModalButtons = document.getElementsByClassName('addBalanceSubmitButton');
    
    for (let index = 0; index < submitAddBalanceModalButtons.length; index++) {
        const button = submitAddBalanceModalButtons[index];
        
        button.addEventListener('click', async function() {
            
            const allAmounts = document.querySelectorAll(".addBalanceAmount");
            const allNames = document.querySelectorAll(".addBalanceName");
            const allBuyPrices = document.querySelectorAll(".addBalannceBuyPrice");
            
            const amount = parseFloat(allAmounts[index].value);
            const name = allNames[index].textContent.trim(); // Use textContent to get the inner text without HTML tags
            const buyprice = allBuyPrices[index].textContent.trim();
            
            
            if (!isNaN(amount)) {
                const request = {
                    name: name,
                    buyprice: buyprice,
                    AddedAmount: amount,
                    walletItemId: "3fa85f64-5717-4562-b3fc-2c963f66afa6"
                };
                
                try {
                    let response = await axios.post(addBalanceRequestUrl, request, {headers});
                    
                    closeAddBalanceModal();
                } catch (error) {
                    console.log("Error:", error);
                }
            }
            
            location.reload();
        });
    }
}


async function addNewCryptoBalance() {
    const submitAddNewCryptoModalButton = document.getElementsByClassName('addNewCryptoButton');
    for (let index = 0; index < submitAddNewCryptoModalButton.length; index++) {
        const button = submitAddNewCryptoModalButton[index];
        button.addEventListener('click', async function() {
            const allAmounts = document.querySelectorAll(".addNewCryptoBalanceAmount");
            const allNames = document.querySelectorAll(".addnewCryptoSymbol");
            const allBuyPrices = document.querySelectorAll(".addnewCryptoBuyPrice");
            const allFullNames = document.querySelectorAll(".addNewCryptoName");
            const amount = parseFloat(allAmounts[index].value);
            if (!isNaN(amount)) {
                const name = allNames[index].innerHTML;
                const fullName = allFullNames[index].innerHTML;
                const buyprice = allBuyPrices[index].innerHTML;
                const request = {
                    "buyPrice": buyprice,
                    "amount": amount,
                    "type": "crypto",
                    "currencyName": fullName,
                    "currencyCode": name,
                    "iconPath": "string",
                    "walletId": "22ee33c7-f59d-4d8c-1249-08db90ea6527"
                };
                
                try {
                    let response = await axios.post(addNewCryptoUrl, request, {headers});
                    closeAddBalanceModal();
                    
                } catch (error) {
                    console.log("error", error);
                }
                
            }
            location.reload();
        });
    }
}


showRecomendationModalButton.addEventListener("click", openRecomendationModal);
closeRecomendationModalButton.addEventListener("click", closeRecomendationModal);