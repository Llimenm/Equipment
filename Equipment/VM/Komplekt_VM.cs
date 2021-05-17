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
using OKB3Admin.M;
using Microsoft.EntityFrameworkCore;

namespace Equipment.VM
{
    public class Komplekt_VM: Base_VM
    {
        public Komplekt_VM() //Инициализация 
        {
            Task.Run(() => GetStartData());
            NewItem = new Komplekt_M
            {
                Account= new Account_M()
                
            };

            OnPropertyChanged();
        }
        ObservableCollection<Komplekt_M> komplektTable; 
        public ObservableCollection<Komplekt_M> KomplektTable// Таблица комлпектов
        {
            get => komplektTable;
            set
            {
                komplektTable = value;
                OnPropertyChanged();
            }
        }

        Komplekt_M selectedItem;
        public Komplekt_M SelectedItem // Выбранный элемент
        {
            get => selectedItem;
            set
            { 
                selectedItem = value;
                GetMB_K_Table();
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
                    using (EqContext ec = new EqContext())
                    {
                        if (NewOtdelenie != null)
                            SelectedItem.Otdelenie_Id = NewOtdelenie.Id;
                        if (NewStatus != null)
                            SelectedItem.Status_id = NewStatus.Id;
                        if (NewType != null)
                            SelectedItem.Type_eq_id = NewType.id;

                        ec.Account.Update(SelectedItem.Account);
                        ec.Komplekt.UpdateRange(KomplektTable);

                        if (NewType != null)                         //Вот это кусок кода - костыль, я не знаю почему, но после назнчения selcteditem новый тип id и статус id они снова сбрасываются
                            SelectedItem.Type_eq_id = NewType.id;    // до исходных значения после updateRange.
                        if (NewStatus != null)
                            SelectedItem.Status_id = NewStatus.Id;
                        ec.SaveChanges();
                        To_do();

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

        

        RelayCommand changeMB_k;
        public RelayCommand ChangeMb_k //Вызов изменения списка материнсикх плат комплекта
        {
            get
            {
                return changeMB_k ??
                    (changeMB_k = new RelayCommand(o =>
                    {
                        Add_MB_K_V window = new Add_MB_K_V();
                        (window.DataContext as Add_MB_K_VM).ChangeOrView = true;
                        (window.DataContext as Add_MB_K_VM).SetStartData(SelectedItem.Id);
                        window.ShowDialog();
                        GetMB_K_Table();
                    }, o => SelectedItem != null
                    ));
            }
        }

        RelayCommand addMB_k;
        public RelayCommand AddMb_k //Вызов окна с добавлением мат плат в комплект
        {
            get
            {
                return addMB_k ??
                    (addMB_k = new RelayCommand(o =>
                    {
                        using (EqContext ec = new EqContext())
                        {
                            Add_MB_K_V window = new Add_MB_K_V();
                            (window.DataContext as Add_MB_K_VM).ChangeOrView = true;
                            (window.DataContext as Add_MB_K_VM).Komplekt_id = SelectedItem.Id;
                            (window.DataContext as Add_MB_K_VM).SetStartData(SelectedItem.Id);
                            window.ShowDialog();
                        }
                    }
                    ));
            }
        }

        Komplekt_M newItem;
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
                return addItem ??
                    (addItem = new RelayCommand(o => 
                    {
                        using (EqContext ec = new EqContext())
                        {
                            ec.Account.Update(NewItem.Account);
                            ec.Type_equipment.Update(NewItem.Type_Eq);
                            ec.Status.Update(NewItem.Status);
                            ec.SaveChanges();
                            NewItem.Acc_id = ec.Account.FirstOrDefault(x => x.Acc_user == NewItem.Account.Acc_user
                                && x.Password == NewItem.Account.Password).Id;
                            NewItem.Status_id = NewItem.Status.Id;
                            NewItem.Type_eq_id = NewItem.Type_Eq.id;
                            NewItem.Otdelenie_Id = NewItem.Otdelenie.Id;
                            ec.Komplekt.Update(NewItem);
                            ec.SaveChanges();
                            GetStartData();
                            NewItem = new Komplekt_M
                            {
                                Account = new Account_M()

                            };
                        }
                    }, o => 
                    NewItem.Status != null 
                    & NewItem.Account.Acc_user != null 
                    & NewItem.Account.Password != null
                    & NewItem.Inventory != null
                    & NewItem.Type_Eq != null
                    & NewItem.Otdelenie != null
                    ));
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
                        List<MB_K_M> deleteList = new List<MB_K_M>(ec.Motherboards_K.Where(x => x.Komplekt_Id == SelectedItem.Id).ToList());
                        foreach (var item in deleteList)
                        {
                            ec.Motherboards_K.Remove(item);
                        }
                        ec.SaveChanges();
                        ec.Komplekt.Remove(SelectedItem);
                        ec.SaveChanges();
                        GetStartData();
                    }
                }, o => SelectedItem != null);
            }
        }


        public async Task GetStartData() //получение данных
        {
            using (EqContext ec = new EqContext())
            {
                CurrentPage = 1;
                To_do();
                Statuses = new ObservableCollection<Status_M>(ec.Status.ToList());
                TypeList = new Collection<Type_eq_M>(ec.Type_equipment.ToList());
                using (EntityContext EntCont = new EntityContext())
                {
                    Otdelenies = new ObservableCollection<Otdelenie_M>(EntCont.Otdelenie.ToList());
                }
            }
            await Task.CompletedTask;
        }

        private async Task GetMB_K_Table()
        {
            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Motherboards_K.Where(x => x.Komplekt_Id == SelectedItem.Id).ToList();
                foreach (var item in tmp)
                {
                    item.Motherboard = ec.Motherboards.FirstOrDefault(x => x.Id == item.MB_id);
                }
                Mb_K_Table = new ObservableCollection<MB_K_M>(tmp);
            }
            await Task.CompletedTask;
        }


        ObservableCollection<MB_K_M> mb_k_table;
        public ObservableCollection<MB_K_M> Mb_K_Table // Таблица мат. плат выбранного комплекта
        {
            get => mb_k_table;
            set
            {
                mb_k_table = value;
                OnPropertyChanged();
            }
        }

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
                To_do();
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
                To_do();
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
                To_do();
                OnPropertyChanged();
            }
        }
        void To_do()
        {
            using (EqContext ec = new EqContext())
            {
                

                var i = ec.Komplekt.Include(x => x.Account).
                Where(x => (string.IsNullOrEmpty(FilterName) ? x.Account.Acc_user.Contains("") : x.Account.Acc_user.Contains(FilterName)) &
                (SelectedFilterStatus != null ? x.Status_id == SelectedFilterStatus.Id : x.Status_id.ToString().Contains(""))&
                (SelectedFilterInventory != null ? x.Inventory.Contains(SelectedFilterInventory) : x.Inventory.Contains(""))&
                (SelectedFilterType != null ? x.Type_eq_id == SelectedFilterType.id : x.Type_eq_id.ToString().Contains(""))&
                (SelectedFilterOtdelenie != null ? x.Otdelenie_Id == SelectedFilterOtdelenie.Id : x.Otdelenie_Id.ToString().Contains(""))).
                Skip((CurrentPage - 1) * 25).
                Take(25);
                AllPage = Convert.ToInt32(Math.Round(i.Count() / 25d, MidpointRounding.ToPositiveInfinity));
                using (EntityContext entCont = new EntityContext())
                {
                    foreach (var item in i)
                    {
                        item.Otdelenie = entCont.Otdelenie.FirstOrDefault(x => x.Id == item.Otdelenie_Id);
                    }
                }
                KomplektTable = new ObservableCollection<Komplekt_M>(i.Include(x=>x.Status).Include(x => x.Type_Eq).OrderBy(x=>x.Id));
                NewItem.Status = null;
                NewItem.Otdelenie = null;
            }
        }

        RelayCommand filtered;
        public RelayCommand Filtered
        {
            get
            {
                return filtered ??= new RelayCommand(o =>
                {
                    To_do();
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
                    FilterName = null;
                    SelectedFilterInventory = null;
                    SelectedFilterStatus = null;
                    selectedFilterType = null;
                    To_do();
                });
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
                    To_do();
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
                    To_do();
                }, o => CurrentPage < AllPage);
            }
        }
    }
}
