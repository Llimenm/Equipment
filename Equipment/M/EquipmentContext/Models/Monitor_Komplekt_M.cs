using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;
using OKB3Admin.M.InventorySystem;
using OKB3Admin.M.Structura;

namespace Equipment.M.EquipmentContext.Models
{
    public class Monitor_Komplekt_M : BaseModelWithID
    {
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
        Guid? monitor_guid;
        public Guid? Monitor_guid
        {
            get => monitor_guid;
            set
            {
                monitor_guid = value;
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

        [NotMapped]
        public InventoryNumber_M InventoryNumber { get; set; }

        [NotMapped]
        public Otdelenie_M Otdelenie { get; set; }

        [ForeignKey("Komplekt_guid")]
        public Komplekt_M Komplekt { get; set; }

        [ForeignKey("Monitor_guid")]
        public Monitor_M Monitor { get; set; }

        [ForeignKey("Status_guid")]
        public Status_M Status { get; set; }
    }
}
