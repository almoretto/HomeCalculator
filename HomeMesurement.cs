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

        private const int CoupleRoom = 14;
        private const int SingleRoom = 9;
        private const float CoupleBath = 7.5f;
        private const float SingleBath = 5f;
        private const int CoupleCloset = 6;
        private const int SingleCloset = 4;
        private const float LivingOne=20.0f;
        private const float LivingTwo=27.0f;
        private const float LivingThree=38.5f;
         


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
            if (c=='S'||c=='s')
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
            if (c=='S'||c=='s')
            {
                Office = 12;
            }
            else
            {
                Office = 0;
            }
         }
        public float CalculateLiving(int n)
        {
            //Formula: =SE(C16=1;'01'!D29;SE(C16=2;'01'!D30;SE(C16=3;'01'!D31)))
            if (n==1)
	        {
                Living=LivingOne;
	        }
            else if (n==2)
            {
                Living=LivingTwo;
            }
            else if (n==3)
	        {
                Living=LivingThree;
	        }
         
        }

    }
}
