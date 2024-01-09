using Models;
using Models.DTO.Logs;

namespace UI.Models
{
    public class UIModel
    {
        public Player Player { get; set; } = new();
        public Monster? Monster { get; set; }

        public Log? Log { get; set; }
    }
}
