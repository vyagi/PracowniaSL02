using System;

namespace SimpleFactoryPattern
{
    public class AnimalFactory
    {
        public Animal Create<T>() where T : Animal, new() => new T();
    }

    // public class AnimalFactory
    // {
    //     public Animal Create(string type)
    //     {
    //         var actualType = Type.GetType("SimpleFactoryPattern." + type);
    //         return (Animal)Activator.CreateInstance(actualType);
    //     }
    // }


    //Nie używać:
    // public class AnimalFactory
    // {
    //     public Animal Create(string type) =>
    //         type.ToUpperInvariant() switch
    //         {
    //             "DOG" => new Dog(),
    //             "CAT" => new Cat(),
    //             "FISH" => new Fish(),
    //             "MONKEY" => new Monkey(),
    //             _ => null
    //         };
    // }
}
