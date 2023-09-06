

const transactionUrl = "https://localhost:7192/api/Wallet/Transactions?userId=";
const deleteTransactionUrl = "https://localhost:7192/api/Wallet/DeleteTransaction?transactionId="



const transactionModal = document.getElementById("transactionModal");
const showTransactionModal = document.getElementById("showTransactionModal");
const closeTransactionModalButton = transactionModal.querySelector(".close");
const submitTransactionModalButton = document.getElementById("submitModalButton");

function openModal() {
    transactionModal.style.display = "block";
    //modal.classList.add("show");
}

// Function to close the modal
function closeModal() {
    transactionModal.style.display = "none";
    //modal.classList.remove("show");
}


function renderAllTransactions(response){

    var listItem = document.getElementById("transaction-item");
    var list = document.getElementById("transaction-list");
  
  for (let index = 0; index < response.length; index++) {
    const newItem = listItem.cloneNode(true); // Clone the listItem element
    const currencyCode = newItem.querySelector("#walletItemName");
    currencyCode.innerHTML = response[index]["walletItemName"];

    const currencyName = newItem.querySelector("#date");
    currencyName.innerHTML = response[index]["date"];

    const buyPrice = newItem.querySelector("#buyPrice");
    buyPrice.innerHTML = response[index]["buyPrice"];

    const amount = newItem.querySelector("#addedBalance");
    amount.innerHTML = "added: " + response[index]["addedBalance"] + "$";

    const transactionId = newItem.querySelector("#transactionId");
    transactionId.setAttribute('name', response[index]["id"])

    list.appendChild(newItem); // Append the cloned and modified element to the list
  }

  list.removeChild(listItem)
}

async function renderTransactions(response){
    var transactions = document.getElementsByClassName("transaction")
    for (let index = transactions.length - 1; index >= 0; index--) {
        if (response[index] != null) {
            const element = transactions[index];
            const transactionSymbol = element.querySelector("#transactionSymbol");
            const transactionDate = element.querySelector("#transactionDate");
            const transactionPrice = element.querySelector("#transactionPrice");
            const transactionBuyPrice = element.querySelector("#transactionBuyPrice");

            transactionSymbol.innerHTML = response[index]["walletItemName"]
            transactionDate.innerHTML = response[index]["date"]
            transactionBuyPrice.innerHTML = response[index]["buyPrice"]
            transactionPrice.innerHTML = response[index]["addedBalance"]
            
            if (parseFloat(response[index]["addedBalance"]) < 0 ) {
                transactionPrice.classList.add("orange-color");
                transactionPrice.classList.remove("purple-color-2");
            }
        }
        else{
            transactions[index].remove()
        }
    }
}

async function deleteTransaction(){
    location.reload();
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



async function AddElementsDeleteEvent(){
    const buttons = document.querySelectorAll("#transactionId")
    for (let index = 0; index < buttons.length; index++) {
        const element = buttons[index];
        element.addEventListener("click", async function(){
            const id = element.getAttribute('name')
            var res = await axios.delete(deleteTransactionUrl + id, {headers})
            
        });
        
    }
}


async function getTransactions(){
    var id = getCookie("userId")
    const response = await axios.get(transactionUrl + id, {headers})
    await renderTransactions(response.data)
}

async function getAllTransactions(){
    var id = getCookie("userId")
    const response = await axios.get(transactionUrl + id, {headers})
    renderAllTransactions(response.data)
}

document.addEventListener("DOMContentLoaded", getTransactions);
document.addEventListener("DOMContentLoaded", getAllTransactions);

showTransactionModal.addEventListener("click", openModal);
closeTransactionModalButton.addEventListener("click", closeModal);