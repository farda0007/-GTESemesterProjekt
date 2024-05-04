using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class Headset : Product
    {
        public string Brand { get; set; }
        public bool Wireless { get; set; }
        public List<Headset> Headsets { get; set; }
        public Headset()
        {
        }

        public Headset(string brand, bool wireless, List<Headset> headsets, int id, string productName, int price) : base(id, productName, price)
        {
            Brand = brand;
            Wireless = wireless;
            Headsets = headsets;
        }
    }
}
