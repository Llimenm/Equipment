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
    class Type_equipment_VM : Base_VM
    {
        public Type_equipment_VM()
        {
            NewItem = new Type_eq_M();
        }
        ObservableCollection<Type_eq_M> typeEqTable;
        public ObservableCollection<Type_eq_M> TypeEqTable
        {
            get => typeEqTable;
            set
            {
                typeEqTable = value;
                OnPropertyChanged();
            }
        }

        Type_eq_M selectedItem;
        public Type_eq_M SelectedItem
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
                var tmp = ec.Type_equipment;
                TypeEqTable = new ObservableCollection<Type_eq_M>(await tmp.ToListAsync());
            }
            await Task.CompletedTask;
        }

        Type_eq_M newItem;
        public Type_eq_M NewItem
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
                        ec.Type_equipment.Update(NewItem);
                        ec.SaveChanges();
                        GetData();
                        NewItem = new Type_eq_M();
                    }
                }, o => NewItem.Type_name != null && NewItem.Type_name != ""
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
                        ec.Type_equipment.Update(SelectedItem);
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
                        ec.Type_equipment.Remove(SelectedItem);
                        ec.SaveChanges();
                        GetData();
                    }
                }, o => SelectedItem != null
                );
            }
        }
    }
}
