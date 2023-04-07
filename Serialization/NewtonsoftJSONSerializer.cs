using Newtonsoft.Json;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Serialization
{
    public class NewtonsoftJSONSerializer : ISerializer
    {
        public void Serialize(string path, object value)
        {
            string data = JsonConvert.SerializeObject(value, Formatting.Indented);

            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(data);
                }
            }
        }

        public bool Deserialize(string path, Type type, out object value)
        {
            value = default;
            string data = default;

            if (File.Exists(path))
            {
                using (var stream = File.Open(path, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        data = reader.ReadString();
                    }
                }

                Console.WriteLine("aaaaaaaaaaaaaa: " + data);
            }

            if (string.IsNullOrEmpty(data))
                return false;

            value = JsonConvert.DeserializeObject(data, type);
            return true;
        }

    }
}