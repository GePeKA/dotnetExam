using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ICharacter
    {
        public string Name { get; set; }

        public int HitPoints { get; set; }

        public int AttackModifier { get; set; }

        public int AttackPerRound { get; set; }

        public string Damage { get; set; }

        public int DamageModifier { get; set; }

        public int ArmorClass { get; set; }
    }
}
