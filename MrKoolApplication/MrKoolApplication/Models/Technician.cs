﻿using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Technician
    {
        public int TechnicianID { get; set; }
        public string Telephone { get; set; }
        public string Status { get; set; }
        public string TechnicianName { get; set; }
        // Relationships
        public User user { get; set; }
        public Manager Manager { get; set; }

        public Station Station { get; set; }

        public Wallet Wallet { get; set; }

        public ICollection<Request> RequestList { get; set; }
        public ICollection<OrderDetail> OrderDetailList { get; set; }
        public ICollection<FixHistory> FixHistoryList { get; set; }
    }
}
