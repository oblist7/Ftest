using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Delivery Route Optimization Functional Test ---");

        // TestCase 1: Sample from the provided document
        var sampleRoutes = new List<(int start, int end)>
        {
            (1, 3),
            (2, 5),
            (4, 6),
            (6, 7),
            (5, 8),
            (8, 9)
        };
        int result1 = GetMaxNonOverlappingRoutes(sampleRoutes);
        Console.WriteLine($"Test Case 1 (Sample): Expected = 4, Actual = {result1}");
        Console.WriteLine(result1 == 4 ? "Status: PASSED" : "Status: FAILED");
        Console.WriteLine("-------------------------------------------------------");

        // TestCase 2: Empty list of routes (edge case)
        var emptyRoutes = new List<(int start, int end)>();
        int result2 = GetMaxNonOverlappingRoutes(emptyRoutes);
        Console.WriteLine($"Test Case 2 (Empty List): Expected = 0, Actual = {result2}");
        Console.WriteLine(result2 == 0 ? "Status: PASSED" : "Status: FAILED");
        Console.WriteLine("-------------------------------------------------------");
        
        // TestCase 3: Strictly adjacent routes
        var adjacentRoutes = new List<(int start, int end)>
        {
            (1, 2),
            (2, 3),
            (4, 5),
            (3, 4)
        };
        int result3 = GetMaxNonOverlappingRoutes(adjacentRoutes);
        Console.WriteLine($"TestCase 3 (Adjacent Routes): Expected = 4, Actual = {result3}");
        Console.WriteLine(result3 == 4 ? "Status: PASSED" : "Status: FAILED");
        Console.WriteLine("-------------------------------------------------------");
    }

    /// Calculates the maximum number of non-overlapping delivery routes using a greedy algorithm.
    public static int GetMaxNonOverlappingRoutes(List<(int start, int end)> routes)
    {
        // 1. Handle the edge case: if the list is null or empty, there are no non-overlapping routes.
        if (routes == null || !routes.Any())
        {
            return 0;
        }

        // 2. Greedy Algorithm: Sort the routes by their end time.
        // This is the core step that allows us to always make the locally optimal choice.
        var sortedRoutes = routes.OrderBy(r => r.end).ToList();

        // 3. Initialization: The first route in the sorted list is always part of the optimal set.
        int maxRoutesCount = 1;
        int lastEndTime = sortedRoutes[0].end;

        // 4. Iterate through the remaining routes.
        // We use a for loop for a minor performance gain by skipping the first element, which is already included.
        for (int i = 1; i < sortedRoutes.Count; i++)
        {
            var currentRoute = sortedRoutes[i];

            // 5. Selection Condition: If the current route starts at or after the last selected route ended,
            // it doesn't overlap. We select it and update the last end time.
            if (currentRoute.start >= lastEndTime)
            {
                maxRoutesCount++;
                lastEndTime = currentRoute.end;
            }
        }

        return maxRoutesCount;
    }
}
