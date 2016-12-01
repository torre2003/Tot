using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot
{
    public partial class FormDialogoPanel : Form
    {
        public UserControl control_de_usuario;
        public FormDialogoPanel()
        {
            InitializeComponent();
        }

        public FormDialogoPanel(UserControl control_de_usuario)
        {
            InitializeComponent();
            this.control_de_usuario = control_de_usuario;
            this.control_de_usuario.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(control_de_usuario);
        }
    }
}
