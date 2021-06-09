using System;
using System.Collections.Generic;
using System.Text;
using Equipment.V.Komplekt;
using Equipment_accounting.Data;
using OKB3Admin;
using System.Threading.Tasks;
using Equipment.M.EquipmentContext.Models;
using Equipment.M.EquipmentContext;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using Equipment.M;
using OKB3Admin.M.InventorySystem;
using Microsoft.EntityFrameworkCore;
using Equipment.V.Monitor;
using OKB3Admin.M.Structura;


namespace Equipment.VM
{
    public class Komplekt_VM : BaseModelForVM
    {
        public Komplekt_VM() { }

        #region Get Запросы на выборку данных
        public void GetStartData() //получение данных
        {
            using (EqContext ec = new EqContext())
            {

                CurrentPage = 1;
                GetEndKomplekt();
                Statuses = new ObservableCollection<Status_M>(ec.Status.ToList());
                TypeList = new ObservableCollection<Type_eq_M>(ec.Type_equipment.ToList());
                using (EntityContext EntCont = new EntityContext())
                {
                    Otdelenies = new ObservableCollection<Otdelenie_M>(EntCont.Otdelenie.ToList());
                }
            }
        }

        public void GetEndKomplekt()
        {
            using (EntityContext entcon = new EntityContext())
            {
                using (EqContext ec = new EqContext())
                {
                    var i = ec.Komplekt.
                        Include(x => x.Account).
                        Include(x => x.Status).
                        Include(x => x.Type_Eq).
                        Include(x => x.Inventory).
                        Where
                        (x =>
                        (string.IsNullOrEmpty(FilterName) ? x.Account.Acc_user.Contains("") : x.Account.Acc_user.Contains(FilterName))
                        & (SelectedFilterStatus != null ? x.Status_guid == SelectedFilterStatus.GID : x.Status_guid.ToString().Contains(""))
                        & (SelectedFilterInventory != null ? x.Inventory.Inventory.Contains(SelectedFilterInventory) : x.Inventory.Inventory.Contains(""))
                        & (SelectedFilterType != null ? x.Type_eq_guid == SelectedFilterType.GID : x.Type_eq_guid.ToString().Contains(""))
                        & (SelectedFilterOtdelenie != null ? x.Otdelenie_gid == SelectedFilterOtdelenie.GID : x.Inventory.Inventory.Contains(""))
                        ).ToList();
                    foreach (var item in i)
                    {
                        item.InventoryNumber = entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == item.Inventory.Inventory);
                        item.Otdelenie = entcon.Otdelenie.FirstOrDefault(x => x.GID == item.Otdelenie_gid);
                    }

                    AllPage = Convert.ToInt32(Math.Ceiling(i.Count() / 25d));

                    i.Skip((CurrentPage - 1) * 25).
                    Take(25);
                    using (EntityContext entCont = new EntityContext())
                    {
                        foreach (var item in i)
                        {
                            item.Otdelenie = entCont.Otdelenie.FirstOrDefault(x => x.GID == item.Otdelenie_gid);
                        }
                    }
                    KomplektTable = new ObservableCollection<Komplekt_M>(i);
                    NewItem.Status = null;
                    NewItem.Otdelenie = null;
                }
            }
        }

        RelayCommand refreshData;
        public RelayCommand RefreshData
        {
            get
            {
                return refreshData ??= new RelayCommand(o =>
                {
                    GetStartData();
                });
            }
        }

        #endregion

        #region Списки и таблицы

        ObservableCollection<Komplekt_M> komplektTable;
        public ObservableCollection<Komplekt_M> KomplektTable
        {
            get => komplektTable;
            set
            {
                komplektTable = value;
                OnPropertyChanged();
            }
        }
        ObservableCollection<Status_M> statuses;
        public ObservableCollection<Status_M> Statuses//Список статусов
        {
            get => statuses;
            set
            {

                statuses = value;
                OnPropertyChanged();
            }
        }
        Collection<Type_eq_M> typeList;
        public Collection<Type_eq_M> TypeList
        {
            get => typeList;
            set
            {
                typeList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Otdelenie_M> otdelenies;
        public ObservableCollection<Otdelenie_M> Otdelenies
        {
            get => otdelenies;
            set
            {
                otdelenies = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Добавление комплекта
        Komplekt_M newItem = new Komplekt_M
        {
            Account = new Account_M(),
            Inventory = new Inventory_m()

        };

        public Komplekt_M NewItem //Новый комплект 
        {
            get => newItem;
            set
            {
                newItem = value;
                OnPropertyChanged();
            }
        }

        RelayCommand addItem;
        public RelayCommand AddItem //Добавление нового комплекта
        {
            get
            {
                return addItem ??= new RelayCommand(o =>
                    {
                        using (EqContext ec = new EqContext())
                        {
                            using (EntityContext entcon = new EntityContext())
                            {

                                if (entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == NewItem.Inventory.Inventory) == null)
                                {
                                    InventoryNumber_M NewInventory = new InventoryNumber_M
                                    {
                                        Inventory = NewItem.Inventory.Inventory,
                                        OtdelenieGID = NewItem.Otdelenie_gid
                                    };
                                    entcon.InventoryNumbers.Update(NewInventory);
                                    entcon.SaveChanges();

                                    NewItem.Inventory.Otdelenie_guid = NewItem.Otdelenie_gid;
                                    ec.Inventory.Update(NewItem.Inventory);
                                    ec.Account.Update(NewItem.Account);
                                    ec.Type_equipment.Update(NewItem.Type_Eq);
                                    ec.Status.Update(NewItem.Status);
                                    ec.SaveChanges();

                                    NewItem.Inventory_id = NewItem.Inventory.Id;
                                    NewItem.Account_id = ec.Account.FirstOrDefault(x => x.Acc_user == NewItem.Account.Acc_user
                                        && x.Password == NewItem.Account.Password).Id;
                                    NewItem.Status_guid = NewItem.Status.GID;
                                    NewItem.Type_eq_guid = NewItem.Type_Eq.GID;
                                    NewItem.Otdelenie_gid = NewItem.Otdelenie.GID;

                                    ec.Komplekt.Update(NewItem);
                                    ec.SaveChanges();
                                    GetStartData();
                                    NewItem = new Komplekt_M
                                    {
                                        Account = new Account_M(),
                                        Inventory = new Inventory_m()
                                    };
                                }
                                else
                                {
                                    ErrorInventory();
                                }
                            };
                        }
                    }
                    , o =>
                    NewItem.Status != null
                    & NewItem.Account.Acc_user != null
                    & NewItem.Account.Password != null
                    & NewItem.Inventory.Inventory != ""
                    & NewItem.Type_Eq != null
                    & NewItem.Otdelenie != null
                    );
            }
        }

        #endregion

        #region Изменение комплекта
        Komplekt_M selectedItem;
        public Komplekt_M SelectedItem // Выбранный элемент
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        RelayCommand saveSelectedItem;
        public RelayCommand SaveSelectedItem //Сохранение данных в выбранной строке
        {
            get
            {
                return saveSelectedItem ??= new RelayCommand(o =>
                {
                    using (EntityContext entcont = new EntityContext())
                    {
                        if (SelectedItem.InventoryNumber.Inventory == SelectedItem.Inventory.Inventory || entcont.InventoryNumbers.FirstOrDefault(x => x.Inventory == SelectedItem.Inventory.Inventory) == null)
                        {
                            using (EqContext ec = new EqContext())
                            {
                                if (NewOtdelenie != null)
                                    SelectedItem.Otdelenie_gid = NewOtdelenie.GID;
                                if (NewStatus != null)
                                    SelectedItem.Status_guid = NewStatus.GID;
                                if (NewType != null)
                                    SelectedItem.Type_eq_guid = NewType.GID;

                                SelectedItem.InventoryNumber.Inventory = SelectedItem.Inventory.Inventory;
                                entcont.InventoryNumbers.Update(SelectedItem.InventoryNumber);

                                ec.Account.Update(SelectedItem.Account);
                                ec.Komplekt.Update(SelectedItem);

                                if (NewType != null) //костыль
                                    SelectedItem.Type_eq_guid = NewType.GID; 
                                if (NewStatus != null) //костыль
                                    SelectedItem.Status_guid = NewStatus.GID;

                                entcont.SaveChanges();
                                ec.SaveChanges();
                                GetEndKomplekt();

                            }
                        }
                        else
                        {
                            ErrorInventory();
                        }
                    }
                        
                            

                });
            }
        }
        Status_M newStatus;
        public Status_M NewStatus
        {
            get => newStatus;
            set
            {
                newStatus = value;
                OnPropertyChanged();
            }
        }
        Otdelenie_M newOtdelenie;
        public Otdelenie_M NewOtdelenie
        {
            get => newOtdelenie;
            set
            {
                newOtdelenie = value;
                OnPropertyChanged();
            }
        }
        Type_eq_M newType;
        public Type_eq_M NewType
        {
            get => newType;
            set
            {
                newType = value;
                OnPropertyChanged();
            }
        }

        RelayCommand changeMB_k;
        public RelayCommand ChangeMb_k //Вызов изменения списка материнсикх плат комплекта
        {
            get
            {
                return changeMB_k ??
                    (changeMB_k = new RelayCommand(o =>
                    {
                        Add_MB_K_V window = new Add_MB_K_V();
                        (window.DataContext as Motherboard_Komplekt_VM).ChangeOrView = true;
                        (window.DataContext as Motherboard_Komplekt_VM).SetStartData(SelectedItem.GID);
                        window.ShowDialog();
                        //GetMB_K_Table();
                    }, o => SelectedItem != null
                    ));
            }
        }

        RelayCommand changeMonitorKomplekt;
        public RelayCommand ChangeMonitorKomplekt
        {
            get
            {
                return changeMonitorKomplekt ??= new RelayCommand(o =>
                {
                    Monitor_Komplekt_V monitorKomplekt = new Monitor_Komplekt_V();
                    //(monitorKomplekt.DataContext as Monitor_VM).GetData();
                    //(monitorKomplekt.DataContext as Monitor_VM).GetMonitorKomplekt(SelectedItem.GID);
                    monitorKomplekt.ShowDialog();
                }, o => SelectedItem != null);
            }
        }

        #endregion

        #region Удаление комплекта

        RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        using (EntityContext entcont = new EntityContext())
                        {
                            InventoryNumber_M inventoryForDelete = entcont.InventoryNumbers.FirstOrDefault(x => x.Inventory == SelectedItem.Inventory.Inventory);
                            entcont.InventoryNumbers.Remove(inventoryForDelete);
                            entcont.SaveChanges();
                        }
                        ec.SaveChanges();
                        ec.Account.Remove(SelectedItem.Account);
                        ec.Komplekt.Remove(SelectedItem);
                        ec.SaveChanges();
                        GetStartData();
                    }
                }, o => SelectedItem != null);
            }
        }

        #endregion

        #region Фильтрация и все что с ней связано
        string filterName;
        public string FilterName
        {
            get => filterName;
            set
            {
                filterName = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Status_M> filterSatus;
        public ObservableCollection<Status_M> FilterStatus
        {
            get => filterSatus;
            set
            {
                filterSatus = value;
                OnPropertyChanged();
            }
        }

        Status_M selectedFilterStatus;
        public Status_M SelectedFilterStatus
        {
            get => selectedFilterStatus;
            set
            {
                //SelectedItem = null;
                selectedFilterStatus = value;
                GetEndKomplekt();
                OnPropertyChanged();
            }
        }

        string selectedFilterInventory;
        public string SelectedFilterInventory
        {
            get => selectedFilterInventory;
            set
            {
                selectedFilterInventory = value;
                OnPropertyChanged();
            }
        }

        Otdelenie_M selectedFilterOtdelenie;
        public Otdelenie_M SelectedFilterOtdelenie
        {
            get => selectedFilterOtdelenie;
            set
            {
                selectedFilterOtdelenie = value;
                GetEndKomplekt();
                OnPropertyChanged();
            }
        }
        Type_eq_M selectedFilterType;
        public Type_eq_M SelectedFilterType
        {
            get => selectedFilterType;
            set
            {
                selectedFilterType = value;
                GetEndKomplekt();
                OnPropertyChanged();
            }
        }

        RelayCommand filtered;
        public RelayCommand Filtered
        {
            get
            {
                return filtered ??= new RelayCommand(o =>
                {
                    GetEndKomplekt();
                }
                );
            }
        }
        RelayCommand filterCancel;
        public RelayCommand FilterCancel
        {
            get
            {
                return filterCancel ??= new RelayCommand(o =>
                {
                    SelectedFilterOtdelenie = null;
                    SelectedFilterType = null;
                    FilterName = null;
                    SelectedFilterInventory = null;
                    SelectedFilterStatus = null;
                    selectedFilterType = null;
                    GetEndKomplekt();
                });
            }
        }
        #endregion Фильтрация и все что с ней связано

        #region Пагинация
        int currentPage;
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
                    GetEndKomplekt();
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
                    GetEndKomplekt();
                }, o => CurrentPage < AllPage);
            }
        }


        #endregion

        
        public void ErrorInventory()
        {
            MessageBox.Show("Такой инвентарный номер уже существует","ErrorInventory", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
