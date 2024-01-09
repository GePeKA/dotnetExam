using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Monster: ICharacter
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int HitPoints { get; set; }
        [Required] public int AttackModifier { get; set; }
        [Required] public int AttackPerRound { get; set; }
        [Required] public string Damage { get; set; }
        [Required] public int DamageModifier { get; set; }
        [Required] public int ArmorClass { get; set; }
    }
}
