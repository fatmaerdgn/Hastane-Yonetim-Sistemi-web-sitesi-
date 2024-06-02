document.addEventListener('DOMContentLoaded', function() {
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

    document.getElementById('randevuForm').addEventListener('submit', function(event) {
        event.preventDefault();

        const formData = new FormData(this);
        const randevuData = {
            fullname: formData.get('fullname'),
            tckn: formData.get('tckn'),
            email: formData.get('email'),
            phone: formData.get('phone'),
            date: formData.get('date'),
            time: formData.get('time')
        };

        // Simulate checking if the appointment slot is already taken
        const existingAppointments = JSON.parse(localStorage.getItem('appointments')) || [];
        const isSlotTaken = existingAppointments.some(appointment => 
            appointment.date === randevuData.date && appointment.time === randevuData.time
        );

        if (isSlotTaken) {
            alert('Seçilen randevu zamanı zaten alınmış. Lütfen başka bir zaman seçin.');
        } else {
            existingAppointments.push(randevuData);
            localStorage.setItem('appointments', JSON.stringify(existingAppointments));
            alert('Randevunuz başarıyla alındı!');
            this.reset();
        }
    });
});

// Poliklinik seçeneklerini al
var departmentSelect = document.getElementById('department');

// Poliklinik seçeneklerini doldur
var departments = ['Genel Cerrahi', 'Kardiyoloji', 'Ortopedi']; // Örnek poliklinikler
departments.forEach(function(department) {
    var option = document.createElement('option');
    option.textContent = department;
    option.value = department.toLowerCase().replace(/\s/g, '_'); // Boşlukları alt çizgi ile değiştirme
    departmentSelect.appendChild(option);
});

