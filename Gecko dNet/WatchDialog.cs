using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp
{
    public partial class WatchDialog : Form
    {
        public WatchDialog()
        {
            InitializeComponent();
        }

        public uint[] WAddress;
        public string WName;
        public WatchDataSize WDataSize;

        private void btn_OK_Click(object sender, EventArgs e)
        {
            uint[] address;
            if (inputName.Text == "")
            {
                MessageBox.Show("Please type in a code name!");
                return;
            }
            bool okay = WatchList.TryStrToAddressList(inputAddress.Text, out address);
            if (!okay)
            {
                MessageBox.Show("Unable to parse address");
            }
            else
            {
                WAddress = address;
                WName = inputName.Text;
                switch (DType.SelectedIndex)
                {
                    case 0:
                        WDataSize = WatchDataSize.Bit8;
                        break;
                    case 1:
                        WDataSize = WatchDataSize.Bit16;
                        break;
                    case 3:
                        WDataSize = WatchDataSize.SingleFp;
                        break;
                    default:
                        WDataSize = WatchDataSize.Bit32;
                        break;
                }
                DialogResult = DialogResult.OK;
            }
        }

        public bool AddCodeDialog()
        {
            DialogResult dr;

            inputAddress.Text = "";
            inputName.Text = "New watch";
            DType.SelectedIndex = 2;
            
            dr = ShowDialog();
            return (dr == DialogResult.OK);
        }

        public bool EditWatchDialog(WatchEntry entry)
        {
            DialogResult dr;

            inputAddress.Text = WatchList.addressToString(entry.address);
            inputName.Text = entry.name;
            switch (entry.dataSize)
            {
                case WatchDataSize.Bit8:
                    DType.SelectedIndex = 0;
                    break;
                case WatchDataSize.Bit16:
                    DType.SelectedIndex = 1;
                    break;
                case WatchDataSize.SingleFp:
                    DType.SelectedIndex = 3;
                    break;
                default:
                    DType.SelectedIndex = 2;
                    break;
            }
            
            dr = ShowDialog();
            return (dr == DialogResult.OK);
        }

        private void WatchDialog_Shown(object sender, EventArgs e)
        {
            inputName.Focus();
        }
    }
}
