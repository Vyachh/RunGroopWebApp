﻿using Microsoft.AspNetCore.Mvc;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using System.Data.Entity;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var clubs = _context.Clubs.ToList();

            return View(clubs);
        }
        public IActionResult Detail(int id)
        {
            Club? club = _context.Clubs.Include(o=>o.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }
    }
}
