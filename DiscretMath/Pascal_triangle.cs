using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscretMath
{
    class Pascal_triangle
    {
        private int[,] table = null;
        //buildig structure
        public Pascal_triangle()
        {
            table = new int[20,20];
            Initialize();
        }

        public Pascal_triangle(int line)
        {
            table = new int[line + 5, line + 5];
            Initialize();
            Get(line);
        }

        public Pascal_triangle(int line, int place)
        {
            table = new int[line+5,line+5];
            Initialize();
            Get(line, place);
        }

        public void Initialize()
        {
            int i = 0, j = 0;
            while (i < table.GetLength(0)) {
                while (j < table.GetLength(1))
                {
                    table[i, j] = 0;
                    j++;
                }
                j = 0;
                i++;
            }
            i = 0; j = 0;
            while (i < table.GetLength(0))
            {
                table[i, 0] = 1;
                i++;
            }
            i = 0;
            while (j < table.GetLength(1))
            {
                table[0, j] = 1;
                j++;
            }            
        }

        public String Get(int line)
        {
            String output = "Error";
            try
            {               
                if (line > table.GetLength(0))
                    throw new ArrayTypeMismatchException("please define a new, and bigger pascal triangle.(use Pascal_triangle(int line, int place)|Pascal_triangle(int line))");
                output = ""+ Get_rec(0, line);
                int place = line-1; line = 1;
                while (place > -1)
                {                  
                    output = Get_rec(line, place) + ", " + output;                    
                    place -= 1;
                    line += 1;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed_1, Exception: " + e);
            }
            return output;
        }

        //make the inserted values suitable to switched table
        public int Get(int line, int place)
        {
            int output = -1;    
            try
            {
                if (place < 0 | place > line)
                    throw new IndexOutOfRangeException("0 <= place <= line.");
                if (line >= table.GetLength(0) | place >= table.GetLength(1))
                    throw new ArrayTypeMismatchException("please define a new, and bigger pascal triangle.(use Pascal_triangle(int line, int place)|Pascal_triangle(int line))");
                output = Get_rec(place, line - place);
            }

            catch (Exception e)
            {
                Console.WriteLine("Failed_2, Exception: " + e);
            }

            return output;
        }

        //find recursicve, with mmorization the place i,j in the table of pascal;
        private int Get_rec(int line, int place)
        {            
            int output = table[line, place];
            if (output == 0)
                output = (table[place, line] = (table[line, place] = Get_rec(line, place - 1) + Get_rec(line - 1, place))); 
            //Console.WriteLine(output + " " + line + " " + place);            
            return output;
        }

        // print the array
        public void print()
        {
            int i = 0, j = 0;
            while (i < table.GetLength(0))
            {
                while (j < table.GetLength(1))
                {
                    Console.Write(table[i, j]+"_");
                    j++;
                }
                Console.WriteLine("\n");
                j = 0;
                i++;
            }
        }

        static void Main(string[] args)
        {
            Pascal_triangle tri = new Pascal_triangle();
            //tri.print();
            Console.WriteLine(tri.Get(15,3));
            //tri.print();            
            Console.WriteLine(tri.Get(19));
            //tri.print();
            //Console.WriteLine(tri.Get(25));
            Console.Read();
        }
    }
}
