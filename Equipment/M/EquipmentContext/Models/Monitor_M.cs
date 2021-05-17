using OKB3Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.M.EquipmentContext.Models
{
    public class Monitor_M : Base_M
    {
        public int Id { get; set; }

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

        int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }

    }
}
