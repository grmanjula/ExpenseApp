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
        //public enum Category { Food, Rent, Insurance, Education, Miscellanous }

        public string toString()
        {
            return $"{ExpenseName}\n{ExpenseDate}\n{Amount}\n{Category}";          
        }
        //public enum CategoryPicker
        //{
        //    Home,
        //    Entertainment,
        //    Food,
        //    Charity,
        //    Utilities,
        //    Auto,
        //    Education,
        //    HelathAndWellness,
        //    Miscellaneous
        //};

       
        //M
        //public Expense(string text, string filename,DateTime expensedate)
        //{
        //    Text = text;
        //    FileName = filename;
        //    ExpenseDate = expensedate;

        //}

        ////M
        //public Expense()
        //{

        //}
    }
}