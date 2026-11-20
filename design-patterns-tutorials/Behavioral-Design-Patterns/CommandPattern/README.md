# Command Design Pattern

## What is the Command pattern?

The Command design pattern is a behavioral pattern that turns a request into a standalone object. The object contains the information required to execute an operation, and it can be passed to other components, stored for later use, queued, logged, or undone.

The usual participants are:

- **Command:** Declares an execution operation, commonly `Execute()`.
- **Concrete Command:** Implements the command and identifies the receiver operation it invokes.
- **Invoker:** Requests that a command execute or maintains commands for undo/redo history.
- **Receiver:** Performs the actual work.
- **Client:** Creates commands and configures the invoker and receiver.

The pattern separates the object that issues a request from the object that performs the work. This reduces coupling and makes operations composable and reversible.

## Does this implementation use the pattern?

Yes. The `to-do-list` application uses explicit command objects for task and subtask operations.

| Command participant | Implementation |
|---|---|
| Command | [`IApplicationCommand`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Interfaces/IApplicationCommand.cs) |
| Concrete Commands | [`CreateTaskCommand`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Commands/CreateTaskCommand.cs), [`UpdateTaskCommand`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Commands/UpdateTaskCommand.cs), [`DeleteTaskCommand`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Commands/DeleteTaskCommand.cs), [`AddSubtaskCommand`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Commands/AddSubtaskCommand.cs), and [`ToggleSubtaskCommand`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Commands/ToggleSubtaskCommand.cs) |
| Invoker | [`CommandInvoker`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Services/CommandInvoker.cs) |
| Receiver | [`TaskService`](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/Services/TaskService.cs) |
| Client | [MainViewModel](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/ViewModels/MainViewModel.cs), [TaskFormViewModel](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/ViewModels/TaskFormViewModel.cs), and [TaskDetailViewModel](/Users/yashnagi/Projects/Design%20Patterns/design-patterns-tutorials/Behavioral-Design-Patterns/CommandPattern/to-do-list/ViewModels/TaskDetailViewModel.cs) |

## How the implementation works

1. A view-model action creates a concrete command.
2. The command contains the receiver and operation arguments.
3. The view model passes the command to `CommandInvoker.ExecuteAsync`.
4. The invoker executes the command and stores it in an undo stack.
5. `UndoAsync` invokes the command's inverse operation.
6. The redo stack allows the command to be executed again.

For example, `CreateTaskCommand` calls `TaskService.CreateTaskAsync` during execution and `TaskService.DeleteTaskAsync` during undo. `UpdateTaskCommand` stores task snapshots and restores the before or after state.

## Supported operations

| Operation | Execute | Undo |
|---|---|---|
| Create task | Adds a task | Deletes the task |
| Update task | Applies the updated task | Restores the original task |
| Delete task | Removes the task | Restores the deleted task |
| Add subtask | Adds the subtask | Removes the subtask |
| Toggle subtask | Changes completion state | Restores the previous state |

## Benefits

- The view models do not need to know the details of JSON persistence.
- Each operation is represented by a reusable object.
- Executed commands can be undone or redone.
- New operations can be added without changing the invoker.
- Undo and redo behavior remains separate from UI controls.

## Real-life example

A text editor represents actions such as typing, deleting, and formatting as commands. The editor invokes those commands and can retain them in a history stack. Undo reverses the most recent command, while redo executes it again.
