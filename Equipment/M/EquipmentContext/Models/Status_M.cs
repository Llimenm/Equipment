﻿using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Status_M : BaseModelWithGUID
    {
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

    }
}
