document.addEventListener('DOMContentLoaded', function () {
    const timeSelect = document.getElementById('time');
    const dateInput = document.getElementById('date');

    if (!timeSelect || !dateInput) {
        console.error("HTML öğesi bulunamadı. 'time' veya 'date' ID'li öğelerin varlığından emin olun.");
        return;
    }

    // Zaman seçeneklerini oluştur
    const startTime = 9 * 60; // 09:00 in minutes
    const endTime = 16 * 60 + 50; // 16:50 in minutes
    const interval = 10; // Interval in minutes

    for (let time = startTime; time <= endTime; time += interval) {
        // Saat hesaplama
        const hours = Math.floor(time / 60);
        const minutes = time % 60;

        const option = document.createElement('option');
        option.value = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
        option.textContent = option.value;

        timeSelect.appendChild(option);
    }

    // Bugünün tarihini al
    const today = new Date().toISOString().split('T')[0];
    dateInput.setAttribute('min', today);
    document.getElementById('randevuForm').addEventListener('submit', function (event) {
        event.preventDefault();

        var formData = new FormData(this);

        $.ajax({
            url: '/Home/RandevuAl',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    this.reset();

                    // Randevu listesini güncelle
                    $.ajax({
                        url: '/Home/RandevulariListele',
                        type: 'GET',
                        success: function (html) {
                            // #randevular div'inin içeriğini güncelle
                            $('#randevular').html(html);
                        },
                        error: function (xhr, status, error) {
                            console.error("Randevu listesini getirirken hata oluştu:", error);
                            alert("Randevu listesini getirirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                        }
                    });
                } else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                console.error("Randevu alırken hata oluştu:", error);
                alert("Randevu alırken bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }
        });
    });
});



