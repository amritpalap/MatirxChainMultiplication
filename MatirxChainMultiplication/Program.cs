using System;

namespace MatirxChainMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMatrix = 6;
            /*
             * intializing the empty  m array 5*5 to store the minMutliCostValue
             */
            int[,] matrixMultiCostTabe = new int[numberOfMatrix, numberOfMatrix];
            
            /*
             * intializing the empty  kValue array 5*5 to store the k which we get the least minMultiCostValue
             */
            int[,] kValue =new int[numberOfMatrix, numberOfMatrix];
           
            int[] p = new int[6] {4, 10, 3, 12, 20, 7 };
            int timesLoopWork = 0;
            
            int diagnalLoopValue, i, k, j,computedValue,minValue;

            for (i = 1; i < numberOfMatrix; i++)
            {
                for (j = i; j < numberOfMatrix; j++)
                {
                    if (i == j)
                    {
                        matrixMultiCostTabe[i, j] = 0;
                    }
                    else
                    {
                        matrixMultiCostTabe[i, j] = int.MaxValue;
                    }
                }
            }

            for ( diagnalLoopValue = 1; diagnalLoopValue < numberOfMatrix; diagnalLoopValue++)
            {
                timesLoopWork++;
                for ( i = 1; i< (numberOfMatrix - diagnalLoopValue); i++)
                {
                    timesLoopWork++;
                    j = i + diagnalLoopValue;
                    Console.Write(i + ", " + j);
                    minValue = int.MaxValue;

                    for ( k = i; k < j ; k++)
                    {
                        
                        computedValue = matrixMultiCostTabe[i, k] + matrixMultiCostTabe[(k + 1), j] + (p[(i - 1)] * p[k] * p[j]);

                            if (  computedValue< minValue)
                                {
                               minValue= computedValue;
                            kValue[i, j] = k;
                        }
                       
                    }
                    matrixMultiCostTabe[i, j] = minValue;
                    Console.WriteLine(", " + matrixMultiCostTabe[i, j]);
                }    

            }
            Console.Write("Times Loop work:- "+timesLoopWork);
            //Display the both Array value
            Console.Write("Multiple Cost Value Chain \n");
            for ( i = 1; i < numberOfMatrix; i++)
            {
                for ( j = 1; j < numberOfMatrix; j++)
                {
                    Console.Write(" | " + matrixMultiCostTabe[i, j] + " | ");
                }
                Console.Write("\n");
            }

            //Display the both Array value
            Console.Write("Multiple Cost Value Chain \n");
            for ( i = 1; i < numberOfMatrix; i++)
            {
                for ( j = 1; j < numberOfMatrix; j++)
                {
                    Console.Write(" | " + kValue[i, j] + " | ");
                }
                Console.Write("\n");
            }



        }
    }
}
