using System;
using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;

namespace bitirmeMVC5.Services
{
    public class PersonelService
    {
        private readonly ApplicationDbContext _context;

        public PersonelService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Veritabanına yeni bir personel ekler
        public void AddPersonel(Personel personel)
        {
            _context.Personeller.Add(personel);
            _context.SaveChanges();
        }

        // ID'si verilen personeli siler
        public void DeletePersonel(int personelId)
        {
            var personel = _context.Personeller.Find(personelId);
            if (personel != null)
            {
                _context.Personeller.Remove(personel);
                _context.SaveChanges();
            }
        }

        // Tüm personelleri listeler
        public List<Personel> GetAllPersoneller()
        {
            return _context.Personeller.ToList();
        }

        // Personel giriş bilgilerini doğrular
        public bool ValidatePersonel(string email, string password)
        {
            var personel = _context.Personeller.FirstOrDefault(p => p.Eposta == email && p.Parola == password);
            return personel != null;
        }
    }
}
