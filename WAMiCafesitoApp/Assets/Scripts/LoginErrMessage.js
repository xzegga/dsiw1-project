function showToast(message) {
    var toast = new bootstrap.Toast(document.getElementById('liveToast'));

    // Set the toast message dynamically
    var toastBody = document.querySelector('.toast-body');
    toastBody.innerText = message;

    // Show the toast
    toast.show();
}

// Check if there's a toast message stored in the hidden field
var toastMessage = document.getElementById('<%= hdnToastMessage.ClientID %>').value;

if (toastMessage) {
    // Show the toast message
    showToast(toastMessage);
}