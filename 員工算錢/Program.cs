using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 員工算錢
{
		internal class Program
		{
			static void Main(string[] args)
			{
				int notEmployee = 2;//Person和Manage不是員工所以不算在內
				int overtime = 10000;
				int bouns = 5000;
				int money = 22000;//底薪
				int ledesmoney = 100000;//每帶一個人加10W
				List<Person> people = new List<Person>();
				people.Add(new Person { Name = "家緯", Gender = true, Nomoney = "我來參觀的啦哈哈" });
				people.Add(new Employee { Name = "員工A", Gender = true, Id = 5087, Money = money });
				people.Add(new Engineer { Name = "工程師", Gender = false, Id = 9466, Money = CluSalary(money, overtime) });
				people.Add(new Sales { Name = "業務", Gender = true, Id = 9527, Money = CluSalary(money, bouns) });
				people.Add(new Manage
				{
					Name = "主管",
					Gender = false,
					Id = 7788,
					Money = CluSalary(money, (people.Count - notEmployee) * ledesmoney)
				});
				//帶入算式CluSalary(輸入兩個整數)
				//peopleCount = List的長度(Add了多少人，目前5個但去除Person和Manger自己本身)-2(Person和Manage不算在主管帶的人)
				foreach (Person person in people)//列出公司有那些人
				{
					Console.WriteLine(person.GeTinformation());
				}
			}
			public class Person
			{
				public string Nomoney { get; set; }
				public string Name { get; set; }
				public bool Gender { get; set; }
				public virtual string GeTinformation()
				=> $"名字:{Name}\t性別是:{Gender}\t{Nomoney}元";
			}
			public class Employee : Person
			{
				public int Id { get; set; }
				public int Money { get; set; }
				public override string GeTinformation()
				=> $"名字:{Name}\t性別是:{Gender}\t員工編號{Id},薪水{Money}元";
			}
			public class Engineer : Employee
			{
			}
			public class Sales : Employee
			{
			}
			public class Manage : Employee
			{
			}
			public static int CluSalary(int num1, int num2) //算薪水大家都底薪22000+職位加給
			{
				int plus = num1 + num2;
				return plus;
			}

		}
	}
