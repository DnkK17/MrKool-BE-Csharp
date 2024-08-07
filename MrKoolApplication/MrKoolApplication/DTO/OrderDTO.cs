﻿using MrKool.Models;
using MrKoolApplication.Enum;

namespace MrKoolApplication.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public int RequestID { get; set; }

        public int? CustomerID { get; set; }

        public ICollection<OrderDetailDTO>? OrderDetailList { get; set; }
    }
}
