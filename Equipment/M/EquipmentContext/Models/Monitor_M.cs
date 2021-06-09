using OKB3Admin;
using OKB3Admin.M.InventorySystem;
using OKB3Admin.M.Structura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Equipment.M.EquipmentContext.Models
{
    public class Monitor_M : BaseModelWithGUID
    {
        string manufacturer;
        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                manufacturer = value;
                OnPropertyChanged();
            }
        }
        string model;
        public string Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }
        int ports_id;
        public int Ports_id
        {
            get => ports_id;
            set
            {
                ports_id = value;
                OnPropertyChanged();
            }
        }

        Guid? komplekt_guid;
        public Guid? Komplekt_guid
        {
            get => komplekt_guid;
            set
            {
                komplekt_guid = value;
                OnPropertyChanged();
            }
        }

        Guid? typeEq_guid;
        public Guid? TypeEq_guid
        { 
            get => typeEq_guid;
            set 
            {
                typeEq_guid = value;
                OnPropertyChanged();
            }
        }

        Guid? status_guid;
        public Guid? Status_guid
        {
            get => status_guid;
            set
            {
                status_guid = value;
                OnPropertyChanged();
            }
        }

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

        Guid? otdelenie_guid;
        public Guid? Otdelenie_guid
        {
            get => otdelenie_guid;
            set
            {
                otdelenie_guid = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public InventoryNumber_M InventoryNumber { get; set; }

        [NotMapped]
        public Otdelenie_M Otdelenie { get; set; }

        [ForeignKey("Inventory_id")]
        public Inventory_m Inventory { get; set; }

        [ForeignKey("TypeEq_guid")]
        public Type_eq_M TypeEquipment { get; set; }

        [ForeignKey("Status_guid")]
        public Status_M Status { get; set; }

        [ForeignKey("Komplekt_guid")]
        public Komplekt_M Komplekt { get; set; }
    }
}
