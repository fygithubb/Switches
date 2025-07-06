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


        [HttpPost]
        public JsonResult AjaxPress(int id)
        {
            _game.PressSwitch(id);

            return Json(new
            {
                state = _game.GetStateString(),
                moves = _game.MoveCount,
                maxMoves = _game.MaxMoves,
                isComplete = _game.IsComplete,
                gameOver = _game.OutOfMoves
            });
        }



        [HttpPost]
        public JsonResult AjaxReset()
        {
            _game.Reset();

            return Json(new
            {
                state = _game.GetStateString(),
                moves = _game.MoveCount,
                maxMoves = _game.MaxMoves,
                isComplete = _game.IsComplete,
                gameOver = _game.OutOfMoves
            });
        }

    }
}



