function forgotPassword(){
  const email = prompt("Enter your email:");

  if(!email){
    alert("Email is required");
    return;
  }

  alert("Reset link sent to " + email);
}