using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class MB_K_M : Base_M
    {
        public int Id { get; set; }

        int komplekt_id;
        /// <summary>
        /// Номер комплекта материнских плат
        /// </summary>
        public int Komplekt_Id
        {
            get => komplekt_id;
            set
            {
                komplekt_id = value;
                OnPropertyChanged();
            }
        }
        int mb_id;
        /// <summary>
        /// Id материнской платы
        /// </summary>
        public int MB_id
        {
            get => mb_id;
            set
            {
                mb_id = value;
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
        string inventory;
        /// <summary>
        /// Инвентарник материнки
        /// </summary>
        public string Inventory
        {
            get => inventory;
            set
            {
                inventory = value;
                OnPropertyChanged();
            }
        }
        [ForeignKey("MB_id")]
        public MB_M Motherboard { get; set; }

        [ForeignKey("Komplekt_Id")]
        public Komplekt_M Komplekt { get; set; }
    }
}
