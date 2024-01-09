using GameLogic.Migrations;
using Models;
using Models.DTO.Logs;

namespace GameLogic.Sevices
{
    public class Battle : IBattle
    {
        public Player Player { get; set; }
        public Monster Monster { get; set; }
        public Log Log { get; set; } = new Log();

        public List<Round> Rounds { get; set; } = new();

        private Random _random = new Random();

        public Log GetBattleResult(Player player, Monster monster)
        {
            Player = player;
            Monster = monster;
            Log.Player = player;
            Log.Monster = monster;

            var initialMonsterHp = monster.HitPoints;

            while (player.HitPoints > 0 && monster.HitPoints > 0) 
            {
                ConductRound(Player, Monster);
            }

            Log.Rounds = Rounds.ToArray();

            Log.Monster.HitPoints = initialMonsterHp;

            return Log;
        }

        private void ConductRound(Player player, Monster monster)
        {
            var round = new Round();

            var playerAttacks = new List<Attack>();
            var monsterAttacks = new List<Attack>();

            for (int i = 0; i < player.AttackPerRound; i++)
            {
                if (monster.HitPoints == 0)
                {
                    round.PlayerAttacks = playerAttacks.ToArray();
                    round.MonsterAttacks = monsterAttacks.ToArray();
                    Log.IsPlayerWinner = true;
                    Rounds.Add(round);
                    return;
                }

                var attack = ProcessAttack(player, monster, round);
                playerAttacks.Add(attack);
            }
            
            if (monster.HitPoints == 0)
            {
                round.PlayerAttacks = playerAttacks.ToArray();
                round.MonsterAttacks = monsterAttacks.ToArray();
                Log.IsPlayerWinner = true;
                Rounds.Add(round);
                return;
            }

            for (int i = 0; i < monster.AttackPerRound; i++)
            {
                if (player.HitPoints == 0) 
                {
                    round.PlayerAttacks = playerAttacks.ToArray();
                    round.MonsterAttacks = monsterAttacks.ToArray();
                    Rounds.Add(round);
                    return;
                }

                var attack = ProcessAttack(monster, player, round);
                monsterAttacks.Add(attack);
            }

            round.PlayerAttacks = playerAttacks.ToArray();
            round.MonsterAttacks = monsterAttacks.ToArray();

            Rounds.Add(round);
        }

        private Attack ProcessAttack(ICharacter active, ICharacter passive, Round round)
        {
            var attack = new Attack();

            var attackRoll = _random.Next(1, 21);

            if (attackRoll == 1 || attackRoll + active.AttackModifier < passive.ArmorClass)
            {
                attack.IsHit = false;
                attack.DiceRollOnAttack = attackRoll;

                return attack;
            }

            attack.IsHit = true;
            attack.DiceRollOnAttack = attackRoll;

            var diceCount = int.Parse(active.Damage.Split('d')[0]);
            var maxDamage = int.Parse(active.Damage.Split('d')[1]);

            attack.TotalDamage = 0;

            for (int k = 0; k < diceCount; k++) 
            {
                var damage = _random.Next(1, maxDamage + 1);
                attack.TotalDamage += damage;
            }

            var totalDamage = attackRoll == 20 ? attack.TotalDamage * 2 + active.DamageModifier
                : attack.TotalDamage + active.DamageModifier;

            passive.HitPoints = Math.Max(0, passive.HitPoints - totalDamage);
            attack.EnemyHitPoints = passive.HitPoints;

            return attack;
        }
    }
}
