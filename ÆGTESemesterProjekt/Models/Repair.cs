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

		public Repair()
		{
		}

		public Repair(int caseId, DateTime subDate, string description, Product repProduct, string image, status repStatus, double repPrice, DateTime estDate)
		{
			CaseId = caseId;
			SubDate = subDate;
			Description = description;
			RepProduct = repProduct;
			Image = image;
			RepPrice = repPrice;
			EstDate = estDate;
		}
	}
}
