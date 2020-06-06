using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApp.Models
{
    public class Expense : Object
    {
        public string FileName { get; set; }
        public string  Text { get; set; }
        public string ExpenseName { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string ImageFile { get; set; }
        public string Category { get; set; }
       
    }
}