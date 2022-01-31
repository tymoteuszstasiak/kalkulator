namespace kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string LiczbaPIerwsza, LiczbaDruga;
        char RodzajDzialania = ' ';
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bDodawanie_Click(object sender, EventArgs e)
        {
            RodzajDzialania = '+';
            tbWynik.Text = "";
        }

        private void bOdejmowanie_Click(object sender, EventArgs e)
        {
            RodzajDzialania = '-';
            tbWynik.Text = "";
        }

        private void bMnozenie_Click(object sender, EventArgs e)
        {
            RodzajDzialania = '*';
            tbWynik.Text = "";
        }

        private void bDzielenie_Click(object sender, EventArgs e)
        {
            RodzajDzialania = '/';
            tbWynik.Text = "";
        }

        private void bWynik_Click(object sender, EventArgs e)
        {
            switch(RodzajDzialania)
            {
                case ('+'):
                    tbWynik.Text = (int.Parse(LiczbaPIerwsza) + int.Parse(LiczbaDruga)).ToString();
                    break;
                    case ('-'):
                    tbWynik.Text = (int.Parse(LiczbaPIerwsza) - int.Parse(LiczbaDruga)).ToString();
                    break;
                case ('*'):
                    tbWynik.Text = (int.Parse(LiczbaPIerwsza) * int.Parse(LiczbaDruga)).ToString();
                    break;
                case ('/'):
                    tbWynik.Text = (int.Parse(LiczbaPIerwsza) / int.Parse(LiczbaDruga)).ToString();
                    break;
            }
            LiczbaPIerwsza = "";
            LiczbaDruga = "";
            RodzajDzialania = ' ';
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Dzialanie(3);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            Dzialanie(6);
        }

        private void b9_Click(object sender, EventArgs e)
        {
            Dzialanie(9);
        }

        private void b8_Click(object sender, EventArgs e)
        {
            Dzialanie(8);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            Dzialanie(5);
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Dzialanie(2);
        }

        private void bDEL_Click(object sender, EventArgs e)
        {
            if (RodzajDzialania == ' ' && LiczbaPIerwsza.Length > 0)
            {
                LiczbaPIerwsza = LiczbaPIerwsza.Remove(LiczbaPIerwsza.Length - 1);
                tbWynik.Text = LiczbaPIerwsza;
            }
            else if (RodzajDzialania != ' ' && LiczbaDruga.Length > 0)
            {
                LiczbaDruga = LiczbaDruga.Remove(LiczbaDruga.Length - 1);
                tbWynik.Text = LiczbaDruga;
            }
        }

        private void b0_Click(object sender, EventArgs e)
        {
            Dzialanie(0);
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Dzialanie(1);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            Dzialanie(4);
        }

        private void b7_Click(object sender, EventArgs e)
        {
            Dzialanie(7);
        }
        private void Dzialanie(int liczba)
        {
            if (RodzajDzialania == ' ')
            {
                LiczbaPIerwsza += liczba;
                tbWynik.Text = LiczbaPIerwsza;
            }
            else
            {
                LiczbaDruga += liczba;
                tbWynik.Text = LiczbaDruga;
            }
        }
    }
}