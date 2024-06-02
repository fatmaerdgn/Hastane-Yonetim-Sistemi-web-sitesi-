document.getElementById('btn-save').addEventListener('click', function() {
    var patientName = document.getElementById('patientName').value;
    var patientID = document.getElementById('patientID').value;
    var surgeryDate = document.getElementById('surgeryDate').value;
    var surgeryTime = document.getElementById('surgeryTime').value;
    var doctorName = document.getElementById('doctorName').value;

    var currentDate = new Date();
    var selectedDate = new Date(surgeryDate + 'T' + surgeryTime);
    
    if (selectedDate < currentDate) {
        alert('Geçmiş bir tarihe veya saate ameliyat randevusu verilemez.');
        return;
    }

    var listItem = document.createElement('li');
    listItem.innerHTML = `
        <span>Hasta Adı: ${patientName}</span>
        <span>T.C. Kimlik: ${patientID}</span>
        <span>Ameliyat Tarihi: ${surgeryDate}</span>
        <span>Ameliyat Saati: ${surgeryTime}</span>
        <span>Doktor Adı: ${doctorName}</span>
        <button class="cancel-button">İptal</button>
    `;
    
    document.getElementById('surgeryList').appendChild(listItem);
    document.getElementById('surgeryForm').reset();
    
    listItem.querySelector('.cancel-button').addEventListener('click', function() {
        if (confirm('Bu ameliyat kaydını iptal etmek istediğinizden emin misiniz?')) {
            listItem.remove();
            alert('Ameliyat kaydı iptal edildi.');
        }
    });
});
