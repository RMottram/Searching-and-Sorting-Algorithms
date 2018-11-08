using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics.PerformanceData;

namespace AlgorithmsAssessment2
{
    // START OF CLASS MAINCLASS
    class MainClass
    {
        // START OF MAIN PROGRAM CLASS
        public static void Main(string[] args)
        {
            #region data arrays

            /* READ TXT FILES AND INSERT THEM INTO ARRAYS
            LINQ ALLOWS THE CONVERSION OF THE DATA FROM THE TXT FILE TO BE ABLE TO BE PLACED INSIDE THE DOUBLE ARRAYS */

            // 128 TXT FILES
            double[] close128Data = File.ReadLines("Bank_Data/Close_128.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] open128Data = File.ReadLines("Bank_Data/Open_128.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] high128Data = File.ReadLines("Bank_Data/High_128.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] low128Data = File.ReadLines("Bank_Data/Low_128.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] change128Data = File.ReadLines("Bank_Data/Change_128.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            // 265 TXT FILES
            double[] close256Data = File.ReadLines("Bank_Data/Close_256.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] open256Data = File.ReadLines("Bank_Data/Open_256.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] high256Data = File.ReadLines("Bank_Data/High_256.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] low256Data = File.ReadLines("Bank_Data/Low_256.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] change256Data = File.ReadLines("Bank_Data/Change_256.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            // 1024 TXT FILES
            double[] close1024Data = File.ReadLines("Bank_Data/Close_1024.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] change1024Data = File.ReadLines("Bank_Data/Change_1024.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] open1024Data = File.ReadLines("Bank_Data/Open_1024.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] high1024Data = File.ReadLines("Bank_Data/High_1024.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            double[] low1024Data = File.ReadLines("Bank_Data/Low_1024.txt")
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

            #endregion data arrays

            #region Testing Area

            //double[] testArr = new double[1024];
            //int indexCounterTest = 0;

            //Random randNum = new Random();
            //for (int i = 0; i < testArr.Length; i++)
            //{
            //    testArr[i] = randNum.Next(0, 1024);
            //}

            //for (int i = 0; i < testArr.Length; i++)
            //{
            //    int steps = 0;
            //    BubbleSortAlgorithm.BubbleSort(close1024Data, 1024, ref steps);
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.Write(indexCounterTest + ": ");
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine(close1024Data[i] + "\t");
            //    indexCounterTest++;
            //}
            //Console.WriteLine(SearchingAlgorithms.LinearSearch(close1024Data, 1024, 17));


            #endregion Testing Area

            // BOOLEANS TO SAY WHETHER TO STAY IN LOOPS OR CONTINUE THROUGH PROGRAM
            bool reverseOrder = false;
            bool ascendingDescending = false;
            bool normalOrder = false;
            bool fileChose = false;

            // MENU LIST FOR SELECTING WHICH FILES TO SEARCH AND SORT
            Console.WriteLine("Which set of data would you like to analyse?\n");
            Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");
            string fileMenu = Console.ReadLine().ToLower();

            // ASKS USER IF THEY WANT THE FILE THEY SELECTED IN ASCENDING OR DESCENDING ORDER
            Console.WriteLine("\nWould you like it sorted in:\n1. Ascending (low to high)\n2. Descending (high to low) order?\n");
            Console.WriteLine("Choose by entering its corresponding value as it appears in the list and pressing \"Enter\"");
            string sortingRule = Console.ReadLine();

            // WHILE ASCENDINGDESCENDING IS SET TO FALSE, LOOP THROUGH THIS
            while (ascendingDescending == false)
            {
                switch (sortingRule)
                {
                    case "1":

                        Console.WriteLine("\nYou have chosen to sort the data into ascending order. Press \"Enter\" to continue\n");
                        normalOrder = true; // TELLS THE PROGRAM TO SORT THE SELECTED FILE INTO ASCENDING ORDER
                        ascendingDescending = true; // SET TO TRUE TO BREAK OUT OF THE LOOP
                        Console.ReadLine();

                        break; // BREAKS OUT THE LOOP IF THIS IS THE DESIRED CASE

                    case "2":

                        Console.WriteLine("\nYou have chosen to sort the data into descending order. Press \"Enter\" to continue\n");
                        reverseOrder = true;
                        ascendingDescending = true;
                        Console.ReadLine();

                        break;

                    default:

                        Console.WriteLine("\nThere is an error in picking whether you wanted to sort in ascending or descending order.");
                        Console.WriteLine("Please choose an option from the list as you see it i.e. 1 for ascending.");

                        Console.WriteLine("\nWould you like it sorted in:\n1. Ascending (low to high)\n2. Descending (high to low) order?\n");
                        sortingRule = Console.ReadLine();

                        break;
                }
            }

            // IF THE FILECHOSE BOOL IS FALSE, LOOP THROUGH THIS BLOCK OF CODE
            while (fileChose == false)
            {
                switch (fileMenu)
                {
                    // EACH CASE FOLLOWS THE SAME PATTERN OF DISPLAYING THE SORTED ARRAY AND ASKING FOR A VALUE TO BE SEARCHED,
                    // DISPLAY ALL LOCATIONS OR DISPLAY LOCATION OF NEAREST VALUE IF NOT PRESENT AND ASK TO RETRUN BACK TO MAIN MENU
                    // OR REDO THE SAME FILE
                    case "1":

                        fileChose = true; // STOPS THE LOOPING OF THE BLOCK OF CODE AND RUN THIS PART OF THE CODE ONLY

                        // IF THE ASCENDING OPTION WAS CHOSEN
                        if (normalOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Close file with 128 data points\n");
                            fileChose = true; // SETS THE BOOL TO TRUE SO THE LOOP CAN BE BROKEN AND THIS CASE CAN BE EXECUTED
                            int indexCounter = 0; // INITIATE THE INDEX COUNTER FOR WHEN DISPLAYING THE LIST OF DATA VALUES

                            Console.WriteLine("The file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < close128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSort(close128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan; // CHANGES THE COLOUR OF THE TEXT SPECIALLY FOR THE INDEX LABELS
                                Console.Write(indexCounter + ": ");
                                Console.ForegroundColor = ConsoleColor.White; // CONVERTS BACK TO WHITE BEFORE DISPLAYING THE SORTED DATA
                                Console.WriteLine(close128Data[i]);
                                indexCounter++; // INCREASES THE INDEX COUNTER FOR EACH VALUE IN ARRAY TO SHOW WHAT POSITION IT IS AT
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(close128Data, 128, userRequest)); // PERFORMS THE SEARCH OF THE VALUE
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(close128Data, userRequest)); // CHECKS FOR DUPLICATES DISPLAYS THEM IF THERE ARE ANY

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            // REQUEST FOR A NEW FILE
                            if (resetChoice == "change")
                            {
                                fileChose = false; // RE-SETS THE BOOL TO FALSE SO THE BLOCK OF CODE CAN RE-RUN ITS LOOP UNTIL SET TO TRUE AGAIN

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            // REQUEST TO SEARCH THE CURRENT FILE AGAIN
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "1"; // SETS THE CASE FOR THE USER TO REDO THE SAME FILE AFTER THE FILECHOSE BOOL IS SET TO FALSE
                            }
                        }
                        // IF THE DESCENDING OPTION WAS CHOSEN
                        if (reverseOrder == true)
                        {
                            Console.WriteLine("\nYou have chosen the Close file with 128 data points\n");
                            fileChose = true;
                            int indexCounter = 0;

                            Console.WriteLine("The file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < close128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSortReverse(close128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(close128Data[i] + "\t");
                                indexCounter++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(close128Data, 128, userRequest));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(close128Data, userRequest));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "1";
                            }
                        }

                        break;

                    case "2":

                        if (normalOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Change file with 128 data points\n");
                            fileChose = true;
                            int indexCounter2 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < change128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSort(change128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter2 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(change128Data[i] + "\t");
                                indexCounter2++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. -0.095");
                            double userRequest2 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(change128Data, 128, userRequest2));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(change128Data, userRequest2));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "2";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Change file with 128 data points\n");
                            fileChose = true;
                            int indexCounter2 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < change128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSortReverse(change128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter2 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(change128Data[i] + "\t");
                                indexCounter2++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. -0.095");
                            double userRequest2 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(change128Data, 128, userRequest2));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(change128Data, userRequest2));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "2";
                            }
                        }

                        break;

                    case "3":

                        if (normalOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Open file with 128 data points\n");
                            fileChose = true;
                            int indexCounter3 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < open128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSort(open128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter3 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(open128Data[i] + "\t");
                                indexCounter3++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest3 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(open128Data, 128, userRequest3));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(open128Data, userRequest3));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "3";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Open file with 128 data points\n");
                            fileChose = true;
                            int indexCounter3 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < open128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSortReverse(open128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter3 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(open128Data[i] + "\t");
                                indexCounter3++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest3 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(open128Data, 128, userRequest3));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(open128Data, userRequest3));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "3";
                            }
                        }

                        break;

                    case "4":

                        if (normalOrder)
                        {
                            Console.WriteLine("\nYou have chosen the High file with 128 data points\n");
                            fileChose = true;
                            int indexCounter4 = 0;
                           
                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < high128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSort(high128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter4 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(high128Data[i] + "\t");
                                indexCounter4++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest4 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(high128Data, 128, userRequest4));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(high128Data, userRequest4));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "4";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("\nYou have chosen the High file with 128 data points\n");
                            fileChose = true;
                            int indexCounter4 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < high128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSortReverse(high128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter4 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(high128Data[i] + "\t");
                                indexCounter4++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest4 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(high128Data, 128, userRequest4));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(high128Data, userRequest4));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "4";
                            }
                        }

                        break;

                    case "5":

                        if (normalOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Low file with 128 data points\n");
                            fileChose = true;
                            int indexCounter5 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < low128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSort(low128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter5 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(low128Data[i] + "\t");
                                indexCounter5++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest5 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(low128Data, 128, userRequest5));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(low128Data, userRequest5));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "5";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("\nYou have chosen the Low file with 128 data points\n");
                            fileChose = true;
                            int indexCounter5 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < low128Data.Length; i++)
                            {
                                BubbleSortAlgorithm.BubbleSortReverse(low128Data, 128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter5 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(low128Data[i] + "\t");
                                indexCounter5++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Bubble Sort algorithm. " +
                                              "This algorithm was used because it is a simple algorithm and works very well with " +
                                              "small amounts of data.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest5 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(low128Data, 128, userRequest5));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(low128Data, userRequest5));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "5";
                            }
                        }

                        break;

                    case "6":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Close file with 256 data points");
                            fileChose = true;
                            int indexCounter6 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < close256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(close256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter6 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(close256Data[i] + "\t");
                                indexCounter6++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest6 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(close256Data, 256, userRequest6));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(close256Data, userRequest6));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "6";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Close file with 256 data points");
                            fileChose = true;
                            int indexCounter6 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < close256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSortReverse(close256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter6 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(close256Data[i] + "\t");
                                indexCounter6++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest6 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(close256Data, 256, userRequest6));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(close256Data, userRequest6));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "6";
                            }
                        }

                        break;

                    case "7":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Change file with 256 data points");
                            fileChose = true;
                            int indexCounter7 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < change256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(change256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter7 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(change256Data[i] + "\t");
                                indexCounter7++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. -0.095");
                            double userRequest7 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(change256Data, 256, userRequest7));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(change256Data, userRequest7));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "7";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Change file with 256 data points");
                            fileChose = true;
                            int indexCounter7 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < change256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSortReverse(change256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter7 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(change256Data[i] + "\t");
                                indexCounter7++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. -0.095");
                            double userRequest7 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(change256Data, 256, userRequest7));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(change256Data, userRequest7));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "7";
                            }
                        }

                        break;

                    case "8":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Open file with 256 data points");
                            fileChose = true;
                            int indexCounter8 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < open256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(open256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter8 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(open256Data[i] + "\t");
                                indexCounter8++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest8 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(open256Data, 256, userRequest8));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(open256Data, userRequest8));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "8";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Open file with 256 data points");
                            fileChose = true;
                            int indexCounter8 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < open256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSortReverse(open256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter8 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(open256Data[i] + "\t");
                                indexCounter8++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest8 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(open256Data, 256, userRequest8));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(open256Data, userRequest8));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "8";
                            }
                        }

                        break;

                    case "9":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the High file with 256 data points");
                            fileChose = true;
                            int indexCounter9 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < high256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(high256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter9 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(high256Data[i] + "\t");
                                indexCounter9++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest9 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(high256Data, 256, userRequest9));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(high256Data, userRequest9));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "9";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the High file with 256 data points");
                            fileChose = true;
                            int indexCounter9 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < high256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSortReverse(high256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter9 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(high256Data[i] + "\t");
                                indexCounter9++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest9 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(high256Data, 256, userRequest9));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(high256Data, userRequest9));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "9";
                            }
                        }

                        break;

                    case "10":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Low file with 256 data points");
                            fileChose = true;
                            int indexCounter10 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < low256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(low256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter10 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(low256Data[i] + "\t");
                                indexCounter10++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest10 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(low256Data, 256, userRequest10));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(low256Data, userRequest10));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "10";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Low file with 256 data points");
                            fileChose = true;
                            int indexCounter10 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < low256Data.Length; i++)
                            {
                                CombSortAlgorithm.CombSortReverse(low256Data);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter10 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(low256Data[i] + "\t");
                                indexCounter10++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest10 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(low256Data, 256, userRequest10));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(low256Data, userRequest10));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "10";
                            }
                        }

                        break;

                    case "11":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Close file with 1024 data points");
                            fileChose = true;
                            int indexCounter11 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < close1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSort(close1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter11 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(close1024Data[i] + "\t");
                                indexCounter11++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest11 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(close1024Data, 0, 1023, userRequest11));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(close1024Data, userRequest11));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "11";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Close file with 1024 data points");
                            fileChose = true;
                            int indexCounter11 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < close1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSortReverse(close1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter11 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(close1024Data[i] + "\t");
                                indexCounter11++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest11 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(close1024Data, 0, 1023, userRequest11));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(close1024Data, userRequest11));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "11";
                            }
                        }

                        break;

                    case "12":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Change file with 1024 data points");
                            fileChose = true;
                            int indexCounter12 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < change1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSort(change1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter12 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(change1024Data[i] + "\t");
                                indexCounter12++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. -0.095");
                            double userRequest12 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(change1024Data, 0, 1023, userRequest12));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(change1024Data, userRequest12));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "12";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Change file with 1024 data points");
                            fileChose = true;
                            int indexCounter12 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < change1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSortReverse(change1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter12 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(change1024Data[i] + "\t");
                                indexCounter12++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. -0.095");
                            double userRequest12 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(change1024Data, 0, 1023, userRequest12));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(change1024Data, userRequest12));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "12";
                            }
                        }

                        break;

                    case "13":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Open file with 1024 data points");
                            fileChose = true;
                            int indexCounter13 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < open1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSort(open1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter13 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(open1024Data[i] + "\t");
                                indexCounter13++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest13 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(open1024Data, 0, 1023, userRequest13));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(open1024Data, userRequest13));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "13";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Open file with 1024 data points");
                            fileChose = true;
                            int indexCounter13 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < open1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSortReverse(open1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter13 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(open1024Data[i] + "\t");
                                indexCounter13++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest13 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(open1024Data, 0, 1023, userRequest13));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(open1024Data, userRequest13));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "13";
                            }
                        }

                        break;

                    case "14":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the High file with 1024 data points");
                            fileChose = true;
                            int indexCounter14 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < high1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSort(high1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter14 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(high1024Data[i] + "\t");
                                indexCounter14++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest14 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(high1024Data, 0, 1023, userRequest14));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(high1024Data, userRequest14));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "14";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the High file with 1024 data points");
                            fileChose = true;
                            int indexCounter14 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < high1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSortReverse(high1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter14 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(high1024Data[i] + "\t");
                                indexCounter14++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest14 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(high1024Data, 0, 1023, userRequest14));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(high1024Data, userRequest14));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "14";
                            }
                        }

                        break;

                    case "15":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen the Low file with 1024 data points");
                            fileChose = true;
                            int indexCounter15 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < low1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSort(low1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter15 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(low1024Data[i] + "\t");
                                indexCounter15++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest15 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(low1024Data, 0, 1023, userRequest15));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(low1024Data, userRequest15));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "15";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen the Low file with 1024 data points");
                            fileChose = true;
                            int indexCounter15 = 0;

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < low1024Data.Length; i++)
                            {
                                QuickSortAlgorithm.QuickSortReverse(low1024Data, 0, 1023);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter15 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(low1024Data[i] + "\t");
                                indexCounter15++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Quick Sort algorithm. " +
                                              "This algorithm was used because it works better than Bubble Sort when it comes to larger " +
                                              "amounts of data");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest15 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(low1024Data, 0, 1023, userRequest15));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(low1024Data, userRequest15));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "15";
                            }
                        }

                        break;

                    case "16":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen to merge the Close 128 and High 128 files together");
                            fileChose = true;
                            int indexCounter16 = 0;

                            // CONCATENATE THE TWO ARRAYS TOGETHER TO CREATE THE NEW LARGER ARRAY
                            double[] closeHigh128 = new double[close128Data.Length + high128Data.Length];
                            Array.Copy(close128Data, closeHigh128, close128Data.Length);
                            Array.Copy(high128Data, 0, closeHigh128, close128Data.Length, high128Data.Length);

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < closeHigh128.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(closeHigh128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter16 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(closeHigh128[i] + "\t");
                                indexCounter16++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest16 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(closeHigh128, 256, userRequest16));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(closeHigh128, userRequest16));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "16";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen to merge the Close 128 and High 128 files together");
                            fileChose = true;
                            int indexCounter16 = 0;

                            double[] closeHigh128 = new double[close128Data.Length + high128Data.Length];
                            Array.Copy(close128Data, closeHigh128, close128Data.Length);
                            Array.Copy(high128Data, 0, closeHigh128, close128Data.Length, high128Data.Length);

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < closeHigh128.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(closeHigh128);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter16 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(closeHigh128[i] + "\t");
                                indexCounter16++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest16 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.LinearSearch(closeHigh128, 256, userRequest16));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(closeHigh128, userRequest16));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "16";
                            }
                        }

                        break;

                    case "17":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen to merge the Close 128 and High 128 files together");
                            fileChose = true;
                            int indexCounter17 = 0;

                            double[] closeHigh256 = new double[close256Data.Length + high256Data.Length];
                            Array.Copy(close256Data, closeHigh256, close256Data.Length);
                            Array.Copy(high256Data, 0, closeHigh256, close256Data.Length, high256Data.Length);

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < closeHigh256.Length; i++)
                            {
                                CombSortAlgorithm.CombSort(closeHigh256);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter17 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(closeHigh256[i] + "\t");
                                indexCounter17++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest17 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(closeHigh256, 0, 511, userRequest17));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(closeHigh256, userRequest17));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "14";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen to merge the Close 128 and High 128 files together");
                            fileChose = true;
                            int indexCounter17 = 0;

                            double[] closeHigh256 = new double[close256Data.Length + high256Data.Length];
                            Array.Copy(close256Data, closeHigh256, close256Data.Length);
                            Array.Copy(high256Data, 0, closeHigh256, close256Data.Length, high256Data.Length);

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < closeHigh256.Length; i++)
                            {
                                CombSortAlgorithm.CombSortReverse(closeHigh256);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter17 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(closeHigh256[i] + "\t");
                                indexCounter17++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Comb Sort algorithm. " +
                                              "This algorithm was used because it is an adaptation to the Bubble Sort algorithm where instead of one value being shifted, " +
                                              "two values are shifted simulataneously\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest17 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(closeHigh256, 0, 511, userRequest17));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(closeHigh256, userRequest17));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "17";
                            }
                        }

                        break;

                    case "18":

                        if (normalOrder)
                        {
                            Console.WriteLine("You have chosen to merge the Close 128 and High 128 files together");
                            fileChose = true;
                            int indexCounter18 = 0;

                            double[] closeHigh1024 = new double[close1024Data.Length + high1024Data.Length];
                            Array.Copy(close1024Data, closeHigh1024, close128Data.Length);
                            Array.Copy(high1024Data, 0, closeHigh1024, close1024Data.Length, high1024Data.Length);

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < closeHigh1024.Length; i++)
                            {
                                CocktailSortAlgorithm.CocktailSort(closeHigh1024);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter18 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(closeHigh1024[i] + "\t");
                                indexCounter18++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Cocktail Shaker algorithm. " +
                                              "This algorithm was used because it works well with large data entries and sorts the data " +
                                              "by placing the smallest and largest values at either end simultaneously.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest18 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(closeHigh1024, 0, 2047, userRequest18));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(closeHigh1024, userRequest18));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "18";
                            }
                        }
                        if (reverseOrder)
                        {
                            Console.WriteLine("You have chosen to merge the Close 128 and High 128 files together");
                            fileChose = true;
                            int indexCounter18 = 0;

                            double[] closeHigh1024 = new double[close1024Data.Length + high1024Data.Length];
                            Array.Copy(close1024Data, closeHigh1024, close128Data.Length);
                            Array.Copy(high1024Data, 0, closeHigh1024, close1024Data.Length, high1024Data.Length);

                            Console.WriteLine("\nThe file you have chosen with its data sorted is as follows:\n");

                            for (int i = 0; i < closeHigh1024.Length; i++)
                            {
                                CocktailSortAlgorithm.CocktailSortReverse(closeHigh1024);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(indexCounter18 + ": ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(closeHigh1024[i] + "\t");
                                indexCounter18++;
                            }

                            Console.WriteLine("\n\nThe algorithm used for sorting this data was the Cocktail Shaker algorithm. " +
                                              "This algorithm was used because it works well with large data entries and sorts the data " +
                                              "by placing the smallest and largest values at either end simultaneously.\n");

                            Console.WriteLine("To search for a particular data entry, press \"Enter\".");
                            Console.ReadLine();

                            Console.WriteLine("Enter a data entry you wish to find in the file. Enter it exactly how you see it above e.g. 1.95");
                            double userRequest18 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine(SearchingAlgorithms.BinarySearch(closeHigh1024, 0, 2047, userRequest18));
                            Console.WriteLine(SearchingAlgorithms.DuplicateChecker(closeHigh1024, userRequest18));

                            // CHANGE TO A DIFFERENT FILE
                            Console.WriteLine("\nIf you want to search a different file, type \"change\" on your keyboard. Or type \"redo\" to search this file again.");
                            string resetChoice = Console.ReadLine().ToLower();

                            if (resetChoice == "change")
                            {
                                fileChose = false;

                                Console.WriteLine("\nSelect the new file you wish to read from\n");
                                Console.WriteLine("Choose between: \n\n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                              "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                              "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                              "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                              "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                              "The number in brackets refers to how many data entries are in the file.");

                                fileMenu = Console.ReadLine().ToLower();
                            }
                            if (resetChoice == "redo")
                            {
                                fileChose = false;
                                fileMenu = "18";
                            }
                        }

                        break;

                    default:

                        Console.WriteLine("\nThere is an error in picking which set of data you wish to evaluate.");
                        Console.WriteLine("Please choose an option from the list as you see it i.e. 1 for Close with 128 data entries.");

                        Console.WriteLine("\nChoose between: \n1.  Close (128) \n2.  Change (128) \n3.  Open (128) \n4.  High (128)\n" +
                             "5.  Low (128)\n6.  Close (256)\n7.  Change (256)\n8.  Open (256)\n9.  High (256)\n10. Low (256) " +
                             "\n11. Close (1024)\n12. Change (1024)\n13. Open (1024)\n14. High (1024)\n15. Low (1024) " +
                             "\n16. Close and High 128 merged\n17. Close and High 256 merged\n18. Close and High 1024 merged" +
                             "\n\nby entering its corresponding value as it appears in the list and pressing \"Enter\". " +
                             "The number in brackets refers to how many data entries are in the file.");
                        fileMenu = Console.ReadLine().ToLower();

                        break;
                }
            }
        } // END OF MAIN PROGRAM CLASS

        #region SearchingAndSortingAlgorithms

        class SearchingAlgorithms
        {
            public static int BinarySearch(double[] arr, int l, int r, double searchValue)
            {
                int steps = 0;

                if (r >= l)
                {
                    int mid = r - l / 2;

                    // IF THE ELEMENT IS THE MIDDLE VALUE
                    if (arr[mid] == searchValue)
                    {
                        steps++;
                        Console.Write("Value found at position ");
                        return mid;
                    }
                    // IF ELEMENT IS SMALLER THAN MID VALUE, IT CAN BE FOUND IN THE LEFT PART OF THE ARRAY
                    if (arr[mid] > searchValue)
                    {
                        steps++;
                        return BinarySearch(arr, l, mid - 1, searchValue);
                    }
                    steps++;

                    Console.WriteLine($"Steps performed: {steps}");
                    
                    int nearestIndex = Array.IndexOf(arr, arr.OrderBy(number => Math.Abs(number - searchValue)).First());

                    var nearest = arr.OrderBy(x => Math.Abs((double)x - searchValue)).First();

                    Console.Write("\nSearch value not found ");
                    Console.WriteLine($"\nHowever, the closest value {nearest} can be found at position {nearestIndex}\n");

                    // ELSE, IN THE RIGHT PART OF THE ARRAY
                    //return BinarySearch(arr, mid - 1, r, searchValue);
                }
                return -1;
            }

            public static int LinearSearch(double[] arr, int n, double userRequest)
            {
                for (int i = 0; i < n; i++)
                {
                    // RETURN INDEX IF FOUND
                    if (arr[i] == userRequest)
                    {
                        Console.Write("Value found at position ");
                        return i;
                    }
                }

                Console.WriteLine();
                Console.WriteLine(DuplicateChecker(arr, userRequest));

                Console.Write("Search value not found ");

                double nearestValue = arr.Select(p => new { Value = p, Difference = Math.Abs(p - userRequest) })
                      .OrderBy(p => p.Difference)
                      .First().Value;
                int nearestIndex = Array.IndexOf(arr, arr.OrderBy(number => Math.Abs(number - userRequest)).First());

                Console.WriteLine($"\nHowever, the closest value {nearestValue} can be found at position {nearestIndex}");

                // RETURN -1 IF NOT FOUND
                return -1;
            }

            /* CHECKS IF THE USER REQUESTED VALUE RESIDES IN THE ARRAY MORE THAN ONCE
            AND IF IT DOES IT SHOWS THE POSITIONS FOR EACH ITERATION.
            CALLED IN THE SEARCH METHODS */

            public static int DuplicateChecker(double[] array, double requestedValue)
            {
                int index = -1;
                int duplicateCounter = 0;

                while ((index = Array.IndexOf(array, requestedValue, index + 1)) != -1)
                {
                    Console.WriteLine($"Your value {requestedValue} also appears in position {index} of the array ");
                    duplicateCounter++;
                }

                Console.Write("\nDuplicates found: ");
                return duplicateCounter;
            }
        }

        class CocktailSortAlgorithm
        {
            public static void CocktailSort(double[] array)
            {
                int steps = 0;

                for (int i = array.Length - 1; i > 0; i--)
                {
                    bool swapped = false;

                    for (int j = i; i > 0; i--)
                    {
                        if (array[i] < array[i - 1])
                        {
                            // SWAP
                            double temp = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = temp;
                            swapped = true;
                        }
                        steps++;
                    }

                    for (int j = 0; i < j; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            // SWAP
                            double temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapped = true;
                        }
                        steps++;
                    }
                    steps++;
                    if (!swapped) break;
                }
                steps++;
                Console.WriteLine($"Steps performed: {steps}");
            }

            public static void CocktailSortReverse(double[] array)
            {
                for (int i = array.Length - 1; i > 0; i--)
                {
                    bool swapped = false;

                    for (int j = i; i > 0; i--)

                        if (array[i] > array[i - 1])
                        {
                            // SWAP ELEMENTS
                            double temp = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = temp;
                            swapped = true;
                        }

                    for (int j = 0; i < j; i++)

                        if (array[i] < array[i + 1])
                        {
                            // SWAP ELEMENST
                            double temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapped = true;
                        }

                    if (!swapped)
                    {
                        break;
                    }
                }
            }
        }

        class QuickSortAlgorithm
        {
            public static void QuickSort(double[] array, int left, int right)
            {
                int i, j;
                int steps = 0;
                double pivot, temp;

                i = left;
                j = right;
                pivot = array[(left + right) / 2];

                do
                {
                    while ((array[i] < pivot) && (i < right))
                    {
                        i++;
                        steps++;
                    }
                    while ((pivot < array[j]) && (j > left))
                    {
                        j--;
                        steps++;
                    }

                    if (i <= j)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        i++;
                        j--;
                        steps++;
                    }
                } while (i <= j);

                if (left < j)
                {
                    QuickSort(array, left, j);
                    steps++;
                }
                if (i < right)
                {
                    QuickSort(array, i, right);
                    steps++;
                }

                Console.WriteLine($"Steps performed: {steps}");
            }

            public static void QuickSortReverse(double[] array, int left, int right)
            {
                int i, j;
                int steps = 0;
                double pivot, temp;

                i = left;
                j = right;
                pivot = array[(left + right) / 2];

                do
                {
                    while ((array[i] > pivot) && (i < right))
                    {
                        i++;
                        steps++;
                    }
                    while ((pivot > array[j]) && (j > left))
                    {
                        j--;
                        steps++;
                    }

                    if (i <= j)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        i++;
                        j--;
                    }
                } while (j >= i);

                if (left < j)
                {
                    QuickSortReverse(array, left, j);
                    steps++;
                }
                if (i < right)
                {
                    QuickSortReverse(array, i, right);
                    steps++;
                }
                Console.WriteLine($"Steps performed: {steps}");
            }
        }

        class CombSortAlgorithm
        {
            // FIND GAP BETWEEN ELEMENTS
            public static int GetNextGap(int gap)
            {
                // SHRINK THE GAP BY THE FACTOR
                gap = (gap * 10) / 13;
                if (gap < 1)
                {
                    return 1;
                }
                return gap;
            }

            public static void CombSort(double[] arr)
            {
                int steps = 0;
                int n = arr.Length;

                // INITIALISE THE GAP TO THE SIZE OF THE ARRAY AT FIRST
                int gap = n;

                // SWAPPED = TRUE MAKES THE LOOP RUN 
                bool swapped = true;

                // KEEP LOOPING WHILE THE GAP IS MORE THAN 1 VALUE 
                while (gap != 1 || swapped == true)
                {
                    // FIND THE NEXT GAP AFTER EACH ARRAY SCAN
                    gap = GetNextGap(gap);

                    // INITIALISE SWAPPED AS FALSE TO CHECK VALUES
                    swapped = false;

                    // COMPARE ELEMENTS WITH THE GAP
                    for (int i = 0; i < n - gap; i++)
                    {
                        if (arr[i] > arr[i + gap])
                        {
                            // SWAP ARR[i] AND ARR[i+GAP]
                            double temp = arr[i];
                            arr[i] = arr[i + gap];
                            arr[i + gap] = temp;

                            swapped = true;
                        }
                        steps++;
                    }
                    steps++;
                }
                Console.WriteLine($"Steps performed: {steps}");
            }


            // To find gap between elements
            public static int GetNextGapReverse(int gap)
            {
                // Shrink gap by Shrink factor
                gap = (gap * 10) / 13;
                if (gap < 1)
                {
                    return 1;
                }
                return gap;
            }

            // Function to sort arr[] using Comb Sort
            public static void CombSortReverse(double[] arr)
            {
                int steps = 0;
                int n = arr.Length;

                int gap = n;

                bool swapped = true;

                while (gap != 1 || swapped == true)
                {
                    gap = GetNextGapReverse(gap);

                    swapped = false;

                    for (int i = 0; i < n - gap; i++)
                    {
                        if (arr[i] < arr[i + gap])
                        {
                            double temp = arr[i];
                            arr[i] = arr[i + gap];
                            arr[i + gap] = temp;

                            swapped = true;
                        }
                        steps++;
                    }
                    steps++;
                }
                Console.WriteLine($"Steps performed: {steps}");
            }
        }

        class BubbleSortAlgorithm
        {
            public static void BubbleSort(double[] array, int n) // N = NUMBER OF DATA POINTS
            {
                int steps = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j + 1] < array[j])
                        {
                            double temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                        steps++;
                    }
                }
                Console.WriteLine($"Steps performed: {steps}");
            }

            public static void BubbleSortReverse(double[] array, int n)
            {
                int steps = 0; 

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j + 1] > array[j])
                        {
                            double temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                        steps++;
                    }
                }
                Console.Write($"Steps performed: {steps}");
            }
        }

        #endregion SearchingAndSortingAlgorithms

    } // END OF CLASS MAINCLASS
}

/* THE INSPIRATION FOR SOME OF THE ALGORITHMS HAVE BEEN FROM SOURCES SUCH AS GEEKSFORGEEKS.COM AND UNIVERSITY OF LINCOLN ALGORITHMS AND COMPLEXITY LECTURE SLIDES
 * 
 * OTHER BITS OF CODE FOR OTHER FEATURES HAVE BEEN RESEARCHED AND USED FOR INSPIRATION FROM CONTRIBUTORS ON STACKOVERFLOW.COM */