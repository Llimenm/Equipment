using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
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

        int komplekt_id;
        public int Komplekt_id
        {
            get => komplekt_id;
            set
            {
                komplekt_id = value;
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

        /// <summary>
        /// Выборка мониторов поставленных с комплектом
        /// </summary>
        /// <param name="k_id"></param>
        /// <returns></returns>
        public async Task GetMonitorKomplekt(int k_id)
        {
            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Monitor_komplekt.Where(x => x.Komplekt_id == k_id);
                MonitorKomplektTable = new ObservableCollection<Monitor_Komplekt_M>(await tmp.Include(x => x.Monitor).ToListAsync());
                Komplekt_id = k_id;
            }
        }

        RelayCommand addMonitor_in_Komplekt;
        public RelayCommand AddMonitor_in_Komplekt
        {
            get
            {
                return addMonitor_in_Komplekt ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        Monitor_Komplekt_M NewMonitorInKomplekt = new Monitor_Komplekt_M
                        {
                            Monitor = SelectedMonitor,
                            Monitor_id = SelectedMonitor.Id,
                            Komplekt_id = Komplekt_id,
                            Ports_id = SelectedMonitor.Ports_id,
                            Inventory = InventoryName
                        };
                        ec.Monitor_komplekt.Update(NewMonitorInKomplekt);
                        ec.SaveChanges();
                        Task.Run(() => GetMonitorKomplekt(Komplekt_id));
                        InventoryName = null;
                    }
                },o => InventoryName != null);
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
    }
}
