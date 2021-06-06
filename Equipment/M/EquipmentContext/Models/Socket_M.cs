using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Socket_M: BaseModelWithGUID
    {
        string name;
        /// <summary>
        /// Наименование сокета
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }
}
