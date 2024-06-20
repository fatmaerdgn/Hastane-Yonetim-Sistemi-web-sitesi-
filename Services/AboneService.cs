using System;
using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;
using Microsoft.EntityFrameworkCore;

namespace bitirmeMVC5.Services
{
    public class AboneService
    {
        private readonly ApplicationDbContext _context;

        public AboneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAbone(Aboneler abone)
        {
            _context.Aboneler.Add(abone); // Abone nesnesini veritabanına ekler
            _context.SaveChanges(); // Değişiklikleri kaydeder
        }
    }
}