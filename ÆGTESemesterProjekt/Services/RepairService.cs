using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class RepairService : IRepairService
    {
        private JsonFileService<Repair> JsonFileRepairService;
        private List<Repair> _repairs;
        private DbGenericService<Repair> _genericDbService;
        //private DbService _dbService;
        //private DbGenericService<Repair> _dbService;

        public RepairService(JsonFileService<Repair> jsonFileRepairService, DbGenericService<Repair> genericDbService)
        {
            JsonFileRepairService = jsonFileRepairService;
            _genericDbService = genericDbService;
            //_dbService = dbService;
            //_repairs = MockRepairs.GetMockRepairs();
            _repairs = JsonFileRepairService.GetJsonObjects().ToList();
            JsonFileRepairService.SaveJsonObjects(_repairs);
            //_repairs = _genericDbService.GetObjectsAsync().Result.ToList();
            _genericDbService.SaveObjects(_repairs);
        }

        public RepairService()
        {

        }

        public async Task AddRepairAsync(Repair repair)
        {
            _repairs.Add(repair);
            JsonFileRepairService.SaveJsonObjects(_repairs);
            await _genericDbService.AddObjectAsync(repair);
        }
        public List<Repair> GetRepair() { return _repairs; }
        public void AddRepair(Repair repair)
        {
            _repairs.Add(repair);
            JsonFileRepairService.SaveJsonObjects(_repairs);
            _genericDbService.SaveObjects(_repairs);
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
                        r.RepPrice = repair.RepPrice;
                        r.RepairStatus = repair.RepairStatus;
                        r.EstDate = repair.EstDate;
                       
                    }
                }
                JsonFileRepairService.SaveJsonObjects(_repairs);
                _genericDbService.SaveObjects(_repairs);
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
                    _genericDbService.SaveObjects(_repairs);
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

