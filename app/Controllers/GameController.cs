using Game.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using Game.Models;

namespace Game.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Field();
            HttpContext.Session.SetObject<Field>("field", model);
            HttpContext.Session.SetInt32("turn", 1);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int x, int y)
        {
            var colorNum = HttpContext.Session.GetInt32("turn") ?? default(int);
            var piece = new Piece(x, y, colorNum);
            var model = HttpContext.Session.GetObject<Field>("field");
            model.AddPiece(piece);
            HttpContext.Session.SetObject<Field>("field",model);
            HttpContext.Session.SetInt32("turn", -1*colorNum);
            return View(model);
        }
    }
}