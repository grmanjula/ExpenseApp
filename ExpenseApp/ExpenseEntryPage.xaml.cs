using ExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseEntryPage : ContentPage
    {
        public ExpenseEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
           var expense = (Expense)BindingContext;

            var filename = Path.Combine(
                  Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                  $"{Path.GetRandomFileName()}.expenses.txt");
            // File.WriteAllText(filename, expenseeditorName.Text, expenseeditorDate, expenseeditorAmount, SelectExpenseCategoryIcon);
            File.WriteAllText(filename, expenseeditorName.Text);
            //update
            // File.WriteAllText(expense.FileName, expenseeditorName.Text, expenseeditorAmount.);


            await Navigation.PopModalAsync();

        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            //var expense = (Expense)BindingContext;
            //if(File.Exists(expense.FileName))
            //{
            //    File.Delete(expense.FileName);
            //}
            // expenseeditorName.Text = string.Empty;
            await Navigation.PopModalAsync();

        }
    }
}