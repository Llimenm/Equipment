using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;

namespace Equipment.VM
{
    public class Account_VM : Base_VM
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

        public async Task GetData()
        {
            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Account;
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

        RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        ec.Account.Remove(SelectedItem);
                        ec.SaveChanges();
                        GetData();
                    }
                }, o => SelectedItem != null
                );
            }
        }
    }
}
