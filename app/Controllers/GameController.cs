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
            saveField(model);
            saveTurn(1);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int row, int col)
        {
            var colorNum = loadTurn();
            var model = loadField();
            model.AddPiece(row, col, colorNum);
            saveField(model);
            saveTurn(colorNum*-1);
            return View(model);
        }

        private void saveField(Field field)=>HttpContext.Session.SetObject<Field>("field", field);
        private void saveTurn(int turn)=>HttpContext.Session.SetInt32("turn", turn);
        private Field loadField()=>HttpContext.Session.GetObject<Field>("field");
        private int loadTurn()=>HttpContext.Session.GetInt32("turn") ?? default(int);
    }
}