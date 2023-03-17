# Key OOP COncept

- Objects: Instance of a classes
- Class: Blue print for the data type (variables) and available methods for a given type or class of object
- Composition: how an object is made (eg: 2 eyes, one tail...)

1) Inheritance: Reuse the code by having a sublclass derive from a base or super class.
2) Polymorhism: allow a derived class to override and inherited action to provide custom behavior. (different aninals sound)
3) Abstraction: is about capturing the core idea of an object and ignoring the details or specifics. Eg: Create an abstract class animals, but create a derived class Cat by giving actual behaviors of a Cat.
4) Encapsulation: the combination of the data and actions that are related to an object. Achieve by using access modifiers, which is a way to ensure security.

## Interface

- Definition: An interface defines a contract. Any class or struct that implements that contract must provide an implementation of the members defined in the interface.

## Inheritance

To inherit from a super class we use the semicolon operator:
> public class WildCats : Cat

