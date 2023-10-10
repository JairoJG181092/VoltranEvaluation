using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvaluacionVoltron.Core;

namespace EvaluacionVoltron
{
    public partial class Form1 : Form
    {
        CoreEvaluacionVoltron core = new CoreEvaluacionVoltron();
        public Form1()
        {
            InitializeComponent();
            cmbAltura.Items.AddRange(new string[] { "1.03", "1.53", "2.03" });
            cmbColor.Items.AddRange(new string[] { "sin pintura", "blanca", "negra", "verde" });
            LlenarListBox();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string largo = txtLargo.Text;
            double altura = double.Parse(cmbAltura.SelectedItem.ToString());
            string color = cmbColor.SelectedItem.ToString();

            double requestedLength;
            if (!double.TryParse(txtLargo.Text, out requestedLength))
            {
                MessageBox.Show("Por favor ingrese un valor numérico válido para el largo.");
                return;
            }

            

            var resp = core.insertapedido(requestedLength, altura, color) ;

            MessageBox.Show(resp);

            //lblRespuesta.Text = resp.ToString();

            LlenarListBox();
        }

        private void LlenarListBox()
        {
            List<string> datos = core.ConsultarDatos();

            foreach (string itemText in datos)
            {
                listBox1.Items.Add(itemText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
