﻿using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;

namespace Equipment.M.EquipmentContext.Models
{
    public class Account_M : Base_M
    {
        public int Id { get; set; }
        string acc_user;
        /// <summary>
        /// Имя пользователя комплекта
        /// </summary>
        public string Acc_user
        {
            get => acc_user;
            set
            {
                acc_user = value;
                OnPropertyChanged();
            }
        }
        string password;
        /// <summary>
        /// Пароль от пользователя комплекта
        /// </summary>
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Комментарий
        /// </summary>
        string comment;
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }
    }
}
