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
            int numberOfMatrix = 0;
            /*
             * intializing the variables
             */
            int diagnalLoopValue, i, k, j, computedValue, minValue;


            //will turn this into funtion


            //prompt user for the number for matrixes
            string userInput = GetUserInput("Please enter the total number of matrixes:");

            //Check if the user input type is integer
            //keep prompting until the value matches requirements
            while (true)
            {
                string message = "";
                if (IsTypeInt(userInput))
                {
                    message = "Please enter an Value that is integer and more than one :)";
                    if (int.Parse(userInput) > 1)
                    {
                        numberOfMatrix = int.Parse(userInput);
                        break;
                    }
                    else
                    {
                        message = "please enter the value more than 1";
                    }

                }
                else
                {
                    GetUserInput(message);
                }
            }

            // reason we add 1 in the user input:- to make calculation of matrixMultiCostTable easier, you will see in the next lines :)
            // add one in the user value to  start the loop from 1  whcich result in overcoming the  error of (p[(i - 1)] * p[k] * p[j]), so when we comopute the value it will start from the index 1.
            numberOfMatrix += 1;


            /*
             * intializing the empty  m array userInput*userInput to store the minMutliCostValue
             */
            int[,] matrixMultiCostTabe = new int[numberOfMatrix, numberOfMatrix];


            /*
             * intializing the empty  kValue array userInput*userInput to store the k which we get the least minMultiCostValue
             */
            int[,] kValue = new int[numberOfMatrix, numberOfMatrix];


            /*
             * get the dimensions for the each matrix
             * Prompt the user to enter each matrix dimensions
             * 
             */
            int[] p = new int[numberOfMatrix];

            for (i = 0; i < numberOfMatrix; i++)
            {
                userInput = GetUserInput("please enter the value of P" + i);
                if (IsTypeInt(userInput))
                {
                    p[i] = int.Parse(userInput);

                }
                //still need to add a  else condition for p's value
            }
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

            for (diagnalLoopValue = 1; diagnalLoopValue < numberOfMatrix; diagnalLoopValue++)
            {
                timesLoopWork++;
                for (i = 1; i < (numberOfMatrix - diagnalLoopValue); i++)
                {
                    timesLoopWork++;
                    j = i + diagnalLoopValue;
                    Console.Write(i + ", " + j);
                    minValue = int.MaxValue;

                    for (k = i; k < j; k++)
                    {

                        computedValue = matrixMultiCostTabe[i, k] + matrixMultiCostTabe[(k + 1), j] + (p[(i - 1)] * p[k] * p[j]);

                        if (computedValue < minValue)
                        {
                            minValue = computedValue;
                            kValue[i, j] = k;
                        }

                    }
                    matrixMultiCostTabe[i, j] = minValue;
                    Console.WriteLine(", " + matrixMultiCostTabe[i, j]);
                }

            }
            Console.Write("Times Loop work:- " + timesLoopWork);
            //Display the both Array value
            Console.Write("Multiple Cost Value Chain \n");
            for (i = 1; i < numberOfMatrix; i++)
            {
                for (j = 1; j < numberOfMatrix; j++)
                {
                    Console.Write(" | " + matrixMultiCostTabe[i, j] + " | ");
                }
                Console.Write("\n");
            }

            //Display the both Array value
            Console.Write("Multiple Cost Value Chain \n");
            for (i = 1; i < numberOfMatrix; i++)
            {
                for (j = 1; j < numberOfMatrix; j++)
                {
                    Console.Write(" | " + kValue[i, j] + " | ");
                }
                Console.Write("\n");
            }



        }

        public static String GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();

            return userInput;
        }
        public static bool IsTypeInt(string numberOfMatrix)
        {
            bool result = false;
            int value;
            if (int.TryParse(numberOfMatrix.ToString(), out value))
            {
                result = true;
            }

            return result;
        }
    }
}
