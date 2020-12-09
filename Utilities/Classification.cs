using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class Classification
    {
        static double[] water = new double[] { 0.6, 1.1, 1.5, 2, 3 };
        static double[] average = new double[] { 49, 89, 139, 189, 300 };
        static double[] gas = new double[] { 0.01, 0.025, 0.04, 0.08, 0.15 };
        static double[] electricity = new double[] { 0.05, 0.12, 0.22, 0.3, 0.4 };
        public void Class(List<Utility> Utilities, List<Utility> Cheap, List<Utility> Average, List<Utility> Expensive)
        {
            DBConnection dBConnection = new DBConnection();
            dBConnection.Contries(Utilities);

            foreach (var item in Utilities)
            {
                char cWater;
                char cGas;
                char cAverage;
                char cElectricity;
                #region Water
                if (item.water_m3 < water[1])
                {
                    cWater = 'c';
                }
                else if (item.water_m3 >= water[1] && item.water_m3 < water[3])
                {
                    cWater = 'a';
                }
                else
                {
                    cWater = 'e';
                }
                #endregion
                #region GAS
                if (item.gas_kWh < gas[1])
                {
                    cGas = 'c';
                }
                else if (item.gas_kWh >= gas[1] && item.gas_kWh < gas[3])
                {
                    cGas = 'a';
                }
                else
                {
                    cGas = 'e';
                }
                #endregion
                #region Electricity
                if (item.electricity_kWh < electricity[1])
                {
                    cElectricity = 'c';
                }
                else if (item.electricity_kWh >= electricity[1] && item.electricity_kWh < electricity[3])
                {
                    cElectricity = 'a';
                }
                else
                {
                    cElectricity = 'e';
                }
                #endregion
                #region Average
                if (item.average < average[1])
                {
                    cAverage = 'c';
                }
                else if (item.average >= average[1] && item.average < average[3])
                {
                    cAverage = 'a';
                }
                else
                {
                    cAverage = 'e';
                }
                #endregion
                string res = Convert.ToString(cWater) + Convert.ToString(cGas) + Convert.ToString(cElectricity) + Convert.ToString(cAverage);
                #region Classification
                if (res.Split('c').Length - 1 >= 3)
                {
                    Cheap.Add(item);
                }
                else if (res.Split('a').Length - 1 >= 3)
                {
                    Average.Add(item);
                }
                else if (res.Split('e').Length - 1 >= 3)
                {
                    Expensive.Add(item);
                }
                else if ((res.Split('c').Length - 1 == 2 && res.Split('e').Length - 1 == 2) || res.Split('c').Length - 1 == 2 && res.Split('a').Length - 1 == 2)
                {
                    Average.Add(item);
                }
                else if (res.Split('a').Length - 1 == 2 && res.Split('e').Length - 1 == 2)
                {
                    Expensive.Add(item);
                }
                else if (res.Split('c').Length - 1 == 2)
                {
                    Cheap.Add(item);
                }
                else if (res.Split('a').Length - 1 == 2)
                {
                    Average.Add(item);
                }
                else if (res.Split('e').Length - 1 == 2)
                {
                    Expensive.Add(item);
                }
                #endregion
            }
        }
    }
}
