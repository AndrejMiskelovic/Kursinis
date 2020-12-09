using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class DBConnection
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-ARQFBOB;Initial Catalog = Country; Integrated Security = True");

        public List<Utility> Contries(List<Utility> utility)
        {
            con.Open();
            string query = "SELECT * FROM Price";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Utility d = new Utility();
                d.countryID = Convert.ToInt32(rd[0]);
                d.country = rd[1].ToString();
                d.water_m3 = Convert.ToDouble(rd[2]);
                d.gas_kWh = Convert.ToDouble(rd[3]);
                d.electricity_kWh = Convert.ToDouble(rd[4]);
                d.average = Convert.ToDouble(rd[5]);
                utility.Add(d);

            }
            rd.Close();
            con.Close();
            return utility;
        }
    }
}
