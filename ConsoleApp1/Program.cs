using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//题目：17个人围成一圈，从第一个人开始报数，报到3的退出（打印出来），一直到剩下最后一个人，用面向对象的思想去做这道题。
namespace ConsoleApp1
{
    public class person
    {
        public person Prev { get; set; }
        public person Next { get; set; }
        public int Val { get; set; }

        public person() { }
        public person(person pre, person next, int val)
        {
            Prev = pre;
            Next = next;
            Val = val;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var rootperson = new person();
            rootperson.Val = 1;


            //初始化数据
            var temp = rootperson;
            for (int i = 2; i <= 17; i++)
            {
                var p = new person(temp, null, i);
                temp.Next = p;
                temp = p;
            }
            temp.Next = rootperson;
            rootperson.Prev = temp;//最后一个与第一个连接上

            //输出
            int j = 1;
            person start = rootperson;
            while (start.Next != null)
            {
                if (j % 3 == 0) remove(start);
                start = start.Next;
                j++;
            }

            Console.ReadLine();
        }
        public static void remove(person p)//输出并退出链环www.elivn.com
        {
            Console.WriteLine(p.Val);
            if (p.Prev != p.Next)
            {
                p.Prev.Next = p.Next;
                p.Next.Prev = p.Prev;
            }
            else//只剩下两人时.
            {
                p.Prev.Next = null;
                p.Prev.Prev = null;
            }
        }
    }
}
