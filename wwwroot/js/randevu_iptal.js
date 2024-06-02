// Örnek randevu verisi
const randevular = [
    { id: 1, tarih: '2024-06-01', saat: '10:00', poliklinik: 'Genel Cerrahi' },
    { id: 2, tarih: '2024-06-02', saat: '11:30', poliklinik: 'Kardiyoloji' },
    { id: 3, tarih: '2024-06-03', saat: '14:15', poliklinik: 'Ortopedi' }
];

// Randevuları HTML'e ekleme
const randevuListesi = document.getElementById('randevular');

randevular.forEach(randevu => {
    const randevuHTML = `
        <div class="randevu__item" id="randevu-${randevu.id}">
            <p><strong>Tarih:</strong> ${randevu.tarih}</p>
            <p><strong>Saat:</strong> ${randevu.saat}</p>
            <p><strong>Poliklinik:</strong> ${randevu.poliklinik}</p>
            <button class="cancel-button" onclick="iptalEt(${randevu.id})">Randevuyu İptal Et</button>
        </div>
    `;
    randevuListesi.innerHTML += randevuHTML;
});

// Randevu iptal fonksiyonu
function iptalEt(randevuId) {
    // İptal işlemi için kullanıcıdan onay al
    const onay = confirm("Randevunuzu iptal etmek istediğinize emin misiniz?");
    
    if (onay) {
        // Burada randevunun iptal işlemi gerçekleştirilir
        // Örneğin, bir API çağrısı yapılabilir veya veritabanından silme işlemi gerçekleştirilebilir
        
        // İptal işlemi başarılı olduğunda aşağıdaki uyarıyı gösterebiliriz
        const successMessage = document.createElement('div');
        successMessage.classList.add('success-message');
        successMessage.innerText = 'Randevunuz başarıyla iptal edildi.';
        document.body.appendChild(successMessage);

        // İptal edilen randevuyu listeden kaldırma (bu sadece örnektir, gerçek bir uygulamada veritabanından kaldırılmalıdır)
        const iptalEdilenRandevu = document.getElementById(`randevu-${randevuId}`);
        iptalEdilenRandevu.remove();

        // İptal edildi butonu ekleme
        const iptalEdildiButonu = document.createElement('button');
        iptalEdildiButonu.classList.add('cancel-button');
        iptalEdildiButonu.innerText = 'İptal Edildi';
        iptalEdildiButonu.disabled = true; // Tekrar tıklanamaz yapmak için
        iptalEdilenRandevu.appendChild(iptalEdildiButonu);
    }
}


function showSuccessMessage() {
const messageContainer = document.createElement('div');
messageContainer.classList.add('success-message');
 messageContainer.textContent = 'Randevunuz başarıyla iptal edildi.';
 document.body.appendChild(messageContainer);

//Belirli bir süre sonra mesajı kaldır
 setTimeout(function() {
messageContainer.remove();
}, 3000); // 3 saniye sonra mesajı kaldır
};
