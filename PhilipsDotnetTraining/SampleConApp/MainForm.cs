using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleConApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(DataTable table) : this()
        {
            GridTable.DataSource = table;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
