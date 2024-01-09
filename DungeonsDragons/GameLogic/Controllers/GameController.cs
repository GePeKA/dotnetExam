using GameLogic.DbModels;
using GameLogic.Models;
using GameLogic.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System.Diagnostics;
using System.Text.Json;

namespace GameLogic.Controllers
{
    public class GameController : Controller
    {
        private ApplicationContext _dbContext;
        private IBattle _battleHandler;

        public GameController(ApplicationContext dbContext, IBattle battleHandler)
        {
            _dbContext = dbContext;
            _battleHandler = battleHandler;
        }

        [HttpGet]
        public async Task<JsonResult> GetRandomMonster()
        {
            var randomMonster = await _dbContext.GetRandomMonster();

            return Json(randomMonster);
        }

        [HttpPost]
        public IActionResult StartBattle([FromBody] BattleParticipants participants)
        {
            var battleLog = _battleHandler.GetBattleResult(participants.Player, participants.Monster);
            
            return Json(battleLog);
        }
    }
}
