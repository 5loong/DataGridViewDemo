using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            //add one row ,combobox column's value must in its list, checkbox column's value can be set as bool

            dgv_list.Rows.Add(true,"21000000", "XXU", "NULL", "lpu1");

        }

        private void dgv_list_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                // first remove event handler to keep from attaching multiple:
                cb.SelectedIndexChanged -= new
                EventHandler(cb_SelectedIndexChanged);

                // now attach the event handler
                cb.SelectedIndexChanged += new
                EventHandler(cb_SelectedIndexChanged);
            }
        }

        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Selected index changed");
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            string str = "";

            foreach (DataGridViewRow dgvr in dgv_list.Rows)
            {
                if ((bool)dgvr.Cells[0].FormattedValue)
                {
                    str += dgvr.Cells[1].FormattedValue;
                }
            }
            MessageBox.Show(str);
        }

    }   
}
