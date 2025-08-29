# Delivery Route Optimization

C# implementation of maximum non-overlapping delivery routes using greedy algorithm.

## Requirements

- .NET 8+ SDK

## Quick Start

```bash
dotnet run
```

## Algorithm

Greedy approach for Activity Selection Problem:
1. Sort routes by end time
2. Select routes that start after previous route ends
3. Return count of selected routes

## Test Cases

- Sample input: 6 routes → Expected: 4
- Empty list → Expected: 0  
- Adjacent routes → Expected: 4

## Assumptions

- Adjacent routes (end time = start time) are non-overlapping
- Input data is valid (start ≤ end)

## Implementation

`GetMaxNonOverlappingRoutes(List<(int start, int end)> routes)` - Main algorithm using LINQ and greedy strategy.