using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Employe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("размер массива: ");
            int size=-1;
            int salary = 0;
            int position = 0;
            int day=0, month=0, year=0;
            bool isTrue = false;
            while (true)
            {
                Employe.IsNumber(Console.ReadLine(), ref size);
                if (size > 0) break;
            }
            Employe[] arrayEmploye = new Employe[size];               
            for (int i = 0; i < size; i++)
            {
                arrayEmploye[i] = new Employe();
                Console.Write("введите фамилию : ");
                arrayEmploye[i].SurName = Console.ReadLine();
                Console.Write("введите зарплату : ");                
                Employe.IsNumber(Console.ReadLine(),ref salary);
                arrayEmploye[i].Slary = salary;
                Console.Write("введите код должности 0-менеджер , 1-клерк , 2-босс : ");
                Employe.IsNumber(Console.ReadLine(), ref position);
                arrayEmploye[i].Position = (ePosition)position;
                while (!isTrue)
                {
                    Console.Write("введите день принятия на работу: ");
                    Employe.IsNumber(Console.ReadLine(), ref day);
                    Console.Write("введите месяц принятия на работу: ");
                    Employe.IsNumber(Console.ReadLine(), ref month);
                    Console.Write("введите год принятия на работу: ");
                    Employe.IsNumber(Console.ReadLine(), ref year);
                    try
                    {
                        arrayEmploye[i].AcceptanceDateWork = new DateTime(year, month, day);
                        isTrue = true;
                    }
                    catch
                    {
                        isTrue = false;
                    }
                }//while(!istrue)
                isTrue = false;
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\n    a.Полная информация о сотрудниках : ");
            foreach(Employe ep in arrayEmploye)
            {
                Console.WriteLine(ep.SurName+" - "+ep.Position+" - "+ep.Slary+" $   -  "+ep.AcceptanceDateWork);
            }
            Console.WriteLine("\n    b. Все менеджеры зарплата которых" +
                " больше средней зарплаты всех клерков (с сортировкой по фамилии) : ");
            double avgSalaryClerk=0,sumSalaryClerk=0, countClerk=0 ;
            foreach(Employe e in arrayEmploye)
            {
                if (e.Position == ePosition.clerk)
                {
                    countClerk++;
                    sumSalaryClerk += e.Slary;
                }
            }
            if (countClerk > 0)
                avgSalaryClerk = sumSalaryClerk / (double)countClerk;
            else avgSalaryClerk = 0;
            List<Employe> list = new List<Employe>();
            foreach(Employe emp in arrayEmploye)
            {
                if(emp.Slary>avgSalaryClerk && emp.Position == ePosition.manager)
                {
                    list.Add(emp);
                }
            }

            var result = from sortList in list
                         orderby sortList.SurName
                         select sortList;
            foreach (Employe emp in result)
                Console.Write(emp.SurName+" - "+emp.Slary+" - "+emp.Position+" - "+emp.AcceptanceDateWork+"\n");

            Console.WriteLine("\n    c.Bся информация о сотрудниках принятые позже босса   (с сортировкой по фамилии)  : ");            
            Employe.SortList(arrayEmploye);
            Employe boss = new Employe();
            foreach(Employe emp in arrayEmploye)
                if (emp.Position == ePosition.boss)
                {
                     boss = new Employe()
                    {
                        AcceptanceDateWork = emp.AcceptanceDateWork,
                        Slary = emp.Slary,
                        Position = emp.Position,
                        SurName = emp.SurName
                    };
                }
                    
            foreach (Employe emp in arrayEmploye)
            {                
                if(boss.AcceptanceDateWork<emp.AcceptanceDateWork)
                Console.Write(emp.SurName + " - " + emp.Slary + " - " + emp.Position + " - " + emp.AcceptanceDateWork + "\n");
            }
        }
    }
}
