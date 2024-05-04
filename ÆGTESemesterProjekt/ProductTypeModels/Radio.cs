using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class Radio : Product
    {
        public string Brand { get; set; }
        public string Dimensions { get; set; }
        public bool Bluetooth { get; set; }
        public List<Radio> Radios { get; set; }

        public Radio()
        {
        }

        public Radio(string brand, string dimensions, bool bluetooth, List<Radio> radios, int id, string productName, int price) : base(id, productName, price)
        {
            Brand = brand;
            Dimensions = dimensions;
            Bluetooth = bluetooth;
            Radios = radios;
            
        }

    }
}
