﻿using Juan_fronttoback.DAL;
using Juan_fronttoback.Models;
using Juan_fronttoback.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_fronttoback.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db { get; }
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM
            {
                Sliders = _db.Sliders.ToList(),
                Features = _db.Features.ToList(),
                Products=_db.Products.Where(c=>!c.IsDeleted).Include(p=>p.Images).Take(12).ToList(),
                Categories=_db.Categories.Where(c=>!c.IsDeleted).ToList(),
                ProductCategories=_db.ProductCategories.ToList(),
                ProductImages=_db.ProductImages.ToList(),
                Colors=_db.Colors.ToList(),
                ProductColors=_db.ProductColors.ToList()
            };
                return View(home);
        }
    }
}
