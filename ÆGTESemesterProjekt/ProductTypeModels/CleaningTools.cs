using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class CleaningTools : Product
    {

        public string Brand { get; set; }
        public List<CleaningTools> Tools { get; set; }

        public CleaningTools()
        {
        }

        public CleaningTools(int id, string productName, int price) : base(id, productName, price)
        {
        }
    }
}
