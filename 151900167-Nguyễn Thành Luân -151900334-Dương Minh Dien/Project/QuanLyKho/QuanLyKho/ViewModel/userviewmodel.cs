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
    public class userviewmodel : BaseViewModel
    {
        private ObservableCollection<UserRole> _List;
        public ObservableCollection<UserRole> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private UserRole _SelectedItem;
        public UserRole SelectedItem
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
                }

            }
        }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public userviewmodel()
        {
            List = new ObservableCollection<UserRole>(data.Ins.DB.UserRoles);

          
                AddCommand = new RelayCommand<object>((p) =>
                {
                    if (string.IsNullOrEmpty(DisplayName))
                        return false;

                    var displayList = data.Ins.DB.UserRoles.Where(x => x.DisplayName == DisplayName);
                    if (displayList == null || displayList.Count() != 0)
                        return false;

                    return true;

                }, (p) =>
                {
                    var userRole = new UserRole() { DisplayName = DisplayName, UserName = UserName };

                    data.Ins.DB.UserRoles.Add(userRole);
                    data.Ins.DB.SaveChanges();

                    List.Add(userRole);
                });
           

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = data.Ins.DB.UserRoles.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var userRole = data.Ins.DB.UserRoles.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                userRole.DisplayName = DisplayName;
                userRole.UserName = UserName;
                data.Ins.DB.SaveChanges();

                SelectedItem.DisplayName = DisplayName;
                //OnPropertyChanged("List");
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = data.Ins.DB.UserRoles.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var userRole = data.Ins.DB.UserRoles.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                if (List.Count > 0)
                {
                    List.RemoveAt(List.Count - 1);
                }
                data.Ins.DB.UserRoles.Remove(userRole);
                data.Ins.DB.SaveChanges();
                List.Remove(userRole);

                
            });

        }
    }
}
