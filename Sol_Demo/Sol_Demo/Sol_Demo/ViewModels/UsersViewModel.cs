using Sol_Demo.Helpers.Commands;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sol_Demo.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        public UsersViewModel()
        {
            // Create an Insatnce of User Model
            Users = new UserModel();

            // Submit Command Execute
            Submit = new AsyncCommand(OnAddUsersAsync);

            ContentPageInstace = new AsyncCommand<ContentPage>(GetContentPageInstance);
        }

        #region Model Property
        private UserModel _users = null;
        public UserModel Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private string _fullName;
        public String FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }
        #endregion

        #region Command Property
        public AsyncCommand Submit { get; set; }

        public AsyncCommand<ContentPage> ContentPageInstace { get; set; }

        #endregion

        #region Private Method
        private Task OnAddUsersAsync()
        {
            return Task.Run(() => {

                this.FullName = $"{Users.FirstName} {Users.LastName}";

            });
        }

        private async Task GetContentPageInstance(ContentPage contentPage)
        {
            await contentPage.DisplayAlert("Xamarine", "Hello C#", "Cancel");
        }
        #endregion 


    }
}
