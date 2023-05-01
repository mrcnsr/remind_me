using System.Windows.Forms;

namespace remind_me
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kontroller
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("L�tfen bir g�rev ba�l��� girin.");
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("L�tfen bir zaman se�in.");
                return;
            }

            // Gerekli De�i�kenler
            string baslik = textBox1.Text;
            int sayac = 0;

            // Se�ime G�re Saya�lar
            if (radioButton1.Checked)
            {
                sayac = 5;
            }
            else if (radioButton2.Checked)
            {
                sayac = 10;
            }
            else if (radioButton3.Checked)
            {
                sayac = 15;
            }

            // Alanlar�n Temizli�i
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            // Listbox S�ral� ��lemler
            if (sayac > 0)
            {
                string taskName = ("G�rev " + (listBox1.Items.Count + 1).ToString() + " : " + baslik);

                listBox1.Items.Add(taskName);

                Task.Delay(TimeSpan.FromSeconds(sayac)).ContinueWith((task) =>
                {
                    MessageBox.Show(baslik + " adl� g�revi unutma!");

                    if (listBox1.Items.Contains(taskName))
                    {
                        listBox1.Items.Remove(taskName);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
                // TaskSchduler.
            }
        }
    }
}
