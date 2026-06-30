# Exercise 11: Use the Postgres Data Store

## Goal

Refactor one data access path so the API can use Postgres locally.

## Scenario

Now that a local database exists, the team wants one narrow API path to read from it while preserving the learning-focused structure.

## Steps

1. Pick one data path to move behind the Postgres option
2. Keep the service boundary readable
3. Add configuration so local developers can choose the intended data source
4. Add or update tests where practical
5. Verify the API still runs locally

## Suggested Copilot Prompt

Help me refactor one data access path to use the local Postgres option. Keep the service design simple and preserve the current API contract.

## Acceptance Criteria

* One API path can use Postgres-backed data
* Configuration is understandable for workshop participants
* Existing tests pass or are updated for the new behavior
* The app remains runnable without production services
