using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class Vinyl : Product
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Condition { get; set; }
        public string Label { get; set; }
        public enum Size { small = 8, medium = 12, large = 16 }
        public int Year { get; set; }
        public List<Vinyl> Vinyls { get; set; }

        public Vinyl()
        {
        }

        public Vinyl(int id, string productName, int price) : base(id, productName, price)
        {
        }
    }
}
