﻿namespace GitterClient.ViewModel
{
    using System;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Common;
    using Windows.Security.Authentication.Web;

    /// <summary>
    /// The authentication view model.
    /// </summary>
    public class AuthenticationViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        public string Token
        {
            get { return App.Token; }
        }

        #region RelayCommands

        /// <summary>
        /// The connect command.
        /// </summary>
        private RelayCommand _connectCommand;
        
        /// <summary>
        /// Gets the connect command.
        /// </summary>
        public RelayCommand ConnectCommand
        {
            get { return _connectCommand ?? (_connectCommand = new RelayCommand(ConnectCommandExecute)); }
        }
        
        #endregion

        /// <summary>
        /// The connect command execute.
        /// </summary>
        private void ConnectCommandExecute()
        {
            var gitterUrl = string.Format("{0}{1}?response_type=code&redirect_uri={2}&client_id={3}", Constants.GitterBaseAddress, Constants.AuthEndPoint, Constants.RedirectUrl, Constants.ClientKey);

            var startUri = new Uri(gitterUrl);
            var endUri = new Uri(Constants.RedirectUrl);

            WebAuthenticationBroker.AuthenticateAndContinue(startUri, endUri, null, WebAuthenticationOptions.None);
        }
    }
}