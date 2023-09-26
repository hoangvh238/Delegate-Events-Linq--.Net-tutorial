using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot7
{
    public delegate int myDeleget(int num1, int num2);
    public delegate void Message(string mess);
    class Program
    {
        event Message Message1;
        static void Print(string mess) => Console.WriteLine(mess.ToUpper());
        static void Show(string mess) => Console.WriteLine(mess.ToLower());
        static void Display(string mess) => Console.WriteLine(mess);
        static int Add(int num1, int num2) => num1 + num2;  
        static int Sub(int num1,int num2) => num1 - num2;
        static void InvokeDelegate(Message message, string mess) => message(mess);

        public static void Main(string[] args) { 
            int num1 = 1;
            int num2 = 2;
            int result;

            myDeleget myDeleget = new myDeleget(Add);
            myDeleget myDeleget1 = Sub;
            // invoke same (value,value)
            Console.WriteLine(myDeleget.Invoke(1,2)+ "and"+myDeleget(3,2));
            Console.WriteLine(myDeleget1(1,2));
            //part 2 passing delegate at a param
            string mess = "heloo  VeASV";
            //InvokeDelegate(Print,mess);
            //InvokeDelegate(Show, mess);


            //Operator with delegate multiCast
            Message message1 = Print;
            Message message2 = Show;
            Message message3 = Display;
            var excute = message1 + message2 + message3;

            InvokeDelegate(excute-Display+Display, mess);


            //Guest delegate 
            Message mess4 = delegate (string msg)
            {
                Console.WriteLine(msg);
            };

            mess4("asdada");
            mess4.Invoke("DASDASDSADAS");

            //GENERIC DELEGATE 
            Func<int, int, int> func = Add;
            Console.WriteLine("Value"+func(1,2));
            Action<string> action = Show;
            action("123");

            //Implement event


            Program newValue = new Program();
            newValue.Message1 += new Message(Show);
            newValue.Message1("HI A as d A");


            //lambada
            string[] names = { "khoagay", "khoabede", "bedekhoa3d", "bibedelakhoa", "dogkhoa" };
            /*foreach (string name in names.OrderBy(s => s))
            {
                Console.WriteLine(name);
            }*/
         /*   foreach (string name in names.OrderBy(s => s))
            {
                Console.WriteLine(name);
            }*/

            //linq query

            var items = from word in names
                        where word.Contains("3d")
                        select word;
            foreach (string item in items) Console.WriteLine(item);
           
        }
    }
}
