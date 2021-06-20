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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Equipment.VM
{
    public class Monitor_VM : BaseModelForVM
    {
        #region Коллекции с таблицами и списками

        ObservableCollection<Monitor_M> manufacturerList;
        public ObservableCollection<Monitor_M> ManufacturerList
        {
            get => manufacturerList;
            set
            {
                manufacturerList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Monitor_M> filterModelList;
        public ObservableCollection<Monitor_M> FilterModelList
        {
            get => filterModelList;
            set
            {
                filterModelList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Otdelenie_M> otdelenieList;
        public ObservableCollection<Otdelenie_M> OtdelenieList
        {
            get => otdelenieList;
            set
            {
                otdelenieList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Status_M> statusList;
        public ObservableCollection<Status_M> StatusList
        {
            get => statusList;
            set
            {
                statusList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Type_eq_M> typeEqList;
        public ObservableCollection<Type_eq_M> TypeEqList
        {
            get => typeEqList;
            set
            {
                typeEqList = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Monitor_M> monitorTable;
        public ObservableCollection<Monitor_M> MonitorTable
        {
            get => monitorTable;
            set
            {
                monitorTable = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Get запросы
        /// <summary>
        /// Метод получения данных
        /// </summary>
        /// <returns></returns>
        public async Task GetData()
        {
            NewMonitor = new Monitor_M()
            {
                Inventory = new Inventory_m()
            };
            CurrentPage = 1;
            await Task.Run(() => GetLists());
            await Task.Run(() => GetMonitorTable());
            await Task.CompletedTask;
        }
        /// <summary>
        /// Получение списков производителей, статусов и отделений
        /// </summary>
        /// <returns></returns>
        public async Task GetLists()
        {
            using (EqContext ec = new EqContext())
            {
                StatusList = new ObservableCollection<Status_M>(await ec.Status.ToListAsync());
                ManufacturerList = new ObservableCollection<Monitor_M>(await ec.Monitor.GroupBy(x => x.Manufacturer).Select(x => new Monitor_M { Manufacturer = x.Key }).ToListAsync());
                TypeEqList = new ObservableCollection<Type_eq_M>(await ec.Type_equipment.ToListAsync());
                FilterModelList = new ObservableCollection<Monitor_M>(ec.Monitor.
                    Where(x => FilterManufacturer != null ? x.Manufacturer == FilterManufacturer.Manufacturer : x.Manufacturer.Contains("")).
                    GroupBy(x => x.Model).
                    Select(x => new Monitor_M { Model = x.Key }).
                    OrderBy(x => x.Model));
                using (EntityContext entcon = new EntityContext())
                {
                    OtdelenieList = new ObservableCollection<Otdelenie_M>(await entcon.Otdelenie.ToListAsync());
                }
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// Выгрузка данных по мониторам, так же учитывает фильтрацию
        /// </summary>
        /// <returns></returns>
        public async Task GetMonitorTable()
        {
            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Monitor.
                        Include(x => x.Inventory).
                        Include(x => x.TypeEquipment).
                        Include(x => x.Status).
                        Include(x => x.Komplekt).
                        Include(x => x.Komplekt.Account).
                        Where(x =>
                        (StatusFilter != null ? x.Status == StatusFilter : x.Status.Name.Contains(""))
                        & (FilterManufacturer != null ? x.Manufacturer == FilterManufacturer.Manufacturer : x.Manufacturer.Contains(""))
                        & (FilterModel != null ? x.Model.Contains(FilterModel.Model) : x.Model.Contains(""))
                        & (OtdelenieFilter != null ? x.Otdelenie_guid == OtdelenieFilter.GID : x.Manufacturer.Contains(""))
                        & (InventoryFilter != null ? x.Inventory.Inventory.Contains(InventoryFilter) : x.Inventory.Inventory.Contains(""))).
                        Skip((CurrentPage - 1) * 25).
                        Take(25).
                        OrderBy(x => x.Inventory.Inventory);
                using (EntityContext entcon = new EntityContext())
                {
                    foreach (var item in tmp)
                    {
                        item.Otdelenie = OtdelenieList.FirstOrDefault(x => x.GID == item.Otdelenie_guid);
                        item.InventoryNumber = entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == item.Inventory.Inventory);
                    }

                    Allpage = Convert.ToInt32(Math.Ceiling(tmp.Where(x =>
                       (StatusFilter != null ? x.Status == StatusFilter : x.Status.Name.Contains(""))
                       & (FilterManufacturer != null ? x.Manufacturer == FilterManufacturer.Manufacturer : x.Manufacturer.Contains(""))
                       & (FilterModel != null ? x.Model.Contains(FilterModel.Model) : x.Model.Contains(""))
                       & (OtdelenieFilter != null ? x.Otdelenie_guid == OtdelenieFilter.GID : x.Manufacturer.Contains(""))
                       & (InventoryFilter != null ? x.Inventory.Inventory.Contains(InventoryFilter) : x.Inventory.Inventory.Contains(""))).Count() / 25d));
                    MonitorTable = new ObservableCollection<Monitor_M>(tmp);
                }

            }
            await Task.CompletedTask;
        }

        #endregion

        #region Filter элементы

        Monitor_M filterManufacturer = null;
        public Monitor_M FilterManufacturer
        {
            get => filterManufacturer;
            set
            {
                filterManufacturer = value;
                using (EqContext ec= new EqContext())
                {
                    FilterModelList = new ObservableCollection<Monitor_M>(ec.Monitor.
                    Where(x => FilterManufacturer != null ? x.Manufacturer == FilterManufacturer.Manufacturer : x.Manufacturer.Contains("")).
                    GroupBy(x => x.Model).
                    Select(x => new Monitor_M { Model = x.Key }).
                    OrderBy(x => x.Model));
                }
                GetMonitorTable();
                OnPropertyChanged();
            }
        }

        Status_M statusFilter = null;
        public Status_M StatusFilter
        {
            get => statusFilter;
            set
            {
                statusFilter = value;
                GetMonitorTable();
                OnPropertyChanged();
            }
        }

        Otdelenie_M otdelenieFilter = null;
        public Otdelenie_M OtdelenieFilter
        {
            get => otdelenieFilter;
            set
            {
                otdelenieFilter = value;
                GetMonitorTable();
                OnPropertyChanged();
            }
        }

        Monitor_M filterModel = null;
        public Monitor_M FilterModel
        {
            get => filterModel;
            set
            {
                filterModel = value;
                GetMonitorTable();
                OnPropertyChanged();
            }
        }

        string inventoryFilter = null;
        public string InventoryFilter
        {
            get => inventoryFilter;
            set
            {
                inventoryFilter = value;
                OnPropertyChanged();
            }
        }


        RelayCommand acceptFilter;
        public RelayCommand AcceptFilter
        {
            get
            {
                return acceptFilter ??= new RelayCommand(o =>
                {
                    GetMonitorTable();
                });
            }
        }

        /// <summary>
        /// Сброс фильтра, вызывает GetMonitorTable
        /// </summary>
        RelayCommand cancelFilter;
        public RelayCommand CancelFilter
        {
            get
            {
                return cancelFilter ??= new RelayCommand(o =>
                {
                    FilterManufacturer = null;
                    FilterModel = null;
                    InventoryFilter = null;
                    StatusFilter = null;
                    OtdelenieFilter = null;
                    Task.Run(() => GetMonitorTable());
                    GetLists();
                });
            }
        }
        #endregion

        #region Постраничные элементы (тек страница, все стр, переключение стр)

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
        public int Allpage
        {
            get => allPage;
            set
            {
                allPage = value;
                OnPropertyChanged();
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
                    Task.Run(() => GetMonitorTable());
                }, o => CurrentPage < Allpage);
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
                    Task.Run(() => GetMonitorTable());
                }, o => CurrentPage > 1);
            }
        }

        #endregion

        #region Управление данными

        RelayCommand refreshData;
        public RelayCommand RefreshData
        {
            get
            {
                return refreshData ??= new RelayCommand(o =>
                {
                    GetData();
                });
            }
        }

        Monitor_M selectedMonitor;
        public Monitor_M SelectedMonitor
        {
            get => selectedMonitor;
            set
            {
                selectedMonitor = value;
                OnPropertyChanged();
            }
        }

        Monitor_M newMonitor = new Monitor_M();
        public Monitor_M NewMonitor
        {
            get => newMonitor;
            set
            {
                newMonitor = value;
                OnPropertyChanged();
            }
        }

        Type_eq_M changeType;
        public Type_eq_M ChangeType
        {
            get => changeType;
            set
            {
                changeType = value;
                OnPropertyChanged();
            }
        }

        Status_M changeStatus;
        public Status_M ChangeStatus
        {
            get => changeStatus;
            set
            {
                changeStatus = value;
                OnPropertyChanged();
            }
        }

        Otdelenie_M changeOtdelenie;
        public Otdelenie_M ChangeOtdelenie
        {
            get => changeOtdelenie;
            set
            {
                changeOtdelenie = value;
                OnPropertyChanged();
            }
        }

        RelayCommand addMonitor;
        public RelayCommand AddMonitor
        {
            get
            {
                return addMonitor ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        using (EntityContext entcon = new EntityContext())
                        {
                            if (entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == NewMonitor.Inventory.Inventory) == null)
                            {
                                NewMonitor.Status_guid = NewMonitor.Status.GID;
                                NewMonitor.Otdelenie_guid = NewMonitor.Otdelenie.GID;
                                NewMonitor.InventoryNumber = new InventoryNumber_M()
                                {
                                    Inventory = NewMonitor.Inventory.Inventory,
                                    OtdelenieGID = NewMonitor.Otdelenie.GID
                                };
                                entcon.InventoryNumbers.Update(NewMonitor.InventoryNumber);
                                ec.Inventory.Update(NewMonitor.Inventory);
                                ec.SaveChanges();
                                NewMonitor.Inventory_id = NewMonitor.Inventory.Id;
                                ec.Monitor.Update(NewMonitor);
                                ec.SaveChanges();
                                entcon.SaveChanges();

                                Log new_log = new Log()
                                {
                                    ItemId = NewMonitor.GID.ToString(),
                                    LogCategoryEnum = LogCategoryEnum.Добавление,
                                    LogTypeEnum = LogTypeEnum.Монитор,
                                    Changes =
                                        "Добавлен " + NewMonitor.TypeEquipment.Type_name + " " + NewMonitor.Manufacturer + " " + NewMonitor.Model + "\n"
                                        + "С инвентарным номером: " + NewMonitor.Inventory.Inventory + "\n"
                                        + "В отделение: " + NewMonitor.Otdelenie.Name + "\n" 
                                        + "Статус: " + NewMonitor.Status.Name,
                                    ChangeDate = DateTime.Now
                                };

                                entcon.Logs.Add(new_log);
                                entcon.SaveChanges();

                                NewMonitor = new Monitor_M()
                                {
                                    Inventory = new Inventory_m()
                                };
                                GetMonitorTable();
                            }
                            else
                            {
                                MessageBox.Show("Такой инвентарный номер уже существует", "ErrorInventory", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                },
                o =>
                NewMonitor.Manufacturer != null
                && NewMonitor.Model != null
                && NewMonitor.Inventory.Inventory != null
                && NewMonitor.Status != null
                && NewMonitor.Otdelenie != null
                && NewMonitor.TypeEquipment != null
                );
            }
        }

        RelayCommand deleteMonitor;
        public RelayCommand DeleteMonitor
        {
            get
            {
                return deleteMonitor ??= new RelayCommand(o =>
                {
                    if (MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        using (EqContext ec = new EqContext())
                        {
                            using (EntityContext entcon = new EntityContext())
                            {
                                entcon.InventoryNumbers.Remove(entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == SelectedMonitor.Inventory.Inventory));
                                Log log = new Log()
                                {
                                    ItemId = SelectedMonitor.GID.ToString(),
                                    LogCategoryEnum = LogCategoryEnum.Удаление,
                                    LogTypeEnum = LogTypeEnum.Монитор,
                                    Changes =
                                        "Удалён " + SelectedMonitor.TypeEquipment.Type_name + " " + SelectedMonitor.Manufacturer + " " + SelectedMonitor.Model + "\n"
                                        + "С инвентарным номером: " + SelectedMonitor.Inventory.Inventory + "\n"
                                        + "В отделении: " + SelectedMonitor.Otdelenie.Name + "\n",
                                    ChangeDate = DateTime.Now
                                };
                                entcon.Logs.Add(log);
                                entcon.SaveChanges();

                            }
                            ec.Inventory.Remove(SelectedMonitor.Inventory);
                            ec.Monitor.Remove(SelectedMonitor);
                            ec.SaveChanges();
                            GetMonitorTable();
                        }
                    }
                }
                , o => SelectedMonitor != null
                );
            }
        }

        RelayCommand saveMonitor;
        public RelayCommand SaveMonitor
        {
            get
            {
                return saveMonitor ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        using (EntityContext entcon = new EntityContext())
                        {
                            if (SelectedMonitor.InventoryNumber.Inventory == SelectedMonitor.Inventory.Inventory || entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == SelectedMonitor.Inventory.Inventory) == null)
                            {
                                SelectedMonitor.InventoryNumber.Inventory = SelectedMonitor.Inventory.Inventory;
                                entcon.InventoryNumbers.Update(SelectedMonitor.InventoryNumber);

                                if (ChangeType != null)
                                {
                                    SelectedMonitor.TypeEquipment = ChangeType;
                                    SelectedMonitor.TypeEq_guid = ChangeType.GID;
                                }
                                if (ChangeStatus != null)
                                {
                                    SelectedMonitor.Status = ChangeStatus;
                                    SelectedMonitor.Status_guid = ChangeStatus.GID;
                                }
                                if (ChangeOtdelenie != null)
                                {
                                    SelectedMonitor.Otdelenie = ChangeOtdelenie;
                                    SelectedMonitor.Otdelenie_guid = ChangeOtdelenie.GID;
                                }

                                Log log = GetChanges(SelectedMonitor);
                                if (log != null)
                                {
                                    entcon.Logs.Add(log);
                                }

                                ec.Inventory.Update(SelectedMonitor.Inventory);
                                ec.SaveChanges();
                                ec.Monitor.Update(SelectedMonitor);
                                ec.SaveChanges();
                                entcon.SaveChanges();
                                GetMonitorTable();
                            }
                            else
                            {
                                MessageBox.Show("Такой инвентарный номер уже существует", "ErrorInventory", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                });
            }
        }

        private Log GetChanges(Monitor_M monitor)
        {
            using (EqContext ec = new EqContext())
            {

                string changes = "Изменения\n";
                Monitor_M oldMonitor = ec.Monitor.
                    Include(x => x.TypeEquipment).
                    Include(x => x.Inventory).
                    Include(x => x.Status).
                    FirstOrDefault(x => x.GID == monitor.GID);
                using (EntityContext entcon = new EntityContext())
                {
                    oldMonitor.Otdelenie = entcon.Otdelenie.FirstOrDefault(x => x.GID == oldMonitor.Otdelenie_guid);
                }

                if (monitor.TypeEq_guid != oldMonitor.TypeEq_guid)
                {
                    changes += "Тип: " + oldMonitor.TypeEquipment.Type_name + " => " + monitor.TypeEquipment.Type_name + "\n";
                }
                if (monitor.Inventory.Inventory != oldMonitor.Inventory.Inventory)
                {
                    changes += "Инв. номер: " + oldMonitor.Inventory.Inventory + " => " + monitor.Inventory.Inventory + "\n";
                }
                if (monitor.Manufacturer != oldMonitor.Manufacturer)
                {
                    changes += "Производитель: " + oldMonitor.Manufacturer + " => " + monitor.Manufacturer + "\n";
                }
                if (monitor.Model != oldMonitor.Model)
                {
                    changes += "Модель : " + oldMonitor.Model + " => " + monitor.Model + "\n";
                }
                if (monitor.Otdelenie_guid != oldMonitor.Otdelenie_guid)
                {
                    changes += "Отделение: " + oldMonitor.Otdelenie.Name + " => " + monitor.Otdelenie.Name + "\n";
                }
                if (monitor.Status_guid != oldMonitor.Status_guid)
                {
                    changes += "Статус: " + oldMonitor.Status.Name + " => " + monitor.Status.Name + "\n";
                }

                if (changes == "Изменения\n")
                {
                    return null;
                }
                else
                    return new Log()
                    {
                        ItemId = monitor.GID.ToString(),
                        LogCategoryEnum = LogCategoryEnum.Изменение,
                        LogTypeEnum = LogTypeEnum.Монитор,
                        Changes = changes,
                        ChangeDate = DateTime.Now
                    };
            }

        }

        RelayCommand showLogs;
        public RelayCommand ShowLogs
        {
            get
            {
                return showLogs ??= new RelayCommand(o =>
                {
                    Show_log_V log_window = new Show_log_V();
                    (log_window.DataContext as Show_log_VM).GetData(SelectedMonitor.GID.ToString());
                    log_window.ShowDialog();
                });
            }
        }
        #endregion
    }
}