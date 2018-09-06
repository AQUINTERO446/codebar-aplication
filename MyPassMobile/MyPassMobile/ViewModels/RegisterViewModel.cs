using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyPassMobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Attributes
        private string name;
        private string lastName;
        private string email;
        private string password;
        private int? id;
        private bool isRunning;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }
        }

        public int? Id
        {
            get { return this.id; }
            set { SetValue(ref this.id, value); }
        }

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        #endregion

        #region Constructors
        public RegisterViewModel()
        {
            this.Name = "Andres";
            this.LastName = "Quintero Galvan";
            this.Id = 99999999;
            this.Email = "aquintero446@gmail.com";
            this.Password = "123456";
        }
        #endregion

        #region Commands
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        private async void Register()
        {
            #region ValidationInput
            if (this.Id != null && this.Id != 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un numero de cedula.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un nombre.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.LastName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un apellido.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un correo.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una contraseña.",
                    "Aceptar");
                return;
            }
            #endregion
            
            this.IsRunning = true;

            //TODO: Upload data to server

            this.IsRunning = false;

        }

        public ICommand FrontalIdCommand
        {
            get
            {
                return new RelayCommand(FrontalId);
            }
        }

        public void FrontalId()
        {

        }

        public ICommand BackIdCommand
        {
            get
            {
                return new RelayCommand(BackId);
            }
        }

        public void BackId()
        {

        }

        #endregion
    }
}
