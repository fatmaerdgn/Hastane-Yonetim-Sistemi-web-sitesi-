using System;
using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public void AddAbone(Aboneler MailAdresi)
        {
            _context.Aboneler.Add(MailAdresi);
            _context.SaveChanges();
        }
    }
}
