using OKB3Admin;
using System.Collections.Generic;
using System.Text;

namespace Equipment.M.EquipmentContext.Models
{
    public class Ports_M : Base_M
    {
        public int Id { get; set; } //В модели указано количество портов на то или иное устройство
        int vga;
        public int VGA
        {
            get => vga;
            set
            {
                vga = value;
                OnPropertyChanged();
            }
        }
        int hdmi;
        public int HDMI
        {
            get => hdmi;
            set
            {
                hdmi = value;
                OnPropertyChanged();
            }
        }
        int dp;
        public int DP
        {
            get => dp;
            set
            {
                dp = value;
                OnPropertyChanged();
            }
        }
        int dvi_d;
        public int DVI_D
        {
            get => dvi_d;
            set
            {
                dvi_d = value;
                OnPropertyChanged();
            }
        }
        int dvi_i;
        public int DVI_I
        {
            get => dvi_i;
            set
            {
                dvi_i = value;
                OnPropertyChanged();
            }
        }
        int ltp;
        public int LTP
        {
            get => ltp;
            set
            {
                ltp = value;
                OnPropertyChanged();
            }
        }
        int com;
        public int COM
        {
            get => com;
            set
            {
                com = value;
                OnPropertyChanged();
            }
        }
        int ps2;
        public int PS2
        {
            get => ps2;
            set
            {
                ps2 = value;
                OnPropertyChanged();
            }
        }
    }
}
