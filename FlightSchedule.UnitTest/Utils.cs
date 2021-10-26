using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.UnitTest
{
    public class Utils
    {
        public static string GetFileContent(string sampleFile)
        {
            var content = string.Empty;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{typeof(Utils).Namespace}.{sampleFile}"))
            {
                content = new StreamReader(stream).ReadToEnd();
            }
            return content;
        }
    }
}
