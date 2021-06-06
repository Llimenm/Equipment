using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment.V;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;

namespace Equipment.VM
{
    public class Motherboard_Komplekt_VM : BaseModelForVM
    {
        public Motherboard_Komplekt_VM() 
        {
           
        }

        public async Task SetStartData()
        {
            await GetFilterList();
            await Task.Run(() => GetMbTable());
            currentPageMb = 1;


            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Motherboards.GroupBy(x => x.Manufacturer).Select(x => new MB_M { Manufacturer = x.Key });
                ManufacturerList = new ObservableCollection<MB_M>(tmp.ToList());
                ChipsetTable = new ObservableCollection<Chipset_M>(ec.Chipset.ToList());
                SocketList = new ObservableCollection<Socket_M>(ec.Socket.ToList());
                RamTypeList = new ObservableCollection<Ram_type_M>(ec.Ram_type.ToList());
            }
        }

        public void SetStartData(Guid? komplekt_id)
        {
            GetFilterList();
            Task.Run(() => GetMbTable());
            currentPageMb = 1;


            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Motherboards.GroupBy(x => x.Manufacturer).Select(x=> new MB_M { Manufacturer = x.Key });
                ManufacturerList = new ObservableCollection<MB_M>(tmp.ToList());
                ChipsetTable = new ObservableCollection<Chipset_M>(ec.Chipset.ToList());
                SocketList = new ObservableCollection<Socket_M>(ec.Socket.ToList());
                RamTypeList = new ObservableCollection<Ram_type_M>(ec.Ram_type.ToList());
            }
            Komplekt_id = komplekt_id;
            if (ChangeOrView) 
            {
                Task.Run(() => GetMb_K_Table());
            }
            currentPageMb = 1;
            currentPageMb_k = 1;
        }
        public Guid? Komplekt_id { get; set; } //Номер комплекта в который добавлять платы
        bool changeOrView;
        /// <summary>
        /// Переменная которая сменяет просмотр или изменение комплектов мат плат и самих мат плат
        /// </summary>
        public bool ChangeOrView 
        {
            get => changeOrView; 
            set
            {
                changeOrView = value;
                OnPropertyChanged();
            } 
        }



        #region редактирование предмета в строке таблицы
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
        Chipset_M new_chipset_M = new Chipset_M();
        public Chipset_M NewChipset_M 
        {
            get => new_chipset_M;
            set
            {
                
                
                if (value == null)
                {
                    new_chipset_M = new Chipset_M();
                }
                else
                {
                    new_chipset_M = value;
                }
                OnPropertyChanged();
            }
        }

        ObservableCollection<MB_M> manufacturerList;
        public ObservableCollection<MB_M> ManufacturerList
        { 
            get => manufacturerList;
            set
            {
                manufacturerList = value;
                OnPropertyChanged();
            }
        }
        MB_M newManufacturer = new MB_M();
        public MB_M NewManufacturer
        {
            get => newManufacturer;
            set
            {
                newManufacturer = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Socket_M> socketList;
        public ObservableCollection<Socket_M> SocketList
        {
            get => socketList;
            set
            {
                socketList = value;
                OnPropertyChanged();
            }
        }

        Socket_M newSocket = new Socket_M();
        public Socket_M NewSocket
        {
            get => newSocket;
            set
            {
                newSocket = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Ram_type_M> ramTypeList;
        public ObservableCollection<Ram_type_M> RamTypeList
        {
            get => ramTypeList;
            set
            {
                ramTypeList = value;
                OnPropertyChanged();
            }
        }
        Ram_type_M newRamType = new Ram_type_M();
        public Ram_type_M NewRamType
        {
            get => newRamType;
            set
            {
                if (value == null)
                {
                    newRamType = new Ram_type_M();
                }
                else
                {
                    newRamType = value;
                }
                
                OnPropertyChanged();
            }
        }

        RelayCommand saveMB;
        public RelayCommand SaveMB
        {
            get
            {
                return saveMB ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        if (NewSocket.Name != null && NewSocket.Name != "")
                        {
                            if (ec.Socket.FirstOrDefault(x => x.GID == NewSocket.GID) == null)
                            {
                                ec.Socket.Update(NewSocket);
                                ec.SaveChanges();
                            }
                            SelectedItem.Socket_guid = NewSocket.GID;
                            SelectedItem.Socket = NewSocket;
                        }

                        if (NewChipset_M.Name != null && NewChipset_M.Name != "")
                        {
                            var tmp = ec.Chipset.FirstOrDefault(x => x.GID == NewChipset_M.GID);
                            if (tmp == null)
                            {
                                Select_socket_on_chipset win = new Select_socket_on_chipset();
                                MessageBox.Show("Выберите сокет для нового чипсета");
                                win.ShowDialog();
                                if ((win.DataContext as Select_socket_on_chipset_VM).ChooosedSocket != null)
                                {
                                    NewChipset_M.Socket_guid = (win.DataContext as Select_socket_on_chipset_VM).ChooosedSocket.GID;
                                    NewChipset_M.Socket = (win.DataContext as Select_socket_on_chipset_VM).ChooosedSocket;
                                }
                                else
                                    goto IfOut;



                                ec.Chipset.Update(NewChipset_M);
                                ec.SaveChanges();
                            }
                            SelectedItem.Chipset_guid = NewChipset_M.GID;
                            SelectedItem.Chipset = NewChipset_M;
                        }
                                             

                        IfOut:
                        if (NewManufacturer.Manufacturer != null && NewManufacturer.Manufacturer != "")
                        {
                            SelectedItem.Manufacturer = NewManufacturer.Manufacturer;
                        }
                        
                        if (NewRamType.Name != null && NewRamType.Name != "")
                        {
                            if (ec.Ram_type.FirstOrDefault(x => x.GID == NewRamType.GID) == null)
                            {
                                ec.Ram_type.Update(NewRamType);
                                ec.SaveChanges();
                            }
                            SelectedItem.Ram_type_guid = NewRamType.GID;
                            SelectedItem.Ram_Type = NewRamType;
                        }

                        ec.Motherboards.UpdateRange(MbTable);
                        ec.SaveChanges();
                    }
                });
            }
        }
        #endregion

        //Ниже: Блок кода связанный с таблицей мат плат
        ObservableCollection<MB_M> mbTable;
        public ObservableCollection<MB_M> MbTable //Таблица материнок
        {
            get => mbTable;
            set
            {
                mbTable = value;
                OnPropertyChanged();
            }
        }
        MB_M selectedItem;
        public MB_M SelectedItem //Выбранная материнская плата
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        string serialNumber;
        public string SerialNumber // Назначение инв. номера мат платам идущим в комплекты
        {
            get => serialNumber;
            set
            {
                serialNumber = value;
                OnPropertyChanged();
            }
        }
        RelayCommand add_mb_in_k;
        public RelayCommand Add_mb_in_k //Добавление мат платы в комплект
        {
            get
            {
                return add_mb_in_k ??= new RelayCommand(o =>
                {
                    MB_K_M newItem = new MB_K_M();
                    newItem.Komplekt_guid = Komplekt_id;
                    newItem.Motherboard_guid = selectedItem.GID;
                    newItem.Ports_id = selectedItem.Ports_id;
                    if (serialNumber != "" && serialNumber != null)
                    {
                        newItem.SerialNumber = SerialNumber;
                        using (EqContext ec = new EqContext())
                        {
                            ec.Motherboards_K.Update(newItem);
                            ec.SaveChanges();
                            GetMb_K_Table();
                        }
                    }
                }, o => SelectedItem != null && SerialNumber != null);
            }
        }
        int allPageMb;
        public int AllPageMb //Все страницы мат плат
        {
            get => allPageMb;
            set
            {
                allPageMb = value;
                OnPropertyChanged();
            }
        }
        int currentPageMb;
        public int CurrentPageMb// Текущая страница мат плат
        {
            get => currentPageMb;
            set
            {
                currentPageMb = value;
                OnPropertyChanged();
            }
        }
        RelayCommand nextPageMb;
        public RelayCommand NextPageMb //Команда перключения на след страницу мат плат
        {
            get
            {
                return nextPageMb ??= new RelayCommand(o => 
                {
                    CurrentPageMb += 1;
                    GetMbTable();
                }, o => currentPageMb < Convert.ToInt32(allPageMb));
            }

        }
        RelayCommand previousPageMb;
        public RelayCommand PreviousPageMb //Команда перключения на пред страницу мат плат
        {
            get
            {
                return previousPageMb ??= new RelayCommand(o =>
                {
                    CurrentPageMb -= 1;
                    GetMbTable();
                }, o => currentPageMb > 1);
            }

        }
        public async Task GetMbTable() //Получение данных по мат платам
        {
            using (EqContext ec = new EqContext())
            {
                AllPageMb = Convert.ToInt32(Math.Round(ec.Motherboards.Count() / 25d, MidpointRounding.ToPositiveInfinity));
                var tmp = ec.Motherboards.
                    Where(x => SelectedFilterManufacturer == null ? x.Manufacturer.Contains("") : x.Manufacturer.Contains(SelectedFilterManufacturer.Manufacturer)).
                    Where(x => SelectedFilterModel == null ? x.Model.Contains("") : x.Model.Contains(SelectedFilterModel)).
                    Where(x => SelectedFilterSocket == null ? true : x.Socket_guid == ec.Socket.FirstOrDefault(o => o.Name.Contains(SelectedFilterSocket)).GID).
                    Skip((currentPageMb - 1) * 25).
                    Take(25).
                    ToList();
                foreach (var item in tmp)
                {
                    item.Socket = ec.Socket.FirstOrDefault(x => x.GID == item.Socket_guid);
                    item.Chipset = ec.Chipset.FirstOrDefault(x => x.GID == item.Chipset_guid);
                    item.Ram_Type = ec.Ram_type.FirstOrDefault(x => x.GID == item.Ram_type_guid);
                }

                MbTable = new ObservableCollection<MB_M>(tmp);

            }
            await Task.CompletedTask;
        }

        RelayCommand addNewMotherboard;
        public RelayCommand AddNewMotherboard
        {
            get
            {
                return addNewMotherboard ??= new RelayCommand(o =>
                {
                        
                });
            }
        }

        //Ниже: Блок кода связанный с комплектом мат плат

        MB_K_M selectedMotherboardKomplekt;
        public MB_K_M SelectedMotherboardKomplekt
        {
            get => selectedMotherboardKomplekt;
            set
            {
                selectedMotherboardKomplekt = value;
                OnPropertyChanged();
            }
        }
        ObservableCollection<MB_K_M> mb_k_table;
        public ObservableCollection<MB_K_M> Mb_K_table //Таблица комплекта с материнскими платами
        {
            get => mb_k_table;
            set
            {
                mb_k_table = value;
                OnPropertyChanged();
            }
        }
        int allPageMb_k;
        public int AllPageMb_k //Все страницы с мат платами комплекта 
        {
            get => allPageMb_k;
            set
            {
                allPageMb_k = value;
                OnPropertyChanged();
            }
        }
        int currentPageMb_k;
        public int CurrentPageMb_k// Текущая страница комплекта с мат платами
        {
            get => currentPageMb_k;
            set
            {
                currentPageMb_k = value;
                OnPropertyChanged();
            }
        }
        RelayCommand nextPageMb_k;
        public RelayCommand NextPageMb_k //Команда перключения на след страницу комплектв с мат платами
        {
            get
            {
                return nextPageMb_k ??= new RelayCommand(o =>
                {
                    CurrentPageMb_k += 1;
                    GetMb_K_Table();
                }, o => currentPageMb_k < Convert.ToInt32(allPageMb_k));
            }

        }
        RelayCommand previousPageMb_k;
        public RelayCommand PreviousPageMb_k //Команда перключения на пред страницу комплекта мат платами
        {
            get
            {
                return previousPageMb_k ??= new RelayCommand(o =>
                {
                    CurrentPageMb_k -= 1;
                    GetMb_K_Table();
                }, o => currentPageMb_k > 1);
            }

        }
        public async Task GetMb_K_Table() //Получение данных по комплекту
        {

            using (EqContext ec = new EqContext())
            {
                AllPageMb_k = Convert.ToInt32(Math.Round(ec.Motherboards_K.Where(x => x.Komplekt_guid == Komplekt_id).Count() / 25d, MidpointRounding.ToPositiveInfinity));
                var tmp = ec.Motherboards_K.Where(x => x.Komplekt_guid == Komplekt_id).Skip((CurrentPageMb_k - 1) * 25).Take(25).ToList();
                foreach (var item in tmp)
                {
                    item.Motherboard = ec.Motherboards.FirstOrDefault(x => x.GID == item.Motherboard_guid);
                }
                Mb_K_table = new ObservableCollection<MB_K_M>(tmp);
            }
            await Task.CompletedTask;
        }


        //Ниже: блок фильтрации
        MB_M selectedFilterManufacturer;
        public MB_M SelectedFilterManufacturer
        {
            get => selectedFilterManufacturer;
            set
            {
                selectedFilterManufacturer = value;
                GetMbTable();
                OnPropertyChanged();
            }
        }

        string selectedFilterModel;
        public string SelectedFilterModel
        { 
            get => selectedFilterModel;
            set
            {
                selectedFilterModel = value;
                OnPropertyChanged();
            }
        }


        ObservableCollection<MB_M> filterList_ModelMb;
        public ObservableCollection<MB_M> FilterList_ModelMb
        {
            get => filterList_ModelMb;
            set
            {
                filterList_ModelMb = value;
                OnPropertyChanged();
            }
        }

        string selectedFilterSocket;
        public string SelectedFilterSocket
        {
            get => selectedFilterSocket;
            set
            {
                selectedFilterSocket = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<MB_M> filterList_ManufacturerMb;
        public ObservableCollection<MB_M> FilterList_ManufacturerMb //Список для фильтрации мат плат по производителям 
        {
            get => filterList_ManufacturerMb;
            set
            {
                filterList_ManufacturerMb = value;
                OnPropertyChanged();
            }
        }
        public async Task GetFilterList()
        {
            using (EqContext ec = new EqContext())
            {
                FilterList_ModelMb = new ObservableCollection<MB_M>(await ec.Motherboards.
                    GroupBy( x => x.Model).
                    Select(x => new MB_M {Model = x.Key}).
                    ToListAsync());

                FilterList_ManufacturerMb =  new ObservableCollection<MB_M>(await ec.Motherboards.
                    GroupBy(x => x.Manufacturer).
                    Select(x => new MB_M { Manufacturer = x.Key }).
                    ToListAsync());
                
            }
            await Task.CompletedTask;
        }

        RelayCommand declineFilter;
        public RelayCommand DeclineFilter
        {
            get
            {
                return declineFilter ??= new RelayCommand(o =>
                {
                    SelectedFilterManufacturer = null;
                    SelectedFilterModel = null;
                    SelectedFilterSocket = null;
                    GetMbTable();
                }
                );
            }
        }
        RelayCommand acceptFilter;
        public RelayCommand AcceptFilter
        {
            get
            {
                return acceptFilter ??= new RelayCommand(o =>
                {
                    GetMbTable();
                }
                );
            }
        }

        RelayCommand deleteSelectedMB_in_K;
        public RelayCommand DeleteSelectedMb_in_K
        {
            get
            {
                return deleteSelectedMB_in_K ??= new RelayCommand(o =>
                {
                    using (EqContext ec = new EqContext())
                    {
                        ec.Motherboards_K.Remove(SelectedMotherboardKomplekt);
                        ec.SaveChanges();
                        GetMb_K_Table();
                    }
                });
            }
        }


    }
}
