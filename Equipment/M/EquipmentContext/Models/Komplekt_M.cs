using OKB3Admin;
using OKB3Admin.M.InventorySystem;
using OKB3Admin.M.Structura;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipment.M.EquipmentContext.Models
{
    public class Komplekt_M : BaseModelWithGUID
    {
        Guid? type_eq_guid;
        /// <summary>
        /// Тип оборудования
        /// </summary>
        public Guid? Type_eq_guid
        {
            get => type_eq_guid;
            set
            {
                type_eq_guid = value;
                OnPropertyChanged();
            }
        }

        Guid? status_guid;
        /// <summary>
        /// Id статуса
        /// </summary>
        public Guid? Status_guid
        {
            get => status_guid;
            set
            {
                status_guid = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Инвентарный номер
        /// </summary>
        int inventory_id;
        public int Inventory_id
        {
            get => inventory_id;
            set
            {
                inventory_id = value;
                OnPropertyChanged();
            }
        }

        Guid? otdelenie_gid;
        public Guid? Otdelenie_gid
        {
            get => otdelenie_gid;
            set
            {
                otdelenie_gid = value;
                OnPropertyChanged();
            }
        }

        int account_id;
        /// <summary>
        /// Id админки комплекта
        /// </summary>
        public int Account_id
        {
            get => account_id;
            set
            {
                account_id = value;
                OnPropertyChanged();
            }
        }

        string comment;
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }
        [ForeignKey("Status_guid")]
        public Status_M Status { get; set; }

        [ForeignKey("Account_id")]
        public Account_M Account { get; set; }

        [NotMapped]
        public Otdelenie_M Otdelenie { get; set; }

        [ForeignKey("Inventory_id")]
        public Inventory_m Inventory { get; set; }

        [NotMapped]
        public InventoryNumber_M InventoryNumber { get; set; }

        [ForeignKey("Type_eq_guid")]
        public Type_eq_M Type_Eq { get; set; }



    }
}
