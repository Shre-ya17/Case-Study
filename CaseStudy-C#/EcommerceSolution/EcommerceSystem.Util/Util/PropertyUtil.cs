using System.IO;

namespace EcommerceSystem.Util
{
    public class PropertyUtil
    {
        public static string GetPropertyString()
        {
            return File.ReadAllText("config/dbconfig.txt");
        }
    }
}