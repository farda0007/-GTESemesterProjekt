using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class Speaker : Product
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Dimensions { get; set; }
        public List<Speaker> Speakers { get; set; }
        public string SpeakerType { get; set; }

        public Speaker()
        {
        }

        public Speaker(int id, string productName, int price) : base(id, productName, price)
        {
        }
    }
}
