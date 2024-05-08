using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IRepairService
    {
        List<Repair> GetRepair();
        Task AddRepairAsync(Repair repair);
        void AddRepair(Repair repair);
        void UpdateRepair(Repair repair);
        Repair DeleteRepair(int? repairID);
        Repair GetRepair(int Id);
    }
}
