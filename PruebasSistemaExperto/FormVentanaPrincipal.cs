using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaExpertoLib;

namespace PruebasSistemaExperto
{
    public partial class FormVentanaPrincipal : Form
    {
        GestionadorBaseConocimiento base_conocimiento = new GestionadorBaseConocimiento();
        FormGestionHechos ventana_hechos;
        FormGestionDeReglas ventana_reglas;


        public FormVentanaPrincipal()
        {
            InitializeComponent();
            ventana_hechos = new FormGestionHechos(base_conocimiento);
            ventana_reglas = new FormGestionDeReglas(base_conocimiento);

        }

        private void button_gestion_de_hechos_Click(object sender, EventArgs e)
        {
            ventana_hechos.Show();
        }

        private void button_gestion_de_reglas_Click(object sender, EventArgs e)
        {
            ventana_reglas.Show();
        }

 






    }
}
