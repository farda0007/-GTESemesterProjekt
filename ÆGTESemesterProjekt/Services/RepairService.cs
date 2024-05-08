using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class RepairService : IProductService
    {
        private JsonFileService<Repair> JsonFileRepairService;
        private List<Repair> _repairs;
        //private DbService _dbService;
        private DbGenericService<Repair> _dbService;

        public RepairService(JsonFileService<Repair> jsonFileRepairService, DbGenericService<Repair> dbService)
        {
            JsonFileRepairService = jsonFileRepairService;
            _dbService = dbService;
            //_products = MockProducts.GetMockProducts();
            _repairs = JsonFileRepairService.GetJsonObjects().ToList();
            //JsonFileProductService.SaveJsonObjects(_products);
            _dbService.SaveObjects(_repairs);
            //_products = _dbService.GetObjectsAsync().Result.ToList();
        }

        public RepairService()
        {

        }





    }
}
