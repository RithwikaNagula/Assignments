let Data=[
  {
    "id": 1,
    "name": "Health Plus",
    "type": "Health",
    "premium": 12000,
    "duration": 1,
    "status": "Active"
  },
  {
    "id": 2,
    "name": "Life Secure",
    "type": "Life",
    "premium": 9000,
    "duration": 10,
    "status": "Inactive"
  },
  {
    "id": 3,
    "name": "Car Protect",
    "type": "Vehicle",
    "premium": 7000,
    "duration": 1,
    "status": "Active"
  },
  {
    "id": 4,
    "name": "Family Health",
    "type": "Health",
    "premium": 15000,
    "duration": 2,
    "status": "Active"
  }
]
let policies=[];

function fetchfromapi(){
    return new Promise((res,rej)=>{
        setTimeout(()=>{
            let apisuccess=true;
            if(apisuccess){
                res(Data);
            }
            else{
                rej("Failed to fetch data");
            }
        },2000);
    }
)}


// Task1
//using promise to make asynchronous data and behave like api
async function fetchdata() {
  try {
    policies = await fetchfromapi();
    console.log(policies);
    showdata(policies);         
  } catch (error) {
    alert(error);
  }
}

//  Task2
function showdata(list) {
  const display = document.getElementById("display");
  display.innerHTML = "";

  for (let p of list) {
    display.innerHTML += `
      <tr>
        <td>${p.name}</td>
        <td>${p.type}</td>
        <td>${p.premium}</td>
        <td>${p.duration}</td>
        <td>${p.status}</td>
      </tr>
    `;
  }
}


// Task3
function filterhealth(){
const healthpolicies=Data.filter(h=>(h.type=='Health'));
showdata(healthpolicies);
}

function filterlife(){
    const lifepolicies=Data.filter(l=>(l.type=='Life'));
  showdata(lifepolicies);
   
}

function filtervehicle(){
    const vehiclepolicies=Data.filter(v=>(v.type=='Vehicle'));
    showdata(vehiclepolicies);  
}


// Task4
function totalpremium(){
    const totpremium=Data.filter(p=>p.status==='Active').reduce((sum,p)=>sum+p.premium,0);
    console.log(totpremium);
    document.getElementById("totalPremiumDisplay").innerText =totpremium;
}


// Task5
function premiumdiscount(){
    const discount=Data.map(p=>{
        if(p.premium>10000){
            return{
                ...p,premium:p.premium-p.premium*0.1
            }
        }
        return p;
    })
    console.log(discount);
    const container = document.getElementById("discountDisplay");
    container.innerHTML = "";

    for (let p of discount) {
    container.innerHTML += `<p>${p.name} :${p.premium}</p>`
      }
}


// Task6
function approvePolicy(policyId, callback) {
  setTimeout(() => {
    const policy = policies.find(p => p.id === policyId);
    if (policy) policy.status = "Active";
    callback("Policy approved successfully");
  }, 2000);
}

function approvalCallback(message) {
  alert(message);
  showWithAction(policies); 
      
}

function showWithAction(list) {
  const display = document.getElementById("approvedisplay");
  display.innerHTML = "";

  for (let p of list) {
    display.innerHTML += `
      <tr>
        <td>${p.name}</td>
        <td>${p.type}</td>
        <td>${p.premium}</td>
        <td>${p.duration}</td>
        <td>${p.status}</td>
        <td>
          ${
            p.status === "Inactive"? `<button onclick="approvePolicy(${p.id}, approvalCallback)">Approve</button>`
              : `<span style="color:green;font-weight:bold">Approved</span>`
          }
        </td>
      </tr>
    `;
  }
}


// Task7
function purchasePolicy(policyId) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const policy = policies.find(p => p.id === policyId); 
      if (!policy) {
        reject("Invalid policy ID");
        return;
      }
      if (policy.status === "Active") {
        reject("Policy already active");
        return;
      }
      policy.status = "Active";
      resolve("Policy purchased successfully");
    }, 2000);
  });
}
function buyPolicy(id) {
  purchasePolicy(id)
    .then(msg => {
      document.getElementById("purchaseMessage").innerText = msg;
    })
    .catch(err => {
      document.getElementById("errorMessage").innerText = err;
    });
}



// Task8
function buyPolicyinvalid(id) {
  purchasePolicy(id)
    .then(msg => {
      document.getElementById("successMessage").innerText = msg;
      document.getElementById("errorMessage").innerText = "";
    })
    .catch(err => {
      document.getElementById("errorMessage").innerText = err;
      document.getElementById("successMessage").innerText = "";
    });
}

function fetchapi() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const apiSuccess = false; 
    //   simulate API Failure
      if (apiSuccess) {
        resolve(Data);
      } else {
        reject("API failure: Unable to fetch policies");
      }
    }, 2000);
  });
}

async function fetchData() {
  try {
    policies = await fetchapi();
    document.getElementById("successMessage").innerText = "Policies fetched";
    document.getElementById("errorMessage").innerText = "";
  } catch (error) {
    document.getElementById("errorMessage").innerText = error;
    document.getElementById("successMessage").innerText = "";
  }
}

function totalpremiumamount() {
  try {
    const total = policies.reduce((sum, p) => {
      if (typeof p.premium !== "number") {
        throw new Error("Invalid premium value");
      }
      return sum + p.premium;
    }, 0);

    document.getElementById("successMessage").innerText =
      "Total Premium: " + total;
    document.getElementById("errorMessage").innerText = "";
  } catch (error) {
    document.getElementById("errorMessage").innerText =
      "Premium Calculation Error: " + error.message;
    document.getElementById("successMessage").innerText = "";
  }
}