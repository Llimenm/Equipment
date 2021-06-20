using Equipment.M;
using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment.V;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;
using OKB3Admin.M.InventorySystem;
using OKB3Admin.M.Printers;
using OKB3Admin.M.Structura;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Equipment.VM
{
    public class Komplekt_VM : BaseModelForVM
    {
        public Komplekt_VM() { }

        #region Get Запросы на выборку данных
        public void GetStartData() //Получение данных
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
                    var tmp = ec.Komplekt.
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
                        & (SelectedFilterOtdelenie != null ? x.Otdelenie_gid == SelectedFilterOtdelenie.GID : x.Inventory.Inventory.Contains(""))).
                        Skip((CurrentPage - 1) * 25).
                        Take(25);
                    foreach (var item in tmp)
                    {
                        item.InventoryNumber = entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == item.Inventory.Inventory);
                        item.Otdelenie = entcon.Otdelenie.FirstOrDefault(x => x.GID == item.Otdelenie_gid);
                    }
                    AllPage = Convert.ToInt32(Math.Ceiling(ec.Komplekt.Where
                        (x =>
                        (string.IsNullOrEmpty(FilterName) ? x.Account.Acc_user.Contains("") : x.Account.Acc_user.Contains(FilterName))
                        & (SelectedFilterStatus != null ? x.Status_guid == SelectedFilterStatus.GID : x.Status_guid.ToString().Contains(""))
                        & (SelectedFilterInventory != null ? x.Inventory.Inventory.Contains(SelectedFilterInventory) : x.Inventory.Inventory.Contains(""))
                        & (SelectedFilterType != null ? x.Type_eq_guid == SelectedFilterType.GID : x.Type_eq_guid.ToString().Contains(""))
                        & (SelectedFilterOtdelenie != null ? x.Otdelenie_gid == SelectedFilterOtdelenie.GID : x.Inventory.Inventory.Contains(""))).Count() / 25d));
                    using (EntityContext entCont = new EntityContext())
                    {
                        foreach (var item in tmp)
                        {
                            item.Otdelenie = entCont.Otdelenie.FirstOrDefault(x => x.GID == item.Otdelenie_gid);
                        }
                    }

                    KomplektTable = new ObservableCollection<Komplekt_M>(tmp);
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
                                    Log log = new Log()
                                    {
                                        ItemId = NewItem.GID.ToString(),
                                        LogCategoryEnum = LogCategoryEnum.Добавление,
                                        LogTypeEnum = LogTypeEnum.Комплекты,
                                        Changes =
                                           "Добавлен " + NewItem.Type_Eq.Type_name + " " + NewItem.Account.Acc_user + "\n"
                                           + "С инвентарным номером: " + NewItem.Inventory.Inventory + "\n"
                                           + "В отделение: " + NewItem.Otdelenie.Name + "\n"
                                           + "Статус: " + NewItem.Status.Name + "\n"
                                           + "Комментарий: " + NewItem.Comment,
                                        ChangeDate = DateTime.Now
                                    };
                                    GetStartData();

                                   

                                    entcon.Logs.Add(log);
                                    entcon.SaveChanges();

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
                                {
                                    SelectedItem.Otdelenie_gid = NewOtdelenie.GID;
                                    SelectedItem.Otdelenie = NewOtdelenie;
                                }
                                if (NewStatus != null)
                                {
                                    SelectedItem.Status_guid = NewStatus.GID;
                                    SelectedItem.Status = NewStatus;
                                }
                                if (NewType != null)
                                {
                                    SelectedItem.Type_eq_guid = NewType.GID;
                                    SelectedItem.Type_Eq = NewType;
                                }

                                SelectedItem.InventoryNumber.Inventory = SelectedItem.Inventory.Inventory;
                                entcont.InventoryNumbers.Update(SelectedItem.InventoryNumber);

                                ec.Account.Update(SelectedItem.Account);
                                ec.Komplekt.Update(SelectedItem);

                                Log log = GetChanges(SelectedItem);
                                if (log != null)
                                {
                                    entcont.Logs.Add(log);
                                }
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

        /// <summary>
        /// Составляет Лог об внесенных изменениях в комплект
        /// </summary>
        /// <param name="komplekt"></param>
        /// <returns></returns>
        private Log GetChanges(Komplekt_M komplekt)
        {
            using (EqContext ec = new EqContext())
            {

                string changes = "Изменения\n";
                Komplekt_M oldKomplekt = ec.Komplekt.
                    Include(x => x.Type_Eq).
                    Include(x => x.Inventory).
                    Include(x => x.Status).
                    Include(x => x.Account).
                    FirstOrDefault(x => x.GID == komplekt.GID);

                using (EntityContext entcon = new EntityContext())
                {
                    oldKomplekt.Otdelenie = entcon.Otdelenie.FirstOrDefault(x => x.GID == oldKomplekt.Otdelenie_gid);
                }

                if (komplekt.Type_eq_guid != oldKomplekt.Type_eq_guid)
                {
                    changes += "Тип: " + oldKomplekt.Type_Eq.Type_name + " => " + komplekt.Type_Eq.Type_name + "\n";
                }
                if (komplekt.Inventory.Inventory != oldKomplekt.Inventory.Inventory)
                {
                    changes += "Инв. номер: " + oldKomplekt.Inventory.Inventory + " => " + komplekt.Inventory.Inventory + "\n";
                }
                if (komplekt.Account.Acc_user != oldKomplekt.Account.Acc_user)
                {
                    changes += "Имя комплекта: " + oldKomplekt.Account.Acc_user + " => " + komplekt.Account.Acc_user + "\n";
                }
                if (komplekt.Account.Password != oldKomplekt.Account.Password)
                {
                    changes += "Пароль : " + oldKomplekt.Account.Password + " => " + komplekt.Account.Password + "\n";
                }
                if (komplekt.Otdelenie_gid != oldKomplekt.Otdelenie_gid)
                {
                    changes += "Отделение: " + oldKomplekt.Otdelenie.Name + " => " + komplekt.Otdelenie.Name + "\n";
                }
                if (komplekt.Status_guid != oldKomplekt.Status_guid)
                {
                    changes += "Статус: " + oldKomplekt.Status.Name + " => " + komplekt.Status.Name + "\n";
                }
                if (komplekt.Comment != oldKomplekt.Comment)
                {
                    changes += "Комментарий: " + komplekt.Comment + "\n";
                }

                if (changes == "Изменения\n")
                {
                    return null;
                }
                else
                    return new Log()
                    {
                        ItemId = komplekt.GID.ToString(),
                        LogCategoryEnum = LogCategoryEnum.Изменение,
                        LogTypeEnum = LogTypeEnum.Комплекты,
                        Changes = changes,
                        ChangeDate = DateTime.Now
                    };
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

                            Log log = new Log()
                            {
                                ItemId = SelectedItem.GID.ToString(),
                                LogCategoryEnum = LogCategoryEnum.Удаление,
                                LogTypeEnum = LogTypeEnum.Комплекты,
                                Changes =
                                           "Удалён " + SelectedItem.Type_Eq.Type_name + " " + SelectedItem.Account.Acc_user + " " + "\n"
                                           + "С инвентарным номером: " + SelectedItem.Inventory.Inventory + "\n"
                                           + "В отделении: " + SelectedItem.Otdelenie.Name + "\n",
                                ChangeDate = DateTime.Now
                            };
                            entcont.Logs.Add(log);
                            entcont.SaveChanges();

                            ec.SaveChanges();
                            ec.Account.Remove(SelectedItem.Account);
                            ec.Komplekt.Remove(SelectedItem);
                            ec.SaveChanges();
                            GetStartData();
                        }
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

        RelayCommand showLogs;
        public RelayCommand ShowLogs
        {
            get
            {
                return showLogs ??= new RelayCommand(o =>
                {
                    Show_log_V log_window = new Show_log_V();
                    (log_window.DataContext as Show_log_VM).GetData(SelectedItem.GID.ToString());
                    log_window.ShowDialog();
                });
            }
        }

        public void ErrorInventory()
        {
            MessageBox.Show("Такой инвентарный номер уже существует","ErrorInventory", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
