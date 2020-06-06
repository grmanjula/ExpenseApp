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
           // To delete expense files

            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");
            foreach (var filename in files)
            {
                //File.Delete(filename);
            }
        }
        protected override void OnAppearing()
        {
            //return;
            var BudgetPath = Path.Combine
                (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "ExpenseBudget.txt");
            budget.Text = File.ReadAllText(BudgetPath);

            //budget.Text = File.ReadAllText(
            //  Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),ExpenseBudget.txt)
            //   ); 

            // File.ReadAllText()
            //budget.Text = $"BudgetExpense is {budget.Text}";
           // budget.Text = $"BudgetExpense is {ExpenseEntryPage.}"

            //M
          //  budget.Text = $"BudgetExpense is {Budget}";

            var expenses = new List<Expense>();

           var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");
            foreach (var filename in files)
            {
                var data = File.ReadAllText(filename);
                string[] dataSplit = data.Split('\n');

                // Do not populate the expenses when there are no records yet
                // if (dataSplit.Length <= 1)
                // return;

                // Console.WriteLine(dataSplit);

                var expense = new Expense
                {
                    // ExpenseName =
                    ExpenseName = dataSplit[0],
                    ExpenseDate = Convert.ToDateTime(dataSplit[1]),
                    Amount = Convert.ToDecimal(dataSplit[2]),
                    // Amount = dataSplit[2],
                    Category = Convert.ToString(dataSplit[3]),
                    ImageFile = GetImage(Convert.ToString(dataSplit[3])),
                };

                expenses.Add(expense);
                
            }

          //  listView.ItemsSource = notes.OrderBy(n => n.Date).ToList();
          //  listView.ItemsSource = expenses.Oder
           //listView.ItemsSource = expenses.OrderByDescending()
            listView.ItemsSource = expenses.OrderBy(e => e.ExpenseDate).ToList();
            
            ////Code to Render Image
            //Image assignImageFromFile = new Image
            //{
            //    Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("Education.png") : ImageSource.FromFile("Rent.jpg"),
                
            //};

        }

        private string GetImage(string category)
        {
            string imagePath = string.Empty;
            // if category is education, associate education.gif to image
            if (string.Compare(category, "Rent", true) == 0)
            {
                imagePath = "Rent.png";
            }
          if (string.Compare(category, "Food", true) == 0)
            {                             
                    imagePath = "Food.png";
            }
          if (string.Compare(category, "Insurance", true) == 0)
            {
              
                    imagePath = "Insurance.png";
             
            }
            if (string.Compare(category, "Education", true) == 0)
            {

                imagePath = "Education.png";

            }

            //if (string.Compare(category, "Miscellaneous", true) == 0)
            if (string.Compare(category, "Miscellaneous", true) == 0)
            {
         
                    imagePath = "Miscelleneous.png";
               
            }

            return imagePath;
        }

        private async void OnSaveBudgetButtonClicked(object sender, EventArgs e)
        {
            var expenseBudgetPath = Path.Combine
                (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "ExpenseBudget.txt");
            File.WriteAllText(expenseBudgetPath, budget.Text);

            await Navigation.PushModalAsync(new ExpenseEntryPage
            {
                Budget = budget.Text
            });
        }


        private void OnDeleteBudgetButtonClicked(object sender, EventArgs e)
        {

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
