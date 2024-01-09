using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Models.DTO.Logs;
using System;
using System.Diagnostics;
using System.Net.Http;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private string _dbUrl = "https://localhost:7067/game/getrandommonster";
        private string _gameLogicUrl = "https://localhost:7067/game/startbattle";

        public HomeController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UIModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(new UIModel() { Player = player });
            }

            var client = new HttpClient();

            var monster = await client.GetFromJsonAsync<Monster>(_dbUrl);

            var participants = new BattleParticipants() { Player = player, Monster = monster };

            var battleResult = await client.PostAsJsonAsync(_gameLogicUrl, participants);

            var battleLog = await battleResult.Content.ReadFromJsonAsync<Log>();

            var UIModel = new UIModel() { Player = battleLog.Player, Monster = battleLog.Monster, Log = battleLog };

            return View(UIModel);
        }

        public async Task<IActionResult> GetResult()
        {
            var player = new Player()
            {
                Name = "Me",
                ArmorClass = 10,
                AttackModifier = 5,
                AttackPerRound = 1,
                Damage = "4d10",
                DamageModifier = 4,
                HitPoints = 150
            };

            var url = "https://localhost:7067/game/getrandommonster";
            
            var httpClient = new HttpClient();
            var monster = await httpClient.GetFromJsonAsync<Monster>(url);

            var participants = new BattleParticipants() { Player = player, Monster = monster };

            url = "https://localhost:7067/game/startbattle";
            var battleResult = await httpClient.PostAsJsonAsync(url, participants);

            Console.WriteLine(await battleResult.Content.ReadAsStringAsync());

            return Content(await battleResult.Content.ReadAsStringAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
