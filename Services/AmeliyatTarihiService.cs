using System;
using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;

namespace bitirmeMVC5.Services
{
    public class AmeliyatTarihiService
    {
        private readonly ApplicationDbContext _context;

        public AmeliyatTarihiService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Veritabanına yeni bir personel ekler
        public void AddAmeliyat(Ameliyat ameliyat)
        {
            _context.Ameliyatlar.Add(ameliyat);
            _context.SaveChanges();
        }

        // ID'si verilen personeli siler
        public void DeleteAmeliyat(int ameliyatId)
        {
            var ameliyat = _context.Ameliyatlar.Find(ameliyatId);
            if (ameliyat != null)
            {
                _context.Ameliyatlar.Remove(ameliyat);
                _context.SaveChanges();
            }
        }

        // Tüm personelleri listeler
        public List<Ameliyat> GetAllAmeliyat()
        {
            return _context.Ameliyatlar.ToList();
        }
    }
}
