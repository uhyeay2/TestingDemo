
# TestingDemo

This project is meant to introduce you to Unit Tests and Integration Tests. Here we will cover both kinds of tests and discuss the differences between them.

Below is some information to help understand the differences between Unit and Integration Tests.

## What is a 'Dependency' ?

"A dependency is an object that another object depends on."

[Quote Source: TutorialsPoint.com](https://www.tutorialspoint.com/explain-dependency-injection-in-chash#:~:text=Explain%20dependency%20injection%20in%20C%23&text=A%20dependency%20is%20an%20object,it%20construct%20the%20objects%20themselves.)

Long story short, your class has a 'Dependency' on another class/interface if it must use that class to perform its actions.

## What is a 'Unit Test' ?

"Unit testing is a software development process in which the smallest testable parts of an application, called units, are individually scrutinized for proper operation."

[Quote Source: TechTarget.com](https://www.techtarget.com/searchsoftwarequality/definition/unit-testing)

"A unit test is a way of testing a unit - the smallest piece of code that can be logically isolated in a system. In most programming languages, that is a function, a subroutine, a method or property. The isolated part of the definition is important."

[Quote Source: SmartBear.com](https://smartbear.com/learn/automated-testing/what-is-unit-testing/)

Notice that the quote above mentions isolation. This means we are testing a unit while isolating it from any dependencies it may rely on. In other words, we are testing the class without using its dependencies.

## What is a 'Integration Test' ?

"Integration testing ensures that different components inside the application function correctly when working together."

[Quote Source: Code-Maze.com](https://code-maze.com/aspnet-core-integration-testing/)

"In contrast to unit tests that focus on individual code units in isolation, integration tests simulate real-world external dependencies to verify that components work together seamlessly, and to detect any defects that may arise during integration."

[Quote Source: Medium.com](https://medium.com/@samuilovas/c-integration-tests-with-code-examples-505c9baaa02f)

Essentially an Integration Test will test a class/function while using the concrete/real implementation that the unit under test relies on. If you are testing a method/class that makes a call to a Database or an External API, that would be another example of an Integration Test, because in those scenarios we are using the actual Database or API to conduct our testing.

## Conclusion

A unit test will test a class/function without relying on the dependencies that class/function relies on. Alternatively, an Integration Test will test a class/function while using the concrete/real implementation. Unit tests are honed into one unit, making sure that it individually behaves the way it should, while Integration tests ensure that the unit behaves as it should when integrated with its dependencies.
