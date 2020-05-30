using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApp.Models
{
    public class Expense
    {
        public string FileName { get; set; }
        public string Text { get; set; }
        public string ExpenseName { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public enum Category { Food, Rent, Insurance, Education, Miscellanous }

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