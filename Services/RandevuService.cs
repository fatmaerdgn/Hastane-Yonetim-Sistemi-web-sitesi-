using System;
using System.Collections.Generic;
using System.Linq;
using bitirmeMVC5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bitirmeMVC5.Services
{
    public class RandevuService
    {
        private readonly ApplicationDbContext _context;

        public RandevuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Randevular> GetAllRandevular()
        {
            try
            {
                var randevular = _context.Randevular.ToList();
                if (randevular == null || !randevular.Any())
                {
                    Console.WriteLine("No appointments found.");
                }
                else
                {
                    Console.WriteLine($"Found {randevular.Count} appointments.");
                }
                return randevular;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Randevular>();
            }
        }
    }

}
