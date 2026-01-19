const apiurl ="https://69660d56f6de16bde44bfe24.mockapi.io/policiesdetails/policies";

async function getPolicies() {
  const res = await fetch(apiurl);
  const data = await res.json();

  const container = document.getElementById("policyCards");
  container.innerHTML = "";

  data.forEach(p => {
    container.innerHTML += `
      <div class="card">
        <b>ID:</b> ${p.id}<br>
        <b>Name:</b> ${p.name}<br>
        <b>Type:</b> ${p.type}<br>
        <b>Premium:</b> ${p.premium}<br>
        <b>Duration:</b> ${p.duration}<br>
        <b>Status:</b> ${p.status}
      </div>`;
  });
}


async function addPolicy() {
  const name = document.getElementById("Name").value.trim();
  const type = document.getElementById("type").value.trim();
  const premium = document.getElementById("premium").value.trim();
  const duration = document.getElementById("duration").value.trim();
  const status = document.getElementById("Status").value.trim();

  if (!name || !type || !premium || !duration || !status) {
    alert("Please enter all policy details");
    return;
  }

  const policy = { name, type, premium, duration, status };

  await fetch(apiurl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(policy)
  });

  alert("Policy added");
  getPolicies();
}



async function updatePolicy() {
  const id = document.getElementById("policyId").value.trim();
  if (!id) return alert("Enter Policy ID");
  const name = document.getElementById("Name").value.trim();
  const type = document.getElementById("type").value.trim();
  const premium = document.getElementById("premium").value.trim();
  const duration = document.getElementById("duration").value.trim();
  const status = document.getElementById("Status").value.trim();

  if (!name || !type || !premium || !duration || !status) {
    alert("All fields required for update");
    return;
  }

  const policy = { name, type, premium, duration, status };
  const res = await fetch(`${apiurl}/${id}`, {
  method: "PUT",
  headers: { "Content-Type": "application/json" },
  body: JSON.stringify(policy)
  });
  if (!res.ok) {
    alert("Policy not found. Update failed.");
    return;
  }

}



async function patchPolicy() {
  const id = document.getElementById("policyId").value.trim();
  if (!id) {
    alert("Enter Policy ID");
    return;
  }
  const getRes = await fetch(`${apiurl}/${id}`);
  if (!getRes.ok) {
    alert("Policy not found");
    return;
  }

  const existing = await getRes.json();
  const name = document.getElementById("Name").value.trim();
  const type = document.getElementById("type").value.trim();
  const premium = document.getElementById("premium").value.trim();
  const duration = document.getElementById("duration").value.trim();
  const status = document.getElementById("Status").value.trim();

  const updatedPolicy = {
    ...existing,
    ...(name && { name }),
    ...(type && { type }),
    ...(premium && { premium }),
    ...(duration && { duration }),
    ...(status && { status })
  };

  if (JSON.stringify(existing) === JSON.stringify(updatedPolicy)) {
    alert("No changes detected");
    return;
  }

  await fetch(`${apiurl}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(updatedPolicy)
  });

  alert("Policy patched successfully");
  getPolicies();
}





async function deletePolicy() {
  const id = document.getElementById("policyId").value;
  if (!id) return alert("Enter ID to delete");

 const res = await fetch(`${apiurl}/${id}`, { method: "DELETE" });

if (!res.ok) {
  alert("Policy not found");
  return;
}

alert("Policy deleted");

}
