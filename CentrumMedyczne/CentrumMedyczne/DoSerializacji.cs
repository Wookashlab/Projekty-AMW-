using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary; 
using System.ComponentModel; 
namespace CentrumMedyczne
{
    [Serializable()]
    public class DoSerializacji : ISerializable
    {
        
        public BindingList<Lekarz> zapisanaLista { set; get; }
        public DoSerializacji(SerializationInfo info, StreamingContext ctxt)
        {
           
            this.zapisanaLista = (BindingList<Lekarz>)info.GetValue("Lista", typeof(BindingList<Lekarz>));
        }
        public DoSerializacji()
        { }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Lista", zapisanaLista); 
        }
    }
}
