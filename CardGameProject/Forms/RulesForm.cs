using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class RulesForm : Form
    {
        public RulesForm()
        {
            InitializeComponent();
            axAcroPDF2.setShowToolbar(false);
            axAcroPDF2.LoadFile("./Corellian Spike Sabacc Rules.pdf");
        }
    }
}
