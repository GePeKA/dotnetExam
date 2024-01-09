using Microsoft.EntityFrameworkCore;
using Models;

namespace GameLogic.DbModels
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Monster> Monsters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var archelon = new Monster
            {
                Id = 1,
                Name = "Archelon",
                HitPoints = 26,
                AttackModifier = 5,
                AttackPerRound = 1,
                Damage = "4d8",
                DamageModifier = 3,
                ArmorClass = 14
            };

            var armanit = new Monster
            {
                Id = 2,
                Name = "Armanit",
                HitPoints = 94,
                AttackModifier = 8,
                AttackPerRound = 3,
                Damage = "9d10",
                DamageModifier = 9,
                ArmorClass = 16
            };

            var demogorgon = new Monster
            {
                Id = 3,
                Name = "Demogorgon",
                HitPoints = 60,
                AttackModifier = 6,
                AttackPerRound = 2,
                Damage = "8d8",
                DamageModifier = 3,
                ArmorClass = 15
            };

            var mindFlayer = new Monster
            {
                Id = 4,
                Name = "Mind flayer",
                HitPoints = 71,
                AttackModifier = 7,
                AttackPerRound = 1,
                Damage = "13d8",
                DamageModifier = 4,
                ArmorClass = 15
            };

            modelBuilder.Entity<Monster>().HasData(archelon, armanit, demogorgon, mindFlayer);
        }
    }
}
