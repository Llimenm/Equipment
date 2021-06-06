using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;
using Equipment.V;
using System.Windows.Controls;
using Equipment.V.Komplekt;
using Equipment.V.Supplementary_tables;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Equipment.VM
{
    public class MainWindow_VM : BaseModelForVM
    {
        private Page komplekt_page = new Komplekt_V();
        private Page motherboard_page = new Motherboard_V();
        private Page monitor_page = new Monitor_V();
        private Page status_page = new Status_V();
        private Page typeEq_page = new Type_equipment_V();
        private Page socket_page = new Socket_V();
        private Page chipset_page = new  Chipset_V();
        private Page ramtype_page = new Ram_type_V();
        private Page account_page = new Account_V();

        public MainWindow_VM()
        {
            GetDataPage();
        }

        public void GetDataPage()
        {
            (komplekt_page.DataContext as Komplekt_VM).GetStartData();
            (monitor_page.DataContext as Monitor_VM).GetData();
            (status_page.DataContext as Status_VM).GetData();
            (typeEq_page.DataContext as Type_equipment_VM).GetData();
            (socket_page.DataContext as Socket_VM).GetData();
            (chipset_page.DataContext as Chipset_VM).GetData();
            (ramtype_page.DataContext as Ram_type_VM).GetData();
            (account_page.DataContext as Account_VM).GetData();
            (motherboard_page.DataContext as Motherboard_Komplekt_VM).SetStartData();
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
                FrameForPage = status_page;
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
                FrameForPage = komplekt_page;
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
                FrameForPage = motherboard_page;
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
                FrameForPage = typeEq_page;
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
                FrameForPage = socket_page;
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
                FrameForPage = chipset_page;
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
                FrameForPage = ramtype_page;
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
                FrameForPage = account_page;
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
                FrameForPage = monitor_page;
                OnPropertyChanged();
            }
        }
    }
}
