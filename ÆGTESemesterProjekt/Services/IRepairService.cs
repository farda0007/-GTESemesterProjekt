using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IRepairService
    {
        List<Repair> GetRepairs();
        Task AddRepairAsync(Repair repair);
        void AddRepair(Repair repair);
        void UpdateRepair(Repair repair);
        Task<Repair> DeleteRepairAsync(int? repairID);
        Repair GetRepair(int Id);
    }
}
