using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;
using MyPassMobile.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;

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
        private string barCode;
        private ImageSource imageSourceFront;
        private ImageSource imageSourceBack;
        private MediaFile file;
        private ScanService scanService;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string BarCode
        {
            get { return this.barCode; }
            set { SetValue(ref this.barCode, value); }
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

        public ImageSource ImageSourceFront
        {
            get { return this.imageSourceFront; }
            set { SetValue(ref this.imageSourceFront, value); }
        }

        public ImageSource ImageSourceBack
        {
            get { return this.imageSourceBack; }
            set { SetValue(ref this.imageSourceBack, value); }
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
            scanService = new ScanService();

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
            await Application.Current.MainPage.DisplayAlert(
                    "Lectura de Scaner",
                    "Errorrrr",
                    "Aceptar");
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

        public async void FrontalId()
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsCameraAvailable &&
                CrossMedia.Current.IsTakePhotoSupported)
            {
                var source = await Application.Current.MainPage.DisplayActionSheet(
                    "¿De donde quieres tomar la imagen?",
                    "Cancelar",
                    null,
                    "Desde la galería",
                    "Desde la cámara");

                if (source == "Cancelar")
                {
                    this.file = null;
                    return;
                }

                if (source == "Desde la cámara")
                {
                    this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
                }
                else
                {
                    this.file = await CrossMedia.Current.PickPhotoAsync();
                }
            }
            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null)
            {
                this.ImageSourceFront = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        public ICommand BackIdCommand
        {
            get
            {
                return new RelayCommand(BackId);
            }
        }

        public async void BackId()
        {
            string BarCode = await scanService.Scanner();
            await Application.Current.MainPage.DisplayAlert(
                    "Lectura de Scaner",
                    BarCode,
                    "Aceptar");
        }

        #endregion
    }
}
