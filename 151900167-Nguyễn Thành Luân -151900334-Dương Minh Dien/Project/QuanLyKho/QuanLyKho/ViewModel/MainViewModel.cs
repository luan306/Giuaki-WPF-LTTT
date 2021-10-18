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
    public class MainViewModel : BaseViewModel
    {
        //private ObservableCollection<mainmodel> _mainList;
        //public ObservableCollection<mainmodel> mainList { get => _mainList; set { _mainList = value; OnPropertyChanged(); } }
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand dkCommand { get; set; }
        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }



        private Customer _SelectedItem;

        public Customer SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Name = SelectedItem.Name;
                    Phone = SelectedItem.Phone;
                    soluong = SelectedItem.soluong;
                    ghichu = SelectedItem.ghichu;
                    DICHI = SelectedItem.DICHI;
                    chiphi = SelectedItem.chiphi;
                    NgayBatDau = SelectedItem.NgayBatDau;
                    NgayKetThuc = SelectedItem.NgayKetThuc;
                }

            }
        }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }


        private string _soluong;
        public string soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }


        private string _ghichu;
        public string ghichu { get => _ghichu; set { _ghichu = value; OnPropertyChanged(); } }


        private string _DICHI;
        public string DICHI { get => _DICHI; set { _DICHI = value; OnPropertyChanged(); } }
        private string _chiphi;
        public string chiphi { get => _chiphi; set { _chiphi = value; OnPropertyChanged(); } }


        private DateTime? _NgayBatDau;
        public DateTime? NgayBatDau { get => _NgayBatDau; set { _NgayBatDau = value; OnPropertyChanged(); } }
        private DateTime? _NgayKetThuc;
        public DateTime? NgayKetThuc { get => _NgayKetThuc; set { _NgayKetThuc = value; OnPropertyChanged(); } }
        
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        /// </summary>


        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {
            List = new ObservableCollection<Customer>(data.Ins.DB.Customers);
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();

                }
                else
                {
                    p.Close();
                }
            }
              );
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UserWindow us = new UserWindow();us.ShowDialog();});
            //dkCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
            //    dkWindow us = new dkWindow(); us.ShowDialog();
            //});
            //var a = data.Ins.DB.UserRoles.ToList();



            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var customer = new Customer() { Name = Name, Phone = Phone, soluong = soluong, ghichu = ghichu, DICHI = DICHI, chiphi = chiphi, NgayBatDau = NgayBatDau, NgayKetThuc = NgayKetThuc };

                data.Ins.DB.Customers.Add(customer);
                data.Ins.DB.SaveChanges();
                List.Add(customer);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = data.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Customer = data.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Customer.Name = Name;
                Customer.Phone = Phone;
                Customer.soluong = soluong;
                Customer.ghichu = ghichu;
                Customer.DICHI = DICHI;
                Customer.chiphi = chiphi;
                Customer.NgayBatDau = NgayBatDau;
                Customer.NgayKetThuc = NgayKetThuc;
                data.Ins.DB.SaveChanges();
                SelectedItem.Name = Name;
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = data.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var customer = data.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                if (List.Count > 0)
                {
                    List.RemoveAt(List.Count - 1);
                }
                data.Ins.DB.Customers.Remove(customer);
                data.Ins.DB.SaveChanges();
                List.Remove(customer);


            });
        }
        void LoadData()
        {
            //mainList = new ObservableCollection<mainmodel>();
            //mainList = new ObservableCollection<mainmodel>();

            //var objectList = data.Ins.DB.Objects;

            //int i = 1;
            //List = new ObservableCollection<Customer>(data.Ins.DB.Customer);

            //AddCommand = new RelayCommand<object>((p) =>
            //{
            //    return true;

            //}, (p) =>
            //{
            //    var customer = new Customer() { Name = Name, Phone = Phone, soluong = soluong, ghichu = ghichu, DICHI = DICHI, chiphi = chiphi, NgayBatDau = NgayBatDau, NgayKetThuc = NgayKetThuc };

            //    data.Ins.DB.Customer.Add(customer);
            //    data.Ins.DB.SaveChanges();

            //    List.Add(customer);
            //});

            //EditCommand = new RelayCommand<object>((p) =>
            //{
            //    if (SelectedItem == null)
            //        return false;

            //    var displayList = data.Ins.DB.Customer.Where(x => x.STT == SelectedItem.STT);
            //    if (displayList != null && displayList.Count() != 0)
            //        return true;

            //    return false;

            //}, (p) =>
            //{
            //    var Customer = data.Ins.DB.Customer.Where(x => x.STT == SelectedItem.STT).SingleOrDefault();
            //    Customer.Name = Name;
            //    Customer.Phone = Phone;
            //    Customer.soluong = soluong;
            //    Customer.ghichu = ghichu;
            //    Customer.DICHI = DICHI;
            //    Customer.chiphi = chiphi;
            //    Customer.NgayBatDau = NgayBatDau;
            //    Customer.NgayKetThuc = NgayKetThuc;
            //    data.Ins.DB.SaveChanges();
            //    SelectedItem.Name = Name;
            //});


        }
    }
}
