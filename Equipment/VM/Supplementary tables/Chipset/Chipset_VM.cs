﻿using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment.V;
using Equipment_accounting.Data;
using OKB3Admin;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace Equipment.VM
{
    public class Chipset_VM :BaseModelForVM
    {
        public Chipset_VM()
        {
            NewItem = new Chipset_M();
        }

        ObservableCollection<Chipset_M> chipsetTable;
        public ObservableCollection<Chipset_M> ChipsetTable
        {
            get => chipsetTable;
            set
            {
                chipsetTable = value;
                OnPropertyChanged();
            }
        }

        Chipset_M selectedItem;
        public Chipset_M SelectedItem
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
                var tmp = ec.Chipset.ToList();
                foreach (var item in tmp)
                {
                        item.Socket = ec.Socket.FirstOrDefault(x => x.GID == item.Socket_guid);
                   
                }
                ChipsetTable = new ObservableCollection<Chipset_M>(tmp);
            }
            await Task.CompletedTask;
        }

        Chipset_M newItem;
        public Chipset_M NewItem
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
                        ec.Chipset.Update(NewItem);
                        ec.SaveChanges();
                        GetData();
                        NewItem = new Chipset_M();
                    }
                }, o => NewItem.Name != null && NewItem.Name != ""
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
                        ec.Chipset.Update(SelectedItem);
                        ec.SaveChanges();
                    }
                    GetData();
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
                    try
                    {
                        using (EqContext ec = new EqContext())
                        {
                            ec.Chipset.Remove(SelectedItem);
                            ec.SaveChanges();
                            GetData();
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        MessageBox.Show("Есть записи в другой таблице с данным сокетом", "Невозможно удлаить запись", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }, o => SelectedItem != null
                );
            }
        }

        RelayCommand chooseSocket;
        public RelayCommand ChooseSocket
        { 
            get
            {
                return chooseSocket ??= new RelayCommand(o =>
                {
                    Select_socket_on_chipset window = new Select_socket_on_chipset();
                    window.ShowDialog();
                    if ((window.DataContext as Select_socket_on_chipset_VM).SelectedItem != null)
                    {
                        NewItem.Socket = (window.DataContext as Select_socket_on_chipset_VM).ChooosedSocket;
                        NewItem.Socket_guid = NewItem.Socket.GID;
                    }
                    
                    OnPropertyChanged("NewItem");
                }
                );
            } 
        }

        RelayCommand changeSocket;
        public RelayCommand ChangeSocket
        {
            get
            {
                return changeSocket ??= new RelayCommand(o =>
                {
                    Select_socket_on_chipset window = new Select_socket_on_chipset();
                    window.ShowDialog();
                    if ((window.DataContext as Select_socket_on_chipset_VM).SelectedItem != null)
                    {
                        SelectedItem.Socket = (window.DataContext as Select_socket_on_chipset_VM).ChooosedSocket;
                        SelectedItem.Socket_guid = SelectedItem.Socket.GID;
                    }

                    OnPropertyChanged("SelectedItem");
                }
                );
            }
        }

    }
}
