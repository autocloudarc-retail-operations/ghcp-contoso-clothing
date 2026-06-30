# Exercise 10: Add a Postgres Container

## Goal

Introduce a local Postgres option for hosting catalog-style data.

## Scenario

The workshop team wants to explore a more realistic data store while keeping the local developer experience lightweight.

## Steps

1. Choose a simple way to run Postgres locally for this repo
2. Add only the configuration needed for a local learning environment
3. Create a minimal schema or seed approach for the selected data
4. Document how to start and stop the local database
5. Avoid requiring cloud resources or production credentials

## Suggested Copilot Prompt

Help me add a lightweight local Postgres container option for this .NET learning API. Keep the setup minimal and document the developer steps.

## Acceptance Criteria

* A local Postgres option is documented or configured
* Sample data can be represented in the database
* No secrets or real connection strings are committed
* The original in-memory or file-based path is not accidentally broken
