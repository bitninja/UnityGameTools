# UnityGameTools

**UnityGameTools** is a collection of utility classes and components designed to extend Unity's functionality. These tools help streamline game development by providing various utilities for performance checking, movement, health management, spawning, and more.  Currently still in the process of copying over code from my previous games to this project.

If you enjoy this project and want to support future development, please consider purchasing my Steam game [Blasteron](https://store.steampowered.com/app/720850/Blasteron/). It's available for just $1.99, and your reviews would mean a lot. Thank you for your support!
https://store.steampowered.com/app/720850/Blasteron/


## Editor Components
* **PerformanceChecker**
   - **Description:** 
     - Provides tools for checking the performance of operations in the Unity editor, such as randomizing arrays and checking the distribution of said randomization.
   - **Key Methods:**
     - `CheckCollectionUtilsRandomizeSpeed()`: Measures the performance of randomizing arrays of different sizes.
     - `CheckRandomizeDistribution()`: Checks the random distribution of the `CollectionUtils.Randomize` method.

## Gizmos Components
* **AxisGizmo**
   - **Description:** 
      - Draws axis pointers in the editor to indicate the positive directions of the X, Y, and Z axes.

## Health Components
* **HasHealth**
   - **Description:** 
     - Manages the health of a game object, including events for health depletion, increase, decrease, and invulnerability.

* **HealthAffector**
   - **Description:** 
     - Affects the health of a `HasHealth` component when triggered by collisions or triggers.

## Movement Components
* **AlignToTransform**
   - **Description:** 
     - Aligns the rotation of the game object to another transform.

* **AlignToZeroRotation**
   - **Description:** 
     - Resets the rotation of the game object to the zero rotation (Quaternion.identity) every frame.

* **AlignWorldForward**
   - **Description:** 
     - Aligns the forward direction of the game object to a specified world direction.

* **AlignWorldUp**
   - **Description:** 
     - Aligns the up direction of the game object to a specified world direction.

* **EasingFollowMovement**
   - **Description:** 
     - Provides a smooth following movement with easing applied, useful for cameras or objects that need to follow a target smoothly.

* **ExponentialOscillatingMovement**
   - **Description:** 
     - Implements an oscillating movement with exponential decay, allowing objects to oscillate and gradually settle over time.

* **LinearMovement**
   - **Description:** 
     - Provides simple linear movement in up, forward, and right directions, with options for relative movement and reversing direction.

* **OscillatingMovement**
   - **Description:** 
     - Moves the game object between two positions using different wave types (Sine, Triangle, Square) for oscillation.

* **SpinMovement**
   - **Description:** 
     - Continuously rotates the game object around specified axes, with options to start, stop, and reverse the rotation.

## Physics Based Components
* **Collision2DForwarder**
   - **Description:** 
     - Forwards 2D collision events (enter, exit, stay) to UnityEvents for easier handling of collision events in Unity.

* **CollisionForwarder**
   - **Description:** 
     - Forwards 3D collision events (enter, exit, stay) to UnityEvents for easier handling of collision events in Unity.

* **Trigger2DForwarder**
   - **Description:** 
     - Forwards 2D trigger events (enter, exit, stay) to UnityEvents for easier handling of trigger events in Unity.

* **TriggerForwarder**
   - **Description:** 
     - Forwards 3D trigger events (enter, exit, stay) to UnityEvents for easier handling of trigger events in Unity.

# Spawner Components
* **CountLimitedSpawner**
   - **Description:** 
     - A spawner that limits the maximum number of objects that can be spawned at any given time.

* **GameObjectShuffleBag**
   - **Description:** 
     - A shuffle bag implementation for game objects, ensuring a more even distribution of randomized selections.

* **RateLimitedSpawner**
   - **Description:** 
     - Spawns game objects at a limited rate, with options for continuous spawning and using a shuffle bag for random selection.

## Time Components
* **DestroyAfterTime**
   - **Description:** 
     - Destroys the game object after a specified time-to-live (TTL), with an option to manually start the countdown.

* **InvokeOnAwake**
   - **Description:** 
     - Invokes a UnityEvent when the game object awakes.

* **TimedInvoke**
   - **Description:** 
     - Invokes a UnityEvent after a specified duration, with options for periodic or one-time invocation.

## UI Components
* **UpdateableTextMeshPro**
   - **Description:** 
     - Updates a TextMeshPro text element with dynamic content, supporting formatted text and token replacement.

## Utilities
* **CollectionUtils**
   - **Description:** 
     - Provides utility methods for collection manipulation, including randomization and dictionary value creation.

* **MathUtil**
   - **Description:** 
     - A utility class offering various mathematical functions, including sigmoid calculations and easing functions.

* **ShuffleBag**
   - **Description:** 
     - A class designed to manage randomness in a way that aligns with human perception of fairness, particularly useful in scenarios where a balanced random distribution is required.

## Vars
   - These classes provide a method of sharing simple data that is monitored for changes.  Allowing more of an
      MVC kind of approach.
* **AbstractVariable<T>**
   - **Description:** 
     - An abstract class for variable management, providing get and set functionality for generic types.

* **BoolVar**
   - **Description:** 
     - A concrete implementation of `AbstractVariable<bool>` for managing boolean variables.

* **FloatVar**
   - **Description:** 
     - A concrete implementation of `AbstractVariable<float>` for managing float variables, with methods for incrementing and decrementing the value.

* **FloatVarWatcher**
   - **Description:** 
     - Watches a `FloatVar` for changes and invokes UnityEvents when the value changes.

* **GameObjectVar**
   - **Description:** 
     - A concrete implementation of `AbstractVariable<GameObject>` for managing GameObject variables.

* **IntVar**
   - **Description:** 
     - A concrete implementation of `AbstractVariable<int>` for managing integer variables, with methods for incrementing and decrementing the value.

* **StringVar**
   - **Description:** 
     - A concrete implementation of `AbstractVariable<string>` for managing string variables.

* **IVariable<T>**
   - **Description:** 
     - An interface defining the structure for variables, including methods for getting and setting values.
