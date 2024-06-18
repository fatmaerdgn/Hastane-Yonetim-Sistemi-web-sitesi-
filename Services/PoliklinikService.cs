using System;
using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bitirmeMVC5.Services
{
    public class PoliklinikService
    {
        private readonly ApplicationDbContext _context;

        public PoliklinikService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Veritabanına yeni bir poliklinik ekler
        public void AddPoliklinik(string poliklinikAdi)
        {
            var poliklinik = new Poliklinik
            {
                PoliklinikAdi = poliklinikAdi
            };
            _context.Poliklinikler.Add(poliklinik);
            _context.SaveChanges();
        }

        // ID'si verilen polikliniği siler
        public void DeletePoliklinik(int poliklinikId)
        {
            var poliklinik = _context.Poliklinikler.Find(poliklinikId);
            if (poliklinik != null)
            {
                _context.Poliklinikler.Remove(poliklinik);
                _context.SaveChanges();
            }
        }

        // Tüm poliklinikleri listeler
        public List<Poliklinik> GetAllPoliklinikler()
        {
            return _context.Poliklinikler.ToList();
        }

        public async Task<List<Poliklinik>> GetAllPolikliniklerAsync()
        {
            return await _context.Poliklinikler.ToListAsync();
        }
        public Poliklinik GetPoliklinikById(int poliklinikId)
        {
            return _context.Poliklinikler.FirstOrDefault(p => p.ID == poliklinikId);
        }
    }
}
