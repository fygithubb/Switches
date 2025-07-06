using Microsoft.AspNetCore.Mvc;
using Switches.Services;
using System.Text.Json;

namespace Switches.Controllers
{
    public class GameController : Controller
    {
        private const string SessionKey = "GameState";

        // Helper: Get game from session
        private SwitchGameService GetGame()
        {
            var json = HttpContext.Session.GetString(SessionKey);
            if (string.IsNullOrEmpty(json))
            {
                var newGame = new SwitchGameService();
                SaveGame(newGame);
                return newGame;
            }

            var game = JsonSerializer.Deserialize<SwitchGameService>(json)!;

            game.toggleMasks = new int[]
            {
                0b110,   // A affects A & B
                0b011,   // B affects B & C
                0b001    // C affects C
            };

            return game;
        }

        // Helper: Save game to session
        private void SaveGame(SwitchGameService game)
        {
            var json = JsonSerializer.Serialize(game);
            HttpContext.Session.SetString(SessionKey, json);
        }

        // GET: /Game
        public IActionResult Index()
        {
            var game = GetGame();
            return View(game);
        }

        // POST: /Game/Press
        [HttpPost]
        public IActionResult Press(int id)
        {
            var game = GetGame();
            game.PressSwitch(id);
            SaveGame(game);
            return RedirectToAction("Index");
        }

        // POST: /Game/Reset
        [HttpPost]
        public IActionResult Reset()
        {
            var game = new SwitchGameService();
            SaveGame(game);
            return RedirectToAction("Index");
        }

        // POST: /Game/AjaxPress
        [HttpPost]
        public JsonResult AjaxPress(int id)
        {
            var game = GetGame();
            game.PressSwitch(id);
            SaveGame(game);

            return Json(new
            {
                state = game.GetStateString(),
                moves = game.MoveCount,
                maxMoves = game.MaxMoves,
                isComplete = game.IsComplete,
                gameOver = game.OutOfMoves
            });
        }

        // POST: /Game/AjaxReset
        [HttpPost]
        public JsonResult AjaxReset()
        {
            var game = new SwitchGameService();
            SaveGame(game);

            return Json(new
            {
                state = game.GetStateString(),
                moves = game.MoveCount,
                maxMoves = game.MaxMoves,
                isComplete = game.IsComplete,
                gameOver = game.OutOfMoves
            });
        }
    }
}
