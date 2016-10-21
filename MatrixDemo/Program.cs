using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool isp = true;
            while (isp)
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    int rows = int.Parse(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    int cols = int.Parse(Console.ReadLine());
                    int[,] mas = ISM.Matrix.Generate(rows, cols, 5,-5);
                    ISM.Matrix.mas_out(mas);
                    Console.Write("Определитель матрицы= ");
                    Console.WriteLine(ISM.Matrix.Determ(mas));
                    Console.Write("Кількість рядків, які не містять жодного нульового елемента: ");
                    Console.WriteLine(ISM.Matrix.rows_without_nul(mas));
                    Console.Write("Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: ");
                    Console.WriteLine(ISM.Matrix.max_more_one(mas));
                    Console.Write("Кількість стовпців, які містять хоча б один нульовий елемент: ");
                    Console.WriteLine(ISM.Matrix.cols_with_nul(mas));
                    Console.Write("Номер рядка, в якому знаходиться найдовша серія однакових елементів: ");
                    Console.WriteLine(ISM.Matrix.largest_seria(mas));
                    ISM.Matrix.dobutok_ne_videmnih(mas);
                    Console.Write("Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: ");
                    Console.WriteLine(ISM.Matrix.suma_elem_diah(mas));
                    ISM.Matrix.suma_ne_videmnih(mas);
                    Console.Write("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: ");
                    Console.WriteLine(ISM.Matrix.suma_elem_pobich_diah(mas));
                    ISM.Matrix.suma_videmnih(mas);
                    //Console.Write("Мінор матриці: ");
                   // ISM.Matrix.mas_out(ISM.Matrix.Alg_dop(mas));
                    Console.WriteLine("Транспонована матриця: ");
                    ISM.Matrix.mas_out(ISM.Matrix.transponovana(mas));
                    Console.WriteLine("Обернена матриця: ");
                    ISM.Matrix.mas_out(ISM.Matrix.obernena(mas));
                    isp = false;
                }
                catch (Exception osh)
                {
                    Console.WriteLine(osh.Message);
                    Console.WriteLine("Попробуй ещё))");
                    isp = true;
                }
            }
        }
    }
}
