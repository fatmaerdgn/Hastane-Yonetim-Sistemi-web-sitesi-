// document.getElementById('submitBtn').addEventListener('click', function() {
//     var patientName = document.getElementById('patientName').value;
//     var patientID = document.getElementById('patientID').value;
//     var reason = document.getElementById('reason').value;
//     var doctor = document.getElementById('doctor').value;
//     var destination = document.getElementById('destination').value;

//     // Burada form verilerini işleyip gerekli işlemleri yapabilirsiniz
//     console.log('Hasta Adı:', patientName);
//     console.log('Hasta Kimlik Numarası:', patientID);
//     console.log('Sevk Nedeni:', reason);
//     console.log('Yönlendiren Doktor:', doctor);
//     console.log('Yönlendirilen Yer:', destination);

//     // Burada formun bir sunucuya gönderilmesi gibi bir işlem gerçekleştirebilirsiniz
//     // Örneğin, bir AJAX isteği gönderebilirsiniz veya başka bir işlem yapabilirsiniz
//     // Bu örnekte sadece form verilerini konsola yazdırıyoruz
// });


document.getElementById('btn-generate-pdf').addEventListener('click', function() {
    //const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Form bilgilerini al
    var patientName = document.getElementById('patientName').value;
    var patientID = document.getElementById('patientID').value;
    var reason = document.getElementById('reason').value;
    var destination = document.getElementById('destination').value;
    var doctor = document.getElementById('doctor').value;

    // Türkçe karakter desteği için karakter kodlamasını belirle
    doc.setFont('times', 'normal');
    doc.setTextColor(0, 0, 0);

    // Reçete başlığı ekle
    doc.setFontSize(20);
    doc.text('MEDITECH', 105, 40, null, null, 'center');

    doc.setFontSize(20);
    doc.text('Hasta Sevk Raporu', 105, 60, null, null, 'center');
    doc.text('--------------------------------------------------------------------------',10,80)


    // Hasta bilgileri
    doc.setFontSize(14);
    doc.text('Hasta Ad: ' + patientName, 10, 100);
    doc.text('T.C. Kimlik: ' + patientID, 10, 120);

    // Sevk bilgileri
    doc.text('Sevk Nedeni: ' + reason, 10, 140);
    doc.text('Sevk Edilen Hastane: ' + destination, 10, 160);

    // Doktor imzası
    doc.text('Doktor Ad-Soyad:'+ doctor, 10, 240);

    // PDF'i yeni pencerede aç
    doc.autoPrint();
    doc.output('dataurlnewwindow');
});
