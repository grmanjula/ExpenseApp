using ExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            /*var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");
            foreach (var filename in files)
            {
                File.Delete(filename);
            }*/
        }
        protected override void OnAppearing()
        {
            //return;

            //Budget.Text = $"BudgetExpense is {Budget}";
            //M
          //  budget.Text = $"BudgetExpense is {Budget}";

            var expenses = new List<Expense>();

           var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");
            foreach (var filename in files)
            {
                var data = File.ReadAllText(filename);
                string[] dataSplit = data.Split('\n');

                // Do not populate the expenses when there are no records yet
                if (dataSplit.Length <= 1)
                    return;

               // Console.WriteLine(dataSplit);


                var expense = new Expense
                {
                   // ExpenseName =
                    ExpenseName = dataSplit[0],
                    ExpenseDate = Convert.ToDateTime(dataSplit[1]),
                   Amount = Convert.ToDecimal(dataSplit[2]),
                   // Amount = dataSplit[2],
                    Category = Convert.ToString(dataSplit[3]),
                   
                };

                expenses.Add(expense);
                
            }

            listView.ItemsSource = expenses;
           // listView.ItemsSource = expenses.OrderBy(e => e.ExpenseDate).ToList();
        }
        
            
        
        private async void AddMoreExpensesButton_Clicked(object sender, EventArgs e)
        {
            //var expensePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
            //   LocalApplicationData),
            //   $"{Path.GetRandomFileName()}.expenses.txt");
            await Navigation.PushModalAsync(new ExpenseEntryPage
            {
                BindingContext = new Expense()
            });


            //var expenses = new Expenses
            //{


            //    Name = nameLabel.Text,
            //    Amount = Convert.ToDecimal(amountLabel.Text),
            //    DateOfPurchase = SelectedDate,
            //    Category = pickerCategory.SelectedItem.ToString()

            //};

            // File.WriteAllText(expensePath, expenses.toString());
        }

        private  async void OnExpenseAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseEntryPage
            {
                BindingContext = new Expense()
            });
        }

        private async void OnlistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new ExpenseEntryPage
                {
                    BindingContext = (Expense)e.SelectedItem
                });
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
