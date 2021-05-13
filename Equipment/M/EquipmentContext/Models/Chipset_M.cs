using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Chipset_M : Base_M
    {
        public int Id { get; set; }
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
        int socket_id;
        /// <summary>
        /// ID сокета
        /// </summary>
        public int Socket_id
        {
            get => socket_id;
            set
            {
                socket_id = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public Socket_M Socket { get; set; }
    }
}
