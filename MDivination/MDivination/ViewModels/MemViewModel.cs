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


namespace MDivination.ViewModels
{
    public class MemViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                }

        public ICommand DivinationCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public INavigation Navigation;
        public Mem Mem;
        public static Random random=new Random();
        public static int i
        {
            get => i;
            set
            {
                i = value;
            }
        }
        public static string ImagePath = $"MDivination.Images.{i}.png";
      
        public ImageSource ImageSource => ImageSource.FromResource(ImagePath);

        public string interpretation;

        public string Interpretation
        {
            get => interpretation;
            set
            {
                Stream streamInterpretation = Assembly.GetExecutingAssembly().GetManifestResourceStream($"MDivination.Interpretation.{i}.txt");
                TextReader readerInterpretation = new StreamReader(streamInterpretation);
                interpretation = readerInterpretation.ReadToEnd();
                streamInterpretation.Close();
                OnPropertyChanged(nameof(Interpretation));
            }
        }
        public string history;
        public string History
        {
            get => history;
            set
            {
                Stream streamHistory = Assembly.GetExecutingAssembly().GetManifestResourceStream($"MDivination.History.{i}.txt");
                TextReader readerHistory = new StreamReader(streamHistory);
                interpretation = readerHistory.ReadToEnd();
                streamHistory.Close();
                OnPropertyChanged(nameof(History));
            }
        }
        public MemViewModel()
        {
            Mem = new Mem();
            DivinationCommand = new Command(Divination);
            BackCommand = new Command(Back);
            HistoryCommand = new Command(ToHistory);
            
        }
      
       

        void Divination(object sender)
        {
                Navigation.PushAsync(new DivinationResult());
        }
        void Back(object sender)
        {
            Navigation.PopToRootAsync();
        }
        void ToHistory(object sender)
        {
            Navigation.PushAsync(new HistoryPage());
        }

    }
}
