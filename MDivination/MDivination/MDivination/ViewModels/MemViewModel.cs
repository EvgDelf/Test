using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using MDivination.Models;
using Xamarin.Forms;
using MDivination.Views;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MDivination.ViewModels
{
    public class MemViewModel
    {


        public ICommand BackCommand { get; set; }
        public ICommand DivinationCommand { get; set; }

        public INavigation Navigation;

        public Mem Mem;

        
        public string ImagePath = $"MDivination.Images.{DivinationResult.i}.png";
        public ImageSource ImageSource
        {
            get
            {
                return ImageSource.FromResource(ImagePath);
            }
        }
        public string Interpretation
        {
            get
            {
                Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(MemViewModel)).Assembly;
                Stream streamInterpretation = assembly.GetManifestResourceStream($"MDivination.Interpretation.{DivinationResult.i}.txt");
                string text = "";
                using (var reader = new StreamReader(streamInterpretation))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
        }

        public MemViewModel()
        {
            
            Mem = new Mem();
            DivinationCommand = new Command(DivinationAsync);
            BackCommand = new Command(Back);
            
        }
        public void DivinationAsync()
        {
             
            Navigation.PushAsync(new DivinationResult());
        }
        void Back()
        {
            Navigation.PopToRootAsync();
        }
    }
}
