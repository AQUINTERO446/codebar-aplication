using MyPassMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPassMobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        public RegisterViewModel Register
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
