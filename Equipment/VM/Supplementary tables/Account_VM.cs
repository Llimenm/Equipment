using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;

namespace Equipment.VM
{
    public class Account_VM : BaseModelForVM
    {
        public Account_VM()
        {
            NewItem = new Account_M();
        }
        ObservableCollection<Account_M> accountTable;
        public ObservableCollection<Account_M> AccountTable
        {
            get => accountTable;
            set
            {
                accountTable = value;
                OnPropertyChanged();
            }
        }

        Account_M selectedItem;
        public Account_M SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Вызывает подгрузку данных с учетом пагинации и поиска
        /// </summary>
        /// <returns></returns>
        public async Task GetData()
        {
            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Account.
                    Where(x => (x.Acc_user.Contains(SearchBox) || x.Password.Contains(SearchBox))).
                    Skip((CurrentPage - 1) * 25).
                    Take(25);
                AllPage = Convert.ToInt32(Math.Ceiling(tmp.Count() / 25d));
                AccountTable = new ObservableCollection<Account_M>(await tmp.ToListAsync());
            }
            await Task.CompletedTask;
        }

        Account_M newItem;
        public Account_M NewItem
        {
            get => newItem;
            set
            {
                newItem = value;
                OnPropertyChanged();
            }
        }
        RelayCommand addNewItem;
        public RelayCommand AddNewItem
        {
            get
            {
                return addNewItem ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        ec.Account.Update(NewItem);
                        ec.SaveChanges();
                        GetData();
                        NewItem = new Account_M();
                    }
                }, o => NewItem.Acc_user != null && NewItem.Password != ""
                );
            }
        }

        RelayCommand saveSelectedItem;
        public RelayCommand SaveSelectedItem
        {
            get
            {
                return saveSelectedItem ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        ec.Account.Update(SelectedItem);
                        ec.SaveChanges();
                    }
                }, o => SelectedItem != null
                );
            }
        }
        #region Поиск
        string searchBox = "";
        public string SearchBox
        {
            get => searchBox;
            set
            {
                searchBox = value;
                OnPropertyChanged();
            }
        }

        RelayCommand acceptSearch;
        public RelayCommand AcceptSearch
        {
            get
            {
                return acceptSearch ??= new RelayCommand(o =>
                {
                    CurrentPage = 1;
                    GetData();
                }
                );
            }
        }
        #endregion

        #region Пагинация
        int currentPage = 1;
        public int CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        int allPage;
        public int AllPage
        {
            get => allPage;
            set
            {
                allPage = value;
                OnPropertyChanged();
            }
        }

        RelayCommand previousPage;
        public RelayCommand PreviousPage
        {
            get
            {
                return previousPage ??= new RelayCommand(o =>
                {
                    CurrentPage -= 1;
                    GetData();
                }, o => CurrentPage > 1);
            }
        }
        RelayCommand nextPage;
        public RelayCommand NextPage
        {
            get
            {
                return nextPage ??= new RelayCommand(o =>
                {
                    CurrentPage += 1;
                    GetData();
                }, o => CurrentPage < AllPage);
            }
        }
        #endregion

        RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ??= new RelayCommand(o =>
                {
                    GetData();
                });
            }
        }
    }
}
