using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CentrumMedyczne
{
    [Serializable()]
    public class Lekarz : ISerializable
    {
        public string imie { set; get; }
        public string nazwisko{ set; get; }
        public string pesel{ set; get; }
        public string opis{ set; get; }
        public string data{ set; get; } 
        public string lekarz { set; get; }
        public string recepta { set; get; }
        public string choroba { set; get; }
        public string wykonanie { set; get; }
        

        public Lekarz()
        { }
        public Lekarz(string Im, string Nz, string ps, string op, string da, string lek, string wyk)
        {
            imie = Im;
            nazwisko = Nz;
            pesel = ps;
            opis = op;
            data = da;
            lekarz = lek;
            wykonanie = wyk;

           
        }

        public Lekarz(SerializationInfo info, StreamingContext ctxt)
        { 
            this.imie = info.GetString("imie");
            this.nazwisko = info.GetString("nazwisko");
            this.pesel = info.GetString("pesel");
            this.opis = info.GetString("opis");
            this.data = info.GetString("data");
            this.lekarz = info.GetString("lekarz");
            this.recepta = info.GetString("recepta");
            this.choroba = info.GetString("choroba");
            this.wykonanie = info.GetString("wykonanie");

        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        { 
            info.AddValue("imie", this.imie);
            info.AddValue("nazwisko", this.nazwisko);
            info.AddValue("pesel", this.pesel);
            info.AddValue("opis", this.opis);
            info.AddValue("data", this.data);
            info.AddValue("lekarz", this.lekarz);
            info.AddValue("recepta", this.recepta);
            info.AddValue("choroba", this.choroba);
            info.AddValue("wykonanie", this.wykonanie);
        }

        public override string ToString()
        {
            return data + "  || " + lekarz + ": " + imie + " " + nazwisko;
        }

    }
}
