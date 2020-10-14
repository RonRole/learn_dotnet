using Amidakuji.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Amidakuji.Controllers
{
    public class KujiController : Controller
    {
        public IActionResult Index()
        {
            var model = new KujiModel();
            model.Title = "スーパー澤井あみだくじ";
            model.NumberOfKuji = 5;
            model.Result = new List<ResultModel>()
            {
                new ResultModel("sawai"),
                new ResultModel("さわい"),
                new ResultModel("澤井"),
                new ResultModel("サワイ")
            };
            return View(model);
        }
    }
}