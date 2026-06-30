# Exercise 08: Externalize Sample Data

## Goal

Move some static sample data out of code and into a simple data file.

## Scenario

The product catalog is growing, and the team wants sample data to be easier to review and change without editing C# objects directly.

## Steps

1. Identify one static sample data set that would work well as a file
2. Create a small CSV file for that data
3. Refactor the app to read from the CSV at startup or through a simple service
4. Keep the existing API behavior the same
5. Update or add tests around the changed data-loading path

## Suggested Copilot Prompt

Help me refactor one static sample data set into a CSV-backed source. Keep the app beginner-friendly and preserve the existing API behavior.

## Acceptance Criteria

* Sample data exists in a CSV file
* The API still returns the expected data
* Tests cover the refactored data-loading behavior
* The change stays small and understandable
