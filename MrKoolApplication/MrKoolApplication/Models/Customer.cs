﻿using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Telephone { get; set; }
        public string CustomerName { get; set; }
        public bool Gender { get; set; }


        // Relationship
        public User user { get; set; }
        public Area Area { get; set; }

        public virtual ICollection<Order> OrderList { get; set; }
        public virtual ICollection<FixHistory> FixHistoryList { get; set; }
        public virtual ICollection<Request> RequestList { get; set; }
    }
}
