# Exercise 09: Improve File Data Loading

## Goal

Make the CSV-backed data path easier to maintain and safer to change.

## Scenario

After moving sample data into a file, the team wants clearer handling for missing files, malformed rows, and basic data quality issues.

## Steps

1. Review the CSV-loading code from the previous exercise
2. Decide which validation or error cases are worth handling
3. Add a small improvement without overengineering the parser
4. Add or update tests for the chosen behavior
5. Update docs if the local setup steps changed

## Suggested Copilot Prompt

Review this CSV-loading code and suggest one or two beginner-friendly improvements for validation, error handling, or tests.

## Acceptance Criteria

* CSV-loading behavior is clearer or safer
* At least one relevant test is added or updated
* Error handling remains appropriate for a learning repo
* Existing API behavior still works
