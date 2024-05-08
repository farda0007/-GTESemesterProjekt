namespace ÆGTESemesterProjekt.Models
{
	public class Repair
	{
        public int CaseId { get; set; }
        public DateTime SubDate { get; set; }
        public string Description { get; set; }
        public Product RepProduct { get; set; }
        public string Image { get; set; }
        public enum status 
        {
            Pending,
            Finished, 
            InProgress
        }
        public double RepPrice { get; set; }
        public DateTime EstDate { get; set; }

    }
}
