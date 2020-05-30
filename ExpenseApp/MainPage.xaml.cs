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
        }

        protected override void OnAppearing()
        { 
            var expenses = new List<Expense>();

           var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");
            foreach (var filename in files)
            {
                var expense = new Expense
                {
                    Text = File.ReadAllText(filename),
                    FileName = filename,
                   // ExpenseDate = File.GetCreationTime(filename)
                    //M
                    Date = File.GetCreationTime(filename)
                };
                expenses.Add(expense);
            }
           // listView.ItemsSource = expenses.OrderBy(e => e.ExpenseDate).ToList();
            //M
            listView.ItemsSource = expenses.OrderBy(e => e.Date).ToList();
        }

        private void AddMoreExpensesButton_Clicked(object sender, EventArgs e)
        {

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
