using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList A = new ArrayList();
            A.AddRange(new int[] {1,2,3,4,5});

            ArrayList B = new ArrayList();
            B.Add(1);
            B.Add(3);
            B.Add(5);
            B.Add(5);
            B.Add(9);

            ArrayList C1 = Union(A, B);
            ArrayList C2 = AllNumbers(A, B);
            ArrayList C3 = Intersection(A, B);
            ArrayList C4 = AnotB(A, B);
            ArrayList C5 = NotInBoth(A, B);

            Console.WriteLine("=============ArrayList=============\n");
            foreach (int i in C1)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("Union A and B");

            Console.WriteLine();      
           
            foreach (int i in C2)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("All numbers in A and B");  

            Console.WriteLine();      
            
            foreach (int i in C3)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("Intersection of A and B");
            Console.WriteLine();

            foreach (int i in C4)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("Elements in A but not in B");
            Console.WriteLine();
            foreach (int i in C5)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("Numbers in A and B that don't exist in both lists");

            
            Console.WriteLine("\n\n=============Stack and queue=============\n");

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int check1 = stack.Count;
            stack.Pop();
            int check2 = stack.Count;
            Console.Write("Stack: ");
            foreach (int i in stack)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\nBefore pop: {0}, after: {1}\n", check1, check2);

            Queue<int> q = new Queue<int>();

            q.Enqueue(5);   
            q.Enqueue(6);
            int c1 = q.Count;
            q.Dequeue();
            int c2 = q.Count;
            q.Enqueue(7);  
            q.Enqueue(8);
            int c3 = q.Count;
            Console.Write("Queue: ");
            foreach (int i in q)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\nBefore dequeue: {0}, after: {1}, finally: {2}", c1, c2, c3);


           
            
        }

        private static ArrayList NotInBoth(ArrayList A, ArrayList B)
        {
            ArrayList c = new ArrayList();
            c = AnotB(Union(A, B), Intersection(A, B));
            return c;
        }

        private static ArrayList AnotB(ArrayList A, ArrayList B)
        {
            ArrayList AnotB = new ArrayList();
            foreach (int i in A)
            {
                if (!B.Contains(i))
                {
                    AnotB.Add(i);
                }
            }
            return AnotB;
        }

        private static ArrayList Union(ArrayList A, ArrayList B)
        {
            ArrayList union = new ArrayList();
            foreach (int i in A)
            {
                if (!union.Contains(i))
                {
                    union.Add(i);
                }

            }
            foreach (int i in B)
            {
                if (!union.Contains(i))
                {
                    union.Add(i);
                }
            }
            return union;

        }

        private static ArrayList AllNumbers(ArrayList A, ArrayList B)
        {
            ArrayList union = new ArrayList();
            union.AddRange(A);
            union.AddRange(B);
            return union;
        }

        private static ArrayList Intersection(ArrayList A, ArrayList B)
        {
            ArrayList intersection = new ArrayList();
            foreach (int i in A)
            {
                if (B.Contains(i))
                {
                    if (!intersection.Contains(i))
                    {
                        intersection.Add(i);
                    }
                }
            }
            return intersection;
        }
    }
}
