﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Birthdays.Models;
using Birthdays.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Birthdays.ViewModels {
    [Preserve(AllMembers = true)]
    public class AdminViewModel : INotifyPropertyChanged {
        readonly IBirthdayService birthdayService;

        string name;
        DateTime birthday;
        bool showButton;

        public AdminViewModel(IBirthdayService birthdayService) {
            this.birthdayService = birthdayService;
            SaveCommand = new Command(async () => await Save(), () => !string.IsNullOrEmpty(Name));
            Today = Birthday = DateTime.Today;
            ShowButton = true;
        }

        public DateTime Today { get; }

        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        public DateTime Birthday {
            get { return birthday; }
            set {
                birthday = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        public bool ShowButton {
            get { return showButton; }
            set { showButton = value; OnPropertyChanged(); }
        }

        public Command SaveCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        async Task Save() {
            try {
                ShowButton = false;
                var newBirthday = new Birthday(Name, Birthday);
                await birthdayService.SaveBirthday(newBirthday);
                Name = "";
                Birthday = DateTime.Today;
            } catch (Exception e) {
                // TODO: Error handling
            } finally {
                ShowButton = true;
            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
