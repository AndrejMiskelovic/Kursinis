using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    class SimpleAp
    {
        List<Utility> Cheap = new List<Utility>();
        List<Utility> Average = new List<Utility>();
        List<Utility> Expensive = new List<Utility>();
        List<Utility> Utilities = new List<Utility>();
        public List<Utility> SimpleApproachAlgorithm(float waterinput, float gasinput, float electricityinput, float averageinput)
        {
            
            Classification classification = new Classification();
            classification.Class(Utilities,Cheap,Average,Expensive);
            List<float> cheapcentre = new List<float>();
            List<float> averagecentre = new List<float>();
            List<float> expensivecentre = new List<float>();

            List<float> CheapDistance = new List<float>();
            List<float> AverageDistance = new List<float>();
            List<float> ExpensiveDistance = new List<float>();

            CenterSearch(cheapcentre, Cheap);
            CenterSearch(averagecentre, Average);
            CenterSearch(expensivecentre, Expensive);

            decimal water = 0;
            decimal gas = 0;
            decimal electricity = 0;
            decimal average = 0;
            
            if (waterinput != 0)
            {
                CheapDistance.Add((float)Math.Pow(cheapcentre[0] - waterinput, 2));
                AverageDistance.Add((float)Math.Pow(averagecentre[0] - waterinput, 2));
                ExpensiveDistance.Add((float)Math.Pow(expensivecentre[0] - waterinput, 2));
            }
            if (gasinput != 0)
            {
                CheapDistance.Add((float)Math.Pow(cheapcentre[1] - gasinput, 2));
                AverageDistance.Add((float)Math.Pow(averagecentre[1] - gasinput, 2));
                ExpensiveDistance.Add((float)Math.Pow(expensivecentre[1] - gasinput, 2));


            }
            if (electricityinput != 0)
            {
                CheapDistance.Add((float)Math.Pow(cheapcentre[2] - electricityinput, 2));
                AverageDistance.Add((float)Math.Pow(averagecentre[2] - electricityinput, 2));
                ExpensiveDistance.Add((float)Math.Pow(expensivecentre[2] - electricityinput, 2));

            }
            if (averageinput != 0)
            {
                CheapDistance.Add((float)Math.Pow(cheapcentre[3] - averageinput, 2));
                AverageDistance.Add((float)Math.Pow(averagecentre[3] - averageinput, 2));
                ExpensiveDistance.Add((float)Math.Pow(expensivecentre[3] - averageinput, 2));

            }
            if (waterinput == 0 && gasinput == 0 && electricityinput == 0 && averageinput == 0)
            {
                return Utilities;
            }
            else
            {
                float one = 0;
                float two = 0;
                float three = 0;
                for (int i = 0; i < CheapDistance.Count; i++)
                {
                    one += CheapDistance[i];
                }
                for (int i = 0; i < AverageDistance.Count; i++)
                {
                    two += AverageDistance[i];
                }
                for (int i = 0; i < ExpensiveDistance.Count; i++)
                {
                    three += ExpensiveDistance[i];
                }
                one = (float)Math.Sqrt(one);
                two = (float)Math.Sqrt(two);
                three = (float)Math.Sqrt(three);
                if (one < two && one < three)
                {
                    return Cheap;
                }
                else if (two < one && two < three)
                {
                    return Average;
                }
                else //(PfinalExpansive > PfinalCheap && PfinalExpansive > PfinalAverage)
                {
                    return Expensive;
                }
            }

        }
        private void CenterSearch(List<float> Name, List<Utility> utilities)
        {
            float water = 0;
            float gas = 0;
            float electricity = 0;
            float average = 0;
            foreach (var item in utilities)
            {
                water += (float)item.water_m3;
                gas += (float)item.gas_kWh;
                electricity += (float)item.electricity_kWh;
                average += (float)item.average;
            }
            Name.Add(water / Cheap.Count);
            Name.Add(gas / Cheap.Count);
            Name.Add(electricity / Cheap.Count);
            Name.Add(average / Cheap.Count);
        }
    }
}
