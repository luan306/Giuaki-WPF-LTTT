using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class dkviewmodel : BaseViewModel
    {
        private ObservableCollection<User> _List;
        public ObservableCollection<User> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private User _SelectedItem;
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand dkCommand { get; set; }
        public ICommand quyenCommand { get; set; }
        public User SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    UserName = SelectedItem.UserName;
                    //IdRole = SelectedItem.IdRole;
                    Password = SelectedItem.Password;

                }

            }
        }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private int _IdRole;
        public int IdRole { get; set;  }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }

     


        public dkviewmodel()
        {
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            LoginCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoginWindow us = new LoginWindow(); us.ShowDialog(); });
             //List = new ObservableCollection<User>(data.Ins.DB.Users);


            dkCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;

                var displayList = data.Ins.DB.Users.Where(x => x.DisplayName == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                var user = new User() { DisplayName = DisplayName, UserName = UserName,Password=Password ,IdRole=IdRole};

               data.Ins.DB.Users.Add(user);
               data.Ins.DB.SaveChanges();

                List.Add(user);
            });

           
           

        }
    }
}
