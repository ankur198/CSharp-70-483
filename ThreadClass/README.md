# Thread Class

## Short notes for myself

- Simple Thread
  - Non Parameterized

    ```csharp
    var t = new Thread(new ThreadStart(<NonParameterizedThreadMethod>));
    t.start();
    ```

  - Parameterized
    Method should take object as a parameter and then cast it inside.

    ```csharp
    var t = new Thread(new ThreadStart(<ParameterizedThreadMethod>));
    t.start(object args);
    ```

- Making background thread will allow parent thread to end before finishing background thread
  
  ```csharp
  Thread t = new Thread();
  t.IsBackground = true;
  ```

- ThreadStatic is for static variables only, it always have default value
  
  ```csharp
  [ThreadStatic] //this makes _field local to each thread
  static int _field;
  ```

- `ThreadLocal<T>` is for local variable which can be initialized

  ```csharp
  ThreadLocal<int> _field =new ThreadLocal<int>(() =>Thread.CurrentThread.ManagedThreadId);  
  ```

- ThreadPool
  - Add WaitCallback interface into queue
  - It should have only object as parameter
  - Additional data can be retrieved from object sent during queue as second parameter

    ```csharp
    ThreadPool.QueueUserWorkItem(ThreadPoolThread, "asd"); //with data
    ThreadPool.QueueUserWorkItem(ThreadPoolThread); //without data
    ```
