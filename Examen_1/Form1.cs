namespace Examen_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult resultado;
            resultado = openFileDialogCSV.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialogCSV.FileName;
                    string[] texto = File.ReadAllLines(filePath);

                    for (int i = 0; i < texto.Length; i++)
                    {

                        dgvDatos.Rows.Add(texto[i].ToString().Split(","));

                        string Curp = dgvDatos.Rows[i].Cells[0].Value.ToString();
                        string fechaNac = Curp.Substring(4, 6);
                        DateTime fecha = formatearFecha(fechaNac);
                        int edad = DateTime.Now.Year - fecha.Year;

                        if (fecha > DateTime.Now.AddYears(-edad))
                        {
                            edad--;
                        }

                        string sexo;
                        sexo = Curp.Substring(10, 1).ToUpper() == "H" ? "Hombre" : "Mujer";


                        dgvDatos.Rows[i].Cells[2].Value = edad;
                        dgvDatos.Rows[i].Cells[3].Value = sexo;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                
            }

        }

        private DateTime formatearFecha(string fecha)
        {
              
            int año = int.Parse(fecha.Substring(0, 2));
            int mes = int.Parse(fecha.Substring(2, 2));
            int dia = int.Parse(fecha.Substring(4, 2));

            if(año < 30)
            {
                año += 2000;
            }
            else
            {
                año += 1900;
            }

            return new DateTime(año, mes, dia);
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
