document.addEventListener('DOMContentLoaded', function () {
    // ... (Zaman seçenekleri ve bugünün tarihini ayarlama) ...
    const timeSelect = document.getElementById('time');
    const dateInput = document.getElementById('date');

    // Zaman seçeneklerini oluştur
    const startTime = 9 * 60; // 09:00 in minutes
    const endTime = 16 * 60 + 50; // 16:50 in minutes
    const interval = 10; // Interval in minutes

    for (let time = startTime; time <= endTime; time += interval) {
        const hours = Math.floor(time / 60);
        const minutes = time % 60;

        // 12:00 - 13:00 aralığını atla
        if (hours === 12 || (hours === 12.50 && minutes === 0)) {
            continue;
        }

        const option = document.createElement('option');
        option.value = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
        option.textContent = option.value;
        timeSelect.appendChild(option);
    }

    // Bugünün tarihini al
    const today = new Date().toISOString().split('T')[0];
    dateInput.setAttribute('min', today);


    document.getElementById('randevuForm').addEventListener('submit', function (event) {
        event.preventDefault(); // Formun varsayılan davranışını engelle

        var formData = new FormData(this); // Form verilerini al

        $.ajax({
            url: '/Home/RandevuAl', // RandevuAl action metodunun URL'si
            type: 'POST',
            data: formData,
            processData: false,  // FormData için gerekli ayarlar
            contentType: false,
            success: function (response) {
                if (response.success) {
                    alert(response.message); // Başarı mesajını göster
                    this.reset(); // Formu temizle
                    // Yönlendirme
                    window.location.href = '@Url.Action("RandevulariListele", "Home")';
                } else {
                    alert(response.message); // Hata mesajını göster
                }
            },
            error: function (xhr, status, error) {
                console.error("Randevu alırken hata oluştu:", error);
                alert("Randevu alırken bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        });
    });
});