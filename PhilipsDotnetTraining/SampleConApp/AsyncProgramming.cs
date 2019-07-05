using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;
/*
* If U want one or more functions to be running parallelly within the application without waiting for the function to complete is called as Async Programming. 
* Most of the time, functions are synchronous.
*/
namespace SampleConApp
{
    //Another advantage of delegate is that it can facilitate to invoke the associated method asynchronously. 
    class AsyncProgramming
    {

        static void ThreadFunc()
        {
            //lock is a keyword in C# for Monitor object of the .NET which performs the locking pattern on a given resource. In this case, only one thread which first gets hold of the resource will have a control on it while the other threads have to wait till the holding thread completes or exits the block. This blocks a  section of the code, hense the name CRITICAL SECTION. Monitor is the class the implements CRITICAL SECTION in .NET. 
            //Use Semaphore(More than one but upto a limit), Mutex which is for multi processes..
            lock (typeof(AsyncProgramming))
            {
                string file = "SampleFile.txt";
                int count = new StreamReader(file).ReadToEnd().Length;
                int half = (int)count / 2;
                using (StreamReader reader = new StreamReader(file))
                {
                    //                int index = 0; 
                    while (!reader.EndOfStream)
                    {
                        char value = (char)reader.Read();
                        Console.Write(value);
                        Thread.Sleep(50);
                        //if (index == half)
                        //    Thread.CurrentThread.Suspend();
                        //                   index++;
                    }
                }
            }
        }
        static void AsyncFunction()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Looping job with beep#" + i);
                Console.Beep();
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            //asyncUsingDelegate();
            //asyncUsingThread();
            //TwoThreadsReadingFile();
            Thread t1 = new Thread(() =>
            {
                ThreadFunc();
            });
            Thread t2 = new Thread(ThreadFunc);
            t1.Start();
            t2.Start();
        }

        private static void TwoThreadsReadingFile()
        {
            Thread th = new Thread(ThreadFunc);
            th.Start();
            Console.WriteLine("Main Thread is reading other file....");
            StreamReader reader = new StreamReader(@"C:\Users\phani\source\repos\PhilipsDotnetTraining\SampleConApp\AsyncProgramming.cs");
            do
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
                Thread.Sleep(100);
            } while (!reader.EndOfStream);
            Console.WriteLine("[Main has completed, now lets resume the thread");
            if (th.ThreadState == ThreadState.Suspended)
            {
                th.Resume();
            }
        }

        private static void asyncUsingThread()
        {
            /*A path of  Execution is called Thread. Every process will have a Thread. 
             * Process is a boundary and thread is the path of execution within the boundary.
             * OS supports multiple paths of execution within a process. This is called as Multi Threading. Older apps that used to run on 32 bit Platforms used to create Threads for Resource Management as they were running on single processor and they needed to perform the tasks symultaneously so that they can manage the time slice given by the processor. This kind of processing was called Preemtive multitasking.
             * Thread is programmatically represented by a class called System.Thread. This class has both static and instance methods to create, maintain and process the threads that U create. 
             */
            Thread th = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Thread Beep#" + i);
                    Console.Beep();
                    Thread.Sleep(1000);
                }
            });
            //th.IsBackground = true;
            th.Start();//Starts the thread and invokes the function associated with the Thread. THe Thread object is associated with a Thread Function thro a delegate called ThreadStart. 
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("[Main] is doing someother operation");
                Thread.Sleep(1000);
            }
        }

        private static void asyncUsingDelegate()
        {
            AsyncFunction();//To invoke a method in a synchronous way(Normal way)..
            asyncCallExample1();//invoke a method that is void...
            asyncCallExample2();//Invoke method which returns a value...
            asyncCallAndCallBack();
        }

        private static void asyncCallAndCallBack()
        {
            Func<int, int, int> myFunc = GetBigResult;
            var aRes = myFunc.BeginInvoke(3, 2, (res) =>
            {
                AsyncResult obj = res as AsyncResult;
                Func<int, int, int> actual = obj.AsyncDelegate as Func<int, int, int>;
                var actualResult = actual.EndInvoke(res);
                Console.WriteLine("The Result of this Async func is " + actualResult);
            }, null);
            
            while(aRes.IsCompleted == false)
            {
                Console.WriteLine("Please wait....");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Main has completed its Task");
        }
        private static int GetBigResult(int v1, int v2) 
        {
            var res = 0;
            for (int i = 0; i< 10; i++)
            {
                res += v1* v2 + i;
                Console.WriteLine("Doing some proessing");
                Thread.Sleep(1000);
            }
            return res;
        }
        private static void asyncCallExample2()
        {
            Func<int, int, int> someFunc = GetBigResult;
            var aRes = someFunc.BeginInvoke(2, 3, null, null);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main doing some job...");
                Thread.Sleep(500);
            }
            var result = someFunc.EndInvoke(aRes);
            Console.WriteLine("The Result of this Async func is " + result);
            Console.WriteLine("End of the Main method, closing the App....");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
        }

        private static void asyncCallExample1()
        {
            Action act = AsyncFunction;

            var asyncResult = act.BeginInvoke(null, null);//BeginInvoke method of the Delegate will make UR function invoked asynchronously....
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main is also doing some job");
                Thread.Sleep(1000);
            }
            //Once the Main completes the job, all the async operations will automatically die...
            Console.WriteLine("Main is waiting.....");
            act.EndInvoke(asyncResult);
            Console.WriteLine("End of Main");
            //EndInvoke is responsible to make the Main Function wait till the job is completed. The Arg passed IAsyncResult will be helping the function to determine whether the Async function is completed or not...
        }
    }
}
