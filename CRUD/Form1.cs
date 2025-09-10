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
            Persona unaPersona = new Persona();
            if (unaPersona.Ok())
                MessageBox.Show("Conectado");
            else
                MessageBox.Show("No conectado");
        }
    }
}
