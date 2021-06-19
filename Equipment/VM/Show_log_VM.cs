using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Equipment.M;
using Equipment.M.EquipmentContext;
using Equipment_accounting.Data;
using OKB3Admin;
using OKB3Admin.M.Printers;

namespace Equipment.VM
{
    public class Show_log_VM : BaseModelForVM
    {
        public Show_log_VM()
        {

        }

        ObservableCollection<ExtLog> logTable = new ObservableCollection<ExtLog>();
        public ObservableCollection<ExtLog> LogTable
        {
            get => logTable;
            set
            {
                logTable = value;
                OnPropertyChanged();
            }
        }

        ExtLog selectedLog;
        public ExtLog SelectedLog
        {
            get => selectedLog;
            set
            {
                selectedLog = value;
                OnPropertyChanged();
            }
        }

        string id_item;

        /// <summary>
        /// Запрос за получение данных
        /// </summary>
        public void GetData(string id_guid_item)
        {
            LogTable = new ObservableCollection<ExtLog>();
            id_item = id_guid_item;
            using (EntityContext entcon = new EntityContext())
            {
                var tmp = entcon.Logs.
                    Where(x => 
                    x.ItemId == id_guid_item &&
                    (SearchBox != "" ? x.Changes.Contains(SearchBox) : x.Changes.Contains(""))).
                    OrderByDescending(x => x.ChangeDate);

                foreach (var item in tmp)
                {
                    ExtLog extLog = new ExtLog()
                    {
                        Id = item.Id,
                        Changes = item.Changes,
                        ChangeDate = item.ChangeDate,
                        ItemId = item.ItemId,
                        LogCategoryEnum = item.LogCategoryEnum,
                        LogTypeEnum = item.LogTypeEnum,
                        UserId = item.UserId,
                    };

                    switch (item.LogCategoryEnum)
                    {
                        case LogCategoryEnum.Добавление:
                            extLog.LogCategory = "Добавление";
                            break;
                        case LogCategoryEnum.Изменение:
                            extLog.LogCategory = "Изменение";
                            break;
                        case LogCategoryEnum.Удаление:
                            extLog.LogCategory = "Удаление";
                            break;
                    }

                    switch(item.LogTypeEnum)
                    {
                        case LogTypeEnum.Картридж:
                            extLog.LogType = "Картридж";
                            break;
                        case LogTypeEnum.Комплекты:
                            extLog.LogType = "Комплекты";
                            break;
                        case LogTypeEnum.Монитор:
                            extLog.LogType = "Монитор";
                            break;
                        case LogTypeEnum.Принтер:
                            extLog.LogType = "Принтер";
                            break;
                    }
                    LogTable.Add(extLog);
                }
            }
        }

        RelayCommand acceptFilter;
        public RelayCommand AcceptFilter
        {
            get
            {
                return acceptFilter ??= new RelayCommand(o =>
                {
                    GetData(id_item);
                });
            }
        }

        string searchBox = "";
        public string SearchBox
        {
            get => searchBox;
            set
            {
                searchBox = value;
                OnPropertyChanged();
            }
        }
    }
    public class ExtLog : Log
    {
        string logCategory;
        public string LogCategory
        {
            get => logCategory;
            set
            {
                logCategory = value;
                OnPropertyChanged();
            }
        }

        string logType;
        public string LogType
        {
            get => logType;
            set
            {
                logType = value;
                OnPropertyChanged();
            }
        }


    }
}
