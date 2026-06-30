# Exercise 19: Create a README Update Workflow

## Goal

Create a GitHub Actions workflow that can help keep the README current.

## Scenario

The team wants to experiment with automation that invokes an agent or GitHub Copilot CLI workflow to propose README updates after meaningful repository changes.

## Steps

1. Decide what event should trigger a README review or update proposal
2. Choose whether the workflow should call an agent, GitHub Copilot CLI, or another approved automation path
3. Keep permissions and safety boundaries explicit
4. Make the workflow propose changes rather than silently rewriting documentation
5. Document how maintainers should review the result

## Suggested Copilot Prompt

Help me design a GitHub Actions workflow that can ask an agent or GitHub Copilot CLI to propose README updates. Keep permissions limited and require human review.

## Acceptance Criteria

* A workflow draft or implementation exists
* The workflow has clear trigger and review behavior
* Permissions are limited to what the workflow needs
* README updates remain reviewable by a human
