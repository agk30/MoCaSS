using System.Security.Cryptography;
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
            var num = random.RandomCosineVector(1);
            textBox1.Text = num.x.ToString();
            // do stuff with the random generator
        }
    }
}
