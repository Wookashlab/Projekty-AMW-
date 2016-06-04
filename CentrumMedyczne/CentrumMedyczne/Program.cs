using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace CentrumMedyczne
{
    static class Program
    {
        public static BindingList<Lekarz> MojaLista = new BindingList<Lekarz>();
        public static BindingList<Lekarz> Pomoc = new BindingList<Lekarz>();
        public static BindingList<Lekarz> Przed = new BindingList<Lekarz>();
        public static BindingList<Lekarz> Po = new BindingList<Lekarz>();
       
        [STAThread]
        static void Main()

        {
           // ZapiszDane();
            PobierzDane();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            Application.Run(new Form1());
            

        }
            
            public static void ZapiszDane()
        {
            DoSerializacji zapis = new DoSerializacji(); 
            zapis.zapisanaLista = Program.MojaLista; 
            Serializer<DoSerializacji>.Serialize(zapis, @".\database.bin"); 
        }
        public static void PobierzDane()
        {
            DoSerializacji odczyt = new DoSerializacji(); 
            odczyt = Serializer<DoSerializacji>.Deserialize(@".\database.bin"); 
            Program.MojaLista = odczyt.zapisanaLista; 
        }
        
    }
}
