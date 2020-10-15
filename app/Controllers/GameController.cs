using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index(int x, int y)
        {
            var piece = new Piece(x, y, -1);
            var model = new Field();
            model.addPiece(piece);
            return View(model);
        }
    }
}