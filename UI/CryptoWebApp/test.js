


// Get references to the modal and the button that triggers it
const modal = document.getElementById("myModal");
const showModalButton = document.getElementById("showModalButton");
const closeModalButton = modal.querySelector(".close");
const submitModalButton = document.getElementById("submitModalButton");


const apiUrl = 'https://localhost:7192/api/Account/LogIn';



// Function to open the modal
function openModal() {
  modal.style.display = "block";
}

// Function to close the modal
function closeModal() {
  modal.style.display = "none";
}

async function Create_User(){
  const name = document.getElementById('name').value;
  if (!name) {
    alert('Please enter a name.');
    return;
  }
  const password = document.getElementById('password').value;
  if (!password) {
      alert('Please enter a password.');
      return;
  }

  const User = {
    UserName: name,
    Password: password
  }
  try {
    await console.log(axios.post(apiUrl,User)) 
  } catch (error) {
    console.log("error", error)
  }

  modal.style.display = "none";
}


// Event listeners to open and close the modal
showModalButton.addEventListener("click", openModal);
closeModalButton.addEventListener("click", closeModal);
submitModalButton.addEventListener("click", Create_User);

// Close the modal if the user clicks outside of it
window.addEventListener("click", (event) => {
  if (event.target === modal) {
    closeModal();
  }
});

// Implement any additional functionality as needed (e.g., handling form submission)
