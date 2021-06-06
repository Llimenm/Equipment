using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Ram_type_M : BaseModelWithGUID
    {
        string name;
        /// <summary>
        /// Имя типа памяти
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
