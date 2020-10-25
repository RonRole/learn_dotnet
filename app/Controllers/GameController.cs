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
        void saveField(FieldRepository repository)=>HttpContext.Session.SetObject<FieldRepository>("field", repository);
        void saveTurn(int turn)=>HttpContext.Session.SetInt32("turn", turn);
        FieldRepository loadField()=>HttpContext.Session.GetObject<FieldRepository>("field");
        int loadTurn()=>HttpContext.Session.GetInt32("turn") ?? default(int);

        [HttpGet]
        public IActionResult Index()
        {
            var model = Field.Initialize().ToRepository();
            saveField(model);
            saveTurn(1);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int row, int col)
        {
            var colorNum = this.loadTurn();
            var repository = this.loadField();
            var field = Field.LoadRepository(repository);
            field.AddPiece(row, col, colorNum);
            var model = field.ToRepository();
            saveField(model);
            saveTurn(colorNum*-1);
            return View(model);
        }
    }
}