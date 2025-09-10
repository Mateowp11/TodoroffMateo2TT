using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonaDB unaPersona = new PersonaDB();
            if (unaPersona.Ok())
                MessageBox.Show("Conectado");
            else
                MessageBox.Show("No conectado");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }


        private void Refresh()
        {
            PersonaDB unaPersonaDB = new PersonaDB();
            dataGridView1.DataSource = unaPersonaDB.Get();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevo frm = new frmNuevo();
            frm.ShowDialog();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();

            if (Id != null)
            {
                frmNuevo frmEdit = new frmNuevo(Id);
                frmEdit.ShowDialog();
                Refresh();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();

            try { 

                if (Id != null)
                {
                    PersonaDB unaPersonaDB = new PersonaDB();

                    unaPersonaDB.Delete((int)Id);

                    Refresh();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);
            }
        }

        #region HELPER
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



    }
}