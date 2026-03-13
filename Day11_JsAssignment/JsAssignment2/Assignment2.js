function logMessage(msg) {
  const output = document.getElementById("output");
  output.innerHTML += msg + "<br>";
}

// Exercise 1
const section = document.getElementById("paymentSection");
const paymentbutton = document.getElementById("payBtn");
section.addEventListener("click", () => {
  logMessage("Payment Section Clicked");
});
paymentbutton.addEventListener("click", () => {
  logMessage("Pay Premium Button Clicked");
});



// Exercise 2
const container = document.getElementById("policyContainer");
const policybutton = document.getElementById("viewPolicy");
container.addEventListener("click",() => {
    logMessage("User Validation at Container");
  },true   
);
policybutton.addEventListener("click",() => {
    logMessage("Policy Details Shown");
  },true   
);



// Exercise 3
const card = document.querySelector(".policyCard");
const deleteBtn = document.querySelector(".deleteBtn");
card.addEventListener("click", () => {
  logMessage("Navigating to Policy Details");
});
deleteBtn.addEventListener("click", (e) => {
  e.stopPropagation();
  logMessage("Policy Deleted");
});



// Exercise 4
const claimRow = document.querySelector(".claimRow");
const approveBtn = document.querySelector(".approveBtn");
claimRow.addEventListener("click", () => {
  logMessage("Opening Claim Details");
});
approveBtn.addEventListener("click", (e) => {
  e.stopPropagation(); 
  logMessage("Claim Approved");
});
/*What happens without stopPropagation():
The event bubbles from the button to the parent row.
If stopPropagation() is not used, clicking the Approve Claim button produces:
Claim Approved
Opening Claim Details*/

/*What happens with stopPropagation():
Navigation to claim details is prevented.
When stopPropagation() is used, clicking Approve Claim produces:
Claim Approved*/



