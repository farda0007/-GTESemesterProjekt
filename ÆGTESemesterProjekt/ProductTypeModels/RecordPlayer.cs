using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class RecordPlayer : Product
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public List<RecordPlayer> recordPlayers { get; set; }

        public RecordPlayer()
        {
        }

        public RecordPlayer(string brand, string type, string color, List<RecordPlayer> recordPlayers, int id, string productName, int price) : base(id, productName, price)
        {
            Brand = brand;
            Type = type;
            Color = color;
            this.recordPlayers = recordPlayers;
        }
    }
}
