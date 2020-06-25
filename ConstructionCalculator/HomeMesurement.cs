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
        /*Properties Area*/
        public float Rooms { get; set; }
        public float Bath { get; set; }
        public float Closet { get; set; }
        public float Office { get; set; }
        public float Theater { get; set; }
        public float Living { get; set; }
        public float Balcony { get; set; }
        public float Garage { get; set; }
        public float Kitchen { get; set; }
        public float Pool { get; set; }
        public float PartialArea { get; set; }
        public float ComplementaryArea { get; set; }
        public float TotalArea { get; set; }
        public float TerrainPrice { get; set; }
        public float ConstructionPrice { get; set; }
        public float TotalPrice { get; set; }

        /*Properties Form*/
        public int RoomsQte { get; set; }
        public int BathQte { get; set; }
        public int ClosetQte { get; set; }
        public string OfficeEx { get; set; }
        public string TheaterEx { get; set; }
        public int LivingTp { get; set; }
        public string BalconyTp { get; set; }
        public int GarageQte { get; set; }
        public string KitchenTp { get; set; }
        public string PoolTp { get; set; }
        
        /*Constants*/
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


        public void CalculateRooms()
        {
            //Formula: ='01'!D11+((C6-1)*'01'!D12)
            //casal         14  m2 
            //solteiro       9   m2
            Rooms = (CoupleRoom + ((RoomsQte - 1) * SingleRoom));
        }
        public void CalculateBath()
        {
            //Formula: ='01'!D15+((C8-1)*'01'!D16)
            //Casal     7,5
            //solteiro    5
            Bath = (CoupleBath + ((BathQte - 1) * SingleBath));
        }
        public void CalculateCloset()
        {
            //Formula: ='01'!D19+((C10-1)*'01'!D20)
            Closet = (CoupleCloset + ((ClosetQte - 1) * SingleCloset));
        }
        public void CalculateOffice()
        {
            if (OfficeEx == "S" || OfficeEx == "s")
            {
                Office = 7.5f;
            }
            else
            {
                Office = 0.0f;
            }
        }
        public void CalculateTheater()
        {
            if (TheaterEx == "S" || TheaterEx == "s")
            {
                Theater = 12;
            }
            else
            {
                Theater = 0;
            }
        }
        public void CalculateLiving()
        {
            //Formula: =SE(C16=1;'01'!D29;SE(C16=2;'01'!D30;SE(C16=3;'01'!D31)))
            if (LivingTp == 1)
            {
                Living = LivingOne;
            }
            else if (LivingTp == 2)
            {
                Living = LivingTwo;
            }
            else if (LivingTp == 3)
            {
                Living = LivingThree;
            }

        }
        public void CalculateBalcony()
        {
            if (BalconyTp == "A" || BalconyTp == "a")
            {
                Balcony = BalconyA;
            }
            else if (BalconyTp == "B" || BalconyTp == "b")
            {
                Balcony = BalconyB;
            }
            else if (BalconyTp == "C" || BalconyTp == "c")
            {
                Balcony = BalconyC;
            }
        }
        public void CalculateGarage()
        {
            if (GarageQte == 2)
            {
                Garage = Garage2;
            }
            else if (GarageQte == 3)
            {
                Garage = Garage3;
            }
            else if (GarageQte == 4)
            {
                Garage = Garage4;
            }
        }
        public void CalculateKitchen()
        {
            if (KitchenTp == "A" || KitchenTp == "a")
            {
                Kitchen = KitchenA;
            }
            else if (KitchenTp == "B" || KitchenTp == "b")
            {
                Kitchen = KitchenB;
            }
        }
        public void CalculatePool()
        {
            if (PoolTp == "n" || PoolTp == "N")
            {
                Pool = 0.0f;
            }
            else if (PoolTp == "a" || PoolTp == "B")
            {
                Pool = PoolA;
            }
            else if (PoolTp == "b" || PoolTp == "B")
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
