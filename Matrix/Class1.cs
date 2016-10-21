using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISM
{
        public class Matrix
        {
            public static int[,] Generate(int rows, int cols,int mx,int min)
            {
                int[,] mas = new int[rows, cols];
                Random r = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        mas[i, j] = r.Next(min, mx);
                    }
                }
                return mas;
            }
       //--------------------------------------------------------------
            public static int[,] transponovana(int[,] Arr)
            {
                int c1, r1;
                r1 = Arr.GetLength(0);
                c1 = Arr.GetLength(1);
                int[,] rmas = new int[c1, r1];
                for (int i = 0; i < r1; i++)
                {
                    for (int j = 0; j < c1; j++)
                    {
                        rmas[j,i] = Arr[i, j];
                    }
                }
                return rmas;
            }
//--------------------------------------------------------------
            public static int[,] mnoz(int[,] mas1, int[,] mas2)
            {
                int c1, c2, r1, r2;
                r1 = mas1.GetLength(0);
                c1 = mas1.GetLength(1);
                r2 = mas2.GetLength(0);
                c2 = mas2.GetLength(1);
                if (c1 != r2)
                    return null;
                int[,] rmas = new int[r1, c2];
                for (int i = 0; i < r1; i++)
                {
                    for (int j = 0; j < c2; j++)
                    {
                        for (int k = 0; k < r2; k++)
                        {
                            rmas[i, j] += mas1[i, k] * mas2[k, j];
                        }
                    }
                }
                return rmas;
            }
            //--------------------------------------------------
            public static int[,] Alg_dop(int[,] Arr)
            {
                int det = 0;
                int i, j;
                int size = Arr.GetLength(0);
                int size2 = Arr.GetLength(1);
                if (size != size2)
                    return null;
                int[,] matr = new int[size, size];
                if (size == 1)
                {
                    matr[0,0] = Arr[0, 0];
                }
                else if (size == 2)
                {
                    matr[0, 0] = Arr[1, 1];
                    matr[0, 1] = Arr[1, 0];
                    matr[1, 0] = Arr[0, 1];
                    matr[1, 1] = Arr[0, 0];
                }
                else
                {
                    int[,] mas = new int[size - 1, size - 1];
                    for (i = 0; i < size; i++)
                    {
                        for (j = 0; j < size; j++)
                        {
                            for (int r = 0; r < size-1; r++)
                            {
                                for (int t = 0; t < size-1; t++)
                                {
                                    int ii,jj;
                                    if (r < i)
                                        ii = r;
                                    else
                                        ii = r + 1;
                                    if (t < j)
                                        jj = t;
                                    else
                                        jj = t + 1;
                                    if((r+t)%2==0)
                                        mas[r,t] = Arr[ii,jj];
                                    else
                                        mas[r, t] = Arr[ii, jj]*-1;
                                }
                            }
                            matr[i, j] = Determ(mas);
                        }
                    }
                }
                return matr;
            }
            //--------------------------------------------------
            public static int[,] obernena(int[,] Arr)
            {
                int i, j;
                int size = Arr.GetLength(0);
                int size2 = Arr.GetLength(1);
                int determ = Determ(Arr);
                if (size != size2)
                    return null;
                int[,] matr = new int[size, size];
                int[,] resm = new int[size, size];
                matr = Alg_dop(Arr);
                matr = transponovana(matr);
                for (i = 0; i < size; i++)
                {
                    for (j = 0; j < size; j++)
                    {
                        resm[i, j] = matr[i, j] / determ;
                    }
                }
                return matr;
            }
//--------------------------------------------------
            public static int Determ(int[,] Arr)
            {
                int det = 0;
                int i, j;
                int size = Arr.GetLength(0);
                int size2 = Arr.GetLength(1);
                if (size != size2)
                    return int.MinValue;
                if (size == 1)
                {
                    det = Arr[0, 0];
                }
                else if (size == 2)
                {
                    det = Arr[0, 0] * Arr[1, 1] - Arr[0, 1] * Arr[1, 0];
                }
                else
                {
                    int[,] matr = new int[size - 1, size - 1];
                    for (i = 0; i < size; ++i)
                    {
                        for (j = 0; j < size - 1; ++j)
                        {
                            if (j < i)
                                for (int k = 0; k < size - 1; k++)
                                    matr[j, k] = Arr[j, k];
                            else
                                for (int k = 0; k < size - 1; k++)
                                    matr[j, k] = Arr[j + 1, k];
                        }
                        int odinica=1;
                        if ((i + j) % 2 == 0)
                            odinica = 1;
                        else
                            odinica = -1;
                        det += odinica * Determ(matr) * Arr[i, size - 1];
                    }
                }
                return det;
            }
//----------------------------------------------------------------------------------------
            public static void mas_out(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(Arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            //--------------------------------------------------------------------
            public static void dobutok_ne_videmnih(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                bool vid = false;
                int d = 1;
                Console.WriteLine("добуток елементів в тих рядках, які не містять від’ємних елементів");
                for (int i = 0; i < rows; i++)
                {
                    vid = false;
                    for (int j = 0; j < cols; j++)
                    {
                        if (Arr[i, j] < 0)
                            vid = true;
                    }
                    if (!vid)
                    {
                        d = 1;
                        for (int j = 0; j < cols; j++)
                        {
                            d *= Arr[i, j];
                        }
                        Console.WriteLine("Добуток елементів в "+(i+1)+" рядку = "+d);
                    }
                }
                return;
            }
            //--------------------------------------------------------------------
            public static void suma_ne_videmnih(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                bool vid = false;
                int d = 0;
                Console.WriteLine("суму елементів в тих стовпцях, які не містять від’ємних елементів: ");
                for (int i = 0; i < cols; i++)
                {
                    vid = false;
                    for (int j = 0; j < rows; j++)
                    {
                        if (Arr[j, i] < 0)
                            vid = true;
                    }
                    if (!vid)
                    {
                        d = 1;
                        for (int j = 0; j < cols; j++)
                        {
                            d += Arr[j, i];
                        }
                        Console.WriteLine("Сума елементів в " + (i + 1) + " стовбці = " + d);
                    }
                }
                return;
            }
            //--------------------------------------------------------------------
            public static void suma_videmnih(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                bool vid = false;
                int d = 0;
                Console.WriteLine("суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: ");
                for (int i = 0; i < cols; i++)
                {
                    vid = false;
                    for (int j = 0; j < rows; j++)
                    {
                        if (Arr[j, i] < 0)
                            vid = true;
                    }
                    if (vid)
                    {
                        d = 1;
                        for (int j = 0; j < cols; j++)
                        {
                            d += Arr[j, i];
                        }
                        Console.WriteLine("Сума елементів в " + (i + 1) + " стовбці = " + d);
                    }
                }
                return;
            }
            //--------------------------------------------------------------------
            public static int suma_elem_pobich_diah(int[,] Arr)
            {
                //Console.WriteLine();
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                int res = int.MaxValue, sum = 0;
                if (rows != cols)
                    return int.MaxValue;
                for (int i = 1; i < rows; i++)
                {
                    sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (j + i < cols)
                        {
                            sum +=Math.Abs( Arr[j + i, cols - j - 1]);
                        }
                        
                    }
                    //Console.WriteLine( );
                    res = Math.Min(res, sum);

                    sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (j - i >= 0)
                        {
                            sum +=Math.Abs( Arr[j - i, cols - j - 1]);
                            //Console.Write(Arr[j - i, cols - j - 1] + "      ");
                        }
                    }
                    //Console.WriteLine();
                    res = Math.Min(res, sum);
                }
                return res;
            }
            //--------------------------------------------------------------------
            public static int suma_elem_diah(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1); 
                int res=int.MinValue,sum=0;
                if (rows != cols)
                    return int.MinValue;
                for (int i = 1; i < rows; i++)
                {
                    sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if(j+i<cols)
                        sum+=Arr[j+i,j];
                    }
                    //Console.WriteLine(sum);
                    res = Math.Max(res, sum);

                    sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (j - i >=0)
                            sum += Arr[j - i, j];
                    }
                    //Console.WriteLine(sum);
                    res = Math.Max(res, sum);
                }
                return res;
            }
            //--------------------------------------------------------------------
            public static int largest_seria(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                int res = int.MinValue, poper = int.MinValue, dovzina = 0, seria = int.MinValue;
                for (int i = 0; i < rows; i++)
                {
                    dovzina = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (j > 0)
                            poper = Arr[i, j - 1];
                        if (poper == Arr[i, j])
                            dovzina++;
                        else
                        {
                            if (seria < dovzina)
                            {
                                res = i;
                                seria = dovzina;
                            }
                            dovzina = 0;
                        }
                    }
                }
                return res + 1;
            }
            //--------------------------------------------------------------------
            public static int rows_without_nul(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                int k,res=0;
                for (int i = 0; i < rows; i++)
                {
                    k = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if(Arr[i,j]==0)
                            k++;
                    }
                    if (k == 0)
                        res++;
                }
                return res;
            }
            public static int cols_with_nul(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                int k, res = 0;
                for (int i = 0; i < cols; i++)
                {
                    k = 0;
                    for (int j = 0; j < rows; j++)
                    {
                        if (Arr[j, i] == 0)
                            k++;
                    }
                    if (k != 0)
                        res++;
                }
                return res;
            }
            //---------------------------------------------------------------------
            //---------------------------------------------------------------------
            public static int max_more_one(int[,] Arr)
            {
                int rows = Arr.GetLength(0);
                int cols = Arr.GetLength(1);
                int[] dop = new int[1000000];
                int  res = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        dop[Arr[i, j]+50000]++;
                    }
                }
                for (int i = 0; i < 100000; i++)
                {
                    if (dop[i] > 1)
                        res = i-50000;
                }
                return res;
            }
        }
 }