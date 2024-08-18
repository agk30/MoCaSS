using System.Security.Cryptography.X509Certificates;

namespace MoCaSS
{
    public partial class MainForm : Form
    {
        private MCRandom random;


        public MainForm()
        {
            InitializeComponent();
            random = new MCRandom();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Molecule mol = new Molecule(17.0,ref random);

            textBox1.Text = mol.massAMU.ToString();
            //textBox1.Text = mol.massKG.ToString();

            //var num = random.RandomCosineVector(1);
            //textBox1.Text = num.x.ToString();
            // do stuff with the random generator
            //textBox1.Text = 
        }
    }
}
