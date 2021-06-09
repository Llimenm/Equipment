using OKB3Admin;
using OKB3Admin.M.Structura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Equipment.M.EquipmentContext.Models
{
    public class Inventory_m : BaseModelWithID
    {
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
        public Otdelenie_M Otdeleine { get; set; }

    }
}
