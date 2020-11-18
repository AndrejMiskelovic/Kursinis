using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utilities
{
    class NaiveB
    {
        static string[] classes = new string[] { "Cheap", "Average", "Expensive" };
        static double[] water = new double[] { 0.6, 1.1, 1.5, 2, 3 };
        static double[] average = new double[] { 49, 89, 139, 189, 300 };
        static double[] gas = new double[] { 0.01, 0.025, 0.04, 0.08, 0.15 };
        static double[] electricity = new double[] { 0.05, 0.12, 0.22, 0.3, 0.4 };
        List<Utility> Cheap = new List<Utility>();
        List<Utility> Average = new List<Utility>();
        List<Utility> Expensive = new List<Utility>();
        List<Utility> Utilities = new List<Utility>();

        public List<Utility> NaiveBAlgorithm(float waterinput, float gasinput, float electricityinput, float averageinput)
        {
            Classification classification = new Classification();
            classification.Class(Utilities, Cheap, Average, Expensive);
            float dCheap = (float)Cheap.Count / Utilities.Count;
            float dAverage = (float)Average.Count / Utilities.Count;
            float dExpansive = (float)Expensive.Count / Utilities.Count;

            float PtCheap = 0;
            float PtAverage = 0;
            float PtExpansive = 0;

            //float[,] temporary = new float[6, 3];
            for (int i = 0; i < 4; i++)
            {
                float[,] temporary = new float[6, 3];

                if (i == 0)
                {
                    if (waterinput != 0)
                    {
                        temporary[0, 0] = (float)NaiveBCalculationWater(Cheap, 0, water[0]) / Cheap.Count;
                        temporary[1, 0] = (float)NaiveBCalculationWater(Cheap, water[0], water[1]) / Cheap.Count;
                        temporary[2, 0] = (float)NaiveBCalculationWater(Cheap, water[1], water[2]) / Cheap.Count;
                        temporary[3, 0] = (float)NaiveBCalculationWater(Cheap, water[2], water[3]) / Cheap.Count;
                        temporary[4, 0] = (float)NaiveBCalculationWater(Cheap, water[3], water[4]) / Cheap.Count;
                        temporary[5, 0] = (float)NaiveBCalculationWater(Cheap, water[4], 1501) / Cheap.Count;

                        if (waterinput < water[0])
                            PtCheap += temporary[0, 0];
                        else if (waterinput >= water[0] && waterinput < water[1])
                            PtCheap += temporary[1, 0];
                        else if (waterinput >= water[1] && waterinput < water[2])
                            PtCheap += temporary[2, 0];
                        else if (waterinput >= water[2] && waterinput < water[3])
                            PtCheap += temporary[3, 0];
                        else if (waterinput >= water[3] && waterinput < water[4])
                            PtCheap += temporary[4, 0];
                        else if (waterinput >= water[4] && waterinput < 1501)
                            PtCheap += temporary[5, 0];

                        temporary[0, 1] = (float)NaiveBCalculationWater(Average, 0, water[0]) / Average.Count;
                        temporary[1, 1] = (float)NaiveBCalculationWater(Average, water[0], water[1]) / Average.Count;
                        temporary[2, 1] = (float)NaiveBCalculationWater(Average, water[1], water[2]) / Average.Count;
                        temporary[3, 1] = (float)NaiveBCalculationWater(Average, water[2], water[3]) / Average.Count;
                        temporary[4, 1] = (float)NaiveBCalculationWater(Average, water[3], water[4]) / Average.Count;
                        temporary[5, 1] = (float)NaiveBCalculationWater(Average, water[4], 1501) / Average.Count;

                        if (waterinput < water[0])
                            PtAverage += temporary[0, 1];
                        else if (waterinput >= water[0] && waterinput < water[1])
                            PtAverage += temporary[1, 1];
                        else if (waterinput >= water[1] && waterinput < water[2])
                            PtAverage += temporary[2, 1];
                        else if (waterinput >= water[2] && waterinput < water[3])
                            PtAverage += temporary[3, 1];
                        else if (waterinput >= water[3] && waterinput < water[4])
                            PtAverage += temporary[4, 1];
                        else if (waterinput >= water[4] && waterinput < 1501)
                            PtAverage += temporary[5, 1];

                        temporary[0, 2] = (float)NaiveBCalculationWater(Expensive, 0, water[0]) / Expensive.Count;
                        temporary[1, 2] = (float)NaiveBCalculationWater(Expensive, water[0], water[1]) / Expensive.Count;
                        temporary[2, 2] = (float)NaiveBCalculationWater(Expensive, water[1], water[2]) / Expensive.Count;
                        temporary[3, 2] = (float)NaiveBCalculationWater(Expensive, water[2], water[3]) / Expensive.Count;
                        temporary[4, 2] = (float)NaiveBCalculationWater(Expensive, water[3], water[4]) / Expensive.Count;
                        temporary[5, 2] = (float)NaiveBCalculationWater(Expensive, water[4], 1501) / Expensive.Count;

                        if (waterinput < water[0])
                            PtExpansive += temporary[0, 2];
                        else if (waterinput >= water[0] && waterinput < water[1])
                            PtExpansive += temporary[1, 2];
                        else if (waterinput >= water[1] && waterinput < water[2])
                            PtExpansive += temporary[2, 2];
                        else if (waterinput >= water[2] && waterinput < water[3])
                            PtExpansive += temporary[3, 2];
                        else if (waterinput >= water[3] && waterinput < water[4])
                            PtExpansive += temporary[4, 2];
                        else if (waterinput >= water[4] && waterinput < 1501)
                            PtExpansive += temporary[5, 2];


                    }
                }
                else if (i == 1)
                {
                    if (gasinput != 0)
                    {
                        temporary[0, 0] = (float)NaiveBCalculationGas(Cheap, 0, gas[0]) / Cheap.Count;
                        temporary[1, 0] = (float)NaiveBCalculationGas(Cheap, gas[0], gas[1]) / Cheap.Count;
                        temporary[2, 0] = (float)NaiveBCalculationGas(Cheap, gas[1], gas[2]) / Cheap.Count;
                        temporary[3, 0] = (float)NaiveBCalculationGas(Cheap, gas[2], gas[3]) / Cheap.Count;
                        temporary[4, 0] = (float)NaiveBCalculationGas(Cheap, gas[3], gas[4]) / Cheap.Count;
                        temporary[5, 0] = (float)NaiveBCalculationGas(Cheap, gas[4], 1501) / Cheap.Count;

                        if (gasinput < gas[0])
                            PtCheap += temporary[0, 0];
                        else if (gasinput >= gas[0] && gasinput < gas[1])
                            PtCheap += temporary[1, 0];
                        else if (gasinput >= gas[1] && gasinput < gas[2])
                            PtCheap += temporary[2, 0];
                        else if (gasinput >= gas[2] && gasinput < gas[3])
                            PtCheap += temporary[3, 0];
                        else if (gasinput >= gas[3] && gasinput < gas[4])
                            PtCheap += temporary[4, 0];
                        else if (gasinput >= gas[4] && gasinput < 1501)
                            PtCheap += temporary[5, 0];

                        temporary[0, 1] = (float)NaiveBCalculationGas(Average, 0, gas[0]) / Average.Count;
                        temporary[1, 1] = (float)NaiveBCalculationGas(Average, gas[0], gas[1]) / Average.Count;
                        temporary[2, 1] = (float)NaiveBCalculationGas(Average, gas[1], gas[2]) / Average.Count;
                        temporary[3, 1] = (float)NaiveBCalculationGas(Average, gas[2], gas[3]) / Average.Count;
                        temporary[4, 1] = (float)NaiveBCalculationGas(Average, gas[3], gas[4]) / Average.Count;
                        temporary[5, 1] = (float)NaiveBCalculationGas(Average, gas[4], 1501) / Average.Count;

                        if (gasinput < gas[0])
                            PtAverage += temporary[0, 1];
                        else if (gasinput >= gas[0] && gasinput < gas[1])
                            PtAverage += temporary[1, 1];
                        else if (gasinput >= gas[1] && gasinput < gas[2])
                            PtAverage += temporary[2, 1];
                        else if (gasinput >= gas[2] && gasinput < gas[3])
                            PtAverage += temporary[3, 1];
                        else if (gasinput >= gas[3] && gasinput < gas[4])
                            PtAverage += temporary[4, 1];
                        else if (gasinput >= gas[4] && gasinput < 1501)
                            PtAverage += temporary[5, 1];

                        temporary[0, 2] = (float)NaiveBCalculationGas(Expensive, 0, gas[0]) / Expensive.Count;
                        temporary[1, 2] = (float)NaiveBCalculationGas(Expensive, gas[0], gas[1]) / Expensive.Count;
                        temporary[2, 2] = (float)NaiveBCalculationGas(Expensive, gas[1], gas[2]) / Expensive.Count;
                        temporary[3, 2] = (float)NaiveBCalculationGas(Expensive, gas[2], gas[3]) / Expensive.Count;
                        temporary[4, 2] = (float)NaiveBCalculationGas(Expensive, gas[3], gas[4]) / Expensive.Count;
                        temporary[5, 2] = (float)NaiveBCalculationGas(Expensive, gas[4], 1501) / Expensive.Count;

                        if (gasinput < gas[0])
                            PtExpansive += temporary[0, 2];
                        else if (gasinput >= gas[0] && gasinput < gas[1])
                            PtExpansive += temporary[1, 2];
                        else if (gasinput >= gas[1] && gasinput < gas[2])
                            PtExpansive += temporary[2, 2];
                        else if (gasinput >= gas[2] && gasinput < gas[3])
                            PtExpansive += temporary[3, 2];
                        else if (gasinput >= gas[3] && gasinput < gas[4])
                            PtExpansive += temporary[4, 2];
                        else if (gasinput >= gas[4] && gasinput < 1501)
                            PtExpansive += temporary[5, 2];
                    }

                }
                else if (i == 2)
                {
                    if (electricityinput != 0)
                    {

                        temporary[0, 0] = (float)NaiveBCalculationElectricity(Cheap, 0, electricity[0]) / Cheap.Count;
                        temporary[1, 0] = (float)NaiveBCalculationElectricity(Cheap, electricity[0], electricity[1]) / Cheap.Count;
                        temporary[2, 0] = (float)NaiveBCalculationElectricity(Cheap, electricity[1], electricity[2]) / Cheap.Count;
                        temporary[3, 0] = (float)NaiveBCalculationElectricity(Cheap, electricity[2], electricity[3]) / Cheap.Count;
                        temporary[4, 0] = (float)NaiveBCalculationElectricity(Cheap, electricity[3], electricity[4]) / Cheap.Count;
                        temporary[5, 0] = (float)NaiveBCalculationElectricity(Cheap, electricity[4], 1501) / Cheap.Count;

                        if (electricityinput < electricity[0])
                            PtCheap += temporary[0, 0];
                        else if (electricityinput >= electricity[0] && electricityinput < electricity[1])
                            PtCheap += temporary[1, 0];
                        else if (electricityinput >= electricity[1] && electricityinput < electricity[2])
                            PtCheap += temporary[2, 0];
                        else if (electricityinput >= electricity[2] && electricityinput < electricity[3])
                            PtCheap += temporary[3, 0];
                        else if (electricityinput >= electricity[3] && electricityinput < electricity[4])
                            PtCheap += temporary[4, 0];
                        else if (electricityinput >= electricity[4] && electricityinput < 1501)
                            PtCheap += temporary[5, 0];

                        temporary[0, 1] = (float)NaiveBCalculationElectricity(Average, 0, electricity[0]) / Average.Count;
                        temporary[1, 1] = (float)NaiveBCalculationElectricity(Average, electricity[0], electricity[1]) / Average.Count;
                        temporary[2, 1] = (float)NaiveBCalculationElectricity(Average, electricity[1], electricity[2]) / Average.Count;
                        temporary[3, 1] = (float)NaiveBCalculationElectricity(Average, electricity[2], electricity[3]) / Average.Count;
                        temporary[4, 1] = (float)NaiveBCalculationElectricity(Average, electricity[3], electricity[4]) / Average.Count;
                        temporary[5, 1] = (float)NaiveBCalculationElectricity(Average, electricity[4], 1501) / Average.Count;

                        if (electricityinput < electricity[0])
                            PtAverage += temporary[0, 1];
                        else if (electricityinput >= electricity[0] && electricityinput < electricity[1])
                            PtAverage += temporary[1, 1];
                        else if (electricityinput >= electricity[1] && electricityinput < electricity[2])
                            PtAverage += temporary[2, 1];
                        else if (electricityinput >= electricity[2] && electricityinput < electricity[3])
                            PtAverage += temporary[3, 1];
                        else if (electricityinput >= electricity[3] && electricityinput < electricity[4])
                            PtAverage += temporary[4, 1];
                        else if (electricityinput >= electricity[4] && electricityinput < 1501)
                            PtAverage += temporary[5, 1];

                        temporary[0, 2] = (float)NaiveBCalculationElectricity(Expensive, 0, electricity[0]) / Expensive.Count;
                        temporary[1, 2] = (float)NaiveBCalculationElectricity(Expensive, electricity[0], electricity[1]) / Expensive.Count;
                        temporary[2, 2] = (float)NaiveBCalculationElectricity(Expensive, electricity[1], electricity[2]) / Expensive.Count;
                        temporary[3, 2] = (float)NaiveBCalculationElectricity(Expensive, electricity[2], electricity[3]) / Expensive.Count;
                        temporary[4, 2] = (float)NaiveBCalculationElectricity(Expensive, electricity[3], electricity[4]) / Expensive.Count;
                        temporary[5, 2] = (float)NaiveBCalculationElectricity(Expensive, electricity[4], 1501) / Expensive.Count;

                        if (electricityinput < electricity[0])
                            PtExpansive += temporary[0, 2];
                        else if (electricityinput >= electricity[0] && electricityinput < electricity[1])
                            PtExpansive += temporary[1, 2];
                        else if (electricityinput >= electricity[1] && electricityinput < electricity[2])
                            PtExpansive += temporary[2, 2];
                        else if (electricityinput >= electricity[2] && electricityinput < electricity[3])
                            PtExpansive += temporary[3, 2];
                        else if (electricityinput >= electricity[3] && electricityinput < electricity[4])
                            PtExpansive += temporary[4, 2];
                        else if (electricityinput >= electricity[4] && electricityinput < 1501)
                            PtExpansive += temporary[5, 2];
                    }
                }
                else
                {
                    if (averageinput != 0)
                    {
                        temporary[0, 0] = (float)NaiveBCalculationAverage(Cheap, 0, average[0]) / Cheap.Count;
                        temporary[1, 0] = (float)NaiveBCalculationAverage(Cheap, average[0], average[1]) / Cheap.Count;
                        temporary[2, 0] = (float)NaiveBCalculationAverage(Cheap, average[1], average[2]) / Cheap.Count;
                        temporary[3, 0] = (float)NaiveBCalculationAverage(Cheap, average[2], average[3]) / Cheap.Count;
                        temporary[4, 0] = (float)NaiveBCalculationAverage(Cheap, average[3], average[4]) / Cheap.Count;
                        temporary[5, 0] = (float)NaiveBCalculationAverage(Cheap, average[4], 1501) / Cheap.Count;

                        if (averageinput < average[0])
                            PtCheap += temporary[0, 0];
                        else if (averageinput >= average[0] && averageinput < average[1])
                            PtCheap += temporary[1, 0];
                        else if (averageinput >= average[1] && averageinput < average[2])
                            PtCheap += temporary[2, 0];
                        else if (averageinput >= average[2] && averageinput < average[3])
                            PtCheap += temporary[3, 0];
                        else if (averageinput >= average[3] && averageinput < average[4])
                            PtCheap += temporary[4, 0];
                        else if (averageinput >= average[4] && averageinput < 1501)
                            PtCheap += temporary[5, 0];

                        temporary[0, 1] = (float)NaiveBCalculationAverage(Average, 0, average[0]) / Average.Count;
                        temporary[1, 1] = (float)NaiveBCalculationAverage(Average, average[0], average[1]) / Average.Count;
                        temporary[2, 1] = (float)NaiveBCalculationAverage(Average, average[1], average[2]) / Average.Count;
                        temporary[3, 1] = (float)NaiveBCalculationAverage(Average, average[2], average[3]) / Average.Count;
                        temporary[4, 1] = (float)NaiveBCalculationAverage(Average, average[3], average[4]) / Average.Count;
                        temporary[5, 1] = (float)NaiveBCalculationAverage(Average, average[4], 1501) / Average.Count;

                        if (averageinput < average[0])
                            PtAverage += temporary[0, 1];
                        else if (averageinput >= average[0] && averageinput < average[1])
                            PtAverage += temporary[1, 1];
                        else if (averageinput >= average[1] && averageinput < average[2])
                            PtAverage += temporary[2, 1];
                        else if (averageinput >= average[2] && averageinput < average[3])
                            PtAverage += temporary[3, 1];
                        else if (averageinput >= average[3] && averageinput < average[4])
                            PtAverage += temporary[4, 1];
                        else if (averageinput >= average[4] && averageinput < 1501)
                            PtAverage += temporary[5, 1];

                        temporary[0, 2] = (float)NaiveBCalculationAverage(Expensive, 0, average[0]) / Expensive.Count;
                        temporary[1, 2] = (float)NaiveBCalculationAverage(Expensive, average[0], average[1]) / Expensive.Count;
                        temporary[2, 2] = (float)NaiveBCalculationAverage(Expensive, average[1], average[2]) / Expensive.Count;
                        temporary[3, 2] = (float)NaiveBCalculationAverage(Expensive, average[2], average[3]) / Expensive.Count;
                        temporary[4, 2] = (float)NaiveBCalculationAverage(Expensive, average[3], average[4]) / Expensive.Count;
                        temporary[5, 2] = (float)NaiveBCalculationAverage(Expensive, average[4], 1501) / Expensive.Count;

                        if (averageinput < average[0])
                            PtExpansive += temporary[0, 2];
                        else if (averageinput >= average[0] && averageinput < average[1])
                            PtExpansive += temporary[1, 2];
                        else if (averageinput >= average[1] && averageinput < average[2])
                            PtExpansive += temporary[2, 2];
                        else if (averageinput >= average[2] && averageinput < average[3])
                            PtExpansive += temporary[3, 2];
                        else if (averageinput >= average[3] && averageinput < average[4])
                            PtExpansive += temporary[4, 2];
                        else if (averageinput >= average[4] && averageinput < 1501)
                            PtExpansive += temporary[5, 2];
                    }
                }
            }
            PtCheap = (float)PtCheap / 4;
            PtAverage = (float)PtAverage / 4;
            PtExpansive = (float)PtExpansive / 4;

            float likeHoudCheap = PtCheap * dCheap;
            float likeHoudAverage = PtAverage * dAverage;
            float likeHoudExpansive = PtExpansive * dExpansive;

            float Pt = likeHoudCheap + likeHoudAverage + likeHoudExpansive;

            float PfinalCheap = ((float)likeHoudCheap / Pt) * 100;
            float PfinalAverage = ((float)likeHoudAverage / Pt) * 100;
            float PfinalExpansive = ((float)likeHoudExpansive / Pt) * 100;

            if (waterinput == 0 && gasinput == 0 && electricityinput == 0 && averageinput == 0)
            {
                return Utilities;
            }
            else if (PfinalCheap > PfinalAverage && PfinalCheap > PfinalExpansive)
            {
                return Cheap;
            }
            else if (PfinalAverage > PfinalCheap && PfinalAverage > PfinalExpansive)
            {
                return Average;
            }
            else //(PfinalExpansive > PfinalCheap && PfinalExpansive > PfinalAverage)
            {
                return Expensive;
            }

            // return "asd";

        }
        public int NaiveBCalculationWater(List<Utility> listU, double range1, double range2)
        {
            int cnt = 0;
            foreach (var item in listU)
            {
                if (item.water_m3 >= range1 && item.water_m3 < range2)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        public int NaiveBCalculationGas(List<Utility> listU, double range1, double range2)
        {
            int cnt = 0;
            foreach (var item in listU)
            {
                if (item.gas_kWh >= range1 && item.gas_kWh < range2)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        public int NaiveBCalculationElectricity(List<Utility> listU, double range1, double range2)
        {
            int cnt = 0;
            foreach (var item in listU)
            {
                if (item.electricity_kWh >= range1 && item.electricity_kWh < range2)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        public int NaiveBCalculationAverage(List<Utility> listU, double range1, double range2)
        {
            int cnt = 0;
            foreach (var item in listU)
            {
                if (item.average >= range1 && item.average < range2)
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
    }
