
const insurancePlans = [
    {
        id: 1,
        name: "Health Insurance",
        basePremium: 3000,
        coverage: "Up to ₹10L"
    },
    {
        id: 2,
        name: "Life Insurance",
        basePremium: 5000,
        coverage: "Up to ₹50L"
    },
    {
        id: 3,
        name: "Vehicle Insurance",
        basePremium: 2000,
        coverage: "Up to ₹5L"
    }
];


let customers = [];

function displayInsurancePlans() {
    const plansContainer = document.getElementById('insurancePlans');
    
    plansContainer.innerHTML = insurancePlans.map(plan => `
        <div class="plan-card bg-white rounded-lg shadow-lg p-6 hover:shadow-xl transition-shadow">
            <h3 class="text-xl font-bold text-gray-800 mb-3">${plan.name}</h3>
            <div class="mb-4">
                <p class="text-gray-600 text-sm mb-1">Base Premium</p>
                <p class="text-2xl font-bold text-blue-600">₹${plan.basePremium.toLocaleString()}</p>
            </div>
            <div class="mb-4">
                <p class="text-gray-600 text-sm mb-1">Coverage Amount</p>
                <p class="text-lg font-semibold text-gray-800">${plan.coverage}</p>
            </div>
            <button 
                class="w-full bg-blue-600 text-white py-2 rounded-lg font-semibold hover:bg-blue-700 transition-colors mt-4"
                onclick="selectPolicyType('${plan.name}')"
            >
                Enroll Now
            </button>
        </div>
    `).join('');
}

function selectPolicyType(policyType) {
    const policySelect = document.getElementById('policyType');
    policySelect.value = policyType;
    document.getElementById('enquiryForm').scrollIntoView({ behavior: 'smooth' });
}


function calculatePremium(age, policyType, coverage) {
    let basePremium = 0;
    if (policyType === "Health Insurance") {
        basePremium = 3000;
    } else if (policyType === "Life Insurance") {
        basePremium = 5000;
    } else if (policyType === "Vehicle Insurance") {
        basePremium = 2000;
    }
    

    if (age > 45) {
        basePremium = basePremium * 1.2;
    }
    

    const baseCoverage = 500000;
    const additionalCoverage = Math.max(0, coverage - baseCoverage);
    const additionalPremium = (additionalCoverage / 100000) * 500;
    
    return Math.round(basePremium + additionalPremium);
}


const enquiryForm = document.getElementById('enquiryForm');

enquiryForm.addEventListener('submit', function(event) {
    event.preventDefault();

    clearErrors();

    const name = document.getElementById('customerName').value.trim();
    const age = parseInt(document.getElementById('age').value);
    const email = document.getElementById('email').value.trim();
    const policyType = document.getElementById('policyType').value;
    const coverage = parseInt(document.getElementById('coverage').value);
    

    let isValid = true;
    
    if (!name || name.length < 2) {
        showError('nameError', 'Please enter a valid name (at least 2 characters)');
        markFieldAsError('customerName');
        isValid = false;
    }
    
    if (!age || age < 18 || age > 100) {
        showError('ageError', 'Please enter a valid age (18-100)');
        markFieldAsError('age');
        isValid = false;
    }
    
    if (!email || !isValidEmail(email)) {
        showError('emailError', 'Please enter a valid email address');
        markFieldAsError('email');
        isValid = false;
    }
    
    if (!policyType) {
        showError('policyTypeError', 'Please select a policy type');
        markFieldAsError('policyType');
        isValid = false;
    }
    
    if (!coverage || coverage < 500000) {
        showError('coverageError', 'Coverage amount must be at least ₹5L');
        markFieldAsError('coverage');
        isValid = false;
    }
    
    if (isValid) {

        const premium = calculatePremium(age, policyType, coverage);
        const customer = {
            id: Date.now(), 
            name: name,
            age: age,
            email: email,
            policyType: policyType,
            coverage: coverage,
            premium: premium
        };
        
        customers.push(customer);
        renderCustomerTable();
        updateDashboardSummary();
        enquiryForm.reset();
        document.getElementById('coverageValue').textContent = '500000';
        showSuccessMessage('Customer enquiry submitted successfully!');
    }
});


function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}


function showError(errorId, message) {
    const errorElement = document.getElementById(errorId);
    if (errorElement) {
        errorElement.textContent = message;
    }
}

function clearErrors() {
    const errorMessages = document.querySelectorAll('.error-message');
    errorMessages.forEach(error => {
        error.textContent = '';
    });
    
    const errorFields = document.querySelectorAll('.error');
    errorFields.forEach(field => {
        field.classList.remove('error');
    });
}

function markFieldAsError(fieldId) {
    const field = document.getElementById(fieldId);
    if (field) {
        field.classList.add('error');
    }
}

function showSuccessMessage(message) {
    let successDiv = document.getElementById('successMessage');
    if (!successDiv) {
        successDiv = document.createElement('div');
        successDiv.id = 'successMessage';
        successDiv.className = 'fixed top-4 right-4 bg-green-500 text-white px-6 py-3 rounded-lg shadow-lg z-50';
        document.body.appendChild(successDiv);
    }
    successDiv.textContent = message;
    successDiv.style.display = 'block';
    

    setTimeout(() => {
        successDiv.style.display = 'none';
    }, 3000);
}


function renderCustomerTable(filteredCustomers = null) {
    const tableBody = document.getElementById('customerTableBody');
    const customersToDisplay = filteredCustomers || customers;
    
    if (customersToDisplay.length === 0) {
        tableBody.innerHTML = `
            <tr>
                <td colspan="6" class="px-6 py-8 text-center text-gray-500">
                    No customers found. Submit an enquiry to get started.
                </td>
            </tr>
        `;
        return;
    }
    
    tableBody.innerHTML = customersToDisplay.map(customer => `
        <tr class="hover:bg-gray-50">
            <td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">${customer.name}</td>
            <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-700">${customer.age}</td>
            <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-700">${customer.email}</td>
            <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-700">
                <span class="px-2 py-1 text-xs font-semibold rounded-full ${
                    customer.policyType === 'Health Insurance' ? 'bg-blue-100 text-blue-800' :
                    customer.policyType === 'Life Insurance' ? 'bg-green-100 text-green-800' :
                    'bg-purple-100 text-purple-800'
                }">
                    ${customer.policyType}
                </span>
            </td>
            <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-700">₹${(customer.coverage / 100000).toFixed(1)}L</td>
            <td class="px-6 py-4 whitespace-nowrap text-sm font-semibold text-blue-600">₹${customer.premium.toLocaleString()}</td>
        </tr>
    `).join('');
}


document.getElementById('filterPolicyType').addEventListener('change', function() {
    applyFilters();
});


document.getElementById('searchName').addEventListener('input', function() {
    applyFilters();
});

function applyFilters() {
    const filterPolicyType = document.getElementById('filterPolicyType').value;
    const searchName = document.getElementById('searchName').value.trim().toLowerCase();  
    let filteredCustomers = customers;
    
    if (filterPolicyType) {
        filteredCustomers = filteredCustomers.filter(customer => 
            customer.policyType === filterPolicyType
        );
    }
    
    if (searchName) {
        filteredCustomers = filteredCustomers.filter(customer =>
            customer.name.toLowerCase().includes(searchName)
        );
    }
    renderCustomerTable(filteredCustomers);
}


function updateDashboardSummary() {
    const totalCustomers = customers.length;
    document.getElementById('totalCustomers').textContent = totalCustomers;
    document.getElementById('totalPolicies').textContent = totalCustomers;
    const totalPremium = customers.reduce((sum, customer) => sum + customer.premium, 0);
    document.getElementById('totalPremium').textContent = `₹${totalPremium.toLocaleString()}`;
}

document.getElementById('coverage').addEventListener('input', function(e) {
    const coverageValue = parseInt(e.target.value);
    document.getElementById('coverageValue').textContent = coverageValue.toLocaleString();
});

document.addEventListener('DOMContentLoaded', function() {
    displayInsurancePlans();
    renderCustomerTable();
    updateDashboardSummary();
});

