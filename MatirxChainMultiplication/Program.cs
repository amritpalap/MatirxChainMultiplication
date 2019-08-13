using System;

namespace MatirxChainMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * provide the nunmber fo matrixes. 
             *  
             */
            int numberOfMatrix;
            /*
             * intializing the variables
             */
            int diagnalLoopValue, i, k, j, computedValue, minValue;

            Console.WriteLine("Please enter the total number of matrixes:");
            //will trun this into funtion


            // reason we add 1 in the user input:- to make calculation of matrixMultiCostTable easier, you will see in the next lines :)
            numberOfMatrix += 1;
            /*
             * intializing the empty  m array unerInput*unerInput to store the minMutliCostValue
             */
            int[,] matrixMultiCostTabe = new int[numberOfMatrix, numberOfMatrix];

            /*
             * intializing the empty  kValue array unerInput*unerInput to store the k which we get the least minMultiCostValue
             */
            int[,] kValue =new int[numberOfMatrix, numberOfMatrix];
            /*
             * get the dimensions for the each matrix
             */

            //for ( i = 0; i <(numberOfMatrix *2) ; i++)
            //{

            //}
            int[] p = new int[6] {4, 10, 3, 12, 20, 7 };
            /*
             * keep the count for every loop
             */
            int timesLoopWork = 0;
            
            

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
        public static string GetNumberOfMatrixes()
        {
            Console.WriteLine("Please enter the total number of matrixes:");
            string userInput = Console.ReadLine();
            return userInput;
        }
       public static bool IsUserInputInt(int numberOfMatrix)
        {
            bool result = false;
            if (int.TryParse(Console.ReadLine(), out numberOfMatrix))
            {
                result = true;
            }

            return result;
        }
    }
}
