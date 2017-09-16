using System.IO;
using System.Xml.Serialization;

namespace Race.Common.Service
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>(string content)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(T),
            //         new XmlRootAttribute
            //         {
            //             ElementName = "Submission_x0023_0"
            //         });

            //T result = (T)serializer.Deserialize(new StringReader(content));

            using (TextReader txtReader = new StringReader(content))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                T result = (T)xmlSerializer.Deserialize(txtReader);

                return result;
            }            
        }
    }
}
