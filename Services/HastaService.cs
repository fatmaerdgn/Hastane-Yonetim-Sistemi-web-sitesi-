using bitirmeMVC5.Models;
using Microsoft.Extensions.Hosting;

namespace bitirmeMVC5.Services
{
    public class HastaService
    {
        private readonly ApplicationDbContext _context;

        public HastaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Veritabanına yeni bir personel ekler
        public void AddHasta(Hasta hasta)
        {
            _context.Hasta.Add(hasta);
            _context.SaveChanges();
        }

        public bool ValidateHasta(string tcKimlikNo, string password)
        {
            var hasta = _context.Hasta.FirstOrDefault(h => h.TcKimlikNo == tcKimlikNo && h.Parola == password);
            return hasta != null;
        }

    }
}