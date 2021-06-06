using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;
namespace Equipment.M.EquipmentContext.Models
{
    public class MB_M : BaseModelWithGUID
    { 
        string manufacturer;
        /// <summary>
        /// Производитель
        /// </summary>
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
        /// <summary>
        /// Модель
        /// </summary>
        public string Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Тип оборудования
        /// </summary>
        Guid? type_eq_guid;
        public Guid? Type_eq_guid
        {
            get => type_eq_guid;
            set
            {
                type_eq_guid = value;
                OnPropertyChanged();
            }
        }
        Guid? socket_guid;
        /// <summary>
        /// id сокета 
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
        int socket_count;
        /// <summary>
        /// Количество сокетов
        /// </summary>
        public int Socket_count
        {
            get => socket_count;
            set
            {
                socket_count = value;
                OnPropertyChanged();
            }
        }
        Guid? chipset_guid;
        /// <summary>
        /// ID чипсета
        /// </summary>
        public Guid? Chipset_guid
        {
            get => chipset_guid;
            set
            {
                chipset_guid = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Id типа памяти
        /// </summary>
        Guid? ram_type_guid;
        public Guid? Ram_type_guid
        {
            get => ram_type_guid;
            set
            {
                ram_type_guid = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// количество слотов по ОЗУ
        /// </summary>
        int ram_count;
        public int Ram_count
        {
            get => ram_count;
            set
            {
                ram_count = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// количество М2
        /// </summary>
        int m2_count;
        public int M2_count
        {
            get => m2_count;
            set
            {
                m2_count = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Связь с таблицей и количеством портов у матери
        /// </summary>
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
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Количество в комплектах
        /// </summary>
        int onKomplekt;
        public int OnKomplekt
        {
            get => onKomplekt;
            set
            {
                onKomplekt = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("Type_eq_guid")]
        public Type_eq_M Type_equipment { get; set; }

        [ForeignKey("Socket_guid")]
        public Socket_M Socket { get; set;}

        [ForeignKey("Chipset_guid")]
        public Chipset_M Chipset { get; set; }

        [ForeignKey("Ram_type_guid")]
        public Ram_type_M Ram_Type { get; set; }
    }
}
