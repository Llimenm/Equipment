using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.VM
{
    public class Monitor_VM : Base_VM
    {
        public Monitor_VM() { }

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

        public async Task GetData()
        {
            NewMonitor = new Monitor_M();
            CurrentPage = 1;
            await Task.Run(() => GetManufacturerList());
            await Task.Run(() => GetMonitorTable());
            await Task.CompletedTask;
        }

        public async Task GetManufacturerList()
        {
            using (EqContext ec = new EqContext())
            {
                ManufacturerList = new ObservableCollection<Monitor_M>(await ec.Monitor.GroupBy(x => x.Manufacturer).Select(x => new Monitor_M { Manufacturer = x.Key }).ToListAsync());
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
                Allpage = Convert.ToInt32(Math.Ceiling(ec.Monitor.Where(x => string.IsNullOrEmpty(FilterModel) ? x.Model.Contains("") : x.Model.Contains(FilterModel)).
                Where(x => FilterManufacturer == null ? x.Manufacturer.Contains("") : x.Manufacturer.Contains(FilterManufacturer.Manufacturer)).Count() / 25d));
                var tmp = ec.Monitor.Where(x => string.IsNullOrEmpty(FilterModel) ? x.Model.Contains("") : x.Model.Contains(FilterModel)).
                Where(x => FilterManufacturer == null ? x.Manufacturer.Contains("") : x.Manufacturer.Contains(FilterManufacturer.Manufacturer)).
                Skip((CurrentPage - 1) * 25).
                Take(25);
                MonitorTable = new ObservableCollection<Monitor_M>(tmp.ToList());
            }
            await Task.CompletedTask;
        }

        #endregion

        #region Filter элементы

        Monitor_M filterManufacturer;
        public Monitor_M FilterManufacturer
        {
            get => filterManufacturer;
            set
            {
                filterManufacturer = value;
                AcceptFilterMethod();
                OnPropertyChanged();
            }
        }

        string filterModel;
        public string FilterModel
        {
            get => filterModel;
            set
            {
                filterModel = value;
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
                    AcceptFilterMethod();
                });
            }

        }
        /// <summary>
        /// Применение фильтра, вызывает GetMonitorTable
        /// </summary>
        private void AcceptFilterMethod()
        {
            GetMonitorTable();
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
                    Task.Run(() => GetMonitorTable());
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
                }, o => CurrentPage > 1 );
            }
        }

        #endregion

        #region Управление данными
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

        Monitor_M newMonitor;
        public Monitor_M NewMonitor
        {
            get => newMonitor;
            set
            {
                newMonitor = value;
                OnPropertyChanged();
            }
        }

        Monitor_M newManufacturer;
        public Monitor_M NewManufacturer
        {
            get => newManufacturer;
            set
            {
                newManufacturer = value;
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
                        ec.Monitor.Update(NewMonitor);
                        ec.SaveChanges();
                        NewMonitor = new Monitor_M();
                        CurrentPage = Allpage;
                        GetMonitorTable();
                    }
                });
            }
        }

        RelayCommand deleteMonitor;
        public RelayCommand DeleteMonitor
        {
            get
            {
                return deleteMonitor ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        ec.Monitor.Remove(SelectedMonitor);
                        ec.SaveChanges();
                        GetMonitorTable();
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
                        if(newManufacturer != null)
                        {
                            SelectedMonitor.Manufacturer = NewManufacturer.Manufacturer;
                        }
                        ec.Monitor.Update(SelectedMonitor);
                        ec.SaveChanges();
                        GetManufacturerList();
                        NewManufacturer = null;
                    }
                });
            }
        }

        #endregion

    }
}
