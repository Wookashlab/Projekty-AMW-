using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace SystemBankowy
{
    public class bazaClass
    {


         private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public bazaClass()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {
        server = "pma.bluequeen.tk";
        database = "db_labuda";
        uid = "db_labuda";
        password = "lukasz1";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    //Close connection
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    //Insert statement
    public void Insert(string wprowadz)
    {

          //open connection
    if (this.OpenConnection() == true)
    {
        //create command and assign the query and connection from the constructor
        MySqlCommand cmd = new MySqlCommand(wprowadz, connection);
        
        //Execute command
        cmd.ExecuteNonQuery();

        //close connection
        this.CloseConnection();
    }

    }

    //Update statement
    public void Update(string update)
    {

        //Open connection
        if (this.OpenConnection() == true)
        {
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = update;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }

    }

    //Delete statement
    public void Delete(string delete)
    {

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(delete, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

    }

    //Select statement
    public List <string> [] Select()
    {

        string query = "SELECT * FROM tableinfo";

        //Create a list to store the result
        List<string>[] list = new List<string>[3];
        list[0] = new List<string>();
        list[1] = new List<string>();
        list[2] = new List<string>();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["name"] + "");
                list[2].Add(dataReader["age"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }


    }


    //Count statement
    public int Count()
    {

        string query = "SELECT Count(*) FROM tableinfo";
        int Count = -1;

        //Open Connection
        if (this.OpenConnection() == true)
        {
            //Create Mysql Command
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //ExecuteScalar will return one value
            Count = int.Parse(cmd.ExecuteScalar() + "");

            //close Connection
            this.CloseConnection();

            return Count;
        }
        else
        {
            return Count;
        }


    }

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }




    public void wyswietl_tabele_klientow(DataGridView grid)
    {
        string query = "SELECT Klient.id_Klienta AS Klient, Konto.Numer_Konta AS Konto,	Karta.id_karty AS Karta, Klient.Imie,Klient.Nazwisko FROM Klient Left Join Konto ON Klient.id_Klienta = Konto.id_wlasciciela Left JOIN Karta ON Konto.Numer_Konta = Karta.numer_konta";
       if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
           this.CloseConnection();
        }
    }

    public void szukaj(DataGridView grid, string nazwisko)
    {
        string query = "SELECT Klient.id_Klienta AS Klient, Konto.Numer_Konta AS Konto,	Karta.id_karty AS Karta, Klient.Imie,Klient.Nazwisko FROM Klient Left Join Konto ON Klient.id_Klienta = Konto.id_wlasciciela Left JOIN Karta ON Konto.Numer_Konta = Karta.numer_konta WHERE Klient.Nazwisko='" + nazwisko + "';";
        if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
            this.CloseConnection();
        }
    }




    public void Konto(DataGridView grid, string numer_konta)
    {
        string query = "SELECT Numer_Konta, Saldo  FROM Konto WHERE Numer_Konta = '" + numer_konta + "';";
        if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
            this.CloseConnection();
        }
    }

    public void Karta(DataGridView grid, string numer_karty)
    {
        string query = "SELECT id_karty AS Numer_Karty, Karta.Numer_Konta, Saldo  FROM Konto, Karta WHERE Konto.Numer_Konta = Karta.numer_konta AND id_karty= '" + numer_karty + "';";
        if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
            this.CloseConnection();
        }
    }

    public void Transakcja(DataGridView grid, string numer_karty)
    {
        string query = "SELECT id_karty AS Numer_Karty, Karta.Numer_Konta, Data_waznosci  FROM Konto, Karta WHERE Konto.Numer_Konta = Karta.numer_konta AND id_karty= '" + numer_karty + "';";
        if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
            this.CloseConnection();
        }
    }



    public void HistoriaUP(DataGridView grid, string numer_karty)
    {
        string query = "SELECT id_karty AS Numer_Karty, Karta.Numer_Konta, Data_waznosci  FROM Konto, Karta WHERE Konto.Numer_Konta = Karta.numer_konta AND id_karty= '" + numer_karty + "';";
        if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
            this.CloseConnection();
        }
    }


    public void Historia(DataGridView grid, string numer_k, string data1, string data2, string order)
    {
        string query = "SELECT Karta.id_karty AS Karta, Transakcja.Data, Transakcja.Kwota, Transakcja.Opis FROM Konto Left Join Karta ON Konto.Numer_Konta = Karta.numer_konta Left JOIN Transakcja ON Karta.id_karty = Transakcja.id_karty WHERE Konto.Numer_Konta = '" + numer_k + "'AND Transakcja.Data >= '" + data1 + "' AND Transakcja.Data <= '" + data2 + "'ORDER BY Transakcja.Data" + order;
        if (this.OpenConnection() == true)
        {
            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, this.connection);
                DataSet DS = new DataSet(); //wczytanie dabel
                cmd.Fill(DS); //połączenei z msql i pobranie lini kodu
                grid.DataSource = DS.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Zgłoszenie błędu klienta " + e);
            }
            this.CloseConnection();
        }
    }





    }
}
