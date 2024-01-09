using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models
{
    public class Player: ICharacter
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Максимальная длина имени 30")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 300, ErrorMessage = "Введите число от 0 до 300")]
        [DisplayName("Hit points")]
        public int HitPoints { get; set; }

        [Required]
        [Range(-10, 10, ErrorMessage = "Введите число от -10 до 10")]
        [DisplayName("Attack modifier")]
        public int AttackModifier { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Введите число от 1 до 5")]
        [DisplayName("Attacks per round")]
        public int AttackPerRound { get; set; }

        [Required]
        [RegularExpression(@"\d+d\d+", ErrorMessage = "Неправильный формат. Пример правильного ввода: 2d6")]
        [DisplayName("Damage")]
        public string Damage { get; set; }

        [Required]
        [Range(-5, 5, ErrorMessage = "Введите число от -10 до 10")]
        [DisplayName("Damage modifier")]
        public int DamageModifier { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Введите число от 0 до 100")]
        [DisplayName("Armor class")]
        public int ArmorClass { get; set; }
    }
}
