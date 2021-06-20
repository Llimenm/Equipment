using Equipment.V;
using Equipment.V.Komplekt;
using Equipment.V.Monitor;
using Equipment.V.Supplementary_tables;
using OKB3Admin;
using System.Windows.Controls;

namespace Equipment.VM
{
    public class MainWindow_VM : BaseModelForVM
    {
        private Page komplekt_page = new Komplekt_V();
        private Page monitor_page = new Monitor_V();
        private Page account_page = new Account_V();
        private Page status_page = new Status_V();
        private Page typeEq_page = new Type_equipment_V();

        public MainWindow_VM()
        {
            GetDataPage();
        }

        bool isExpand = true;
        public bool IsExpand
        {
            get => isExpand;
            set
            {
                isExpand = value;
                OnPropertyChanged();
            }
        }

        public void GetDataPage()
        {
            (komplekt_page.DataContext as Komplekt_VM).GetStartData();
            (monitor_page.DataContext as Monitor_VM).GetData();
            (status_page.DataContext as Status_VM).GetData();
            (typeEq_page.DataContext as Type_equipment_VM).GetData();
            (account_page.DataContext as Account_VM).GetData();


        }
        

        Page frameForPage;
        public Page FrameForPage
        {
            get => frameForPage;
            set
            {
                frameForPage = value;
                IsExpand = false;
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
                IsExpand = false;
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
                IsExpand = false;
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
                IsExpand = false;
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
                IsExpand = false;
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
                IsExpand = false;
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
                //FrameForPage = socket_page;
                IsExpand = false;
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
                //FrameForPage = motherboard_page;
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
                //FrameForPage = chipset_page;
                IsExpand = false;
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
                //FrameForPage = ramtype_page;
                IsExpand = false;
                OnPropertyChanged();
            }
        }

       
    }
}
