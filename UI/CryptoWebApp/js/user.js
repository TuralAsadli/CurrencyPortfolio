
document.addEventListener("DOMContentLoaded", function()
{
  const cookies = document.cookie.split(";");

    // Define the name of the cookie you're looking for
    const targetCookieName = "jwt"; // Replace with your cookie name


    // Check if the target cookie exists
    let cookieExists = false;
    for (const cookie of cookies) {
        const [name, value] = cookie.trim().split("=");
        if (name === targetCookieName) {
            cookieExists = true;
            break;
        }
    }

    if (cookieExists) {
      const content = document.getElementById("authenticatorBlock");
      content.style.display = "none";
    }

    if (!cookieExists) {
        const content = document.getElementById("protectedContent");
        content.style.display = "none";
    }
    
}
)

//Modals
const loginButton = document.getElementById("loginButton");
const registerButton = document.getElementById("registerButton");
const loginModal = document.getElementById("loginModal");
const registerModal = document.getElementById("registerModal");
const closeButtons = document.querySelectorAll(".close");

const loginUrl = "https://localhost:7192/api/Account/LogIn"
const registrationUrl = "https://localhost:7192/api/Account/Registration"

const loginForm = document.getElementById("loginForm");

const registerForm = document.getElementById("registerForm");



loginForm.addEventListener("submit", async (event) => {
    event.preventDefault();
  
    const userName = document.getElementById("username").value;
    const password = document.getElementById("password").value;
  
    try {
      const response = await axios.post(loginUrl, { userName, password });
      
      if (response.status === 200) {
        loginModal.style.display = "none";

        const expirationDate = new Date();
        expirationDate.setDate(expirationDate.getDate() + 1);

        document.cookie = `jwt=${response.data.token}; expires=${expirationDate.toUTCString()}; path=/;`;
        document.cookie = `userId=${response.data.userId}; expires=${expirationDate.toUTCString()}; path=/;`;
        document.cookie = `username=${response.data.userName}; expires=${expirationDate.toUTCString()}; path=/;`;
      } 
    } catch (error) {
        if(error.response.status === 401){
            const uservalidate = document.getElementById("userValidate");
            uservalidate.innerHTML = error.response.data
          }
    }
    location.reload();
  });

  registerForm.addEventListener("submit", async (event) => {
    event.preventDefault();
  
    const UserName = document.getElementById("newUsername").value;
    const Email = document.getElementById("newEmail").value;
    const ConfirmPassword = document.getElementById("newConfirPassword").value;
    const Password = document.getElementById("newPassword").value;
    
    const newUser = {
      UserName: UserName,
      Password: Password,
      Email: Email,
      ConfirmPassword: ConfirmPassword

    }
    
    try {
      const response = await axios.post(registrationUrl, newUser);
      
      if (response.status === 201) {
        registerModal.style.display = "none"
      }
    } catch (error) {
      if (error.response.status === 400) {
        
        const uservalidation = document.getElementById("userValidation")
        const emailvalidation = document.getElementById("emailvalidation")
        const passwordvalidation = document.getElementById("passwordvalidation")
        const confirmPasswordValidation = document.getElementById("confirmPasswordValidation")

        console.log(error)

        for (let index = 0; index < error.response.data.length; index++) {
          const element = error.response.data[index];
          
          switch (element.propertyName) {
            case "Email":
              emailvalidation.innerHTML = element.errorMessage
              break;
            

            case "Password":
              passwordvalidation.innerHTML = element.errorMessage
              break;

            case "UserName":
              uservalidation.innerHTML = element.errorMessage
              break;

            case "ConfirmPassword":
              confirmPasswordValidation.innerHTML = element.errorMessage
              break;

            default:
              break;
          }

        }
        


      }
    }
  });


  function getCookie(name) {
    const cookies = document.cookie.split(";");
  
    for (const cookie of cookies) {
      const [cookieName, cookieValue] = cookie.trim().split("=");
      if (cookieName === name) {
        return cookieValue;
      }
    }
    return null; // Return null if cookie not found
  }

  function LogOut(){
    document.cookie = "username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = "userId=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    document.cookie = "jwt=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    location.reload();
  }

  

loginButton.addEventListener("click", () => {
  loginModal.style.display = "block";
});

registerButton.addEventListener("click", () => {
  registerModal.style.display = "block";
});

closeButtons.forEach((button) => {
  button.addEventListener("click", () => {
    loginModal.style.display = "none";
    registerModal.style.display = "none";
  });
});