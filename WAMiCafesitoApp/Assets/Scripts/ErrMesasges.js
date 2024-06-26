﻿// Function to show the Bootstrap toast
function showAnimatedToast(messageCtrl, typeCtrl) {
    const message = messageCtrl.value;

    if (message) {
        const type = typeCtrl.value;


        const toastElement = document.getElementById('liveToast');

        const validTypes = ['bg-primary', 'bg-success', 'bg-info', 'bg-warning', 'bg-danger'];
        toastElement.classList.remove(...validTypes);

        if (type) {
            toastElement.classList.add(`bg-${type}`);
        }

        var toastMessage = document.getElementById('toastMessage');
        toastMessage.innerText = message;

        var toast = new bootstrap.Toast(
            toastElement, {
            animation: true,
            autohide: true,
                delay: 2000,
                closeButton: true,

        });

        toast.show();
    }

}