using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CommonClassLibrary
{
    public class SerializationFormatter
    {
        private SerializationFormatter()
        {

        }

        public static byte[] GetSerializationBytes(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            byte[] message = stream.ToArray();
            stream.Close();

            return message;
        }
    }
}
