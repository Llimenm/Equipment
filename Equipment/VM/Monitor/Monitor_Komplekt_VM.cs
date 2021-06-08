using Equipment.M;
using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin.M.InventorySystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.VM
{
    public class Monitor_Komplekt_VM : Monitor_VM
    {
        #region 
        #endregion
        string inventoryName;
        public string InventoryName
        {
            get => inventoryName;
            set
            {
                inventoryName = value;
                OnPropertyChanged();
            }
        }

        Guid? komplekt_id;
        public Guid? Komplekt_id
        {
            get => komplekt_id;
            set
            {
                komplekt_id = value;
                OnPropertyChanged();
            }
        }

        bool checkBoxForKomplekt;
        public bool CheckBoxForKomplekt
        {
            get => checkBoxForKomplekt;
            set
            {
                checkBoxForKomplekt = value;
                OnPropertyChanged();
            }
        }

        string searchBox;
        public string SearchBox
        {
            get => searchBox;
            set
            {
                searchBox = value;
                OnPropertyChanged();
            }
        }

        Monitor_Komplekt_M selectedMonitorKomplekt;
        public Monitor_Komplekt_M SelectedMonitorKomplekt
        {
            get => selectedMonitorKomplekt;
            set
            {
                selectedMonitorKomplekt = value;
                OnPropertyChanged();
            }
        }


        ObservableCollection<Monitor_Komplekt_M> monitorKomplektTable;
        public  ObservableCollection<Monitor_Komplekt_M> MonitorKomplektTable
        {
            get => monitorKomplektTable;
            set 
            {
                monitorKomplektTable = value;
                OnPropertyChanged();
            }
        }

        #region Get Запросы
        /// <summary>
        /// Выборка мониторов поставленных с комплектом
        /// </summary>
        /// <param name="komplekt_guid"></param>
        /// <returns></returns>
        public ObservableCollection<Monitor_Komplekt_M> GetMonitorKomplekt(Guid? komplekt_guid)
        {
            using (EqContext ec = new EqContext())
            {
                ObservableCollection<Monitor_Komplekt_M> tmp =new ObservableCollection<Monitor_Komplekt_M>
                    (ec.Monitor_komplekt.
                    Where(x => x.Komplekt_guid == komplekt_guid 
                    && (x.Monitor.Manufacturer.Contains(SearchBox) || x.Monitor.Model.Contains(SearchBox) || x.InventoryNumber.Inventory.Contains(SearchBox))));
                Komplekt_id = komplekt_guid;
                return tmp;
            }
        }

        /// <summary>
        /// Выборка мониторов на учете
        ///
        public ObservableCollection<Monitor_Komplekt_M> GetMonitorKomplekt()
        {
            using (EqContext ec = new EqContext())
            {
                ObservableCollection<Monitor_Komplekt_M> tmp = new ObservableCollection<Monitor_Komplekt_M>(ec.Monitor_komplekt);
                return tmp;
            }
        }

        /// <summary>
        /// Вывод в view итоговой таблицы
        /// </summary>
        public void GetMonitorKomplekt_checkbox()
        {
            ObservableCollection<Monitor_Komplekt_M> tmp;
            if (checkBoxForKomplekt == true)
            {
                tmp = GetMonitorKomplekt(Komplekt_id);
            }
            else
            {
                tmp = GetMonitorKomplekt();
            }

            allPageUchet = Convert.ToInt32(Math.Ceiling(tmp.Count() / 25d));
            MonitorKomplektTable = new ObservableCollection<Monitor_Komplekt_M>(tmp.Skip((CurrentPageUchet - 1) * 25).Take(25));

        }

        #endregion

        #region Добавление/удаление
        RelayCommand addMonitor_in_Komplekt;
        public RelayCommand AddMonitor_in_Komplekt
        {
            get
            {
                return addMonitor_in_Komplekt ??= new RelayCommand(o =>
                {
                    using (EntityContext entcon = new EntityContext())
                    {
                        if (entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == InventoryName) == null)
                        {
                            using (EqContext ec = new EqContext())
                            {
                                Monitor_Komplekt_M NewMonitorInKomplekt = new Monitor_Komplekt_M
                                {
                                    Monitor = SelectedMonitor,
                                    Monitor_guid = SelectedMonitor.GID,
                                    Komplekt_guid = Komplekt_id,
                                    Ports_id = SelectedMonitor.Ports_id
                                };
                                InventoryNumber_M NewInventory = new InventoryNumber_M
                                {
                                    Inventory = InventoryName
                                };

                                entcon.InventoryNumbers.Update(NewInventory);
                                entcon.SaveChanges();
                                NewMonitorInKomplekt.Inventory_id = entcon.InventoryNumbers.FirstOrDefault(x => x.Inventory == InventoryName).Id;

                                ec.Monitor_komplekt.Update(NewMonitorInKomplekt);
                                ec.SaveChanges();
                                GetMonitorKomplekt_checkbox();
                                InventoryName = null;
                            }
                        }
                    }
                }, o => InventoryName != null);
            }
        }

        RelayCommand deleteMonitorKomplekt;
        public RelayCommand DeleteMonitorKomplekt
        {
            get
            {
                return deleteMonitorKomplekt ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        ec.Monitor_komplekt.Remove(SelectedMonitorKomplekt);
                        ec.SaveChanges();
                        GetMonitorKomplekt(Komplekt_id);
                        SelectedMonitorKomplekt = null;
                    }
                }, o => SelectedMonitorKomplekt != null);
            }
        }

        #endregion

        #region Пагинация для мониторов в учете

        int currentPageUchet = 1;
        public int CurrentPageUchet
        {
            get => currentPageUchet;
            set
            {
                currentPageUchet = value;
                OnPropertyChanged();
            }
        }
        int allPageUchet;
        public int AllpageUchet
        {
            get => allPageUchet;
            set
            {
                allPageUchet = value;
                OnPropertyChanged();
            }
        }

        RelayCommand nextPageUchet;
        public RelayCommand NextPageUchet
        {
            get
            {
                return nextPageUchet ??= new RelayCommand(o =>
                {
                    CurrentPageUchet += 1;
                    
                }, o => CurrentPageUchet < AllpageUchet);
            }
        }

        RelayCommand previousPageUchet;
        public RelayCommand PreviousPageUchet
        {
            get
            {
                return previousPageUchet ??= new RelayCommand(o =>
                {
                    CurrentPageUchet -= 1;

                }, o => CurrentPageUchet > 1);
            }
        }

        #endregion

    }
}
