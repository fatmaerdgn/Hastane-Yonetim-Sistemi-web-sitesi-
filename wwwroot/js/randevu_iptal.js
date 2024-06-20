document.addEventListener('DOMContentLoaded', function () {
    const randevuListesi = document.getElementById('randevular');

    function renderAppointments(randevular) { // Randevu listesini parametre olarak al
        randevuListesi.innerHTML = '';
        const cancelledAppointments = JSON.parse(localStorage.getItem('cancelledAppointments')) || [];

        randevular.forEach(randevu => {
            if (!cancelledAppointments.includes(randevu.ID)) { // Randevu ID'sini kullan
                const randevuHTML = `
                    <div class="randevu__item" id="randevu-${randevu.ID}">
                        <p><strong>Tarih:</strong> ${randevu.RandevuTarihi.toLocaleDateString()}</p> 
                        <p><strong>Saat:</strong> ${randevu.RandevuSaati.toString()}</p>
                        <p><strong>Poliklinik:</strong> ${randevu.Poliklinik}</p>
                        <button class="cancel-button" onclick="iptalEt(${randevu.ID})">Randevuyu İptal Et</button>
                    </div>
                `;
                randevuListesi.innerHTML += randevuHTML;
            }
        });
    }
});
