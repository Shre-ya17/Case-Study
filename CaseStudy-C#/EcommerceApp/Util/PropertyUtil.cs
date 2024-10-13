using System.Configuration;

namespace EcommerceApp.Util
{
    public static class PropertyUtil
    {
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key]?.ConnectionString;
        }
    }
}
