﻿using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class RepairService : IRepairService
    {
        private List<Repair> _repairs;
        private DbGenericService<Repair> _genericDbService;

        public RepairService(DbGenericService<Repair> genericDbService)
        {
            _genericDbService = genericDbService;
            _repairs = _genericDbService.GetObjectsAsync().Result.ToList();
            _genericDbService.SaveObjects(_repairs);
        }

        public RepairService()
        {

        }

        public async Task AddRepairAsync(Repair repair)
        {
            _repairs.Add(repair);
            await _genericDbService.AddObjectAsync(repair);
        }
        public List<Repair> GetRepair() { return _repairs; }
        public void AddRepair(Repair repair)
        {
            _repairs.Add(repair);
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
                _genericDbService.SaveObjects(_repairs);
            }
        }

        public async Task<Repair> DeleteRepairAsync(int? repairId)
        {
            var repairItem = _repairs.FirstOrDefault(c => c.CaseId == repairId);
            if (repairItem != null)
            {
                _repairs.Remove(repairItem);
                await _genericDbService.DeleteObjectAsync(repairItem);
            }

            return repairItem;
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

