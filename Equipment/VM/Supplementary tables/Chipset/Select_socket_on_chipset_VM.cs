using Equipment.M.EquipmentContext;
using Equipment.M.EquipmentContext.Models;
using Equipment.V;
using Equipment_accounting.Data;
using Microsoft.EntityFrameworkCore;
using OKB3Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.VM
{
    public class Select_socket_on_chipset_VM : BaseModelForVM
    {
        public Socket_M ChooosedSocket { get; set; }
        public Select_socket_on_chipset_VM()
        {
            Task.Run(() => GetData());
        }
        ObservableCollection<Socket_M> socketTable;
        public ObservableCollection<Socket_M> SocketTable
        {
            get => socketTable;
            set
            {
                socketTable = value;
                OnPropertyChanged();
            }
        }
        Socket_M selectedItem;
        public Socket_M SelectedItem
        { 
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        RelayCommand selectSocket;
        public RelayCommand SelectSocket
        {
            get
            {
                return selectSocket ??= new RelayCommand(o =>
                {
                    ChooosedSocket = SelectedItem;
                    (o as Select_socket_on_chipset).Close(); 
                });
            }
        }
        
        private async Task GetData()
        {
            using (EqContext ec = new EqContext())
            {
                var tmp = ec.Socket;
                SocketTable = new ObservableCollection<Socket_M>( await tmp.ToListAsync());
            }
            await Task.CompletedTask;
        }
    }
}
