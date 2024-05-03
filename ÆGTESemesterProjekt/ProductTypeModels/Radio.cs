﻿using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.ProductTypeModels
{
    public class Radio : Product
    {
        public string Brand { get; set; }
        public string Dimensions { get; set; }
        public bool Bluetooth { get; set; }
        public List<Radio> Radios { get; set; }

        public Radio()
        {
        }

        public Radio(int id, string productName, int price) : base(id, productName, price)
        {
        }
    }
}
