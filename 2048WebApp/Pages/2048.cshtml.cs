using _2048WebApp.Models;
using _2048WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2048WebApp.Pages
{
    public class _2048Model : PageModel
    {
        public int[][] board = new int[4][];
        public Moves availableMoves;
        public int maxTile;
        public void OnGet()
        {
            board = _2048GameService.Board;
            availableMoves = _2048GameService.CheckMoves(board);
            maxTile = _2048GameService.MaxTile;
        }
        public IActionResult OnPostNew()
        {
            _2048GameService.NewBoard();
            return RedirectToAction("Get");
        }
        public IActionResult OnPostMove(int playerMove)
        {
            _2048GameService.PostMove(playerMove);
            return RedirectToAction("Get");
        }
    }
}
