const API = "https://696bac61624d7ddccaa1c90d.mockapi.io/users";
let accounts = [];

const tbody = document.getElementById("accounts");
const loader = document.getElementById("loader");
const branchFilter = document.getElementById("branchFilter");
const totalBalanceEl = document.getElementById("totalBalance");
const totalAccountsEl = document.getElementById("totalAccounts");


// Task 1: Fetch Accounts from REST API (GET)
// Task 6: Handle API/network errors gracefully
async function fetchAccounts() {
  document.getElementById("fetchBtn").disabled = true;
  showLoader();

  try {
    await delay(500);
    const res = await fetch(API);
    if (!res.ok) throw new Error("API error");

    const data = await res.json();

    accounts = data.map(u => ({
  ...u,
  branch: u.branch || u.address?.city || "Main",
  balance: u.balance ?? (Math.floor(Math.random() * 40000) + 10000),
  history: u.history || []
}));


    saveToStorage(); 

    populateBranches();
    render(accounts);

  } catch (err) {
    alert("Failed to load accounts");
    console.error(err);
  } finally {
    hideLoader();
  }
}


// Task 1: Display Accounts
function render(data) {
  tbody.innerHTML = "";

  data.forEach(acc => {
    const tr = document.createElement("tr");
    // Task 10: Highlight accounts with balance < ₹5,000
    if (acc.balance < 5000) tr.classList.add("low");

    tr.innerHTML = `
      <td>${acc.id}</td>
      <td>${acc.name}</td>
      <td>${acc.email}</td>
      <td>${acc.branch}</td>
      <td>₹${acc.balance}</td>
      <td>
        <button class="btn-success" onclick="deposit(${acc.id})">Deposit</button>
        <button class="btn-danger" onclick="withdraw(${acc.id})">Withdraw</button>
        <button class="btn-info" onclick="viewHistory(${acc.id})">History</button>
        <button class="btn-dark" onclick="deleteAccount(${acc.id})">Delete</button>
      </td>
    `;

    tbody.appendChild(tr);
  });
  // Task 10: Calculate Total Balance & Total Accounts
  totalAccountsEl.textContent = accounts.length;
  totalBalanceEl.textContent = accounts.reduce((sum, a) => sum + a.balance, 0);
}



// Task 2:Branch Dropdown (Filter)
function populateBranches() {
  branchFilter.innerHTML = `<option value="">All Branches</option>`;
  const branches = [...new Set(accounts.map(a => a.branch))];

  branches.forEach(b => {
    const opt = document.createElement("option");
    opt.value = b;
    opt.textContent = b;
    branchFilter.appendChild(opt);
  });
}



// Task 2: Search Account by Name
document.getElementById("search").addEventListener("input", e => {
  const val = e.target.value.toLowerCase();
  render(accounts.filter(a => a.name.toLowerCase().includes(val)));
});



// Task 2: Filter Accounts by Branch
branchFilter.addEventListener("change", e => {
  const val = e.target.value;
  render(val ? accounts.filter(a => a.branch === val) : accounts);
});


// Task 3: Deposit Operation
async function deposit(id) {
  const amt = Number(prompt("Enter deposit amount"));
  if (!amt || amt <= 0) return;

  const acc = accounts.find(a => a.id == id);
  acc.balance += amt;
  acc.history.push({ type: "Deposit", amount: amt, time: new Date() });

  saveToStorage();
  render(accounts);
  await syncAccountToAPI(acc);
}

// Task 3: Withdraw Operation
async function withdraw(id) {
  const amt = Number(prompt("Enter withdraw amount"));
  if (!amt || amt <= 0) return;

  const acc = accounts.find(a => a.id == id);
  if (acc.balance < amt) return alert("Insufficient balance");

  acc.balance -= amt;
  acc.history.push({ type: "Withdraw", amount: amt, time: new Date() });
  // Task 8: Minimum Balance Rule + Penalty
  if (acc.balance < 5000) {
    acc.balance -= 200;
    alert("Minimum balance violated 200 penalty applied");
  }

  saveToStorage();
  render(accounts);
  await syncAccountToAPI(acc);
}

async function syncAccountToAPI(acc) {
  await fetch(`${API}/${acc.id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(acc)
  });
}


// Task 6: Loading Indicator
function showLoader() {
  loader.style.display = "flex";
}
function hideLoader() {
  loader.style.display = "none";
}

// Task 6: Artificial Delay (for loader visibility)
function delay(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

// Task 9: Persist Data using localStorage
function saveToStorage() {
  localStorage.setItem("accounts", JSON.stringify(accounts));
}
function loadFromStorage() {
  return JSON.parse(localStorage.getItem("accounts"));
}

// Task 7: Transaction History per Account
function viewHistory(id) {
  const acc = accounts.find(a => a.id == id);
   document.getElementById("historyTitle").textContent =
  `Transaction History – ${acc.name}`;
  const card = document.getElementById("historyCard");
  const body = document.getElementById("historyBody");

  body.innerHTML = "";

  if (!acc.history.length) {
    body.innerHTML = `<tr><td colspan="3">No transactions yet</td></tr>`;
  } else {
    acc.history.forEach(h => {
      const tr = document.createElement("tr");
      tr.innerHTML = `
        <td>${h.type}</td>
        <td>₹${h.amount}</td>
        <td>${new Date(h.time).toLocaleString()}</td>
      `;
      body.appendChild(tr);
    });
  }

  card.style.display = "block";
  card.scrollIntoView({ behavior: "smooth" });
}



// Task 4: Create New Bank Account (POST)
document.getElementById("addForm").addEventListener("submit", async e => {
  e.preventDefault();

  const newAcc = {
    name: document.getElementById("name").value,
    email: document.getElementById("email").value,
    branch: document.getElementById("branch").value,
    balance: 10000,
    history: []
  };

  try {
    showLoader();
    await delay(500);

    const res = await fetch(API, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newAcc)
    });

    const saved = await res.json();
    accounts.push(saved);

    saveToStorage();
    populateBranches();
    render(accounts);
    e.target.reset();

  } catch (err) {
    alert("Failed to add account");
  } finally {
    hideLoader();
  }
});


// Task 5: Delete Bank Account (DELETE)
async function deleteAccount(id) {
  if (!confirm("Delete this account?")) return;

  try {
    showLoader();
    await delay(500);

    await fetch(`${API}/${id}`, { method: "DELETE" });
    accounts = accounts.filter(a => a.id != id);

    saveToStorage();
    populateBranches();
    render(accounts);

  } catch (err) {
    alert("Delete failed");
  } finally {
    hideLoader();
  }
}



// Task 10: Sort Accounts by Balance (High to Low)
function sortByBalance() {
  render([...accounts].sort((a, b) => b.balance - a.balance));
}



// Task 6: fetch
document.getElementById("fetchBtn").addEventListener("click", () => {
  fetchAccounts();
  
});


