using RecetasSLN.dominio;
using RecetasSLN.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        IServicio Servicio;

        public FrmConsultarRecetas()
        {
            InitializeComponent();
            Servicio = new Servicio();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Receta> lst = Servicio.listarRecetas(txtNombre.Text, (int)cboTipoReceta.SelectedIndex);
            if (lst.Count != 0)
            {
                dataGridView1.Rows.Clear();
                foreach (Receta receta in lst)
                {
                    dataGridView1.Rows.Add(new object[] { receta.nombre.ToString(), receta.tipoReceta.ToString(), receta.cheff.ToString() });
                }
            }
            else
            {
                MessageBox.Show("No se encontraron resultados", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaReceta FrmNueva = new FrmNuevaReceta();
            FrmNueva.ShowDialog();
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Receta receta in Servicio.listarRecetas())
            {
                dataGridView1.Rows.Add(new object[] { receta.nombre.ToString(),receta.tipoReceta.ToString(),receta.cheff.ToString()});

            }




        }

       
    }
}
