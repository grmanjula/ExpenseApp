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
        public string Budget { get; set; }
        public DateTime SelectedDate { get; set; }
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

            var picker = expenseeditorDate as DatePicker;
            StringBuilder text = new StringBuilder();
            text.Append(expenseeditorName.Text + System.Environment.NewLine);
            text.Append(picker.Date.ToString() + System.Environment.NewLine);
            text.Append((expenseeditorAmount).Text.ToString() + System.Environment.NewLine);
            text.Append((CategoryPicker).SelectedItem.ToString() + System.Environment.NewLine);
            File.WriteAllText(filename, text.ToString());
            await Navigation.PopModalAsync();

        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void expenseeditorDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;
        }
    }
}