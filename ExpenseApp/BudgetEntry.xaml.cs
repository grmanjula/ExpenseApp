using ExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetEntry : ContentPage
    {
        public BudgetEntry()
        {
            InitializeComponent();
        }

        private void SaveBudgetButton_Clicked(object sender, EventArgs e)
        {
            //var budget = (Budget)BindingContext;

            //if (string.IsNullOrWhiteSpace(budget.Filename))
            //{
            //    //create and save
            //    var filename = Path.Combine(
            //        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            //        $"{Path.GetRandomFileName()}.budget.txt");
            //    File.WriteAllText(filename, editor.Text);
            //}
            //else
            //{
            //    //Update
            //    File.WriteAllText(note.Filename, editor.Text);
            //}

            //await Navigation.PopModalAsync();
        }

        private void ModifyBudgetButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}