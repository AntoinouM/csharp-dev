using System;

namespace Sort
{
    interface SortAlg<T>
   {
        static void StartSort(List<T> stringArg) {}
        static void WriteArrayToTerminal(List<T> sortedList) {}
   }
}