using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        //Propriedades
        string displayMessage = string.Empty;
        string name = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ShowMessageCommand { get; }
        public string DisplayName => $"Nome digitado : {Name}";

        //Construtor
        public MainPageViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
        }

        //Getters e Setters
        public string Name
        {
            get => name;
            set
            {
                if (name == null)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayMessage
        {
            get => displayMessage;
            set
            {
                if (displayMessage == null)
                    return;
                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }
        //Métodos
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
        public void ShowMessage()
        {
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();
            DisplayMessage = $"Boa noite {Name}. Hoje é {dataProperty}.";
        }
    }
}

    

