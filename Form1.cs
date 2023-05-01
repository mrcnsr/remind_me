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
                MessageBox.Show("Lütfen bir görev baþlýðý girin.");
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Lütfen bir zaman seçin.");
                return;
            }

            // Gerekli Deðiþkenler
            string baslik = textBox1.Text;
            int sayac = 0;

            // Seçime Göre Sayaçlar
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

            // Alanlarýn Temizliði
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            // Listbox Sýralý Ýþlemler
            if (sayac > 0)
            {
                string taskName = ("Görev " + (listBox1.Items.Count + 1).ToString() + " : " + baslik);

                listBox1.Items.Add(taskName);

                Task.Delay(TimeSpan.FromSeconds(sayac)).ContinueWith((task) =>
                {
                    MessageBox.Show(baslik + " adlý görevi unutma!");

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
