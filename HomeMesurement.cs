using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;

namespace HomeConstructionCalculator
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

        private const int CoupleRoom = 14;
        private const int SingleRoom = 9;
        private const float CoupleBath = 7.5f;
        private const float SingleBath = 5f;
        private const int CoupleCloset = 6;
        private const int SingleCloset = 4;
        private const float LivingOne = 20.0f;
        private const float LivingTwo = 27.0f;
        private const float LivingThree = 38.5f;
        private const int BalconyA = 20;
        private const int BalconyB = 30;
        private const int BalconyC = 44;
        private const int Garage2 = 21;
        private const int Garage3 = 46;
        private const int Garage4 = 67;
        private const float KitchenA = 10.5f;
        private const float KitchenB = 14.0f;
        private const float PoolA = 7.5f;
        private const float PoolB = 14.0f;


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
        public float PartialArea()
        {
            return Rooms + Bath + Closet + Office + Theater + Living + Balcony + Garage + Kitchen + Pool;
        }

    }
}
