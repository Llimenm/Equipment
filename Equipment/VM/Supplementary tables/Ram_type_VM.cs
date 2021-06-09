using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Equipment.VM
{
    public class Ram_type_VM : BaseModelForVM
    {
        public Ram_type_VM()
        {
            NewItem = new Ram_type_M();
        }
        ObservableCollection<Ram_type_M> ramTypeTable;
        public ObservableCollection<Ram_type_M> RamTypeTable
        {
            get => ramTypeTable;
            set
            {
                ramTypeTable= value;
                OnPropertyChanged();
            }
        }

        Ram_type_M selectedItem;
        public Ram_type_M SelectedItem
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
                var tmp = ec.Ram_type;
                RamTypeTable= new ObservableCollection<Ram_type_M>(await tmp.ToListAsync());
            }
            await Task.CompletedTask;
        }

        Ram_type_M newItem;
        public Ram_type_M NewItem
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
                        ec.Ram_type.Update(NewItem);
                        ec.SaveChanges();
                        GetData();
                        NewItem = new Ram_type_M();
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
                        ec.Ram_type.Update(SelectedItem);
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
                    try
                    {
                        using (EqContext ec = new EqContext())
                        {
                            ec.Ram_type.Remove(SelectedItem);
                            ec.SaveChanges();
                            GetData();
                        }
                    }
                    catch 
                    {
                        
                    }
                    finally
                    {
                        MessageBox.Show("Есть записи в другой таблице с данным типом памяти", "Невозможно удлаить запись", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }, o => SelectedItem != null
                );
            }
        }
    }
}
