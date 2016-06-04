using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemBankowy
{

    public partial class Form1 : Form
    {
        int numer, numer2, numer3;
        string ord="";
        public Form1()
        {
            InitializeComponent();
            bazaClass baza = new bazaClass();
            baza.wyswietl_tabele_klientow(dataGridView1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string przelew1 = "UPDATE Konto SET SALDO = Saldo - " +textBox7.Text+" WHERE Numer_Konta = '" + textBox5.Text + "';";
            bazaClass baza = new bazaClass();
            baza.Insert(przelew1);
            string przelew2 = "UPDATE Konto SET SALDO = Saldo + " + textBox7.Text + " WHERE Numer_Konta = '" + textBox6.Text + "';";
            baza.Insert(przelew2);
            baza.Konto(dataGridView3, textBox5.Text);
            textBox6.Text = "";
            textBox7.Text = "";
            panel1.Enabled = false;
             
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
            }
            else if (radioButton2.Checked == true)
            {
                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
            }
            else if (radioButton3.Checked == true)
            {
                button2.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                button2.Enabled = false;
                button1.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int test =(String.Compare(textBox3.Text, ""));
            test = test + (String.Compare(textBox2.Text, ""));
            test = test + (String.Compare(textBox1.Text, ""));
            if (test!=0)
            {
                string KlientIn = "INSERT INTO Klient Values('','";
                bazaClass baza = new bazaClass();
                KlientIn = KlientIn + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');";

                baza.Insert(KlientIn);
                baza.wyswietl_tabele_klientow(dataGridView1);
               

            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            baza.szukaj(dataGridView1, textBox4.Text);
        }

        public void button11_Click_1(object sender, EventArgs e)
        {
           
            bazaClass baza = new bazaClass();
            baza.wyswietl_tabele_klientow(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string s = row.Cells[0].Value.ToString();
            try
            {
                numer = int.Parse(s);
            }
            catch
            {
                MessageBox.Show("Klient nie istnieje");
            }
           
            DataGridViewRow row1 = dataGridView1.Rows[e.RowIndex];
            string s1 = row.Cells[1].Value.ToString();
            try
            {
                numer2 = int.Parse(s1);
            }
            catch
            {
                
            }

            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string uKlient = "DELETE FROM Klient WHERE id_Klienta = '" + numer + "';";
            bazaClass baza = new bazaClass();
            baza.Insert(uKlient);
           baza.wyswietl_tabele_klientow(dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            String KontoIn = "INSERT INTO Konto VALUES('','" + numer + "','0');";
            baza.Insert(KontoIn);
            baza.wyswietl_tabele_klientow(dataGridView1);
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            String KontoIn = "INSERT INTO Karta VALUES('','" + numer2 + "','2020-01-01');";
            baza.Insert(KontoIn);
            baza.wyswietl_tabele_klientow(dataGridView1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            string upKlient = "UPDATE Klient SET id_Klienta ='" + numer + "', Pesel = '" + textBox1.Text + "' , Imie = '" + textBox3.Text + "', Nazwisko = '"+ textBox2.Text +"' WHERE id_Klienta= '" + numer + "';";
            baza.Insert(upKlient);
            baza.wyswietl_tabele_klientow(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            baza.Konto(dataGridView3, textBox5.Text);
            panel1.Enabled = true;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            panel2.Enabled = false;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel3.Enabled = false;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            panel2.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            baza.Karta(dataGridView4, textBox8.Text);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string przelew1 = "UPDATE Konto SET SALDO = Saldo - " + textBox9.Text + " WHERE Numer_Konta = '" + numer3 + "';";
            bazaClass baza = new bazaClass();
            baza.Insert(przelew1);
            textBox9.Text = "";
            baza.Karta(dataGridView4, textBox8.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string przelew1 = "UPDATE Konto SET SALDO = Saldo + " + textBox12.Text + " WHERE Numer_Konta = '" + numer3 + "';";
            bazaClass baza = new bazaClass();
            baza.Insert(przelew1);
            textBox12.Text = "";
            baza.Karta(dataGridView4, textBox8.Text);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row3 = dataGridView4.Rows[e.RowIndex];
            string s1 = row3.Cells[1].Value.ToString();
            try
            {
                numer3 = int.Parse(s1);
            }
            catch
            {
                MessageBox.Show("Konto nie istnieje");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            baza.Transakcja(dataGridView5, textBox14.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string transakcja = "INSERT INTO Transakcja SET id_transakcji = '', id_karty = '" + textBox14.Text + "' , Kwota = '"+ textBox15.Text + "' , Data = '2015-06-25' , Opis = '"+ textBox16.Text + "';";
              
            bazaClass baza = new bazaClass();
            baza.Insert(transakcja);
            textBox15.Text = "";
            textBox16.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bazaClass baza = new bazaClass();
            baza.Historia(dataGridView2, textBox17.Text, dateTimePicker2.Text, dateTimePicker3.Text, ord );
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            ord = "";
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            ord = " DESC";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;
            dataGridView4.Refresh();
            dataGridView3.Refresh();
            dataGridView2.Refresh();
            
        }
    }
}
