// Simüle edilmiş bir randevu listesi
var appointments = [
    { patientName: "Ahmet Yılmaz", appointmentTime: "10:00", doctor: "Dr. Mehmet" },
    { patientName: "Ayşe Demir", appointmentTime: "11:30", doctor: "Dr. Mehmet" },
    { patientName: "Mustafa Çelik", appointmentTime: "13:15", doctor: "Dr. Mehmet" },
    // Doktorun kendi randevularını buraya ekleyebilirsin
];

var appointmentsList = document.getElementById('appointmentsList');

// Doktorun randevu listesini ekrana yazdırma
appointments.forEach(function(appointment) {
    if (appointment.doctor === "Dr. Mehmet") { // Sadece belirli bir doktora ait randevuları göster
        var listItem = document.createElement('li');
        listItem.innerHTML = `
            <span>Hasta Adı: ${appointment.patientName}</span>
            <span>Randevu Saati: ${appointment.appointmentTime}</span>
        `;
        appointmentsList.appendChild(listItem);

    }
});
