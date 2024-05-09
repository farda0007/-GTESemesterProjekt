using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class RepairService : IRepairService
    {
        private JsonFileService<Repair> JsonFileRepairService;
        private List<Repair> _repairs;
        //private DbService _dbService;
        //private DbGenericService<Repair> _dbService;

        public RepairService(JsonFileService<Repair> jsonFileRepairService)
        {
            JsonFileRepairService = jsonFileRepairService;
            //_dbService = dbService;
            _repairs = MockRepairs.GetMockRepairs();
            //_repairs = JsonFileRepairService.GetJsonObjects().ToList();
            JsonFileRepairService.SaveJsonObjects(_repairs);
            //_dbService.SaveObjects(_repairs);
            //_products = _dbService.GetObjectsAsync().Result.ToList();
        }

        public RepairService()
        {

        }

        public async Task AddRepairAsync(Repair repair)
        {
            _repairs.Add(repair);

            //await _dbService.AddObjectAsync(product);
        }
        public List<Repair> GetRepair() { return _repairs; }
        public void AddRepair(Repair repair)
        {
            _repairs.Add(repair);
            JsonFileRepairService.SaveJsonObjects(_repairs);
            //_dbService.SaveObjects(_repairs);
        }
        public List<Repair> GetRepairs()
        {
            return _repairs;
        }
        public void UpdateRepair(Repair repair)
        {
            if (repair != null)
            {
                foreach (Repair r in _repairs)
                {
                    if (r.CaseId == repair.CaseId)
                    {
                        r.SubDate = repair.SubDate;
                        r.Description = repair.Description;
                        r.RepProduct = repair.RepProduct;
                        r.Image = repair.Image;
                       
                    }
                }
                JsonFileRepairService.SaveJsonObjects(_repairs);
            }
    }
        public Repair DeleteRepair(int? repairId)
        {
            foreach (Repair repair in _repairs)
            {
                if (repair.CaseId == repairId)
                {
                    _repairs.Remove(repair);
                    JsonFileRepairService.SaveJsonObjects(_repairs);
                    return repair;
                }
            }
            return null;
        }
        public Repair GetRepair(int Id)
        {
            foreach (Repair repair in _repairs)
            {
                if (Id == repair.CaseId)
                {
                    return repair;
                }
            }
            return null;
        }
    }



}

