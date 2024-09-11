# OLA2: API Testing, Coverage, and Benchmarking
 - Group: **TofuBytes**
 - Members: **Isak, Jamie & Helena**
## Objective
The goal of this assignment is to build a simple REST API, implement tests for its endpoints, ensure sufficient code coverage, and conduct basic performance benchmarking using tools like HTTP files, REST clients, and JMeter (or similar tools).

---

## Table of Contents
1. [Overview](#overview)
2. [Prerequisites](#prerequisites)
3. [Project Setup](#project-setup)
4. [REST API Development](#rest-api-development)
5. [Testing and Coverage](#testing-and-coverage)
    - [Unit Tests](#unit-tests)
    - [Integration Tests](#integration-tests)
    - [Code Coverage](#code-coverage)
6. [API Testing](#api-testing)
7. [Load Testing](#load-testing)
8. [Reflection](#reflection)
9. [Deliverables](#deliverables)

---

## Overview
This project involves building a simple CRUD (Create, Read, Update, Delete) REST API, writing unit and integration tests for the API, ensuring at least 80% code coverage, and performing basic performance tests with load testing tools.

---

## Prerequisites
Before beginning, ensure you have the following:
- Programming language of choice: **Java**, **C#**, or other preferred languages.
- Testing tools based on language:
    - For **Java**: JUnit, Jacoco
    - For **C#**: NUnit, Coverlet
- **Postman** or **HTTP files** for API testing.
- **JMeter**, **Artillery**, or **Gatling** for load testing.

Ensure you have all dependencies and tools installed before starting.

---

## Project Setup
1. Clone this repository.
2. Set up your development environment based on the language of choice.
3. Install the necessary dependencies for unit testing, integration testing, and code coverage.

---

## REST API Development
1. Build a simple REST API for a basic CRUD application (e.g., Task Manager).
    - API should support:
        - `POST /tasks` – Create a new task
        - `GET /tasks` – Retrieve all tasks
        - `GET /tasks/{id}` – Retrieve a specific task
        - `PUT /tasks/{id}` – Update a specific task
        - `DELETE /tasks/{id}` – Delete a task

2. Use appropriate routing and structure for the API endpoints.

---

## Testing and Coverage

### Unit Tests
- Write unit tests for the core logic of the API (e.g., task creation, validation, deletion).
- Ensure the tests are comprehensive and check for edge cases (e.g., invalid input).

### Integration Tests
- Write at least three integration tests that simulate real-world API interactions.
    - Example: Test creating, updating, and retrieving a task through the API.

### Code Coverage
- Ensure a minimum of **80% code coverage** using:
    - **Jacoco** for Java with Maven.
    - **Coverlet** for .NET with C# or Visual Studio functions.
- Generate and include a coverage report.

---

## API Testing
- Use HTTP files (or Postman) to test all API endpoints.
    - Ensure correct status codes (e.g., 200, 404, 500) are returned.
    - Validate data returned in the response.

Include the HTTP test scripts (or Postman collection) in the project.

---

## Load Testing
- Perform basic load testing on one API endpoint (e.g., `GET /tasks`).
- Simulate 50-100 concurrent users.
- Record performance metrics like response time, throughput, etc.
- Tools:
    - **JMeter** or equivalents like **Artillery** or **Gatling** for C#.

---

## Reflection
- Reflect on how you ensured code coverage.
- Discuss the importance of balancing unit and integration testing.
- Summarize your API’s performance based on the load testing results.
- Identify areas where performance optimization may be needed.

---

## Deliverables
Ensure the following are included in your final submission:
1. Source code for the REST API.
2. Unit and integration tests.
3. Code coverage report (minimum 80%).
4. HTTP test scripts (or Postman collection).
5. Load test results and analysis.
6. Reflection document on testing coverage and performance benchmarking.

---

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
