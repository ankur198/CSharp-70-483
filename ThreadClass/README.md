# Thread Class

## Short notes for myself

- Making background thread will allow parent thread to end before finishing background thread
- Thread can be parameterized or non parameterized
- ThreadStatic is for static variables only, it always have default value
- ThreadLocal<T> is for local variable which can be initialized
- ThreadPool 
    - Add WaitCallback interface into queue
    - It should have only object as parameter
    - Additional data can be retrieved from object sent during queue as second parameter