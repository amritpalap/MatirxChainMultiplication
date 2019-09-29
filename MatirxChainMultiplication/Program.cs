using System;
using System.Collections.Generic;

namespace MatirxChainMultiplication
{
    class Matrix
    {
        public int row { get; set; }

        public int col { get; set; }



        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

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

            /*
             * intializing the Dictionary to store the matrices for matrixes
             */
            Dictionary<string, Matrix> matricesDict = new Dictionary<string, Matrix>(); // XXXXXX 

            /*
             * m array userInput*userInput to store the minMutliCostValue
             */
            int[,] matrixMultiCostTabe;


            /*
             * kValue array userInput*userInput to store the k which we get the least minMultiCostValue
             */
            int[,] kValue;

            /*
             * p array  to store the pvalues start from p0.
             */
            int[] p;

            //Select y for preDefault Values
            //Select n for custom Values
            string userInput = GetUserInput("Use Default Values! y / n ? ");

            if (userInput.ToLower().Equals("y"))
            {
                numberOfMatrix = 6;
                p = new int[6] { 4, 10, 3, 12, 20, 7 };

            }
            else
            {
                //Check if the user input type is integer
                //keep prompting until the value matches requirements

                while (true)
                {

                    userInput = GetUserInput("Please enter the total number of matrixes:");
                    if (IsTypeInt(userInput) && int.Parse(userInput) > 1)
                    {
                        // reason we add 1 in the user input:- to make calculation of matrixMultiCostTable easier, you will see in the next lines :)
                        // add one in the user value to  start the loop from 1  whcich result in overcoming the  error of (p[(i - 1)] * p[k] * p[j]), so when we comopute the value it will start from the index 1.
                        numberOfMatrix = 1 + (int.Parse(userInput));

                        //intializing the empty p array to store the pvalues start from p0.
                        p = new int[numberOfMatrix];
                        break;
                    }
                    else
                    {
                        userInput = GetUserInput("Please enter integer value");

                    }

                }



                /*
                 * get the dimensions for the each matrix
                 * Prompt the user to enter each matrix dimensions:
                 * 
                 */
                for (i = 0; i < numberOfMatrix; i++)
                {
                    userInput = GetUserInput("please enter the value of P" + i);

                    //Check the input type 
                    // If it's integer Store the value 
                    // else  prompt with the message for the integer input
                    while (true)
                    {
                        if (IsTypeInt(userInput))
                        {
                            p[i] = int.Parse(userInput);
                            break;
                        }
                        else
                        {
                            userInput = GetUserInput("please enter the value of P" + i);
                        }
                    }

                    //still need to add a  else condition for p's value
                }
            }

            //intializing the empty m array userInput*userInput to store the minMutliCostValue
            matrixMultiCostTabe = new int[numberOfMatrix, numberOfMatrix];

            //intializing the empty kValue array userInput*userInput to store the k which we get the least minMultiCostValue
            kValue = new int[numberOfMatrix, numberOfMatrix];

            /*
             * keep the count for every loop
             */
            int timesLoopWork = 0;


            /*
             * store 0 in the coordinates where  i = j
             */
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
            /*
             * intialzed a mOrderarray within empty spaces 
             */

            string[] mOrderArray = new string[numberOfMatrix];

            for (i = 1; i < mOrderArray.Length; i++)
            {
                mOrderArray[i] = "M" + i;
            }

            for (diagnalLoopValue = 1; diagnalLoopValue < numberOfMatrix; diagnalLoopValue++)
            {
                timesLoopWork++;
                // Reason for the loop to start from 1: to solve the error of p p[(i - 1)]. 
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
            //Display the matrixMultiCostTabe Array value
            Console.Write("Multiple Cost Value Chain \n");
            for (i = 1; i < numberOfMatrix; i++)
            {
                for (j = 1; j < numberOfMatrix; j++)
                {
                    Console.Write(" | " + matrixMultiCostTabe[i, j] + " | ");
                }
                Console.Write("\n");
            }

            //Display the kValue Array value
            Console.Write("K values \n");
            for (i = 1; i < numberOfMatrix; i++)
            {
                for (j = 1; j < numberOfMatrix; j++)
                {
                    Console.Write(" | " + kValue[i, j] + " | ");
                }
                Console.Write("\n");
            }

            //Display the Matrix Dictionary value
            for (i = 1; i < numberOfMatrix; i++)
            {
                matricesDict.Add("M" + i, new Matrix(p[i - 1], p[i]));
            }

            String key;
            Matrix tmpMtx;
            for (i = 1; i < numberOfMatrix; i++)
            {
                key = "M" + i;
                tmpMtx = matricesDict[key];
                Console.WriteLine("Matrix " + key + "[" + tmpMtx.row + ", " + tmpMtx.col + "]");

            }


            // Display the matrix with brackets
            // For y input: send total number of matrices which is (numberofMatrix -1), beacuse in the end the soultion where we start goinng in is M[1,5] if userinput is 5 for the number of matrixes
            // mOrderArray is simple array that hold the M1, M2,........ Mn, 
            // kValue is an ESSENTIAL part of the method because, it holds the value for the lost multiple cost value
            Console.Write("Matrix with Correct Order of Brackets:");
            string[] arrayWithBrackets = InsertBrackets(1, numberOfMatrix - 1, mOrderArray, kValue);
            foreach (string item in arrayWithBrackets)
            {
                Console.Write(item);
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
        public static string[] InsertBrackets(int x, int y, string[] mArr, int[,] kValuesMemoryTable)
        {
            int mx, my, k, mkAdd1k;
            mx = x;
            my = y;
            k = kValuesMemoryTable[x, y];

            string[] matrixArray = mArr;
            // the formula was M[i, k] + M[(k + 1), j] + (p[(i - 1)] * p[k] * p[j]);

            // we took M[i, k] + M[(k + 1), j] from the formula to find the correct order for the brackets.

            //M[i, k] 
            int diffBTWmxSubk = System.Math.Abs(mx - k);

            //(k + 1)
            mkAdd1k = k + 1;

            //M[(k + 1), j] 
            int diffBTWmkAdd1Subbmy = System.Math.Abs(mkAdd1k - my);

            // IF the result is |1|: add brackets on the left side of the x and to right side of the y, don't call The method. Reason, There are only two matrices left.
            // IF the result is more than |1|: add brackets on the left side of the x and to right side of the y, call the method. Reason,  and add brackets(TODO> need to write a bit more clear explanation) 

            //check the  M[x,k]
            if ((diffBTWmxSubk) > 1)
            {
                //add bracket to the left of the mx and to the right of the k(which represent the y value)
                matrixArray[mx - 1] += "(";
                matrixArray[k] += ")";
                //call the INsertBracket method again to get the next brackets locations
                InsertBrackets(mx, k, matrixArray, kValuesMemoryTable);
            }
            else if ((diffBTWmxSubk) == 1)
            {

                //add bracket to the left of the mx and to the right of the k(which represent the y value)
                matrixArray[mx - 1] += "(";
                matrixArray[k] += ")";

            }


            // check the M[(k+1),j]
            if ((diffBTWmkAdd1Subbmy) > 1)
            {

                //add bracket to the left of the mx and to the right of the k(which represent the y value)
                matrixArray[mkAdd1k - 1] += "(";
                matrixArray[my] += ")";
                //call the INsertBracket method again to get the next brackets locations
                InsertBrackets(mkAdd1k, my, matrixArray, kValuesMemoryTable);
            }
            else if ((diffBTWmkAdd1Subbmy) == 1)
            {

                //add bracket to the left of the mx and to the right of the k(which represent the y value)
                matrixArray[mkAdd1k - 1] += "(";
                matrixArray[my] += ")";

            }

            return matrixArray;
        }


    }
}
