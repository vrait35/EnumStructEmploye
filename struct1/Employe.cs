using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employe
{
    public enum ePosition
    {
        manager=0,
        clerk,
        boss
    }
    public struct Employe
    {
        public string SurName { get; set; }
        public int Slary { get; set; }
        public DateTime AcceptanceDateWork { get; set; } 
        public ePosition Position { get; set; }
        public static bool IsNumber(string numberAsString, ref int number)
        {
            try
            {
                number = int.Parse(numberAsString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void SortList(Employe[] arrayList)
        {
            int minLengthWord = 0;
            for(int i = 0; i < arrayList.Length-1; i++)
            {
                for(int j = i + 1; j < arrayList.Length; j++)
                {
                    if (arrayList[i].SurName.CompareTo(arrayList[j].SurName) >0)
                    {
                        Employe buf = arrayList[i];
                        arrayList[i] = arrayList[j];
                        arrayList[j] = buf;
                    }
                }
            }
        }

    }
}
