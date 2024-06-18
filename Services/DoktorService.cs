using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bitirmeMVC5.Services
{
   
    public class DoktorService
    {
        private readonly ApplicationDbContext _context;

        

        public DoktorService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Veritabanına yeni bir doktor ekler
        public void AddDoktor(Doktor doktor)
        {
            _context.Doktorlar.Add(doktor);
            _context.SaveChanges();
        }

        // ID'si verilen doktoru siler
        public void DeleteDoktor(int doktorId)
        {
            var doktor = _context.Doktorlar.Find(doktorId);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
                _context.SaveChanges();
            }
        }

        // Tüm doktorları listeler
        public List<Doktor> GetAllDoktorlar()
        {
            return _context.Doktorlar.ToList();
        }

        // ID'si verilen doktoru getirir
        public Doktor GetDoktorById(int doktorId)
        {
            return _context.Doktorlar.Find(doktorId);
        }

        // Doktor günceller
        public void UpdateDoktor(Doktor doktor)
        {
            _context.Doktorlar.Update(doktor);
            _context.SaveChanges();
        }

        // Doktor giriş bilgilerini doğrular
        public Doktor ValidateDoktor(string email, string password)
        {
            var doktor = _context.Doktorlar.FirstOrDefault(d => d.Eposta == email && d.Parola == password);
            return doktor; // Eğer doktor varsa, doktor nesnesini döndür, yoksa null döner
        }

        public List<Doktor> GetDoktorlarByPoliklinikId(int poliklinikId)
        {
            return _context.Doktorlar.Where(d => d.PoliklinikID == poliklinikId).ToList();
        }
    }
}
