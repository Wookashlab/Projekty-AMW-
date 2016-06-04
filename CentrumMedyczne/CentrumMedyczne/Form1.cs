using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CentrumMedyczne
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


           listBox_OLista.DataSource = Program.MojaLista;
           listBox_Llista.DataSource = Program.Pomoc;
           


           System.IO.StreamReader file = new System.IO.StreamReader(@".\haslo.txt");
           haslo1 = file.ReadLine();
           haslo2 = file.ReadLine();
           file.Close();
           
           
            
        }
        bool rej = false;

        public void generuj_L()

        {
            Program.Pomoc.Clear();
            foreach (Lekarz x in Program.MojaLista)
            {
                if (x.lekarz==comboBox_L.Text
                    && x.wykonanie=="Przed"
                    && x.data == dateTimePicker1.Text)

                Program.Pomoc.Add(new Lekarz(x.imie,
                                                x.nazwisko,
                                                x.pesel,
                                                 x.opis,
                                                 x.data,
                                                 x.lekarz,
                                                 "Przed"));
            }
           

        }
        public void generuj_Po()
        {
            Program.Po.Clear();
            foreach (Lekarz x in Program.MojaLista)
            {
                if (x.wykonanie == "Po")
                    Program.Po.Add(new Lekarz(x.imie,
                                                    x.nazwisko,
                                                    x.pesel,
                                                     x.opis,
                                                     x.data,
                                                     x.lekarz,
                                                     "Po"));
            }
            listBox_OLista.Refresh();

        }
        public void generuj_Przed()
        {
            Program.Przed.Clear();
            foreach (Lekarz x in Program.MojaLista)
            {
                if (x.wykonanie == "Przed")
                    Program.Przed.Add(new Lekarz(x.imie,
                                                    x.nazwisko,
                                                    x.pesel,
                                                     x.opis,
                                                     x.data,
                                                     x.lekarz,
                                                     "Przed"));
            }
            listBox_OLista.Refresh();
        }
        
        public void ZmianaWidoku()
        {
            textBox_Rnazwisko.Enabled = !textBox_Rnazwisko.Enabled;
            textBox_Rimie.Enabled = !textBox_Rimie.Enabled;
            textBox_Rinfo.Enabled = !textBox_Rinfo.Enabled; 
            maskedTextBox_Rpesel.Enabled = !maskedTextBox_Rpesel.Enabled;
            comboBox_Rlekarze.Enabled = !comboBox_Rlekarze.Enabled;
            monthCalendar1.Enabled = !monthCalendar1.Enabled;
            button_Rreje.Enabled = !button_Rreje.Enabled;
            button_Rzapis.Visible = !button_Rzapis.Visible;
        }
        public void obsluga()
        {
            button_Ousun.Enabled = !button_Ousun.Enabled;
            textBox_Oimie.Enabled = !textBox_Oimie.Enabled;
            textBox_Onazwisko.Enabled = !textBox_Onazwisko.Enabled;
            textBox_Oopis.Enabled=!textBox_Oopis.Enabled;
            maskedTextBox_Opesel.Enabled = !maskedTextBox_Opesel.Enabled;
            comboBox_Olekarz.Enabled = !comboBox_Olekarz.Enabled;
            dateTimePicker2.Enabled = !dateTimePicker2.Enabled;
            button_Ozapisz.Enabled = !button_Ozapisz.Enabled;
            comboBox_Ostatus.Enabled = !comboBox_Ostatus.Enabled;

       
        }

        public void czysc()
        {
            textBox_Rnazwisko.Text = "";
            monthCalendar1.SetSelectionRange(monthCalendar1.TodayDate, monthCalendar1.TodayDate);
            textBox_Rimie.Text = "";
            textBox_Rinfo.Text = "";
            maskedTextBox_Rpesel.Text = "";
            comboBox_Rlekarze.SelectedIndex = -1;
            
            if (rej)
            {
                ZmianaWidoku();
                rej = false;
            }
        }
        public void czysc_L()
        {
            textBox_Lrecepta.Text = "";
            textBox_Lchoroba.Text = "";
            textBox_Luwagi.Text = "";
            zapis = false;
        }
        public void czysc_O()
        {
            textBox_Oimie.Text = "";
            textBox_Onazwisko.Text = "";
            textBox_Oopis.Text = "";
            maskedTextBox_Opesel.Text = "";
            comboBox_Olekarz.SelectedIndex=-1;
            comboBox_Ostatus.SelectedIndex = -1;
        }
        public void przypisanie()
        {
            Oimie = textBox_Oimie.Text;
            Onazwisko = textBox_Onazwisko.Text;
            Opesel = maskedTextBox_Opesel.Text;
            Oopis = textBox_Oopis.Text;
            Odata = dateTimePicker2.Text;
            Olekarz = comboBox_Olekarz.Text;
            Ostatus = comboBox_Ostatus.Text;
        }
        public void zmiana_statusu()
        {
            foreach (Lekarz x in Program.MojaLista)
            {
                if (x.imie == (listBox_Llista.SelectedItem as Lekarz).imie
                    && x.nazwisko == (listBox_Llista.SelectedItem as Lekarz).nazwisko
                    && x.pesel ==(listBox_Llista.SelectedItem as Lekarz).pesel
                    && x.opis == (listBox_Llista.SelectedItem as Lekarz).opis
                    && x.data == (listBox_Llista.SelectedItem as Lekarz).data
                    && x.lekarz == (listBox_Llista.SelectedItem as Lekarz).lekarz)
                {
                    x.wykonanie = "Po";
                      
                }

            }
        }
        public void edycja()
        {
           
            foreach (Lekarz x in Program.MojaLista)
                if (x.imie == Oimie
                     && x.nazwisko == Onazwisko
                     && x.pesel == Opesel
                     && x.opis == Oopis
                     && x.data == Odata
                     && x.lekarz == Olekarz)
                {
                     x.imie=textBox_Oimie.Text;
                     x.nazwisko=textBox_Onazwisko.Text;
                     x.pesel = maskedTextBox_Opesel.Text;
                     x.opis=textBox_Oopis.Text;
                     x.data=dateTimePicker2.Text;
                     x.lekarz=comboBox_Olekarz.Text;
                     x.wykonanie=comboBox_Ostatus.Text;

                }
        }
        public void usun()
        {
            foreach (Lekarz x in Program.MojaLista)
                if (x.imie == Oimie
                     && x.nazwisko == Onazwisko
                     && x.pesel == Opesel
                     && x.opis == Oopis
                     && x.data == Odata
                     && x.lekarz == Olekarz)
                {
                    del = Program.MojaLista.IndexOf(x);
                    
                }
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        string Oimie, Onazwisko, Opesel, Oopis, Odata, Olekarz, Ostatus;
        string haslo1, haslo2;
        int del;
        bool zapis = false;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            dateTimePicker_Rdata.Text = monthCalendar1.SelectionStart.ToShortDateString();
          
           
            
        }

        private void button_Rreje_Click(object sender, EventArgs e)
        {
            if (textBox_Rimie.Text != "" 
                && textBox_Rnazwisko.Text!=""
                && Convert.ToInt64(maskedTextBox_Rpesel.Text) > 999999999 
                && comboBox_Rlekarze.SelectedIndex>-1)
            {
                ZmianaWidoku();
                MessageBox.Show("Gratulujemy rejestracji na podane dane: " + textBox_Rimie.Text + " " + textBox_Rnazwisko.Text, "Rejestracja udana");
                rej = true;
              
                Program.MojaLista.Add(new Lekarz(textBox_Rimie.Text, 
                                                 textBox_Rnazwisko.Text,
                                                 maskedTextBox_Rpesel.Text,
                                                 textBox_Rinfo.Text,
                                                 dateTimePicker_Rdata.Text,
                                                 comboBox_Rlekarze.Text,
                                                 "Przed"));
                saveFileDialog1.FileName = textBox_Rnazwisko.Text + "_Rejestracja";
            }
            else
            {
                MessageBox.Show("Nie poprawde dane", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button_Rczysc_Click(object sender, EventArgs e)
        {
            czysc();
        }

        private void textBox_Rinfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            monthCalendar1.MinDate = monthCalendar1.TodayDate;
            dateTimePicker1.MinDate = monthCalendar1.TodayDate;
            button_Owroc.Visible = false;
            
            
        }

        private void button_Rzapis_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            
        }

        private void button_Uzaloguj_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            czysc_L();
            czysc_O();
            radioButton3.Checked = true;
            button_Rzapis.Visible = false;
            button_Owroc.Visible = false;
            comboBox_L.SelectedIndex=-1;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            dateTimePicker1.Text= monthCalendar1.TodayDate.ToShortDateString();
            if (button_Ozapisz.Enabled == true)
            {
                obsluga();
            }
            listBox_OLista.ClearSelected();
            listBox_Llista.Refresh();
            czysc();
            generuj_Po();
            generuj_Przed();
        }

        private void comboBox_Rlekarze_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button_Lnowy_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            button_Owroc.Visible = true;
        }

        private void button_Owroc_Click(object sender, EventArgs e)
        {
           tabControl1.SelectedIndex = 1;
        }

        private void button_Oedytuj_Click(object sender, EventArgs e)
        {
            if (listBox_OLista.SelectedItem != null)
            {

                przypisanie();
               
              
                obsluga();
            }
            else MessageBox.Show("Zaznacz dane do edycji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button_Ozapisz_Click(object sender, EventArgs e)
        {
            edycja();
            generuj_Po();
            generuj_Przed();
            if (radioButton3.Checked == true)
            {
                radioButton2.Checked = true;
                radioButton3.Checked = true;
            }
            listBox_OLista.Refresh();
            obsluga();

            listBox_OLista.ClearSelected();
        }

        private void listBox_OLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_OLista.SelectedItem != null)
            {
                textBox_Oimie.Text = (listBox_OLista.SelectedItem as Lekarz).imie;
                textBox_Onazwisko.Text = (listBox_OLista.SelectedItem as Lekarz).nazwisko;
                maskedTextBox_Opesel.Text = (listBox_OLista.SelectedItem as Lekarz).pesel;
                textBox_Oopis.Text = (listBox_OLista.SelectedItem as Lekarz).opis;
                comboBox_Olekarz.Text = (listBox_OLista.SelectedItem as Lekarz).lekarz;
                dateTimePicker2.Text = (listBox_OLista.SelectedItem as Lekarz).data;
                comboBox_Ostatus.Text = (listBox_OLista.SelectedItem as Lekarz).wykonanie;

            }
            if (button_Ozapisz.Enabled == true)
            {
                obsluga();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ZapiszDane();

            System.IO.StreamWriter file = new System.IO.StreamWriter(@".\haslo.txt");
            file.WriteLine(haslo1);
            file.WriteLine(haslo2);
            

            file.Close();
        }

        private void button_Ousun_Click(object sender, EventArgs e)
        {
            if (listBox_OLista.SelectedItem != null)
            {
                przypisanie();
                usun();
                Program.MojaLista.RemoveAt(del);
                generuj_Po();
                generuj_Przed();
                listBox_OLista.ClearSelected();
               
            }
            else MessageBox.Show("Zaznacz dane do usnięcia", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void textBox_Luwagi_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox_Llista_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox_Llista.SelectedItem != null)
            {
                textBox_Luwagi.Text = (listBox_Llista.SelectedItem as Lekarz).opis;
                textBox_Lrecepta.Text = "";
                textBox_Lchoroba.Text = "";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            czysc_L();
            generuj_L();
            listBox_Llista.ClearSelected();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            generuj_L();
            czysc_L();
            listBox_Llista.ClearSelected();
            
            
        }

        private void button_Lzatwierdz_Click(object sender, EventArgs e)
        {
            if (listBox_Llista.SelectedItem != null)
            {
                if (zapis)
                {
                    zmiana_statusu();
                    generuj_L();
                    czysc_L();
                    
                }

                else
                {
                    MessageBox.Show("Nie zapisałeś opisu i recepty", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    zapis = true;
                }
            }
            else 
                MessageBox.Show("Wybierz pacjęta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void textBox_Ostatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                
                listBox_OLista.DataSource = Program.Przed;
                generuj_Przed();
                listBox_OLista.Refresh();
                listBox_OLista.ClearSelected();
                czysc_O();
            }
            
            

           
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                
                listBox_OLista.DataSource = Program.Po;
                generuj_Po();
                listBox_OLista.Refresh();
               listBox_OLista.ClearSelected();
               czysc_O();

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton3.Checked == true)
            {
                
                listBox_OLista.DataSource = Program.MojaLista;
                listBox_OLista.Refresh();
                listBox_OLista.ClearSelected();
                czysc_O();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
            using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.Create))
            using (StreamWriter sw =new StreamWriter(s))
            {
                sw.Write("Dziękujemy za rejestracje !"+ Environment.NewLine+ "Imie i Nazwisko: "
                    +textBox_Rimie.Text+ " " + textBox_Rnazwisko.Text
                    + Environment.NewLine + "Pesel: " + maskedTextBox_Rpesel.Text
                    + Environment.NewLine + "Do lekarza: " + comboBox_Rlekarze.Text
                    + Environment.NewLine + "Data: " + dateTimePicker_Rdata.Text);
            }



               

            
        }

        private void button_LZapis_Click(object sender, EventArgs e)
        {
            if (listBox_Llista.SelectedItem != null)
            {
                saveFileDialog2.ShowDialog();
                zapis = true;
                
            }
            else 
            {
                MessageBox.Show("Wybierz pacjęta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
    }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            using (Stream pa = File.Open(saveFileDialog2.FileName, FileMode.Create))
            using (StreamWriter paw = new StreamWriter(pa))
            {
                paw.Write("Szanowa/y Pani/e: " + (listBox_Llista.SelectedItem as Lekarz).imie+ " "+(listBox_Llista.SelectedItem as Lekarz).nazwisko
                            + Environment.NewLine + "Lekarz " + comboBox_L.Text + " stwierdza: "
                            + Environment.NewLine + textBox_Lchoroba.Text
                            + Environment.NewLine + "Recepta:"
                            + Environment.NewLine + textBox_Lrecepta.Text
                            + Environment.NewLine + "Życzymy udanej kuracji i szybkiego powrotu do zdrowia");
            }
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            obsluga();
            czysc_O();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == haslo1)
            {
                panel1.Visible = false;
                maskedTextBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Błędne hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                maskedTextBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == haslo2)
            {
                panel2.Visible = false;
                maskedTextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Błędne hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                maskedTextBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (haslo2 == starehaslo2.Text)
            {
                haslo2 = nowehaslo2.Text;
                MessageBox.Show("Hasło zostało zmienione na: "+haslo2, "Gratulacje");
                groupBox1.Visible = false;
                nowehaslo2.Text = "";
                starehaslo2.Text = "";
            }
            else
            {
                MessageBox.Show("Błędne hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nowehaslo2.Text = "";
                starehaslo2.Text = "";

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = !groupBox2.Visible;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (haslo1 == starehaslo1.Text)
            {
                haslo1 = nowehaslo1.Text;
                MessageBox.Show("Hasło zostało zmienione na: " + haslo1, "Gratulacje");
                groupBox2.Visible = false;
                nowehaslo1.Text = "";
                starehaslo1.Text = "";
            }
            else
            {
                MessageBox.Show("Błędne hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nowehaslo1.Text = "";
                starehaslo1.Text = "";

            }
        }
      
        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void maskedTextBox_Rpesel_Enter(object sender, EventArgs e)
        {
           
        }

        private void maskedTextBox_Rpesel_Click(object sender, EventArgs e)
        {
            maskedTextBox_Rpesel.Select(0, 0);
        }

        private void maskedTextBox_Opesel_Click(object sender, EventArgs e)
        {
            maskedTextBox_Opesel.Select(0, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
