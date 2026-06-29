# Copilot Prompting Guide

Good prompts help GitHub Copilot stay useful and predictable.

## Context

Share the codebase, file, framework, and test context that matters.

## Intent

State what you want Copilot to help you do.

## Clarity

Use direct instructions and name the files or behaviors involved.

## Specificity

Say what should change, what should stay the same, and how to verify the result.

## ROSES framework

**Role**  
Who should Copilot act as?

**Objective**  
What should Copilot produce?

**Scope**  
What is in bounds and out of bounds?

**Environment**  
What technical context matters?

**Standards**  
What quality, style, security, testing, or documentation rules should be followed?

### Example

Role: Senior .NET 8 backend engineer.  
Objective: Add product search by category.  
Scope: Only modify the product endpoint, product service, and related tests.  
Environment: ASP.NET Core Web API using in-memory data and xUnit.  
Standards: Keep the code readable for early-career engineers, add tests, avoid unnecessary dependencies, and update documentation if behavior changes.
