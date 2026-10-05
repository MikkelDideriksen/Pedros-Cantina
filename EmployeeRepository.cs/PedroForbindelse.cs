using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace PedroLib
{
    public class PedroForbindelse
    {
        SqlConnection _forbind;
        public SqlConnection Forbindelse
        {
            get { return _forbind; }
            set { _forbind = value; }
        }

        public PedroForbindelse()
        {
            _forbind = new SqlConnection();
        }

        public static string HentConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
                .Build();

            return configuration["Pcstring"]
                ?? throw new InvalidOperationException("Pcstring blev ikke fundet i User Secrets.");
        }

        public void OpretForbindelse()
        {
            _forbind = new SqlConnection(HentConnectionString());
            _forbind.Open();
        }

        public void LukForbindelse()
        {
            _forbind.Close();
        }
    }
}