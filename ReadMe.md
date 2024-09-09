
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

#### 5 Unit Tests

We've implemented 5 different unit tests focusing on the Add Task functionality that all answer the 5 Questions Every Unit Test Must Answer:

#### AddTask\_ValidDescription\_TaskIsCreated

1. **What are we testing?**
  - The creation of a `Task` with a valid description.
2. **What should it do?**
  - It should create a `Task` with the provided description.
3. **What is the expected outcome?**
  - The `Task` object should have the description "description".
4. **What is the actual outcome?**
  - The `Task` object has the description "description".
5. **How can the test be reproduced?**
  - By running the test with the input "description\r\ncategory\r\n\<dateTomorrow\>".

#### AddTask\_ValidCategory\_TaskIsCreated

1. **What are we testing?**
  - The creation of a `Task` with a valid category.
2. **What should it do?**
  - It should create a `Task` with the provided category.
3. **What is the expected outcome?**
  - The `Task` object should have the category "category".
4. **What is the actual outcome?**
  - The `Task` object has the category "category".
5. **How can the test be reproduced?**
  - By running the test with the input "description\r\ncategory\r\n\<dateTomorrow\>".

#### AddTask\_ValidDeadline\_TaskIsCreated

1. **What are we testing?**
  - The creation of a `Task` with a valid deadline.
2. **What should it do?**
  - It should create a `Task` with the provided deadline.
3. **What is the expected outcome?**
  - The `Task` object should have the deadline "\<dateTomorrow\>".
4. **What is the actual outcome?**
  - The `Task` object has the deadline "\<dateTomorrow\>".
5. **How can the test be reproduced?**
  - By running the test with the input "description\r\ncategory\r\n\<dateTomorrow\>".

#### AddTask\_InvalidDateInput\_ThrowsFormatException

1. **What are we testing?**
  - The creation of a `Task` with an invalid date input.
2. **What should it do?**
  - It should throw a `FormatException`.
3. **What is the expected outcome?**
  - A `FormatException` should be thrown.
4. **What is the actual outcome?**
  - A `FormatException` is thrown.
5. **How can the test be reproduced?**
  - By running the test with the input "description\r\ncategory\r\n\<invalidDate\>".

#### AddTask\_EmptyDescription\_ThrowsArgumentException

1. **What are we testing?**
  - The creation of a `Task` with an empty description.
2. **What should it do?**
  - It should throw an `ArgumentException`.
3. **What is the expected outcome?**
  - An `ArgumentException` should be thrown.
4. **What is the actual outcome?**
  - An `ArgumentException` is thrown.
5. **How can the test be reproduced?**
  - By running the test with the input "\r\ncategory\r\n\<dateTomorrow\>".

### 2 Integration Tests

#### 1. AddTask\_TaskIsAdded

**Purpose:** Confirm that a task can be correctly added to the database and stored for future retrieval.

**Description:** This test validates that when a new task is created in the application, it is correctly added to the database. It checks that all relevant details (e.g., task description, category, deadline, and completion status) are accurately stored in the appropriate database table. After the task is added, the test retrieves the task from the database to ensure that the data is stored correctly and matches what was initially provided.

**Success Criteria:**
- The task is successfully added to the database.
- The task details (description, category, deadline, and completion status) are correctly stored.
- The task can be retrieved from the database with the same details as provided during creation.

#### 2. UpdateTask\_TaskIsUpdated

**Purpose:** Ensure that an existing task can be updated correctly in the database.

**Description:** This test verifies that when an existing task is updated in the application, the changes are correctly reflected in the database. It checks that all relevant details (e.g., task description, category, deadline, and completion status) are accurately updated in the appropriate database table. After the task is updated, the test retrieves the task from the database to ensure that the data is updated correctly and matches the new details provided.

**Success Criteria:**
- The task is successfully updated in the database.
- The updated task details (description, category, deadline, and completion status) are correctly stored.
- The updated task can be retrieved from the database with the new details as provided during the update.

**1 specification-based test:**

User CRUD operations:
- Simulate a user adding a task, updating its details, marking it as completed, and then
  deleting it. Verify that each action is performed successfully, and the task list
  reflects these changes accordingly.


### Test results


### Test doubles
When it comes to Test Doubles we used the following:
We set up a ***InMemoryDatabase*** using ***SQLite*** for our tests, so we can test our database operations without having to connect to a real database. This is a form of a Test Double called a Fake Object as it is a simplified version of the real database.

### Mutation testing


### Verification and validation

### Software quality reflection 