using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;
using Equipment.V;
using System.Windows.Controls;
using Equipment.V.Komplekt;
using Equipment.V.Supplementary_tables;

namespace Equipment.VM
{
    public class MainWindow_VM : Base_VM
    {
        public MainWindow_VM()
        {

        }

        Page frameForPage;
        public Page FrameForPage
        {
            get => frameForPage;
            set
            {
                frameForPage = value;
                OnPropertyChanged();
            }
        }

        private bool statusIsSelected;
        public bool StatusIsSelected
        {
            get => statusIsSelected;
            set
            {

                statusIsSelected = value;
                FrameForPage = new Status_V();
                (FrameForPage.DataContext as Status_VM).GetData();
                OnPropertyChanged();
            }
        }

        private bool komplectIsSelected;
        public bool KomplectIsSelect
        {
            get => komplectIsSelected;
            set
            {
                komplectIsSelected = value;
                FrameForPage = new Komplekt_V();
                OnPropertyChanged();
            }
        }

        private bool mbSelected;
        public bool MbSelected
        {
            get => mbSelected;
            set
            {

                mbSelected = value;
                FrameForPage = new Motherboard_V();
                (FrameForPage.DataContext as Add_MB_K_VM).SetStartData(19);
                OnPropertyChanged();
            }
        }

        private bool typeEqIsSelected;
        public bool TypeEqIsSelected
        {
            get => typeEqIsSelected;
            set
            {
                typeEqIsSelected = value;
                FrameForPage = new Type_equipment_V();
                (FrameForPage.DataContext as Type_equipment_VM).GetData();
                OnPropertyChanged();
            }
        }

        private bool socketIsSelected;
        public bool SocketIsSelectd
        {
            get => socketIsSelected;
            set
            {
                socketIsSelected = value;
                FrameForPage = new Socket_V();
                (FrameForPage.DataContext as Socket_VM).GetData();
                OnPropertyChanged();
            }
        }

        private bool chipsetIsSelected;
        public bool ChipsetIsSelected
        {
            get => chipsetIsSelected;
            set
            {
                chipsetIsSelected = value;
                FrameForPage = new Chipset_V();
                (FrameForPage.DataContext as Chipset_VM).GetData();
                OnPropertyChanged();
            }
        }

        private bool ramTypeIsSelected;
        public bool RamTypeIsSelected
        {
            get => ramTypeIsSelected;
            set
            {
                ramTypeIsSelected = value;
                FrameForPage = new Ram_type_V();
                (FrameForPage.DataContext as Ram_type_VM).GetData();
                OnPropertyChanged();
            }
        }

        private bool accountIsSelected;
        public bool AccountIsSelected
        {
            get => accountIsSelected;
            set
            {
                accountIsSelected = value;
                FrameForPage = new Account_V();
                (FrameForPage.DataContext as Account_VM).GetData();
                OnPropertyChanged();
            }
        }

        private bool monitorIsSelected;
        public bool MonitorIsSelected
        {
            get => monitorIsSelected;
            set
            {
                monitorIsSelected = value;
                FrameForPage = new Monitor_V();
                (FrameForPage.DataContext as Monitor_VM).GetData();
                OnPropertyChanged();
            }
        }
    }
}
