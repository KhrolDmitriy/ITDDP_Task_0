using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITiROD_Lab_1
{
    public class JsonWriter
    {      
        public static void Write(Group group, string path)
        {
            TextWriter writer = null;
            try
            {
                var data = JsonConvert.SerializeObject(group);
                writer = new StreamWriter(path, false);
                writer.Write(data);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
