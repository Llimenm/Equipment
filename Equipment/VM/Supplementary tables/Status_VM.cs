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
    public class Status_VM : Base_VM
    {
        public Status_VM()
        {
            NewItem = new Status_M();
        }
        ObservableCollection<Status_M> statusTable;
        public ObservableCollection<Status_M> StatusTable
        {
            get => statusTable;
            set
            {
                statusTable = value;
                OnPropertyChanged();
            }
        }

        Status_M selectedItem;
        public Status_M SelectedItem
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
                var tmp = ec.Status;
                StatusTable = new ObservableCollection<Status_M>(await tmp.ToListAsync());
            }
            await Task.CompletedTask;
        }

        Status_M newItem;
        public Status_M NewItem
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
                        ec.Status.Update(NewItem);
                        ec.SaveChanges();
                        GetData();
                        NewItem = new Status_M();
                    }
                }, o=> NewItem.Name != null && NewItem.Name != ""
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
                        ec.Status.Update(SelectedItem);
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
                        ec.Status.Remove(SelectedItem);
                        ec.SaveChanges();
                        GetData();
                    }
                }, o => SelectedItem != null
                );
            } 
        }
    }
}
