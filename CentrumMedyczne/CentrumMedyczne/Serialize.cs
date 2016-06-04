using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CentrumMedyczne
{
    public static class Serializer<T>
    {
       
        private static object myobj = new object();

        public static void Serialize(T myobj, string path)
        {
            lock (myobj)
            {
                if (myobj != null)
                {
                    using (Stream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var binary = new BinaryFormatter();
                        binary.Serialize(fs, myobj);
                        fs.Close();
                    }
                }
            }
        }
        public static T Deserialize(string path)
        {
            T abc = default(T);
            lock (myobj)
            {
                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        if (fs.Length > 0)
                        {
                            var binary = new BinaryFormatter();
                            return (T)binary.Deserialize(fs);
                        }
                        fs.Close();
                    }
                }
            }
            return abc;
        }
    }
}
