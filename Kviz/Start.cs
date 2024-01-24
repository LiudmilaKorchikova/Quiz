using System;
using System.Windows.Forms;

namespace Kviz
{
    public partial class Start : Form//startová stránka, spustí se po zahajeni programu
    {
        public Start()
        {
            InitializeComponent();
            txtGreeting.Text = "Vitejte v Kvízu!\r\nZadejte prosim vaše jmeno:\r\n(jestli chcete)";
        }
        public static string userName;//vytvoři prommennou pro jméno


        private void btnStart_Click(object sender, EventArgs e)
        {
                Quiz form1 = new Quiz();
                form1.Show();
                this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            History historie = new History();
            historie.Show();
            this.Hide();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            userName = txtUserName.Text;//pokud uzivatel zadá svoje jmeno zapiše se do promenne jméno
        }


    }
}
