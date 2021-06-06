using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Type_eq_M : BaseModelWithGUID
    {
        string type_name;
        /// <summary>
        /// Наименование типа оборудования
        /// </summary>
        public string Type_name
        {
            get => type_name;
            set
            {
                type_name = value;
                OnPropertyChanged();
            }
        }
    }
}
