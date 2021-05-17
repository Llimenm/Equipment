using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;
namespace Equipment.M.EquipmentContext.Models
{
    public class Monitor_Komplekt_M : Base_M
    {
        public int Id { get; set; }
        int komplekt_id;
        public int Komplekt_id
        {
            get => komplekt_id;
            set
            {
                komplekt_id = value;
                OnPropertyChanged();
            }
        }
        int monitor_id;
        public int Monitor_id
        {
            get => monitor_id;
            set
            {
                monitor_id = value;
                OnPropertyChanged();
            }
        }
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

        [ForeignKey("Komplekt_id")]
        public Komplekt_M Komplekt { get; set; }
        [ForeignKey("Monitor_id")]
        public Monitor_M Monitor { get; set; }

    }
}
