# Introduction
The `TransitiveDependenciesGraph` is a .Net 8/C# 12 is a class library to operate with transitive dependencies in a graph. It uses a repository, `GraphDataRepository`, to interact with the data layer and retrieve graph data (or in another words - to retrieve both direct and transitive dependencies).

It includes `TransitiveDependenciesGraphService`, that is part of a service layer and is used to orchestrate and provide information about the named graphs.
Here's a breakdown of the class and its methods:

**Constructor (TransitiveDependenciesService):** This takes an instance of GraphDataRepository as a parameter, which is used to interact with the graph data. This dependency abides by the Dependency Inversion Principle however whitout making use of an interface. This was intentional following Anthony Steele's opinion [here](https://www.anthonysteele.co.uk/InterfacesAreOverused.html). 

**Method (DependenciesGraphByName):** This method takes a string dependenciesInput and an optional character separator (default is a space). It splits the input string by the separator to get the token and its dependencies.  The retrieved graph is encapsulated in a `DependenciesGraphOutput` object with appropriate `ResultType`.

The `DependenciesGraphOutput` record is a data transfer object (DTO) that carries data between processes. In this case, it carries the result of the `DependenciesGraphByName` operation, including the resulting graph and any relevant messages. The ResultType is an enumeration that represents the result of the operation (e.g., success, invalid input, no graph found, no dependencies).

## Test Briefing
> If A depends on B and B depends on C, then A also depends on C. This is called a transitive
dependency.
Given an input (could either be a direct function call, file input or read from console) with lists of
dependencies, write a program that outputs the full set of distinct dependencies, alphabetically
ordered.
The first token of each input line is the name of the item. The remaining tokens are the names of
the things the first item depends on.
```
As an example, given the input:
A B C
B C E
C G
D A F
E F
F H

The program should output:
A B C E F G H
B C E F G H
C G
D A B C E F G H
E F H
F H
