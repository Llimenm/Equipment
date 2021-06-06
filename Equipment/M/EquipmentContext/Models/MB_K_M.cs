using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class MB_K_M : BaseModelWithID
    {
        Guid? komplekt_guid;
        /// <summary>
        /// Номер комплекта материнских плат
        /// </summary>
        public Guid? Komplekt_guid
        {
            get => komplekt_guid;
            set
            {
                komplekt_guid = value;
                OnPropertyChanged();
            }
        }
        Guid? motherboard_guid;
        /// <summary>
        /// Id материнской платы
        /// </summary>
        public Guid? Motherboard_guid
        {
            get => motherboard_guid;
            set
            {
                motherboard_guid = value;
                OnPropertyChanged();
            }
        }
        int ports_id;
        /// <summary>
        /// Id количества портов
        /// </summary>
        public int Ports_id
        {
            get => ports_id;
            set
            {
                ports_id = value;
                OnPropertyChanged();
            }
        }
        string serialNumber;
        /// <summary>
        /// Серийник материнки
        /// </summary>
        public string SerialNumber
        {
            get => serialNumber;
            set
            {
                serialNumber = value;
                OnPropertyChanged();
            }
        }
        [ForeignKey("Motherboard_guid")]
        public MB_M Motherboard { get; set; }

        [ForeignKey("Komplekt_guid")]
        public Komplekt_M Komplekt { get; set; }
    }
}
