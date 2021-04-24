using System;

namespace SingletonPattern
{
    //Singleton "idealny" - bezpieczny dla wątków i leniwy
    
    public class Singleton
    {
        public DateTime CreatedAt { get; }
        private Singleton() => CreatedAt = DateTime.Now;

        private static readonly Lazy<Singleton> Lazy = new(() => new Singleton());

        public static Singleton GetInstance() => Lazy.Value;
    }

    //Prawie idealny, ale instancja utworzy się 
    //jak tylko odwołam się w jakikolwiek sposób do klasy (typu Singleton)
    // public class Singleton
    // {
    //     private static readonly Singleton Instance = new();
    //
    //     public DateTime CreatedAt { get; }
    //
    //     private Singleton() => CreatedAt = DateTime.Now;
    //
    //     public static Singleton GetInstance() => Instance;
    // }

    // public class Singleton
    // {
    //     private static object padLock = new();
    //
    //     private static volatile Singleton _instance;
    //
    //     public DateTime CreatedAt { get; }
    //
    //     private Singleton()
    //     {
    //         CreatedAt = DateTime.Now;
    //     }
    //
    //     public static Singleton GetInstance()
    //     {
    //         if (_instance != null)
    //             return _instance;
    //
    //         lock (padLock)
    //         {
    //             if (_instance == null)
    //             {
    //                 _instance = new Singleton();
    //             }
    //         }
    //
    //         return _instance;
    //     }
    // }


    //Słaba efektywność
    // public class Singleton
    // {
    //     private static object padLock = new object();
    //     
    //     private static Singleton _instance;
    //     
    //     public DateTime CreatedAt { get; }
    //     
    //     private Singleton()
    //     {
    //         CreatedAt = DateTime.Now;
    //     }
    //
    //     public static Singleton GetInstance()
    //     {
    //         lock (padLock)
    //         {
    //             if (_instance == null)
    //             {
    //                 _instance = new Singleton();
    //             }
    //         }
    //
    //         return _instance;
    //     }
    // }


    //Tego nie używać w środowisku wielowątkowym
    // public class Singleton
    // {
    //     private static Singleton _instance;
    //     
    //     public DateTime CreatedAt { get; }
    //     
    //     private Singleton()
    //     {
    //         CreatedAt = DateTime.Now;
    //     }
    //
    //     public static Singleton GetInstance()
    //     {
    //         if (_instance == null)
    //         {
    //             _instance = new Singleton();
    //         }
    //
    //         return _instance;
    //     }
    // }
}
