using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;

namespace ConstructionCalculator
{
    class HomeMessurement
    {
        public int Rooms { get; set; }
        public int Bath { get; set; }
        public int Closet { get; set; }
        public float Office { get; set; }
        public int Theater { get; set; }
        public float Living { get; set; }
        public int Balcony { get; set; }
        public int Garage { get; set; }
        public float Kitchen { get; set; }
        public float Pool { get; set; }
        public float PartialArea { get; set; }
        public float ComplementaryArea { get; set; }
        public float TotalArea { get; set; }
        public float TerrainPrice { get; set; }
        public float ConstructionPrice { get; set; }
        public float TotalPrice { get; set; }

       const int CoupleRoom = 14;
       const int SingleRoom = 9;
       const float CoupleBath = 7.5f;
       const float SingleBath = 5f;
       const int CoupleCloset = 6;
       const int SingleCloset = 4;
       const float LivingOne = 20.0f;
       const float LivingTwo = 27.0f;
       const float LivingThree = 38.5f;
       const int BalconyA = 20;
       const int BalconyB = 30;
       const int BalconyC = 44;
       const int Garage2 = 21;
       const int Garage3 = 46;
       const int Garage4 = 67;
       const float KitchenA = 10.5f;
       const float KitchenB = 14.0f;
       const float PoolA = 7.5f;
       const float PoolB = 14.0f;
       const float ComplArea210 = 51.1f;
       const float ComplArea135 = 14.75f;
       const float ComplArea135210 = 30.2f;
       const float Terrain135 = 120000.00f;
       const float Terrain135210 = 160000.00f;
       const float Terrain210 = 220000.00f;
       const float ConstructionPrice135 = 2300.00f;
       const float ConstructionPrice135210 = 2800.00f;
       const float ConstructionPreice210 = 3500.00f;


        public float CalculateRooms(int n)
        {
            //Formula: ='01'!D11+((C6-1)*'01'!D12)
            //casal         14  m2 
            //solteiro       9   m2
            return (CoupleRoom + ((n - 1) * SingleRoom));
        }
        public float CalculateBath(int n)
        {
            //Formula: ='01'!D15+((C8-1)*'01'!D16)
            //Casal     7,5
            //solteiro    5
            return (CoupleBath + ((n - 1) * SingleBath));
        }
        public float CalculateCloset(int n)
        {
            //Formula: ='01'!D19+((C10-1)*'01'!D20)
            return (CoupleCloset + ((n - 1) * SingleCloset));
        }
        public void CalculateOffice(char c)
        {
            if (c == 'S' || c == 's')
            {
                Office = 7.5f;
            }
            else
            {
                Office = 0.0f;
            }
        }
        public void CalculateTheater(char c)
        {
            if (c == 'S' || c == 's')
            {
                Office = 12;
            }
            else
            {
                Office = 0;
            }
        }
        public void CalculateLiving(int n)
        {
            //Formula: =SE(C16=1;'01'!D29;SE(C16=2;'01'!D30;SE(C16=3;'01'!D31)))
            if (n == 1)
            {
                Living = LivingOne;
            }
            else if (n == 2)
            {
                Living = LivingTwo;
            }
            else if (n == 3)
            {
                Living = LivingThree;
            }

        }
        public void CalculateBalcony(char c)
        {
            if (c == 'A' || c == 'a')
            {
                Balcony = BalconyA;
            }
            else if (c == 'B' || c == 'b')
            {
                Balcony = BalconyB;
            }
            else if (c == 'C' || c == 'c')
            {
                Balcony = BalconyC;
            }
        }
        public void CalculateGarage(int n)
        {
            if (n == 2)
            {
                Garage = Garage2;
            }
            else if (n == 3)
            {
                Garage = Garage3;
            }
            else if (n == 4)
            {
                Garage = Garage4;
            }
        }
        public void CalculateKitchen(char c)
        {
            if (c == 'A' || c == 'a')
            {
                Kitchen = KitchenA;
            }
            else if (c == 'B' || c == 'b')
            {
                Kitchen = KitchenB;
            }
        }
        public void CalculatePool(char c)
        {
            if (c == 'n' || c == 'N')
            {
                Pool = 0.0f;
            }
            else if (c == 'a' || c == 'B')
            {
                Pool = PoolA;
            }
            else if (c == 'b' || c == 'B')
            {
                Pool = PoolB;
            }
        }
        public void SumPartialArea()
        {
            PartialArea = Rooms
                + Bath
                + Closet
                + Office
                + Theater
                + Living
                + Balcony
                + Garage
                + Kitchen
                + Pool;
        }
        public void CalculateComplementaryArea()
        {
            //=SE(C26>'01'!E62;'01'!F62;SE(Site!C26<'01'!C60;'01'!F60;SE(E(C26<='01'!C61;Site!C26>='01'!E61);'01'!F61)))
            //If PartialArea>210 Then 

            if (PartialArea > 210.0)
            {
                ComplementaryArea = ComplArea210;
            }
            else if (PartialArea < 135.0)
            {
                ComplementaryArea = ComplArea135;
            }
            else if (PartialArea >= 135 && PartialArea <= 210)
            {
                ComplementaryArea = ComplArea135210;
            }

        }
        public void CalculateTotalArea()
        {
            TotalArea = PartialArea + ComplementaryArea;
        }
        public void CalculateTerrainPrice()
        {
            if (TotalArea > 210)
            {
                TerrainPrice = Terrain210;
            }
            else if (TotalArea < 135)
            {
                TerrainPrice = Terrain135;
            }
            else if (TotalArea >= 135 && TotalArea <= 210)
            {
                TerrainPrice = Terrain135210;
            }
        }
        public void CalculateConstructionPrice()
        {
            if (TotalArea > 210)
            {
                ConstructionPrice = ConstructionPreice210 * TotalArea;
            }
            else if (TotalArea < 135)
            {
                ConstructionPrice = ConstructionPrice135 * TotalArea;
            }
            else if (TotalArea >= 135 && TotalArea <= 210)
            {
                ConstructionPrice = ConstructionPrice135210 * TotalArea;
            }
        }
        public void CalculateTotalPrice()
        {
            TotalPrice = TerrainPrice + ConstructionPrice;
        }
    }
}
