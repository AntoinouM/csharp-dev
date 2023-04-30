using System;
using System.Collections.Generic;

namespace Sort
{

    internal class Program
    {
        // Main function to sort the args
        static void Main(string[] args)
        {
            // Input: sort -Method -Type "1,2,4,3"
            if (args.Length != 4 || args[0] != "sort" || args[1] != "-Bubble" && args[1] != "-Merge") {
                Console.WriteLine("Please format your request like this:\n sort [-Bubble or -Merge] [1,2,3,4]");
                return;
            }

            // Create a new string to put the string with characters from args
            List<string> listToSort = new List<string>();

            foreach(string element in args[args.Length - 1].Split(",")) {
                listToSort.Add(element.Trim());
            }

            ConvertAndRedirect(args[1], listToSort, args[2]);
        }

        static void ConvertAndRedirect<T>(string sortingMethod, List<T> passedList, string dataType) where T : IConvertible {
        // -Bubble or -Merge, array to sort, -Int or -String...

            switch (dataType) {
                case "-Int":
                List<int> listToSortInt = passedList.ConvertAll<int>(x => x.ToInt32(Thread.CurrentThread.CurrentCulture));

                if(sortingMethod == "-Bubble") {
                    BubbleSort<int>.StartSort(listToSortInt);
                }
                else if(sortingMethod == "-Merge") {
                    MergeSort<int>.StartSort(listToSortInt);
                }
                    break;

                case "-Double":
                    List<double> listToSortDble = passedList.ConvertAll<double>(x => x.ToDouble(Thread.CurrentThread.CurrentCulture));

                    if(sortingMethod == "-Bubble") {
                        BubbleSort<double>.StartSort(listToSortDble);
                    }
                    else if(sortingMethod == "-Merge") {
                        MergeSort<double>.StartSort(listToSortDble);
                    }
                    break;

                case "-Float":
                    List<float> listToSortFloat = passedList.ConvertAll<float>(x => x.ToSingle(Thread.CurrentThread.CurrentCulture));

                    if(sortingMethod == "-Bubble") {
                        BubbleSort<float>.StartSort(listToSortFloat);
                    }
                    else if(sortingMethod == "-Merge") {
                        MergeSort<float>.StartSort(listToSortFloat);
                    }

                    break;
                default: //string
                    List<string> listToSortString = passedList.ConvertAll<string>(x => x.ToString(Thread.CurrentThread.CurrentCulture));

                    if(sortingMethod == "-Bubble") {
                        BubbleSort<string>.StartSort(listToSortString);
                    }
                    else if(sortingMethod == "-Merge") {
                        MergeSort<string>.StartSort(listToSortString);
                    }
                    break;
            }

        }

        class BubbleSort<T>: SortAlg<T> where T : IComparable<T> {
            public static void StartSort(List<T> listToSort)  {
            List<T> sortedList = Bubble(listToSort);
            WriteArrayToTerminal(sortedList);
            }

            private static List<T> Bubble(List<T> listToSort)
            {       
                // compare each vallue to the direct neigbhor. Repeat until each value in order.
                // create a boolean that change when no swap needed == sorting finished
                bool hasChanged;
                T temp;
                do {
                    hasChanged = false;
                    for (int i = 1; i < listToSort.Count; i++) {
                        if (listToSort[i - 1].CompareTo(listToSort[i]) > 0) {
                            temp = listToSort[i];
                            listToSort[i] = listToSort [i-1];
                            listToSort[i-1] = temp;
                            hasChanged = true;
                        } 
                    }
                } while (hasChanged); 
                return listToSort;
            }
            private static void WriteArrayToTerminal(List<T> sortedList) {
                Console.Write("After Sort: ");

                for(int i = 0; i < sortedList.Count; ++ i) {
                    Console.Write(sortedList[i] + " ");
                }
            }
        }

        class MergeSort<T>: SortAlg<T> where T : IComparable<T> {
            // Initialize Merge sort function
            public static void StartSort(List<T> listToSort) {
                List<T> sortedList = MergeSortFunction(listToSort);
                WriteArrayToTerminal(sortedList);
            }

            private static List<T> Merge(List<T> listToSort) {
                List<T> sortedList = new List<T>();
                sortedList = MergeSortFunction(listToSort);

                return sortedList;
            }

            private static List<T> MergeSortFunction(List<T> listToSort) {
                // If the list has one element or less, return that element
                if(listToSort.Count == 1) {
                    return listToSort;
                }

                // Create the left part and right part of list
                List<T> leftList = new List<T>();
                List<T> rightList = new List<T>();

                // Get the middle position of the list
                int middlePos = listToSort.Count / 2;
            
                // Dividing the sortThisList list
                for(int i = 0; i < middlePos; ++ i) {
                    leftList.Add(listToSort[i]);
                }
            
                for(int i = middlePos; i < listToSort.Count; ++ i){
                    rightList.Add(listToSort[i]);
                }

                // Break down the left and right parts (recursive part)
                leftList = MergeSortFunction(leftList);
                rightList = MergeSortFunction(rightList);

                // Merge the two parts, while ordering the elements
                return MergeMergeFunction(leftList, rightList);
            }

            private static List<T> MergeMergeFunction(List<T> leftList, List<T> rightList) {
                List<T> result = new List<T>();

                while(leftList.Count > 0 && rightList.Count > 0) {
                    // Comparing the first two elements from left part and right part to see which one is smaller
                    if(leftList.First().CompareTo(rightList.First()) < 0) {
                        result.Add(leftList.First()); // Add the smaller one to result list
                        leftList.Remove(leftList.First()); // Remove the smaller one from its list
                    }
                    else {
                        result.Add(rightList.First());
                        rightList.Remove(rightList.First());
                    }
                }

                // Maybe the left part still has some values we do not know -> search for values in the left part
                while(leftList.Count > 0) {
                    result.Add(leftList.First());
                    leftList.Remove(leftList.First());
                }

                // Maybe the right part still has some values we do not know -> search for values in the right part
                while(rightList.Count > 0) {
                    result.Add(rightList.First());
                    rightList.Remove(rightList.First());    
                }    
                
                return result;
            }

            private static void WriteArrayToTerminal(List<T> sortedList) {
                Console.Write("After Sort: ");

                for(int i = 0; i < sortedList.Count; ++ i) {
                    Console.Write(sortedList[i] + " ");
                }
            }
        }
    }
}