using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OKB3Admin;
namespace Equipment.M.EquipmentContext.Models
{
    public class MB_M : Base_M
    {
        public int Id { get; set; }
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
        int type_eq_id;
        public int Type_eq_id
        {
            get => type_eq_id;
            set
            {
                type_eq_id = value;
                OnPropertyChanged();
            }
        }
        int socket_id;
        /// <summary>
        /// id сокета 
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
        int chipset_id;
        /// <summary>
        /// ID чипсета
        /// </summary>
        public int Chipset_id
        {
            get => chipset_id;
            set
            {
                chipset_id = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Id типа памяти
        /// </summary>
        int ram_type_id;
        public int Ram_type_id
        {
            get => ram_type_id;
            set
            {
                ram_type_id = value;
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

        [NotMapped]
        public Type_eq_M Type_equipment { get; set; }
        [NotMapped]
        public Socket_M Socket { get; set;}
        [NotMapped]
        public Chipset_M Chipset { get; set; }
        [NotMapped]
        public Ram_type_M Ram_Type { get; set; }
    }
}
