using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace TP
{
    public partial class salesfigures : Form
    {
        public salesfigures()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            comboBox1.SelectedIndex = today.Month-1;
        }

    }
}
