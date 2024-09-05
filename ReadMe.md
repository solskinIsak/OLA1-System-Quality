
Made by Isak Møgelvang, Jamie Callan and Helena Lykstoft

### Test strategy

The aim is to develop a reliable and maintainable to-do list application by
implementing a comprehensive test strategy. This strategy includes unit testing,
integration testing, and specification-based testing to ensure that individual
components work correctly, interact seamlessly, and fulfill user requirements.

**Unit Tests strategy:**

Purpose: Unit tests validate the smallest components of the application, such as
individual functions, methods, and classes. These tests ensure that each unit
functions correctly in isolation.

Approach:

- Key Areas: We'll focus on testing the Task Management, Category, and Deadline
  modules, covering CRUD operations, task categorization, and deadline handling.
- Coverage: The goal is to achieve high coverage, addressing typical scenarios,
  edge cases, and error handling.
- Tools: XUnit will be used to implement these tests, which will be integrated
  into the development for automated execution.
- Contribution to Quality: Ensures that each component works as intended,
  making it easier to pinpoint defects early in the development cycle.

**Integration tests strategy:**

Purpose: Integration tests validate the interactions between different components
of the application, ensuring that modules such as Task Management and
Category Management work together as intended.

Approach:

- Key Interactions: We will test the interactions between tasks and categories, as
  well as the integration of deadlines within the task structure.
- Tools: XUnit will be employed for these tests, with a focus on ensuring that
  component interactions are tested in an environment that closely resembles production.
- Contribution to Quality: Ensures that components work together as expected,
  catching connection defects.

**Specification-based tests strategy:**

Purpose: Specification-based tests verify that the application meets its functional
requirements and behaves as expected from the user's perspective.

Approach:

- End-to-End Scenarios: We'll simulate user workflows, such as adding a task,
  categorizing it, setting a deadline, and marking it as complete. This ensures the
  application functions as expected across all use cases.
- Tools: These tests will also be implemented using XUnit, focusing on high-level
  use cases to ensure the application aligns with user specifications.
- Contribution to Quality: Ensures that the application meets its functional
  specifications and user expectations.


#### Conclusion
This test strategy, implemented using XUnit, ensures that our to-do list application
is thoroughly tested at every level. By combining unit, integration, and
specification-based testing with the strategic use of test doubles and validation
through mutation testing, we aim to deliver a high-quality, reliable application that meets all user requirements.

### Implementation of test strategy

**5 unit tests:**

1. Add task
- What are we testing?
  We are testing the functionality of adding a task to the to-do list.
- What should it do?
  It should add a task to the to-do list.
- What is the expected outcome?
  The task should be added to the to-do list.
- What is the actual outcome?

- How can the test be reproduced?

2. Update task
- What are we testing?
  We are testing the functionality of updating a task in the to-do list.
- What should it do?
  It should update a task in the to-do list.
- What is the expected outcome?
  The task should be updated in the to-do list.
- What is the actual outcome?
- How can the test be reproduced?

3. Delete task
- What are we testing?
  We are testing the functionality of deleting a task from the to-do list.
- What should it do?
  It should delete a task from the to-do list.
- What is the expected outcome?
  The task should be deleted from the to-do list.
- What is the actual outcome?
- How can the test be reproduced?

4. Mark tasks as completed
- What are we testing?
  We are testing the functionality of marking tasks as completed in the to-do list.
- What should it do?
  It should mark tasks as completed in the to-do list.
- What is the expected outcome?
  The tasks should be marked as completed in the to-do list.
- What is the actual outcome?
- How can the test be reproduced?

5. Set deadlines for tasks
- What are we testing?
  We are testing the functionality of setting deadlines for tasks in the to-do list.
- What should it do?
  It should set deadlines for tasks in the to-do list.
- What is the expected outcome?
  The deadline should be set for the task in the to-do list.
- What is the actual outcome?
- How can the test be reproduced?

**2 integration tests:**

1. Check Database Connection

- Purpose: Ensure that the application can successfully establish a connection to the database.
- Description: This test verifies that when the application attempts to connect to the
  database, the connection is successfully established. It ensures that the connection
  string is correctly configured, the database server is reachable, and the database
  itself is accessible. The test might simulate a connection request and verify that
  the response from the database server confirms a successful connection.

2. Add Task to Database

- Purpose: Confirm that a task can be correctly added to the database and stored for future
  retrieval.
- Description: This test validates that when a new task is created in the application,
  it is correctly added to the database. It checks that all relevant details (e.g.,
  task title, description, deadline, status) are accurately stored in the appropriate
  database table. After the task is added, the test retrieves the task from the database
  to ensure that the data is stored correctly and matches what was initially provided.

**1 specification-based test:**

User CRUD operations:
- Simulate a user adding a task, updating its details, marking it as completed, and then
  deleting it. Verify that each action is performed successfully, and the task list
  reflects these changes accordingly.


### Test results


### Test doubles


### Mutation testing


### Verification and validation

### Software quality reflection 