using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class KNN
    {
        List<Utility> Utilities = new List<Utility>();
        List<double> result = new List<double>();

        public List<KNNSubUtility> KNNAlgorithm(float waterinput, float gasinput, float electricityinput, float averageinput)
        {
            DBConnection dBConnection = new DBConnection();
            dBConnection.Contries(Utilities);

            for (int i = 0; i < Utilities.Count; i++)
            {
                decimal water = 0;
                decimal gas = 0;
                decimal electricity = 0;
                decimal average = 0;
                if (waterinput != 0)
                {
                   water = (decimal)Math.Pow(Utilities[i].water_m3 - waterinput, 2);
                    string.Format("{0:0.00}", water);
                    //water = (float)System.Math.Round(water, 2);

                }
                if (gasinput != 0)
                {
                    gas = (decimal)Math.Pow(Utilities[i].gas_kWh - gasinput, 2);
                    string.Format("{0:0.00}", gas);
                    //gas = (float)System.Math.Round(gas, 2);

                }
                if (electricityinput != 0)
                {
                    electricity = (decimal)Math.Pow(Utilities[i].electricity_kWh - electricityinput, 2);
                    string.Format("{0:0.00}", electricity);
                    //electricity = (float)System.Math.Round(electricity, 2);

                }
                if (averageinput != 0)
                {
                    average = (decimal)Math.Pow(Utilities[i].average - averageinput, 2);
                    string.Format("{0:0.00}", average);
                    //average = (float)System.Math.Round(average, 2);

                }
                if (waterinput == 0 && gasinput == 0 && electricityinput == 0 && averageinput == 0)
                {
                    result.Add(-1);
                }
                else
                {
                    result.Add(Math.Sqrt(Convert.ToDouble(water) + Convert.ToDouble(gas) + Convert.ToDouble(electricity) + Convert.ToDouble(average)));
                }
            }
            List<KNNSubUtility> kNNSubUtility = new List<KNNSubUtility>();

            for (int i = 0; i < Utilities.Count; i++)
            {
                KNNSubUtility kNNSubUtility1 = new KNNSubUtility();
                kNNSubUtility1.countryID = Utilities[i].countryID;
                kNNSubUtility1.country = Utilities[i].country;
                kNNSubUtility1.water_m3 = Utilities[i].water_m3;
                kNNSubUtility1.gas_kWh = Utilities[i].gas_kWh;
                kNNSubUtility1.electricity_kWh = Utilities[i].electricity_kWh;
                kNNSubUtility1.average = Utilities[i].average;
                kNNSubUtility1.KNN = result[i];
                kNNSubUtility.Add(kNNSubUtility1);
            }
            
            return kNNSubUtility = kNNSubUtility.OrderBy(o => o.KNN).ToList();
        }
}
}
