
<img src="UnityProject/Assets/Zenject/Documentation/ReadMe_files/ZenjectLogo.png?raw=true" alt="Zenject" width="600px" height="134px"/>

## Dependency Injection Framework for Unity3D

#### ----- NEW ----- If you like Zenject, you may also be interested in [Projeny](https://github.com/modesttree/projeny) (our other open source project)

## <a id="introduction"></a>Introduction

Zenject is a lightweight dependency injection framework built specifically to target Unity 3D.  It can be used to turn your Unity 3D application into a collection of loosely-coupled parts with highly segmented responsibilities.  Zenject can then glue the parts together in many different configurations to allow you to easily write, re-use, refactor and test your code in a scalable and extremely flexible way.

Tested in Unity 3D on the following platforms: 
* PC/Mac/Linux
* iOS
* Android
* Webplayer
* WebGL
* Windows Store (including 8.1, Phone 8.1, Universal 8.1 and Universal 10 - both .NET and IL2CPP backend)

IL2CPP is supported, however there are some gotchas - see <a href="#aot-support">here</a> for details

This project is open source.  You can find the official repository [here](https://github.com/modesttree/Zenject).

For general troubleshooting / support, please use the [zenject subreddit](http://www.reddit.com/r/zenject) or the [zenject google group](https://groups.google.com/forum/#!forum/zenject/).  If you have found a bug, you are also welcome to create an issue on the [github page](https://github.com/modesttree/Zenject), or a pull request if you have a fix / extension.  You can also follow [@Zenject](https://twitter.com/Zenject) on twitter for updates.  Finally, you can also email me directly at sfvermeulen@gmail.com

## <a id="features"></a>Features

* Injection
    * Supports both normal C# classes and MonoBehaviours
    * Constructor injection (can tag constructor if there are multiple)
    * Field injection
    * Property injection
    * Method injection
* Conditional binding (eg. by type, by name, etc.)
* Optional dependencies
* Support for building dynamic object graphs at runtime using factories
* Injection across different Unity scenes
* Convention based binding, based on class name, namespace, or any other criteria
* Support for global, project-wide bindings to add dependencies for all scenes
* Ability to validate object graphs at editor time including dynamic object graphs created via factories
* "Scene Decorators" which allow adding functionality to a different scene without changing it directly
* Nested Containers aka Sub-Containers
* Commands and Signals
* Automatic binding on components using the `ZenjectBinding` component
* Auto-Mocking using the Moq library

## <a id="installation"></a>Installation

You can install Zenject using any of the following methods

1. From [Releases Page](https://github.com/modesttree/Zenject/releases). Here you can choose between the following:

    * **Zenject-WithAsteroidsDemo.vX.X.unitypackage** - This is equivalent to what you find in the Asset Store and contains both sample games "Asteroids" and "SpaceFighter" as part of the package.  All the source code for Zenject is included here.
    * **Zenject.vX.X.unitypackage** - Same as above except without the Sample projects.
    * **Zenject-NonUnity.vX.X.zip** - Use this if you want to use Zenject outside of Unity (eg. just as a normal C# project)

1. From the [Asset Store Page](http://u3d.as/content/modest-tree-media/zenject-dependency-injection/7ER)

    * Normally this should be the same as what you find in the [Releases section](https://github.com/modesttree/Zenject/releases), but may also be slightly out of date since Asset Store can take a week or so to review submissions sometimes.

1. From Source

    * You can also just clone this repo and copy the `UnityProject/Assets/Zenject` directory to your own Unity3D project.  In this case, make note of the folders underneath "OptionalExtras" and choose only the ones you want.

## <a id="history"></a>History

Unity is a fantastic game engine, however the approach that new developers are encouraged to take does not lend itself well to writing large, flexible, or scalable code bases.  In particular, the default way that Unity manages dependencies between different game components can often be awkward and error prone.

This project was started after reading a <a href="http://blog.sebaslab.com/ioc-container-for-unity3d-part-1/">series of great articles</a> by Sebastiano Mandalà outlining the problem.  Sebastiano even wrote a proof of concept and open sourced it, which became the basis for this library.  Zenject also takes a lot of inspiration from Ninject (as implied by the name).

Finally, I will just say that if you don't have experience with DI frameworks, and are writing object oriented code, then trust me, you will thank me later!  Once you learn how to write properly loosely coupled code using DI, there is simply no going back.

## Documentation

The Zenject documentation is split up into the following sections.  It is split up into two parts (Introduction and Advanced) so that you can get up and running as quickly as possible.  I would recommend at least reading the Introduction section, but then feel free to jump around in the advanced section as necessary

You might also benefit from playing with the provided sample projects (which you can find by opening `Zenject/OptionalExtras/SampleGame1` or `Zenject/OptionalExtras/SampleGame2`).

You may also find the <a href="#cheatsheet">cheatsheet</a> at the bottom of this page helpful in understanding some typical usage scenarios.

The tests may also be helpful to show usage for each specific feature (which you can find at `Zenject/OptionalExtras/UnitTests` and `Zenject/OptionalExtras/IntegrationTests`)

## Table Of Contents

* Introduction
    * What is Dependency Injection?
        * <a href="#theory">Theory</a>
        * <a href="#misconceptions">Misconceptions</a>
    * Zenject API
        * <a href="#hello-world-example">Hello World Example</a>
        * <a href="#injection">Injection</a>
        * Binding
            * <a href="#binding">Binding</a>
            * <a href="#construction-methods">Construction Methods</a>
        * Using Non-MonoBehaviour Classes
            * <a href="#itickable">ITickable</a>
            * <a href="#iinitializable-and-postinject">IInitializable</a>
            * <a href="#implementing-idisposable">IDisposable</a>
        * <a href="#using-the-unity-inspector-to-configure-settings">Using the Unity Inspector To Configure Settings</a>
        * <a href="#object-graph-validation">Object Graph Validation</a>
        * <a href="#scene-bindings">Scene Bindings</a>
        * <a href="#di-guidelines--recommendations">General Guidelines / Recommendations / Gotchas / Tips and Tricks</a>
* Advanced
    * Binding
        * <a href="#optional-binding">Optional Binding</a>
        * <a href="#conditional-bindings">Conditional Bindings</a>
        * <a href="#list-bindings">List Bindings</a>
        * <a href="#global-bindings">Global Bindings</a>
        * <a href="#identifiers">Identifiers</a>
        * <a href="#non-generic-bindings">Non Generic bindings</a>
        * <a href="#convention-based-bindings">Convention Based Binding</a>
        * <a href="#unbind-rebind">Unbind / Rebind</a>
        * <a href="#singleton-identifiers">Singleton Identifiers</a>
    * <a href="#scriptableobject-installer">Scriptable Object Installer</a>
    * <a href="#commands-and-signals">Commands And Signals</a>
    * <a href="#creating-objects-dynamically">Creating Objects Dynamically Using Factories</a>
    * <a href="#update--initialization-order">Update / Initialization Order</a>
    * <a href="#zenject-order-of-operations">Zenject Order Of Operations</a>
    * <a href="#injecting-data-across-scenes">Injecting data across scenes</a>
    * <a href="#scenes-decorator">Scene Decorators</a>
    * <a href="#sub-containers-and-facades">Sub-Containers And Facades</a>
    * <a href="#auto-mocking-using-moq">Auto-Mocking using Moq</a>
* <a href="#questions">Frequently Asked Questions</a>
    * <a href="#isthisoverkill">Isn't this overkill?  I mean, is using statically accessible singletons really that bad?</a>
    * <a href="#aot-support">Does this work on AOT platforms such as iOS and WebGL?</a>
    * <a href="#faq-performance">How is Performance?</a>
    * <a href="#net-framework">Can I use .NET framework 4.0 and above?</a>
    * <a href="#howtousecoroutines">How do I use Unity style Coroutines in normal C# classes?</a>
    * <a href="#memorypools">How do I use Zenject with pools to minimize memory allocations?</a>
* <a href="#cheatsheet">Cheat Sheet</a>
* <a href="#further-help">Further Help</a>
* <a href="#release-notes">Release Notes</a>
* <a href="#license">License</a>

## <a id="theory"></a>Theory

What follows is a general overview of Dependency Injection from my perspective.  However, it is kept light, so I highly recommend seeking other resources for more information on the subject, as there are many other people (often with better writing ability) that have written about the theory behind it.

Also see <a href="https://www.youtube.com/watch?v=8ZCkEXv3QsQ">here</a> for a video that serves as a nice introduction to the theory.

When writing an individual class to achieve some functionality, it will likely need to interact with other classes in the system to achieve its goals.  One way to do this is to have the class itself create its dependencies, by calling concrete constructors:

```csharp
public class Foo
{
    ISomeService _service;

    public Foo()
    {
        _service = new SomeService();
    }

    public void DoSomething()
    {
        _service.PerformTask();
        ...
    }
}
```

This works fine for small projects, but as your project grows it starts to get unwieldy.  The class Foo is tightly coupled to class 'SomeService'.  If we decide later that we want to use a different concrete implementation then we have to go back into the Foo class to change it.

After thinking about this, often you come to the realization that ultimately, Foo shouldn't bother itself with the details of choosing the specific implementation of the service.  All Foo should care about is fulfilling its own specific responsibilities.  As long as the service fulfills the abstract interface required by Foo, Foo is happy.  Our class then becomes:

```csharp
public class Foo
{
    ISomeService _service;

    public Foo(ISomeService service)
    {
        _service = service;
    }

    public void DoSomething()
    {
        _service.PerformTask();
        ...
    }
}
```

This is better, but now whatever class is creating Foo (let's call it Bar) has the problem of filling in Foo's extra dependencies:

```csharp
public class Bar
{
    public void DoSomething()
    {
        var foo = new Foo(new SomeService());
        foo.DoSomething();
        ...
    }
}
```

And class Bar probably also doesn't really care about what specific implementation of SomeService Foo uses.  Therefore we push the dependency up again:

```csharp
public class Bar
{
    ISomeService _service;

    public Bar(ISomeService service)
    {
        _service = service;
    }

    public void DoSomething()
    {
        var foo = new Foo(_service);
        foo.DoSomething();
        ...
    }
}
```

So we find that it is useful to push the responsibility of deciding which specific implementations of which classes to use further and further up in the 'object graph' of the application.  Taking this to an extreme, we arrive at the entry point of the application, at which point all dependencies must be satisfied before things start.  The dependency injection lingo for this part of the application is called the 'composition root'.  It would normally look like this:

```csharp
var service = new SomeService();
var foo = new Foo(service);
var bar = new Bar(foo);

.. etc.
```

DI frameworks such as Zenject simply help automate this process of creating and handing out all these concrete dependencies, so that you don't need to explicitly do it like in the above code.

## <a id="misconceptions"></a>Misconceptions

There are many misconceptions about DI, due to the fact that it can be tricky to fully wrap your head around at first.  It will take time and experience before it fully 'clicks'.

As shown in the above example, DI can be used to easily swap different implementations of a given interface (in the example this was ISomeService).  However, this is only one of many benefits that DI offers.

More important than that is the fact that using a dependency injection framework like Zenject allows you to more easily follow the '[Single Responsibility Principle](http://en.wikipedia.org/wiki/Single_responsibility_principle)'.  By letting Zenject worry about wiring up the classes, the classes themselves can just focus on fulfilling their specific responsibilities.

<a id="overusinginterfaces"></a>Another common mistake that people new to DI make is that they extract interfaces from every class, and use those interfaces everywhere instead of using the class directly.  The goal is to make code more loosely coupled, so it's reasonable to think that being bound to an interface is better than being bound to a concrete class.  However, in most cases the various responsibilities of an application have single, specific classes implementing them, so using interfaces in these cases just adds unnecessary maintenance overhead.  Also, concrete classes already have an interface defined by their public members.  A good rule of thumb instead is to only create interfaces when the class has more than one implementation.  This is known, by the way, as the [Reused Abstraction Principle](http://codemanship.co.uk/parlezuml/blog/?postid=934))

Other benefits include:

* Testability - Writing automated unit tests or user-driven tests becomes very easy, because it is just a matter of writing a different 'composition root' which wires up the dependencies in a different way.  Want to only test one subsystem?  Simply create a new composition root.  Zenject also has some support for avoiding code duplication in the composition root itself (using Installers - described below).
* Refactorability - When code is loosely coupled, as is the case when using DI properly, the entire code base is much more resilient to changes.  You can completely change parts of the code base without having those changes wreak havoc on other parts.
* Encourages modular code - When using a DI framework you will naturally follow better design practices, because it forces you to think about the interfaces between classes.

Also see <a href="#isthisoverkill">here</a> for further justification for using a DI framework.

## <a id="hello-world-example"></a>Hello World Example

```csharp
using Zenject;
using UnityEngine;
using System.Collections;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance("Hello World!");
        Container.Bind<TestRunner>().NonLazy();
    }
}

public class TestRunner
{
    public TestRunner(string message)
    {
        Debug.Log(message);
    }
}
```

You can run this example by doing the following:

* Create a new scene in Unity
* Right Click inside the Hierarchy tab and select `Zenject -> Scene Context`
* Right Click in a folder within the Scene Heirarchy and Choose `Create -> Zenject -> MonoInstaller`.  Name it TestInstaller.cs.  (Note that you can also just directly create this file too without using this template).
* Add your TestInstaller script to the scene (as its own GameObject or on the same GameObject as the SceneContext, it doesn't matter)
* Add a reference to your TestInstaller to the properties of the SceneContext by adding a new row in the inspector of the "Installers" property (Increase "Size" to 1) and then dragging the TestInstaller GameObject to it
* Open up TestInstaller and paste the above code into it
* Validate your scene by either selecting Edit -> Zenject -> Validate Current Scene or hitting CTRL+SHIFT+V.  (note that this step isn't necessary but good practice to get into)
* Run
* Observe unity console for output

The SceneContext MonoBehaviour is the entry point of the application, where Zenject sets up all the various dependencies before kicking off your scene.  To add content to your Zenject scene, you need to write what is referred to in Zenject as an 'Installer', which declares all the dependencies used in your scene and their relationships with each other.  All dependencies that are marked as "NonLazy" are automatically created at this point, as well as any dependencies that implement the standard Zenject interfaces such as `IInitializable`, `ITickable`, etc.  If the above doesn't make sense to you yet, keep reading!

## <a id="injection"></a>Injection

There are many different ways of binding types on the container, which are documented in the <a href="#binding">next section</a>.  There are also several ways of having these dependencies injected into your classes. These are:

1 - **Constructor Injection**

```csharp
public class Foo
{
    IBar _bar;

    public Foo(IBar bar)
    {
        _bar = bar;
    }
}
```

2 - **Field Injection**

```csharp
public class Foo
{
    [Inject]
    IBar _bar;
}
```

Field injection occurs immediately after the constructor is called.  All fields that are marked with the [Inject] attribute are looked up in the container and given a value.  Note that these fields can be private or public and injection will still occur.

3 - **Property Injection**

```csharp
public class Foo
{
    [Inject]
    public IBar Bar
    {
        get;
        private set;
    }
}
```

Property injection works the same as field injection except is applied to C# properties.  Just like fields, the setter can be private or public in this case.

4 - **Method Injection**

```csharp
public class Foo
{
    IBar _bar;
    Qux _qux;

    [Inject]
    public Init(IBar bar, Qux qux)
    {
        _bar = bar;
        _qux = qux;
    }
}
```

Method Inject injection works very similarly to constructor injection.

Note that these methods are called after all other injection types.  It is designed this way so that these methods can be used to execute initialization logic which might make use of one of these dependencies.  Note also that you can leave the parameter list empty if you just want to do some initialization logic only.

Note that there can be any number of inject methods.  In this case, they are called in the order of Base class to Derived class.  This can be useful to avoid the need to forward many dependencies from derived classes to the base class via constructor parameters, while also guaranteeing that the base class inject methods complete first, just like how constructors work.

Note that the dependencies that you receive via inject methods should themselves have already been injected.  This can be important if you use inject methods to perform some basic initialization, since you may need the given dependencies to themselves be initialized via their Inject methods.

Using [Inject] methods to inject dependencies is the recommended approach for MonoBehaviours, since MonoBehaviours cannot have constructors.

**Recommendations**

* Best practice is to prefer constructor injection or method injection to field or property injection.
    * Constructor injection forces the dependency to only be resolved once, at class creation, which is usually what you want.  In most cases you don't want to expose a public property for your initial dependencies because this suggests that it's open to changing.
    * Constructor injection guarantees no circular dependencies between classes, which is generally a bad thing to do.  You can do this however using method injection or field injection if necessary.
    * Constructor/Method injection is more portable for cases where you decide to re-use the code without a DI framework such as Zenject.  You can do the same with public properties but it's more error prone (it's easier to forget to initialize one field and leave the object in an invalid state)
    * Finally, Constructor/Method injection makes it clear what all the dependencies of a class are when another programmer is reading the code.  They can simply look at the parameter list of the method.

## <a id="binding"></a>Binding

Every dependency injection framework is ultimately just a framework to bind types to instances.

In Zenject, dependency mapping is done by adding bindings to something called a container.  The container should then 'know' how to create all the object instances in your application, by recursively resolving all dependencies for a given object.

When the container is asked to construct an instance of a given type, it uses C# reflection to find the list of constructor arguments, and all fields/properties that are marked with an [Inject] attribute.  It then attempts to resolve each of these required dependencies, which it uses to call the constructor and create the new instance.

Each Zenject application therefore must tell the container how to resolve each of these dependencies, which is done via Bind commands.  For example, given the following class:

```csharp
public class Foo
{
    IBar _bar;

    public Foo(IBar bar)
    {
        _bar = bar;
    }
}
```

You can wire up the dependencies for this class with the following:

```csharp
Container.Bind<Foo>().AsSingle();
Container.Bind<IBar>().To<Bar>().AsSingle();
```

This tells Zenject that every class that requires a dependency of type Foo should use the same instance, which it will automatically create when needed.  And similarly, any class that requires the IBar interface (like Foo) will be given the same instance of type Bar.

The full format for the bind command is the following.  Note that in most cases you will not use all of these methods and that they all have logical defaults when unspecified

<pre>
Container.Bind&lt;<b>ContractType</b>&gt;()
    .To&lt;<b>ResultType</b>&gt;()
    .From<b>ConstructionMethod</b>()
    .WithGameObjectName(<b>GameObjectName</b>)
    .UnderGameObjectGroup(<b>GameObjectGroup</b>)
    .As<b>Scope</b>()
    .WithArguments(<b>Arguments</b>)
    .When(<b>Condition</b>)
    .InheritInSubContainers()
    .NonLazy();
</pre>

Where:

* **ContractType** = The type that you are creating a binding for.

    * This value will correspond to the type of the field/parameter that is being injected.

* **ResultType** = The type to bind to.

    * Default: **ContractType**
    * This type must either to equal to **ContractType** or derive from **ContractType**.  If unspecified, it assumes ToSelf(), which means that the **ResultType** will be the same as the **ContractType**.  This value will be used by whatever is given as the **ConstructionMethod** to retrieve an instance of this type

* **ConstructionMethod** = The method by which an instance of **ResultType** is created/retrieved.  See <a href="#construction-methods">this section</a> for more details on the various construction methods.

    * Default: FromNew()
    * Examples: eg. FromGetter, FromMethod, FromPrefab, FromResolve, FromSubContainerResolve, FromInstance, etc.

* **WithGameObjectName** = The name to give the new Game Object associated with this binding.

    * Note that this method is only available for bindings that use construction methods that relate to MonoBehaviour's such as FromPrefab

* **UnderGameObjectGroup** = The name of the game object group to place the new game object under.  This is especially useful for factories, which can be used to create many copies of a prefab for example.

    * Note that this method is only available for bindings that use construction methods that relate to MonoBehaviour's such as FromPrefab

* **Scope** = This value determines how often (or if at all) the generated instance is re-used across multiple injections.

    * Default: AsTransient
    * It can be one of the following:
        1. AsTransient - Will not re-use the instance at all.  Every time **ContractType** is requested, the DiContainer will return a brand new instance of type **ResultType**
        2. AsCached - Will re-use the same instance of **ResultType** every time **ContractType** is requested, which it will lazily generate upon first use
        3. AsSingle - Will re-use the same instance of **ResultType** across the entire DiContainer, which it will lazily generate upon first use.  It can be thought of as a stronger version of AsCached, because it allows you to bind to the same instance across multiple bind commands.  It will also ensure that there is only ever exactly one instance of **ResultType** in the DiContainer (ie. it will enforce **ResultType** to be a 'Singleton' hence the name).

    * In most cases, you will likely want to just use AsSingle, however AsTransient and AsCached have their uses too.
    * To illustrate the difference between the different scope types, see the following example:
        ```csharp
        public interface IBar
        {
        }

        public class Bar : IBar
        {
        }

        public class Foo()
        {
            public Foo(Bar bar)
            {
            }
        }
        ```

        ```csharp
        // This will cause every instance of Foo to be given a brand new instance of Bar
        Container.Bind<Bar>().AsTransient();
        ```

        ```csharp
        // This will cause every instance of Foo to be given the same instance of Bar
        Container.Bind<Bar>().AsCached();
        ```

        ```csharp
        public class Qux()
        {
            public Qux(IBar bar)
            {
            }
        }
        ```

        ```csharp
        // This will cause both Foo and Qux to get different instances of type Bar
        // However, every instance of Foo will be given the the same instance of type Bar
        // and similarly for Qux
        Container.Bind<Bar>().AsCached();
        Container.Bind<IBar>().To<Bar>().AsCached();
        ```

        ```csharp
        // This will cause both Foo and Qux to get the same instance of type Bar
        Container.Bind<Bar>().AsSingle();
        Container.Bind<IBar>().To<Bar>().AsSingle();
        ```

* **Arguments** = A list of objects to use when constructing the new instance of type **ResultType**.  This can be useful as an alternative to `Container.BindInstance(arg).WhenInjectedInto<ResultType>()`
* **Condition** = The condition that must be true for this binding to be chosen.  See <a href="#conditional-bindings">here</a> for more details.
* **InheritInSubContainers** = If supplied, then this binding will automatically be inherited from any subcontainers that are created from it.  In other words, the result will be equivalent to copying and pasting the `Container.Bind` statement into the installer for every sub-container.
* **NonLazy** = Normally, the **ResultType** is only ever instantiated when the binding is first used (aka "lazily").  However, when NonLazy is used, **ResultType** will immediately by created on startup.

## <a id="construction-methods"></a>Construction Methods

1. **FromNew** - Create via the C# new operator. This is the default if no construction method is specified.

    ```csharp
    // These are both the same
    Container.Bind<Foo>();
    Container.Bind<Foo>().FromNew();
    ```

1. **FromInstance** - Use a given instance

    ```csharp
    Container.Bind<Foo>().FromInstance(new Foo());

    // You can also use this short hand which just takes ContractType from the parameter type
    Container.BindInstance(new Foo());

    // This is also what you would typically use for primitive types
    Container.BindInstance(5.13f);
    Container.BindInstance("foo");
    ```

1. **FromMethod** - Create via a custom method

    ```csharp
    Container.Bind<Foo>().FromMethod(SomeMethod);

    Foo SomeMethod(InjectContext context)
    {
        ...
        return new Foo();
    }
    ```

1. **FromComponent** - Create as a new component on an existing game object.  **ResultType** must derive from UnityEngine.MonoBehaviour / UnityEngine.Component in this case

    ```csharp
    Container.Bind<Foo>().FromComponent(someGameObject);
    ```

1. **FromGameObject** - Create as a new component on a new game object.  **ResultType** must derive from UnityEngine.MonoBehaviour / UnityEngine.Component in this case

    ```csharp
    Container.Bind<Foo>().FromGameObject();
    ```

1. **FromPrefab** - Create by instantiating the given prefab and then searching it for type **ResultType**.  **ResultType** must derive from UnityEngine.MonoBehaviour / UnityEngine.Component in this case

    ```csharp
    Container.Bind<Foo>().FromPrefab(somePrefab);
    ```

1. **FromPrefabResource** - Create by instantiating the prefab at the given resource path and then searching it for type **ResultType**.   **ResultType** must derive from UnityEngine.MonoBehaviour / UnityEngine.Component in this case

    ```csharp
    Container.Bind<Foo>().FromPrefabResource("Some/Path/Foo");
    ```

1. **FromResource** - Create by calling the Unity3d function `Resources.Load` for **ResultType**.  This can be used to load any type that `Resources.Load` can load, such as textures, sounds, prefabs, custom classes deriving from ScriptableObject, etc.

    ```csharp
    public class Foo : ScriptableObject
    {
    }

    Container.Bind<Foo>().FromResource("Some/Path/Foo");
    ```

1. **FromResolve** - Get instance by doing another lookup on the container (in other words, calling `DiContainer.Resolve<ResultType>()`).  Note that for this to work, **ResultType** must be bound in a separate bind statement.  This construction method can be especially useful when you want to bind an interface to another interface, as shown in the below example

    ```csharp
    public interface IFoo
    {
    }

    public interface IBar : IFoo
    {
    }

    public class Foo : IBar
    {
    }

    Container.Bind<IFoo>().To<IBar>().FromResolve();
    Container.Bind<IBar>().To<Foo>();
    ```

1. **FromFactory** - Create instance using a custom factory class.  This construction method is similar to `FromMethod` except can be cleaner in cases where the logic is more complicated or requires dependencies (the factory itself can have dependencies injected)

    ```csharp
    class FooFactory : IFactory<Foo>
    {
        public Foo Create()
        {
            // ...
            return new Foo();
        }
    }

    Container.Bind<Foo>().FromFactory<FooFactory>()
    ```

1. **FromResolveGetter<ObjectType>** - Get instance from the property of another dependency which is obtained by doing another lookup on the container (in other words, calling `DiContainer.Resolve<ObjectType>()` and then accessing a value on the returned instance of type **ResultType**).  Note that for this to work, **ObjectType** must be bound in a separate bind statement.

    ```csharp
    public class Bar
    {
    }

    public class Foo
    {
        public Bar GetBar()
        {
            return new Bar();
        }
    }

    Container.Bind<Foo>();
    Container.Bind<Bar>().FromResolveGetter<Foo>(x => x.GetBar());
    ```

1. **FromSubContainerResolve** - Get **ResultType** by doing a lookup on a subcontainer.  Note that for this to work, the sub-container must have a binding for **ResultType**.  This approach can be very powerful, because it allows you to group related dependencies together inside a mini-container, and then expose only certain classes (aka <a href="https://en.wikipedia.org/wiki/Facade_pattern">"Facades"</a>) to operate on this group of dependencies at a higher level.  For more details on using sub-containers, see <a href="#sub-containers-and-facades">this section</a>.  There are 4 different ways to define the subcontainer:

    1. **ByMethod** - Initialize the subcontainer by using a method.

        ```csharp
        Container.Bind<Foo>().FromSubContainerResolve().ByMethod(InstallFooFacade);

        void InstallFooFacade(DiContainer subContainer)
        {
            subContainer.Bind<Foo>();
        }
        ```

    1. **ByInstaller** - Initialize the subcontainer by using a class derived from `Installer`.  This can be a cleaner and less error-prone alternative than using `ByMethod`, especially if you need to inject data into the installer itself.  Less error prone because when using ByMethod it is common to accidentally use Container instead of subContainer in your method.

        ```csharp
        Container.Bind<Foo>().FromSubContainerResolve().ByInstaller<FooFacadeInstaller>();

        class FooFacadeInstaller : Installer
        {
            public override void InstallBindings()
            {
                Container.Bind<Foo>();
            }
        }
        ```

    1. **ByPrefab** - Initialize subcontainer using a prefab.  Note that the prefab must contain a `GameObjectContext` component attached to the root game object.  For details on `GameObjectContext` see <a href="#sub-containers-and-facades">this section</a>.

        ```csharp
        Container.Bind<Foo>().FromSubContainerResolve().ByPrefab(MyPrefab);

        // Assuming here that this installer is added to the GameObjectContext at the root
        // of the prefab.  You could also use a ZenjectBinding in the case where Foo is a MonoBehaviour
        class FooFacadeInstaller : MonoInstaller
        {
            public override void InstallBindings()
            {
                Container.Bind<Foo>();
            }
        }
        ```

    1. **ByPrefabResource** - Initialize subcontainer using a prefab obtained via `Resources.Load`.  Note that the prefab must contain a `GameObjectContext` component attached to the root game object.

        ```csharp
        Container.Bind<Foo>().FromSubContainerResolve().ByPrefabResource("Path/To/MyPrefab");
        ```

## <a id="installers"></a>Installers

Often, there is some collections of related bindings for each sub-system and so it makes sense to group those bindings into a re-usable object.  In Zenject this re-usable object is called an Installer.  You can define a new installer as follows:

```csharp
public class FooInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindAllInterfaces<Foo>().To<Foo>().AsSingle();
    }
}
```

You add bindings by overriding the InstallBindings method, which is called by whatever `Context` the installer has been added to (usually this is `SceneContext`).  MonoInstaller is a MonoBehaviour so you can add FooInstaller by attaching it to a GameObject.  Since it is a GameObject you can also add public members to it to configure your installer from the Unity inspector.  This allows you to add references within the scene, references to assets, or simply tuning data (see <a href="#using-the-unity-inspector-to-configure-settings">here</a> for more information on tuning data).

Note that in order for your installer to be triggered it must be attached to the Installers property of the `SceneContext` object.  This is necessary to be able to control the order that installers are called in (which you can do by dragging rows around in the Installers property).  The order should not usually matter (since nothing should be instantiated during the install process) however it can matter in some cases, such as when you configure an Installer from an existing installer (eg: `Container.BindInstance("mysetting").WhenInjectedInto<MyOtherInstaller>()`).

In many cases you want to have your installer derive from MonoInstaller, so that you can have inspector settings.  There is also another base class called simply `Installer` which you can use in cases where you do not need it to be a MonoBehaviour.

You can also call other installers from an existing installer.  For example:

```csharp
public class BarInstaller : Installer
{
    public override void InstallBindings()
    {
        ...
    }
}

public class FooInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Install<BarInstaller>();
    }
}
```

Note that in this case BarInstaller is of type Installer and not MonoInstaller, which is why we can simply call `Container.Install<BarInstaller>`.  By using Installer for BarInstaller instead of MonoInstaller, we don't need an instance of BarInstaller in our scene to use it.  Any calls to Container.Install will immediately create the given installer type and then call InstallBindings on it.  This will repeat for any installers that this installer installs.

One of the main reasons we use installers as opposed to just having all our bindings declared all at once for each scene, is to make them re-usable.  This is not a problem for installers of type `Installer` because you can simply call `Container.Install` as described above for every scene you wish to use it in, but then how would we re-use a MonoInstaller in multiple scenes?

There are two ways to do this.

1. **Prefabs within the scene**.  After attaching your MonoInstaller to a gameobject in your scene, you can then create a prefab out of it.  This is nice because it allows you to share any configuration that you've done in the inspector on the MonoInstaller across scenes (and also have per-scene overrides if you want).  After adding it in your scene you can then drag and drop it on to the InstallerPrefabs property of a `Context`

2. **Prefabs within Resources folder**.  You can also call `Container.InstallPrefabResource`, which will load a prefab that is assumed to container a MonoInstaller on it from the resources folder.  If you do not supply a resource path, it will be assumed to exist at "Resources/Installers/NameOfMonoInstallerType".  For example:

```csharp
// Note that this is a MonoInstaller and has inspector settings
public class QuxInstaller : MonoInstaller
{
    public string MyConfigurationSetting;

    public override void InstallBindings()
    {
        ...
    }
}

public class FooInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // When this is called, Zenject will look for a prefab at `Resources/Installers/QuxInstaller.prefab` and load that
        Container.InstallPrefabResource<QuxInstaller>();

        // You can also explicitly give a custom resource path
        Container.InstallPrefabResource<QuxInstaller>("Stuff/Qux");
    }
}
```

Using InstallPrefabResource is sometimes a useful alternative to adding installer prefabs to every scene because it allows you to keep the objects in your scenes extremely light.

Another option is to use ScriptableObjectInstaller - for details see <a href="#scriptableobject-installer">here</a>.

## <a id="itickable"></a>ITickable

In many cases it is preferable to avoid the extra weight of MonoBehaviours in favour of just normal C# classes.  Zenject allows you to do this much more easily by providing interfaces that mirror functionality that you would normally need to use a MonoBehaviour for.

For example, if you have code that needs to run per frame, then you can implement the `ITickable` interface:

```csharp
public class Ship : ITickable
{
    public void Tick()
    {
        // Perform per frame tasks
    }
}
```

Then it's just a matter of including the following in one of your installers:

```csharp
Container.Bind<ITickable>().To<Ship>().AsSingle();
```

Or if you don't want to have to remember which interfaces Ship implements:

```csharp
Container.BindAllInterfaces<Ship>().To<Ship>().AsSingle();
```

Note that the order that Tick() is called on all ITickables is also configurable, as outlined <a href="#update--initialization-order">here</a>.

Also note that there are interfaces `ILateTickable` and `IFixedTickable` which work similarly for the other unity update methods.

## <a id="iinitializable-and-postinject"></a>IInitializable

If you have some initialization that needs to occur on a given object, you could include this code in the constructor.  However, this means that the initialization logic would occur in the middle of the object graph being constructed, so it may not be ideal.

One alternative is to implement `IInitializable`, and then perform initialization logic in an `Initialize()` method.  This Initialize method would then be called after the entire object graph is constructed and all constructors have been called.

Note that the constructors for the initial object graph are called during Unity's Awake event, and that the `IInitializable.Initialize` methods are called immediately on Unity's Start event.  Using `IInitializable` as opposed to a constructor is therefore more in line with Unity's own recommendations, which suggest that the Awake phase be used to set up object references, and the Start phase should be used for more involved initialization logic.

This can also be better than using constructors or `[Inject]` methods because the initialization order is customizable in a similar way to `ITickable`, as explained <a href="#update--initialization-order">here</a>.

```csharp
public class Ship : IInitializable
{
    public void Initialize()
    {
        // Initialize your object here
    }
}
```

`IInitializable` works well for start-up initialization, but what about for objects that are created dynamically via factories?  (see <a href="#creating-objects-dynamically">this section</a> for what I'm referring to here).  For these cases you will most likely want to use an `[Inject]` method:

```csharp
public class Foo
{
    [Inject]
    IBar _bar;

    [Inject]
    public void Initialize()
    {
        ...
        _bar.DoStuff();
        ...
    }
}
```

## <a id="implementing-idisposable"></a>IDisposable

If you have external resources that you want to clean up when the app closes, the scene changes, or for whatever reason the context object is destroyed, you can simply declare your class as `IDisposable` like below:

```csharp
public class Logger : IInitializable, IDisposable
{
    FileStream _outStream;

    public void Initialize()
    {
        _outStream = File.Open("log.txt", FileMode.Open);
    }

    public void Log(string msg)
    {
        _outStream.WriteLine(msg);
    }

    public void Dispose()
    {
        _outStream.Close();
    }
}
```

Then in your installer you can include:

```csharp
Container.Bind<Logger>().AsSingle();
Container.Bind<IInitializable>().To<Logger>().AsSingle();
Container.Bind<IDisposable>().To<Logger>().AsSingle();
```

Or you can use the following shortcut:

```csharp
Container.BindAllInterfacesAndSelf<Logger>().To<Logger>().AsSingle();
```

This works because when the scene changes or your unity application is closed, the unity event OnDestroy() is called on all MonoBehaviours, including the SceneContext class, which then triggers Dispose() on all objects that are bound to `IDisposable`

Note that this example may or may not be a good idea (for example, the file will be left open if your app crashes), but illustrates the point  :)

## <a id="using-the-unity-inspector-to-configure-settings"></a>Using the Unity Inspector To Configure Settings

One implication of writing most of your code as normal C# classes instead of MonoBehaviour's is that you lose the ability to configure data on them using the inspector.  You can however still take advantage of this in Zenject by using the following pattern, as seen in the sample project:

```csharp
public class AsteroidsInstaller : MonoInstaller
{
    public Settings SceneSettings;

    public override void InstallBindings()
    {
        ...
        Container.BindInstance(SceneSettings.StateMoving);
        ...
    }

    [Serializable]
    public class Settings
    {
        ...
        public ShipStateMoving.Settings StateMoving;
        ...
    }
}
```

Note that if you follow this method, you will have to make sure to always include the [Serializable] attribute on your settings wrappers, otherwise they won't show up in the Unity inspector.

To see this in action, start the asteroids scene and try adjusting `Ship -> State Moving -> Move Speed` setting and watch live as your ship changes speed.

Another way to do this is to use ScriptableObjectInstaller to store settings, which have the added advantage that you can change your settings at runtime and have those changes automatically persist when play mode is stopped.  See <a href="#scriptableobject-installer">here</a> for details.

## <a id="object-graph-validation"></a>Object Graph Validation

The usual workflow when setting up bindings using a DI framework is something like this:

* Add some number of bindings in code
* Execute your app
* Observe a bunch of DI related exceptions
* Modify your bindings to address problem
* Repeat

This works ok for small projects, but as the complexity of your project grows it is often a tedious process.  The problem gets worse if the startup time of your application is particularly bad, or when the exceptions only occur from factories at various points at runtime.  What would be great is some tool to analyze your object graph and tell you exactly where all the missing bindings are, without requiring the cost of firing up your whole app.

You can do this in Zenject out-of-the-box by executing the menu item `Edit -> Zenject -> Validate Current Scene` or simply hitting CTRL+SHIFT+V with the scene open that you want to validate.  This will execute all installers for the current scene, with the result being a fully bound container.   It will then iterate through the object graphs and verify that all bindings can be found (without actually instantiating any of them).  Under the hood, this works by storing dummy objects in the container in place of actually instantiating your classes

Note that if you want to use this feature (which I recommend as its very useful) then you should avoid instantiating new objects in your installers and executing other code that has similar side effects.

## <a id="scene-bindings"></a>Scene Bindings

In many cases, you have a number of MonoBehaviour's that have been added to the scene within the Unity editor (ie. at editor time not runtime) and you want to also have these MonoBehaviour's added to the Zenject Container so that they can be injected into other classes.

The usual way this is done is to add public references to these objects within your installer like this:

    public class Foo : MonoBehaviour
    {
    }

    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        Foo _foo;

        public override void InstallBindings()
        {
            Container.BindInstance(_foo);
            Container.Bind<IInitializable>().To<GameRunner>().AsSingle();
        }
    }

    public class GameRunner : IInitializable
    {
        readonly Foo _foo;

        public GameRunner(Foo foo)
        {
            _foo = foo;
        }

        public void Initialize()
        {
            ...
        }
    }

(Note that you could also just make `Foo` public here - my personal convention is just to always use `SerializeField` instead to avoid breaking encapsulation)

This works fine however in some cases this can get cumbersome.  For example, if you want to allow an artist to add any number of `Enemy` objects to the scene, and you also want all those `Enemy` objects added to the Zenject Container.  In this case, you would have to manually drag each one to the inspector of one of your installers.  This is very error prone since its easy to forget one, or to delete the `Enemy` game object but forget to delete the null reference in the inspector for your installer, etc.

So another way to do this is to use the `ZenjectBinding` component.  You can do this by adding a `ZenjectBinding` MonoBehaviour to the same game object that you want to be automatically added to the Zenject container.

For example, if I have a MonoBehaviour of type `Foo` in my scene, I can just add `ZenjectBinding` alongside it, and then drag the Foo component into the Component property of the ZenjectBinding component.

<img src="UnityProject/Assets/Zenject/Documentation/ReadMe_files/AutoBind1.png?raw=true" alt="ZenjectBinding"/>

Then our installer becomes:

    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<GameRunner>().AsSingle();
        }
    }

When using `ZenjectBinding` this way, by default it will bind `Foo` using the `Self` method, so it is equivalent to the first example where we did this:

    Container.Bind<Foo>().ToInstance(_foo);

Which is also the same as this:

    Container.BindInstance(_foo);

So if we duplicate this game object to have multiple game objects with `Foo` on them (and its `ZenjectBinding`), they will all be bound to the Container this way.  So after doing this, we would have to change `GameRunner` above to take a `List<Foo>` otherwise we would get Zenject exceptions (see <a href="#list-bindings">here</a> for info on list bindings).

Also note that the `ZenjectBinding` component contains a `Bind Type` property in its inspector.  By default this simply binds the instance as shown above but it can also be set to the following:

1 - `AllInterfaces`

This bind type is equivalent to the following:

    Container.BindAllInterfaces(_foo.GetType()).ToInstance(_foo);

Note however, in this case, that `GameRunner` must ask for type `IFoo` in its constructor.  If we left `GameRunner` asking for type `Foo` then Zenject would throw exceptions, since the `BindAllInterfaces` method only binds the interfaces, not the concrete type.  If you want the concrete type as well then you can use:

2 - `AllInterfacesAndSelf`

This bind type is equivalent to the following:

    Container.BindAllInterfacesAndSelf(_foo.GetType()).ToInstance(_foo);

This is the same as AllInterfaces except we can directly access Foo using type Foo instead of needing an interface.

The final property you will notice on the ZenjectBinding component is the "Context".  This is completely optional and in most cases should be left unset.  However, if you are using GameObjectContext in places, then the other value might be useful to you (see <a href="#sub-containers-and-facades">section on sub-containers</a> for details)

"Context" will determine what container the component gets added to.  If left unset, it will use whatever context the GameObject is in.  In most cases this will be SceneContext, but if it's inside a GameObjectContext it will be bound into that container instead.  One important use case here is to drag the SceneContext into this field for one of the MonoBehaviour's inside a GameObjectContext.  This allows you to treat this MonoBehaviour as a <a href="https://en.wikipedia.org/wiki/Facade_pattern">Facade</a> for the entire sub-container given by the GameObjectContext.

## <a id="di-guidelines--recommendations"></a>General Guidelines / Recommendations / Gotchas / Tips and Tricks

* **Do not use GameObject.Instantiate if you want your objects to have their dependencies injected**
    * If you want to instantiate a prefab at runtime and have any MonoBehaviour's automatically injected, we recommend using a <a href="#creating-objects-dynamically">factory</a>.  You can also instantiate a prefab by directly using the DiContainer by calling any of the `InstantiatePrefab` methods.  Using these ways as opposed to GameObject.Instantiate will ensure any fields that are marked with the [Inject] attribute are filled in properly, and all [Inject] methods within the prefab are called.

* **Best practice with DI is to *only* reference the container in the composition root "layer"**
    * Note that factories are part of this layer and the container can be referenced there (which is necessary to create objects at runtime).  For example, see ShipStateFactory in the sample project.  See <a href="#creating-objects-dynamically">here</a> for more details on this.

* **Do not use IInitializable, ITickable and IDisposable for dynamically created objects**
    * Objects that are of type `IInitializable` are only initialized once - at startup during Unity's Start phase.  If you create an object through a factory, and it derives from `IInitializable`, the Initialize() method will not be called.  You should use [Inject] methods in this case.
    * The same applies to `ITickable` and `IDisposable`.  Deriving from these will do nothing unless they are part of the original object graph created at startup.
    * If you have dynamically created objects that have an Update() method, it is usually best to call Update() on those manually, and often there is a higher level manager-like class in which it makes sense to do this from.  If however you prefer to use `ITickable` for dynamically objects you can declare a dependency to TickableManager and add/remove it explicitly as well.

* **Using multiple constructors**
    * Zenject does not support injecting into multiple constructors currently.  You can have multiple constructors however you must mark one of them with the [Inject] attribute so Zenject knows which one to use.

* **Prefer [Inject] methods to Start/Awake methods for dynamically created MonoBehaviours**
    * One issue that often arises when using Zenject is that a game object is instantiated dynamically, and then one of the MonoBehaviours on that game object attempts to use one of its injected field dependencies in its Start() or Awake() methods.  Often in these cases the dependency will still be null, as if it was never injected.  The issue here is that Zenject cannot fill in the dependencies until after the call to GameObject.Instantiate completes, and in most cases GameObject.Instantiate will call the Start() and Awake() methods.  The solution is to use neither Start() or Awake() and instead define a new method and mark it with a [Inject] attribute.  This will guarantee that all dependencies have been resolved before executing the method.

* **Using Zenject outside of Unity**
    * Zenject is primarily designed to work within Unity3D.  However, it can also be used as a general purpose DI framework outside of Unity3D.  Zenject has been used within ASP.NET MVC and WPF projects successfully.  In order to do this, you can get the DLL from the Releases section of the GitHub page, or build the solution yourself at `NonUnityBuild/Zenject.sln`

* **Lazily instantiated objects and the object graph**
    * Zenject does not immediately instantiate every object defined by the bindings that you've set up in your installers.  Instead, Zenject will construct some number of root-level objects, and then lazily instantiate the rest based on usage.  Root-level objects are any classes that are bound to IInitializable / ITickable / IDisposable, and any class that is declared in a binding that is marked `NonLazy()`.

* <a id="bad-execution-order"></a>**The order that things occur in is wrong, like injection is occurring too late, or Initialize() event is not called at the right time, etc.**
    * It may be because the 'script execution order' of the Zenject classes 'ProjectContext', 'SceneContext', or 'SceneDecoratorContext' are incorrect.  These classes should always have the earliest or near earliest execution order.  This should already be set by default (since this setting is included in the `cs.meta` files for these classes).  However if you are compiling Zenject yourself or have a unique configuration, you may want to make sure, which you can do by going to "Edit -> Project Settings -> Script Execution Order" and confirming that these classes are at the top, before the default time.

Please feel free to submit any other sources of confusion to sfvermeulen@gmail.com and I will add it here.

## <a id="optional-binding"></a>Optional Binding

You can declare some dependencies as optional as follows:

```csharp
public class Bar
{
    public Bar(
        [InjectOptional]
        IFoo foo)
    {
        ...
    }
}
...

// You can comment this out and it will still work
Container.Bind<IFoo>().AsSingle();
```

If an optional dependency is not bound in any installers, then it will be injected as null.

If the dependency is a primitive type (eg. int, float, struct) then it will be injected with its default value (eg. 0 for ints).

You may also assign an explicit default using the standard C# way such as:

```csharp
public class Bar
{
    public Bar(int foo = 5)
    {
        ...
    }
}
...

// Can comment this out and 5 will be used instead
Container.BindInstance(1);
```

Note also that the `[InjectOptional]` is not necessary in this case, since it's already implied by the default value.

Alternatively, you can define the primitive parameter as nullable, and perform logic depending on whether it is supplied or not, such as:

```csharp
public class Bar
{
    int _foo;

    public Bar(
        [InjectOptional]
        int? foo)
    {
        if (foo == null)
        {
            // Use 5 if unspecified
            _foo = 5;
        }
        else
        {
            _foo = foo.Value;
        }
    }
}

...

// Can comment this out and it will use 5 instead
Container.BindInstance(1);
```

## <a id="conditional-bindings"></a>Conditional Bindings

In many cases you will want to restrict where a given dependency is injected.  You can do this using the following syntax:

```csharp
Container.Bind<IFoo>().To<Foo1>().AsSingle().WhenInjectedInto<Bar1>();
Container.Bind<IFoo>().To<Foo2>().AsSingle().WhenInjectedInto<Bar2>();
```

Note that `WhenInjectedInto` is simple shorthand for the following, which uses the more general `When()` method:

```csharp
Container.Bind<IFoo>().To<Foo>().AsSingle().When(context => context.ObjectType == typeof(Bar));
```

The InjectContext class (which is passed as the `context` parameter above) contains the following information that you can use in your conditional:

* `Type ObjectType` - The type of the newly instantiated object, which we are injecting dependencies into.  Note that this is null for root calls to `Resolve<>` or `Instantiate<>`
* `object ObjectInstance` - The newly instantiated instance that is having its dependencies filled.  Note that this is only available when injecting fields or into `[Inject]` methods and null for constructor parameters
* `string Identifier` - This will be null in most cases and set to whatever is given as a parameter to the `[Inject]` attribute.  For example, `[Inject(Id = "foo")] _foo` will result in `Identifier` being equal to the string "foo".
* `string ConcreteIdentifier` - This will be null in most cases and set to whatever is given as the string identifier to the `AsSingle` method.
* `string MemberName` - The name of the field or parameter that we are injecting into.  This can be used, for example, in the case where you have multiple constructor parameters that are strings.  However, using the parameter or field name can be error prone since other programmers may refactor it to use a different name.  In many cases it's better to use an explicit identifier
* `Type MemberType` - The type of the field or parameter that we are injecting into.
* `InjectContext ParentContext` - This contains information on the entire object graph that precedes the current class being created.  For example, dependency A might be created, which requires an instance of B, which requires an instance of C.  You could use this field to inject different values into C, based on some condition about A.  This can be used to create very complex conditions using any combination of parent context information.  Note also that `ParentContext.MemberType` is not necessarily the same as ObjectType, since the ObjectType could be a derived type from `ParentContext.MemberType`
* `bool Optional` - True if the `[InjectOptional]` parameter is declared on the field being injected

## <a id="list-bindings"></a>List Bindings

When Zenject finds multiple bindings for the same type, it interprets that to be a list.  So, in the example code below, Bar would get a list containing a new instance of Foo1, Foo2, and Foo3:

```csharp
// In an installer somewhere
Container.Bind<IFoo>().To<Foo1>().AsSingle();
Container.Bind<IFoo>().To<Foo2>().AsSingle();
Container.Bind<IFoo>().To<Foo3>().AsSingle();

...

public class Bar
{
    public Bar(List<IFoo> foos)
    {
    }
}
```

Also worth noting is that if you try and declare a single dependency of IFoo (like Bar below) and there are multiple bindings for it, then Zenject will throw an exception, since Zenject doesn't know which instance of IFoo to use.

```csharp
public class Bar
{
    public Bar(IFoo foo)
    {
    }
}
```

Also, if the empty list is valid, then you should mark your List constructor parameter (or [Inject] field) as optional (see <a href="#optional-binding">here</a> for details).

## <a id="global-bindings"></a>Global Bindings

This all works great for each individual scene, but what if you have dependencies that you wish to persist permanently across all scenes?  In Zenject you can do this by adding installers to a ProjectContext object.

To do this, first you need to create a prefab for the ProjectContext, and then you can add installers to it.  You can do this most easily by selecting the menu item `Edit -> Zenject -> Create Project Context`. You should then see a new asset in the folder `Assets/Resources` called 'ProjectContext'.

If you click on this it will appear nearly identically to the inspector for `SceneContext`.  The easiest way to configure this prefab is to temporarily add it to your scene, add Installers to it, then click "Apply" to save it back to the prefab before deleting it from your scene.  In addition to installers, you can also add your own custom MonoBehaviour classes to the ProjectContext object directly.

Then, when you start any scene that contains a `SceneContext`, your `ProjectContext` object will always be initialized first.  All the installers you add here will be executed and the bindings that you add within them will be available for use in all scenes within your project.

Note also that this only occurs once.  If you load another scene from the first scene, your ProjectContext will not be called again and the bindings that it added previously will persist into the new scene.  You can declare `ITickable` / `IInitializable` / `IDisposable` objects in your global installers in the same way you do for your scene installers with the result being that `IInitializable.Initialize` is called only once across each play session and `IDisposable.Dispose` is only called once the application is fully stopped.

This works because the container defined for each scene is nested inside the global container that your global installers bind into.  For more information on nested containers see <a href="#sub-containers-and-facades">here</a>.

## <a id="identifiers"></a>Identifiers

You can also give an ID to your binding if you need to have distinct bindings for the same type, and you don't want it to just result in a `List<>`.  For example:

```csharp
Container.Bind<IFoo>().WithId("foo").To<Foo1>().AsSingle();
Container.Bind<IFoo>().To<Foo2>().AsSingle();

...

public class Bar1
{
    [Inject(Id = "foo")]
    IFoo _foo;
}

public class Bar2
{
    [Inject]
    IFoo _foo;
}
```

In this example, the `Bar1` class will be given an instance of `Foo1`, and the `Bar2` class will use the default version of `IFoo` which is bound to `Foo2`.

Note also that you can do the same thing for constructor/inject-method arguments as well:

```csharp
public class Bar
{
    Foo _foo;

    public Bar(
        [Inject(Id = "foo")] 
        Foo foo)
    {
    }
}
```

In many cases, the ID is created as a string, however you can actually use any type you like for this.  For example, it's sometimes useful to use an enum instead:

```csharp
enum Cameras
{
    Main,
    Player,
}

Container.Bind<Camera>().WithId(Cameras.Main).FromInstance(MyMainCamera);
Container.Bind<Camera>().WithId(Cameras.Player).FromInstance(MyPlayerCamera);
```

You can also use custom types, as long as they implement the `Equals` operator.

## <a id="non-generic-bindings"></a>Non Generic bindings

In some cases you may not know the exact type you want to bind at compile time.  In these cases you can use the overload of the `Bind` method which takes a `System.Type` value instead of a generic parameter.

```csharp
// These two lines will result in the same behaviour
Container.Bind(typeof(Foo));
Container.Bind<Foo>();
```

Note also that when using non generic bindings, you can pass multiple arguments:

```csharp
Container.Bind(typeof(Foo), typeof(Bar), typeof(Qux)).AsSingle();

// The above line is equivalent to these three:
Container.Bind<Foo>().AsSingle();
Container.Bind<Bar>().AsSingle();
Container.Bind<Qux>().AsSingle();
```

The same goes for the To method:

```csharp
Container.Bind<IFoo>().To(typeof(Foo), typeof(Bar)).AsSingle();

// The above line is equivalent to these two:
Container.Bind<IFoo>().To<Foo>().AsSingle();
Container.Bind<IFoo>().To<Bar>().AsSingle();
```

You can also do both:

```csharp
Container.Bind(typeof(IFoo), typeof(IBar)).To(typeof(Foo1), typeof(Foo2)).AsSingle();

// The above line is equivalent to these:
Container.Bind<IFoo>().To<Foo>().AsSingle();
Container.Bind<IFoo>().To<Bar>().AsSingle();
Container.Bind<IBar>().To<Foo>().AsSingle();
Container.Bind<IBar>().To<Bar>().AsSingle();
```

This can be especially useful when you have a class that implements multiple interfaces:

```csharp
Container.Bind(typeof(ITickable), typeof(IInitializable), typeof(IDisposable)).To<Foo>().AsSingle();
```

Though in this particular example there is already a built-in shortcut method for this:

```csharp
Container.BindAllInterfaces<Foo>().To<Foo>().AsSingle();
```

## <a id="convention-based-bindings"></a>Convention Based Binding

Convention based binding can come in handy in any of the following scenarios:

- You want to define a naming convention that determines how classes are bound to the container (eg. using a prefix, suffix, or regex)
- You want to use custom attributes to determine how classes are bound to the container
- You want to automatically bind all classes that implement a given interface within a given namespace or assembly

Using "convention over configuration" can allow you to define a framework that other programmers can use to quickly and easily get things done, instead of having to explicitly add every binding within installers.  This is the philosophy that is followed by frameworks like Ruby on Rails, ASP.NET MVC, etc.  Of course, there are both advantages and disadvantages to this approach.

They are specified in a similar way to <a href="#non-generic-bindings">Non Generic bindings</a>, except instead of giving a list of types to the `Bind()` and `To()` methods, you describe the convention using a Fluent API.  For example, to bind `IFoo` to every class that implements it in the entire codebase:

```csharp
Container.Bind<IFoo>().To(x => x.AllTypes().DerivingFrom<IFoo>());
```

Note that you can use the same Fluent API in the `Bind()` method as well, and you can also use it in both `Bind()` and `To()` at the same time.

For more examples see the <a href="#convention-binding-examples">examples</a> section below.  The full format is as follows:

<pre>
x.<b>InitialList</b>().<b>Conditional</b>().<b>AssemblySources</b>()
</pre>

###Where:

* **InitialList** = The initial list of types to use for our binding.  This list will be filtered by the given **Conditional**s.  It can be one of the following (fairly self explanatory) methods:

    1. **AllTypes**
    1. **AllNonAbstractClasses**
    1. **AllAbstractClasses**
    1. **AllInterfaces**
    1. **AllClasses**

* **Conditional** = The filter to apply to the list of types given by **InitialList**.  Note that you can chain as many of these together as you want, and they will all be applied to the initial list in sequence.  It can be one of the following:

    1. **DerivingFrom**<T> - Only match types deriving from `T`
    1. **DerivingFromOrEqual**<T> - Only match types deriving from or equal to `T`
    1. **WithPrefix**(value) - Only match types with names that start with `value`
    1. **WithSuffix**(value) - Only match types with names that end with `value`
    1. **WithAttribute**<T> - Only match types that have the attribute `[T]` above their class declaration
    1. **WithoutAttribute**<T> - Only match types that do not have the attribute `[T]` above their class declaration
    1. **WithAttributeWhere**<T>(predicate) - Only match types that have the attribute `[T]` above their class declaration AND in which the given predicate returns true when passed the attribute.  This is useful so you can use data given to the attribute to create bindings
    1. **InNamespace**(value) - Only match types that are in the given namespace
    1. **InNamespaces**(value1, value2, etc.) - Only match types that are in any of the given namespaces
    1. **MatchingRegex**(pattern) - Only match types that match the given regular expression
    1. **Where**(predicate) - Finally, you can also add any kind of conditional logic you want by passing in a predicate that takes a `Type` parameter

* **AssemblySources** = The list of assemblies to search for types when populating **InitialList**.  It can be one of the following:

    1. **FromAllAssemblies** - Look up types in all loaded assemblies.  This is the default when unspecified.
    1. **FromAssemblyContaining**<T> - Look up types in whatever assembly the type `T` is in
    1. **FromAssembliesContaining**(type1, type2, ..) - Look up types in all assemblies that contains any of the given types
    1. **FromThisAssembly** - Look up types only in the assembly in which you are calling this method
    1. **FromAssembly**(assembly) - Look up types only in the given assembly
    1. **FromAssemblies**(assembly1, assembly2, ...) - Look up types only in the given assemblies
    1. **FromAssembliesWhere**(predicate) - Look up types in all assemblies that match the given predicate

###<a id="convention-binding-examples"></a>Examples:

Note that you can chain together any combination of the below conditionals in the same binding.  Also note that since we aren't specifying an assembly here, Zenject will search within all loaded assemblies.

1. Bind `IFoo` to every class that implements it in the entire codebase:

    ```csharp
    Container.Bind<IFoo>().To(x => x.AllTypes().DerivingFrom<IFoo>());
    ```

    Note that this will also have the same result:

    ```csharp
    Container.Bind<IFoo>().To(x => x.AllNonAbstractTypes());
    ```

    This is because Zenject will skip any bindings in which the concrete type does not actually derive from the base type.  Also note that in this case we have to make sure we use `AllNonAbstractTypes` instead of just `AllTypes`, to ensure that we don't bind `IFoo` to itself

1. Bind an interface to all classes implementing it within a given namespace

    ```csharp
    Container.Bind<IFoo>().To(x => x.AllTypes().DerivingFrom<IFoo>().InNamespace("MyGame.Foos"));
    ```

1. Auto-bind `IController` every class that has the suffix "Controller" (as is done in ASP.NET MVC):

    ```csharp
    Container.Bind<IController>().To(x => x.AllNonAbstractTypes().WithSuffix("Controller"));
    ```

    You could also do this using `MatchingRegex`:

    ```csharp
    Container.Bind<IController>().To(x => x.AllNonAbstractTypes().MatchingRegex("Controller$"));
    ```

1. Bind all types with the prefix "Widget" and inject into Foo

    ```csharp
    Container.Bind<object>().To(x => x.AllNonAbstractTypes().WithPrefix("Widget")).WhenInjectedInto<Foo>();
    ```

1. Auto-bind the interfaces that are used by every type in a given namespace

    ```csharp
    Container.Bind(x => x.AllInterfaces())
        .To(x => x.AllNonAbstractClasses().InNamespace("MyGame.Things"));
    ```

    This is equivalent to calling `Container.BindAllInterfaces<T>().To<T>()` for every type in the namespace "MyGame.Things".  This works because, as touched on above, Zenject will skip any bindings in which the concrete type does not actually derive from the base type.  So even though we are using `AllInterfaces` which matches every single interface in every single loaded assembly, this is ok because it will not try and bind an interface to a type that doesn't implement this interface.

## <a id="unbind-rebind"></a>Unbind / Rebind

It is also possible to remove or replace bindings that were added in another bind statement.  This is especially useful when used in combination with <a href="#scenes-decorator">Scene Decorators</a>

1. Unbind - Remove binding from container.

    ```csharp
    Container.Bind<IFoo>().To<Foo>();

    // This will nullify the above statement
    Container.Unbind<IFoo>();
    ```

1. Rebind - Override an existing binding with a new one.  This is equivalent to calling unbind with the given type and then immediately calling bind afterwards.

    ```csharp
    Container.Bind<IFoo>().To<Foo>();

    // 
    Container.Rebind<IFoo>().To<Bar>();
    ```

## <a id="singleton-identifiers"></a>Singleton Identifiers

In addition to <a href="#identifiers">normal identifiers</a>, you can also assign an identifer to a given singleton.

This allows you to force Zenject to create multiple singletons instead of just one, since otherwise the singleton is uniquely identified based on the type given as generic argument to the `To<>` method.  So for example:

```csharp
Container.Bind<IFoo>().To<Foo>().AsSingle();
Container.Bind<IBar>().To<Foo>().AsSingle();
Container.Bind<IQux>().To<Qux>().AsSingle();
```

In the above code, both `IFoo` and `IBar` will be bound to the same instance.  Only one instance of Foo will be created.

```csharp
Container.Bind<IFoo>().To<Foo>().AsSingle("foo1");
Container.Bind<IBar>().To<Foo>().AsSingle("foo2");
```

In this case however, two instances will be created.

Another use case for this is to allow creating multiple singletons from the same prefab.  For example, Given the following:

```csharp
Container.Bind<Foo>().FromPrefab(MyPrefab).AsSingle();
Container.Bind<Bar>().FromPrefab(MyPrefab).AsSingle();
```

It will only instantiate the prefab MyPrefab once, since the singleton is identified solely by the prefab when using `FromPrefab`.  The concrete type given can be interpreted as "Search the instantiated prefab for this component".  But, if instead you want Zenject to instantiate a new instance of the prefab for each `FromPrefab` binding, then you can do that as well by supplying an identifier to the `AsSingle` function like this:

```csharp
Container.Bind<Foo>().FromPrefab(MyPrefab).AsSingle("foo");
Container.Bind<Bar>().FromPrefab(MyPrefab).AsSingle("bar");
```

Now two instances of the prefab will be created.

## <a id="scriptableobject-installer"></a>Scriptable Object Installer

TBD

## <a id="commands-and-signals"></a>Commands And Signals

See <a href="Documentation/CommandsAndSignals.md">here</a>.

## <a id="creating-objects-dynamically"></a>Creating Objects Dynamically Using Factories

See <a href="Documentation/Factories.md">here</a>.

## <a id="update--initialization-order"></a>Update / Initialization Order

In many cases, especially for small projects, the order that classes update or initialize in does not matter.  However, in larger projects update or initialization order can become an issue.  This can especially be an issue in Unity, since it is often difficult to predict in what order the Start(), Awake(), or Update() methods will be called in.  Unfortunately, Unity does not have an easy way to control this (besides in `Edit -> Project Settings -> Script Execution Order`, though that can be awkward to use)

In Zenject, by default, ITickables and IInitializables are updated in the order that they are added, however for cases where the update or initialization order does matter, there is a much better way:  By specifying their priorities explicitly in the installer.  For example, in the sample project you can find this code in the scene installer:

```csharp
public class AsteroidsInstaller : MonoInstaller
{
    ...

    void InitExecutionOrder()
    {
        // In many cases you don't need to worry about execution order,
        // however sometimes it can be important
        // If for example we wanted to ensure that AsteroidManager.Initialize
        // always gets called before GameController.Initialize (and similarly for Tick)
        // Then we could do the following:
        Container.BindExecutionOrder<AsteroidManager>(-10);
        Container.BindExecutionOrder<GameController>(-20);

        // Note that they will be disposed of in the reverse order given here
    }

    ...

    public override void InstallBindings()
    {
        ...
        InitExecutionOrder();
        ...
    }

}
```

This way, you won't hit a wall at the end of the project due to some unforeseen order-dependency.

Note here that the value given to BindExecutionOrder will apply to ITickable / IInitializable and IDisposable (with the order reversed for IDisposable's).

You can also assign priorities for each specific interface separately like this:

```csharp
Container.BindInitializableExecutionOrder<Foo>(-10);
Container.BindInitializableExecutionOrder<Bar>(-20);

Container.BindTickableExecutionOrder<Foo>(10);
Container.BindTickableExecutionOrder<Bar>(-80);
```

Any ITickables, IInitializables, or `IDisposable`'s that are not assigned a priority are automatically given the priority of zero.  This allows you to have classes with explicit priorities executed either before or after the unspecified classes.  For example, the above code would result in 'Foo.Initialize' being called before 'Bar.Initialize'.

## <a id="zenject-order-of-operations"></a>Zenject Order Of Operations

A Zenject driven application is executed by the following steps:

* Unity Awake() phase begins
    * SceneContext.Awake() method is called.  This should always be the first thing executed in your scene.  It should work this way by default (see <a href="#bad-execution-order">here</a> if you are noticing otherwise).
    * If this is the first scene to be loaded during this play session, SceneContext will create the ProjectContext prefab.  If ProjectContext has already been created by a previous scene, we skip to step 10 to directly initialize the SceneContext
    * ProjectContext iterates through all the Installers that have been added to its prefab via the Unity Inspector, updates them to point to its DiContainer, then calls InstallBindings() on each.  Each Installer calls some number of Bind<> methods on the DiContainer.
    * ProjectContext then injects all MonoBehaviours attached to its game object as well as its children
    * ProjectContext then constructs all the non-lazy root objects, which includes any classes that derive from ITickable / IInitializable or IDisposable, as well as those classes that are added with a `NonLazy()` binding.
    * SceneContext iterates through all the Installers that have been added to it via the Unity Inspector, updates them to point to its DiContainer, then calls InstallBindings() on each.  Each Installer calls some number of Bind<> methods on the DiContainer.
    * SceneContext then injects all objects in the scene (except those objects that are parented to the ProjectContext)
    * SceneContext then constructs all the non-lazy root objects, which includes any classes that derive from ITickable / IInitializable or IDisposable, as well as those classes that are added with a `NonLazy()` binding.
    * If any required dependencies cannot be resolved, a ZenjectResolveException is thrown
    * All other MonoBehaviour's in the scene have their Awake() method called
* Unity Start() phase begins
    * ProjectContext.Start() method is called.  This will trigger the Initialize() method on all `IInitializable` objects in the order specified in the ProjectContext installers.
    * SceneContext.Start() method is called.  This will trigger the Initialize() method on all `IInitializable` objects in the order specified in the SceneContext installers.
    * All other MonoBehaviour's in your scene has their Start() method called
* Unity Update() phase begins
    * ProjectContext.Update() is called, which results in Tick() being called for all `ITickable` objects (in the order specified in the ProjectContext installers)
    * SceneContext.Update() is called, which results in Tick() being called for all `ITickable` objects (in the order specified in the SceneContext installers)
    * All other MonoBehaviour's in your scene has their Update() method called
* These same steps repeated for LateUpdate and ILateTickable
* At the same time, These same steps are repeated for FixedUpdate according to the physics timestep
* Unity scene is unloaded
    * Dispose() is called on all objects mapped to `IDisposable` within the SceneContext installers (see <a href="#implementing-idisposable">here</a> for details)
* App is exitted
    * Dispose() is called on all objects mapped to `IDisposable` within the ProjectContext installers (see <a href="#implementing-idisposable">here</a> for details)

## <a id="injecting-data-across-scenes"></a>Injecting data across scenes

In some cases it's useful to pass arguments from one scene to another.  The way Unity allows us to do this by default is fairly awkward.  Your options are to create a persistent GameObject and call DontDestroyOnLoad() to keep it alive when changing scenes, or use global static classes to temporarily store the data.

Let's pretend you want to specify a 'level' string to the next scene.  You have the following class that requires the input:

```csharp
public class LevelHandler : IInitializable
{
    readonly string _startLevel;

    public LevelHandler(
        [InjectOptional]
        string startLevel)
    {
        if (startLevel == null)
        {
            _startLevel = "default_level";
        }
        else
        {
            _startLevel = startLevel;
        }
    }

    public void Initialize()
    {
        ...
        [Load level]
        ...
    }
}
```

You can load the scene containing `LevelHandler` and specify a particular level by using the following syntax:

```csharp

public class Foo
{
    readonly ZenjectSceneLoader _sceneLoader;

    public Foo(ZenjectSceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void AdvanceScene()
    {
        _sceneLoader.LoadScene("NameOfSceneToLoad", (container) =>
            {
                container.BindInstance("custom_level").WhenInjectedInto<LevelHandler>();
            });
    }
}
```

The bindings that we add here inside the lambda will be added to the container as if they were inside an installer in the new scene.

Note that you can still run the scene directly, in which case it will default to using "default_level".  This is possible because we are using the `InjectOptional` flag.

An alternative and arguably cleaner way to do this would be to customize the installer itself rather than the `LevelHandler` class.  In this case we can write our `LevelHandler` class like this (without the `[InjectOptional]` flag).

```csharp
public class LevelHandler : IInitializable
{
    readonly string _startLevel;

    public LevelHandler(string startLevel)
    {
        _startLevel = startLevel;
    }

    public void Initialize()
    {
        ...
        [Load level]
        ...
    }
}
```

Then, in the installer for our scene we can include the following:

```csharp
public class GameInstaller : Installer
{
    [InjectOptional]
    public string LevelName = "default_level";

    ...

    public override void InstallBindings()
    {
        ...
        Container.BindInstance(LevelName).WhenInjectedInto<LevelHandler>();
        ...
    }
}
```

Then, instead of injecting directly into the `LevelHandler` we can inject into the installer instead.

```csharp

public class Foo
{
    readonly ZenjectSceneLoader _sceneLoader;

    public Foo(ZenjectSceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void AdvanceScene()
    {
        _sceneLoader.LoadScene("NameOfSceneToLoad", (container) =>
            {
                container.BindInstance("custom_level").WhenInjectedInto<GameInstaller>();
            });
    }
}
```

The `ZenjectSceneLoader` class also allows for more complex scenarios, such as loading a scene as a "child" of the current scene, which would cause the new scene to inherit all the dependencies in the current scene.

## <a id="scenes-decorator"></a>Scene Decorators

Scene Decorators can be thought of a more advanced way doing the process described <a href="#injecting-data-across-scenes">above</a>.  That is, they can be used to add behaviour to another scene without actually changing the installers in that scene.

Usually, when you want to customize different behaviour for a given scene depending on some conditions, you would use boolean or enum properties on MonoInstallers, which would then be used to add different bindings depending on the values set.  However, the scene decorator approach can be cleaner sometimes because it doesn't involve changing the main scene.

For example, let's say we want to add some special keyboard shortcuts to our main production scene for testing purposes.  In order to do this using decorators, you can do the following:

* Create a new scene
* Right Click inside the Hierarchy tab and select `Zenject -> Decorator Context`
* Type in the scene you want to 'decorate' in the 'Scene Name' field of SceneDecoratorContext.  Note that as a shortcut, you can click the Open button next to this name to jump to the decorated scene.
* Create a new C# script with the following contents, then add this MonoBehaviour to your scene as a gameObject, then drag it to the `PreInstallers` property of `SceneDecoratorContext`

```csharp
public class ExampleDecoratorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITickable>().To<TestHotKeysAdder>().AsSingle();
    }
}

public class TestHotKeysAdder : ITickable
{
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Hotkey triggered!");
        }
    }
}
```

If you run your scene it should now behave exactly like the scene you entered in 'Scene Name' except with the added functionality in your decorator installer.

NOTE: If the scene fails to load, it might be because the scene that you're decoratoring has not been added to the list of levels in build settings.

Normally it is not that important whether you put your installers in `PreInstallers` or `PostInstallers`.  The one case where this matters is if you are configuring bindings for an installer within the new scene.  In this case you will want to make sure to put your installers in `PreInstallers`.

For a full example see the asteroids project that comes with Zenject (open 'AsteroidsDecoratorExample' scene).  NOTE:  If installing from asset store version, you need to add the 'Asteroids' scene to your build settings so that the scene decorator can find it.

Note also that Zenject validate (using CTRL+SHIFT+V or the menu item via Edit->Zenject->Validate Current Scene) also works with decorator scenes.

Note also that you can add a decorator scene for another decorator scene, and this should work fine.

## <a id="sub-containers-and-facades"></a>Sub-Containers And Facades

See <a href="Documentation/SubContainers.md">here</a>.

## <a id="auto-mocking-using-moq"></a>Auto-Mocking using Moq

See <a href="Documentation/AutoMocking.md">here</a>.

## <a id="questions"></a>Frequently Asked Questions

* **<a id="isthisoverkill"></a>Isn't this overkill?  I mean, is using statically accessible singletons really that bad?**

    For small enough projects, I would agree with you that using a global singleton might be easier and less complicated.  But as your project grows in size, using global singletons will make your code unwieldy.  Good code is basically synonymous with loosely coupled code, and to write loosely coupled code you need to (A) actually be aware of the dependencies between classes and (B) code to interfaces (however I don't literally mean to use interfaces everywhere, as explained [here](#overusinginterfaces))

    In terms of (A), using global singletons, it's not obvious at all what depends on what, and over time your code will become really convoluted, as everything will tend towards depending on everything.  There could always be some method somewhere deep in a call stack that does some hail mary request to some other class anywhere in your code base.  In terms of (B), you can't really code to interfaces with global singletons because you're always referring to a concrete class

    With a DI framework, in terms of (A), it's a bit more work to declare the dependencies you need up-front in your constructor, but this can be a good thing too because it forces you to be aware of the dependencies between classes.

    And in terms of (B), it also forces you to code to interfaces.  By declaring all your dependencies as constructor parameters, you are basically saying "in order for me to do X, I need these contracts fulfilled".  These constructor parameters might not actually be interfaces or abstract classes, but it doesn't matter - in an abstract sense, they are still contracts, which isn't the case when you are creating them within the class or using global singletons.

    Then the result will be more loosely coupled code, which will make it 100x easier to refactor, maintain, test, understand, re-use, etc.

* **<a id="aot-support"></a>Does this work on AOT platforms such as iOS and WebGL?**

    Yes.  However, there are a few things that you should be aware.  One of the things that Unity's IL2CPP compiler does is strip out any code that is not used.  It calculates what code is used by statically analyzing the code to find usage.  This is great, except that this will miss any methods/types that are not used explicitly.  In particular, any classes that are created solely through Zenject will have their constructors ignored by the IL2CPP compiler.  In order to address this, the [Inject] attribute that is sometimes applied to constructors also serves to automatically mark the constructor to IL2CPP to not strip out.   In other words, to fix this issue all you have to do is mark every constructor that you create through Zenject with an [Inject] attribute when compiling for WebGL / iOS.

* **<a id="faq-performance"></a>How is performance?**

    DI can affect start-up time when it builds the initial object graph. However it can also affect performance any time you instantiate new objects at run time.

    Zenject uses C# reflection which is typically slow, but in Zenject this work is cached so any performance hits only occur once for each class type.  In other words, Zenject avoids costly reflection operations by making a trade-off between performance and memory to ensure good performance.

    For some benchmarks on Zenject versus other DI frameworks, see [here](https://github.com/svermeulen/IocPerformance/tree/Zenject).

    Zenject should also produce zero per-frame heap allocations.

* **<a id="net-framework"></a>Can I use .NET framework 4.0 and above?**

    By default Unity uses .NET framework 3.5 and so Zenject assumes that this is what you want.  If you are compiling Zenject with a version greater than this, this is fine, but you'll have to either delete or comment out the contents of Func.cs.

* **<a id="howtousecoroutines"></a>How do I use Unity style Coroutines in normal C# classes?**

    With Zenject, there is less of a need to make every class a `MonoBehaviour`.  But it is often still desirable to be able to call `StartCoroutine` to add asynchronous methods.

    One solution here is to use a dedicated class and just call `StartCoroutine` on that instead.  For example:

        public class AsyncProcessor : MonoBehaviour
        {
            // Purposely left empty
        }

        public class Foo : IInitializable
        {
            AsyncProcessor _asyncProcessor;

            public Foo(AsyncProcessor asyncProcessor)
            {
                _asyncProcessor = asyncProcessor;
            }

            public void Initialize()
            {
                _asyncProcessor.StartCoroutine(RunAsync());
            }

            public IEnumerator RunAsync()
            {
                Debug.Log("Foo started");
                yield return new WaitForSeconds(2.0f);
                Debug.Log("Foo finished");
            }
        }

        public class TestInstaller : MonoInstaller
        {
            public override void InstallBindings()
            {
                Container.Bind<IInitializable>().To<Foo>().AsSingle();
                Container.Bind<AsyncProcessor>().ToSingleGameObject();
            }
        }

    If you need more control than this, another option is to use a coroutine library that implements similar functionality to what Unity provides.  This is what we do.  See [here](https://github.com/svermeulen/UnityCoroutinesWithoutMonoBehaviours) for the library that we use for this.

* **<a id="memorypools"></a>How do I use Zenject with pools to minimize memory allocations?**

    Currently, Zenject does not support memory pooling.  When you bind something to transient or use a factory, Zenject will always create a brand new instance from scratch.  We realize that this can be inefficient in cases where you are creating many objects (especially on mobile) so it is something we want to address in future versions.

## <a id="cheatsheet"></a>Cheat Sheet

TBD

## <a id="further-help"></a>Further Help

For general troubleshooting / support, please use the [zenject subreddit](http://www.reddit.com/r/zenject) or the [zenject google group](https://groups.google.com/forum/#!forum/zenject/).  If you have found a bug, you are also welcome to create an issue on the [github page](https://github.com/modesttree/Zenject), or a pull request if you have a fix / extension.  You can also follow [@Zenject](https://twitter.com/Zenject) on twitter for updates.  Finally, you can also email me directly at sfvermeulen@gmail.com

## <a id="release-notes"></a>Release Notes

See <a href="Documentation/ReleaseNoets.md">here</a>.

## <a id="license"></a>License

    The MIT License (MIT)

    Copyright (c) 2010-2015 Modest Tree Media  http://www.modesttree.com

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.

