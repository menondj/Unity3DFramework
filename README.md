# Unity3DFramework
Contains base classes for Event/Actions &amp; State Machines using design patterns 

This respository contains useful classes written in C# for Event Driven programming as well as state machine execution. Here we use a comination of publisher observer design patterns and delegates to efficiently create state machines and actions on the fly.
A complete project using these patterns can be found in  in https://github.com/menondj/RLearningUnity3D repository. 



1. StateMachine.cs : Base class for state machine. This is a Scriptable Object. Subsequent state machines are dervived from this class. 

2. EventPublisher.cs: A Singleton Base class (ScriptableObject) which forms the foundation for all publisher-observer patterns. If an event occurs in a gameObject, others can register, get notified and perform actions within their script. Any script which has access to this singleton can Notify, Register, UnRegister for events.

Usage:
Using the above classes in a script is illustrated in SampleStateMachine.cs & Sample.cs. The latter is attached to a gameObject and creates and instance of SampleStateMachine

