using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class frmNuevo : Form
    {
        private int? Id;
        public frmNuevo(int? Id=null)
        {
            InitializeComponent();

            this.Id = Id;

            if(this.Id != null)
                LoadData();
        }

        private void LoadData() 
        {
            PersonaDB unaPersonaDB = new PersonaDB();
            Persona unaPersona = unaPersonaDB.Get((int)Id);

            txtNombre.Text = unaPersona.Nombre;
            txtEdad.Text = unaPersona.Edad.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PersonaDB unaPersonaDB = new PersonaDB();

            try 
            {
                if (Id == null)
                    unaPersonaDB.Add(txtNombre.Text, int.Parse(txtEdad.Text));
                else
                    unaPersonaDB.Update(txtNombre.Text, int.Parse(txtEdad.Text), (int)Id);

                this.Close();
            }
            catch(Exception ex)  
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);   
            }
        }
    }
}
