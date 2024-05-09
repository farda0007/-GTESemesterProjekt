using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.MockData
{
	public class MockRepairs
	{
		private static List<Repair> _repairs = new List<Repair>()
		{
			new Repair(1, DateTime.Today.AddHours(-1), "Fejl", (new Product()), "repair1.jpg", Repair.Status.Pending, 1200, DateTime.Today.AddMonths(2)),
			new Repair(1, DateTime.Today.AddHours(-5), "Hele lortet knækket på midten", (new Product()), "repair2.jpg", Repair.Status.InProgress, 1200, DateTime.Today.AddYears(5)),

		};
		public static List<Repair> GetMockRepairs()
		{
			return _repairs;
		}
	}
}
