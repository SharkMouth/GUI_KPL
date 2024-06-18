using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuManager _menuManager = new MenuManager();
            _menuManager.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateOrder _createOrder = new CreateOrder();
            _createOrder.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteOrder _deleteOrder = new DeleteOrder();
            _deleteOrder.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReportTransaction _reportTransaction = new ReportTransaction();
            _reportTransaction.Show();
        }
    }
}
