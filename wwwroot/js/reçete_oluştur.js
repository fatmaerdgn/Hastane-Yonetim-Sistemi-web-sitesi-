document.getElementById('btn-print').addEventListener('click', function() {
    // jsPDF nesnesi oluştur
    var doc = new jsPDF();

    // Türkçe karakter desteği için karakter kodlamasını belirle
    doc.setFont('times', 'normal'); // Fontu belirle (opsiyonel)
    doc.setTextColor(0, 0, 0); // Yazı rengini ayarla (siyah)

    // Reçete başlığı ekle
    doc.setFontSize(40);
    doc.text('MEDITECH', 10, 20);
    doc.setFontSize(30);
    doc.text('Reçete', 10, 40);
    doc.text('--------------------------------------------------------------------------',10,60)

    // Hasta bilgileri
    var patientName = document.getElementById('patientName').value;
    var patientID = document.getElementById('patientID').value;
    doc.setFontSize(14);
    doc.text('Hasta Ad: ' + patientName, 10, 80); // "ı" harfi için Unicode kaçış dizisi
    doc.text('T.C. Kimlik: ' + patientID, 10, 100);

    // İlaçlar ve dozaj bilgisi
    var medications = document.getElementById('medications').value;
    var dosage = document.getElementById('dosage').value;
    doc.setFontSize(12);
    doc.text('Tavsiye edilen ilaçlar: ' + medications, 10, 120);
    doc.text('Dozaj Bilgisi: ' + dosage, 10, 140);
    doc.text('Doktor imza:',10, 220);


    // Yazdırma işlemi
    doc.autoPrint();
    doc.output('dataurlnewwindow'); // Yazdırma penceresini aç
});
