using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Chipset_M : BaseModelWithGUID
    {
        string name;
        /// <summary>
        /// Имя чипсета     
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        Guid? socket_guid;
        /// <summary>
        /// ID сокета
        /// </summary>
        public Guid? Socket_guid
        {
            get => socket_guid;
            set
            {
                socket_guid = value;
                OnPropertyChanged();
            }
        }
        [ForeignKey("Socket_guid")]
        public Socket_M Socket { get; set; }
    }
}
