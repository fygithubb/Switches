using Microsoft.AspNetCore.Mvc;
using Switches.Services;

namespace Switches.Controllers
{
    public class GameController : Controller
    {
        private static SwitchGameService _game = new SwitchGameService();

        // GET: /Game
        public IActionResult Index()
        {
            return View(_game);
        }

        // POST: /Game/Press
        [HttpPost]
        public IActionResult Press(int id)
        {
            _game.PressSwitch(id);
            return RedirectToAction("Index");
        }

        // POST: /Game/Reset
        [HttpPost]
        public IActionResult Reset()
        {
            _game.Reset();
            return RedirectToAction("Index");
        }
    }
}



