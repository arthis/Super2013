using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.IO.Compression;

namespace Projections.InProcessEventBus.Tools
{
    public class Serialization
    {
        public static byte[] SerializeAndCompress(object obj)
        {
            return Compress(Serialize(obj));
        }

        public static string Serialize(object obj)
        {
            MemoryStream memStream = new MemoryStream();
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            xmlSerializer.Serialize(new StreamWriter(memStream, Encoding.UTF8), obj);
            return Encoding.UTF8.GetString(memStream.ToArray());
        }

        public static byte[] Compress(string text)
        {
            MemoryStream outStream = new MemoryStream();
            GZipStream gzipStream = new GZipStream(outStream, CompressionMode.Compress);
            StreamWriter gzipWriter = new StreamWriter(gzipStream, new UTF8Encoding(false));
            gzipWriter.Write(text);
            gzipWriter.Flush();
            gzipWriter.Dispose();
            gzipStream.Dispose();
            //GZipStream
            return outStream.ToArray();
        }
    }
}
