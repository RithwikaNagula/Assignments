const form = document.getElementById('enquiryForm');

form.addEventListener('submit', function(event) {
    event.preventDefault(); 
    clearErrors();
    hideSuccessMessage(); 
    let isValid = true;
    
    // Validate Full Name - not empty
    const fullName = document.getElementById('fullName').value.trim();
    const nameRegex = /^[A-Za-z][A-Za-z\s]*$/;
    if (!fullName) {
        showError('fullNameError', 'Full name is required');
        markFieldAsError('fullName');
        isValid = false;
    }
    else if (!nameRegex.test(fullName)) {
        showError(
            'fullNameError',
            'Name must start with a letter and contain only letters and spaces'
        );
        markFieldAsError('fullName');
        isValid = false;
    }
    else {
        clearFieldError('fullName');
    }

    
    // Validate Email - not empty
    const email = document.getElementById('email').value.trim();
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email) {
    showError('emailError', 'Email is required');
    markFieldAsError('email');
    isValid = false;
    } 
    else if (!emailRegex.test(email)) {
    showError('emailError', 'Enter a valid email address');
    markFieldAsError('email');
    isValid = false;
    } 
    else {
    clearFieldError('email');
    }

    
    // Validate Mobile Number - exactly 10 digits
    const mobile = document.getElementById('mobile').value.trim();
    const mobilePattern = /^\d{10}$/;
    if (!mobile) {
        showError('mobileError', 'Mobile number is required');
        markFieldAsError('mobile');
        isValid = false;
    } else if (!mobilePattern.test(mobile)) {
        showError('mobileError', 'Mobile number must be exactly 10 digits');
        markFieldAsError('mobile');
        isValid = false;
    } else {
        clearFieldError('mobile');
    }
    
    // Validate Request Type - selected
    const requestType = document.getElementById('requestType').value;
    if (!requestType) {
        showError('requestTypeError', 'Please select a request type');
        markFieldAsError('requestType');
        isValid = false;
    } else {
        clearFieldError('requestType');
    }
    
    // Validate Policy Type - selected
    const policyType = document.getElementById('policyType').value;
    if (!policyType) {
        showError('policyTypeError', 'Please select a policy type');
        markFieldAsError('policyType');
        isValid = false;
    } else {
        clearFieldError('policyType');
    }
    
    // Validate Message - minimum 10 characters
    const message = document.getElementById('message').value.trim();
    if (!message) {
        showError('messageError', 'Message is required');
        markFieldAsError('message');
        isValid = false;
    } else if (message.length < 10) {
        showError('messageError', 'Message must be at least 10 characters long');
        markFieldAsError('message');
        isValid = false;
    } else {
        clearFieldError('message');
    }
    
    // Validate Rating - must be selected
    const rating = document.querySelector('input[name="rating"]:checked');
    if (!rating) {
        showError('ratingError', 'Please select an experience rating');
        isValid = false;
    } else {
        const ratingError = document.getElementById('ratingError');
        if (ratingError) {
            ratingError.textContent = '';
        }
    }
    
    if (isValid) {
        showSuccessMessage();
        form.reset();
        clearAllFieldErrors();
    }
});

//show error message
function showError(errorId, message) {
    const errorElement = document.getElementById(errorId);
    if (errorElement) {
        errorElement.textContent = message;
    }
}

//clear all error messages 
function clearErrors() {
    const errorMessages = document.querySelectorAll('.error-message');
    errorMessages.forEach(error => {
        error.textContent = '';
    });
}

// Function to mark field as error
function markFieldAsError(fieldId) {
    const field = document.getElementById(fieldId);
    if (field) {
        field.classList.add('error');
    }
}

// Function to clear field error
function clearFieldError(fieldId) {
    const field = document.getElementById(fieldId);
    if (field) {
        field.classList.remove('error');
    }
}

// Function to clear all field errors
function clearAllFieldErrors() {
    const fields = document.querySelectorAll('input, select, textarea');
    fields.forEach(field => {
        field.classList.remove('error');
    });
}

//show success message 
function showSuccessMessage() {
    const successMessage = document.getElementById('successMessage');
    if (successMessage) {
        successMessage.textContent = 'Thank you! Your enquiry has been successfully submitted.';
        successMessage.classList.add('show');
        successMessage.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
    }
}

// To hide success message
function hideSuccessMessage() {
    const successMessage = document.getElementById('successMessage');
    if (successMessage) {
        successMessage.classList.remove('show');
        successMessage.textContent = '';
    }
}

