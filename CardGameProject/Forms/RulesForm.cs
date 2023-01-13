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