document.getElementById('registerForm').addEventListener('submit', function(event) {
    event.preventDefault();
    
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirm_password').value;

    if (password !== confirmPassword) {
        alert('Şifreler uyuşmuyor. Lütfen tekrar deneyin.');
        return;
    }

    alert('Kayıt başarıyla tamamlandı!');
    // Burada formun sunucuya gönderilmesi işlemi yapılabilir.
});
