using OKB3Admin;
using OKB3Admin.M;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Equipment.M.EquipmentContext.Models
{
    public class Komplekt_M : Base_M
    {
        public int Id { get; set; }
        int status_id;
        /// <summary>
        /// Id статуса
        /// </summary>
        int type_eq_id;
        /// <summary>
        /// Тип оборудования
        /// </summary>
        public int Type_eq_id
        {
            get => type_eq_id;
            set
            {
                type_eq_id = value;
                OnPropertyChanged();
            }
        }
        public int Status_id
        {
            get => status_id;
            set
            {
                status_id = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Инвентарный номер
        /// </summary>
        string inventory;
        public string Inventory
        {
            get => inventory;
            set
            {
                inventory = value;
                OnPropertyChanged();
            }
        }

        int otdelenie_Id;
        public int Otdelenie_Id
        {
            get => otdelenie_Id;
            set
            {
                otdelenie_Id = value;
                OnPropertyChanged();
            }
        }

        int acc_id;
        /// <summary>
        /// Id админки комплекта
        /// </summary>
        public int Acc_id
        {
            get => acc_id;
            set
            {
                acc_id = value;
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
       [ForeignKey("Status_id")]
        public Status_M Status { get; set; }

       
        [ForeignKey("Acc_id")]
        public Account_M Account { get; set; }
        [NotMapped]
        public Otdelenie_M Otdelenie { get; set; }
        [ForeignKey("Type_eq_id")]
        public Type_eq_M Type_Eq { get; set; }

    }
}
