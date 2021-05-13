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
    public class Socket_VM : Base_VM
    {
        public Socket_VM()
        {
            NewItem = new Socket_M();
        }
        ObservableCollection<Socket_M> socketTable;
        public ObservableCollection<Socket_M> SocketTable
        {
            get => socketTable;
            set
            {
                socketTable = value;
                OnPropertyChanged();
            }
        }

        Socket_M selectedItem;
        public Socket_M SelectedItem
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
                var tmp = ec.Socket;
                SocketTable = new ObservableCollection<Socket_M>(await tmp.ToListAsync());
            }
            await Task.CompletedTask;
        }

        Socket_M newItem;
        public Socket_M NewItem
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
                        ec.Socket.Update(NewItem);
                        ec.SaveChanges();
                        GetData();
                        NewItem = new Socket_M();
                    }
                }, o => NewItem.Name != null && NewItem.Name!= ""
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
                        ec.Socket.Update(SelectedItem);
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
                        ec.Socket.Remove(SelectedItem);
                        ec.SaveChanges();
                        GetData();
                    }
                }, o => SelectedItem != null
                );
            }
        }
    }
}
