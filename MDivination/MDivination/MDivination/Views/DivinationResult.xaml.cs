using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MDivination.ViewModels;
using System.Security.Cryptography.X509Certificates;
using MDivination.Models;

namespace MDivination.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DivinationResult : ContentPage
    {
       public static Random Random = new Random();
        public static int i;

        public DivinationResult()
        {
            InitializeComponent();

            BindingContext = new MemViewModel();
        }

           


       protected override void OnAppearing()
        {
            base.OnAppearing();
            i = Random.Next(0, 3);
        }

    }
}
