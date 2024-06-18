// Randevuları HTML'e ekleme
const randevuListesi = document.getElementById('randevular');

function renderAppointments() {
    randevuListesi.innerHTML = '';
    const cancelledAppointments = JSON.parse(localStorage.getItem('cancelledAppointments')) || [];

    randevular.forEach(randevu => {
        if (!cancelledAppointments.includes(randevu.id)) {
            const randevuHTML = `
                        <div class="randevu__item" id="randevu-${randevu.id}">
                            <p><strong>Tarih:</strong> ${randevu.tarih}</p>
                            <p><strong>Saat:</strong> ${randevu.saat}</p>
                            <p><strong>Poliklinik:</strong> ${randevu.poliklinik}</p>
                            <button class="cancel-button" onclick="iptalEt(${randevu.id})">Randevuyu İptal Et</button>
                        </div>
                    `;
            randevuListesi.innerHTML += randevuHTML;
        }
    });
}

// Randevu iptal fonksiyonu
function iptalEt(randevuId) {
    // İptal işlemi için kullanıcıdan onay al
    const onay = confirm("Randevunuzu iptal etmek istediğinize emin misiniz?");

    if (onay) {
        // İptal edilen randevuları localStorage'da sakla
        let cancelledAppointments = JSON.parse(localStorage.getItem('cancelledAppointments')) || [];
        if (!cancelledAppointments.includes(randevuId)) {
            cancelledAppointments.push(randevuId);
            localStorage.setItem('cancelledAppointments', JSON.stringify(cancelledAppointments));
        }

        // İptal edilen randevuyu listeden kaldır
        renderAppointments();

        // Başarı mesajını göster
        showSuccessMessage();
    }
}

function showSuccessMessage() {
    const messageContainer = document.createElement('div');
    messageContainer.classList.add('success-message');
    messageContainer.textContent = 'Randevunuz başarıyla iptal edildi.';
    document.body.appendChild(messageContainer);

    // Belirli bir süre sonra mesajı kaldır
    setTimeout(function () {
        messageContainer.remove();
    }, 3000); // 3 saniye sonra mesajı kaldır
}

// Sayfa yüklendiğinde randevuları ekrana ekle
document.addEventListener('DOMContentLoaded', renderAppointments);
