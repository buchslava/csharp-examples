using Animals;

namespace Animals
{
    enum Mood
    {
        Hungry,
        Happy
    }
    abstract class Animal
    {
        public string name;

        public Animal(string namePar)
        {
            name = namePar;
        }

        public abstract string WhoAmI();
        public abstract string MyStory();
    }

    abstract class Mammal : Animal
    {
        protected Mood mood;
        public Mammal(string namePar) : base(namePar)
        {
            mood = Mood.Hungry;
        }
        public abstract string Sound();


        public override string WhoAmI()
        {
            return "Mammal";
        }

        public void Feed()
        {
            mood = Mood.Happy;
        }
        public void MakeMyHungry()
        {
            mood = Mood.Hungry;
        }
        public override string MyStory()
        {
            return "My name is " + name + " and " + (mood == Mood.Happy ? "I'm happy;)" : "I want to eat! Also, I want to tell you " + Sound() + "!!!");
        }

    }

    class Dog : Mammal
    {
        public Dog(string namePar) : base(namePar)
        { }

        public override string WhoAmI()
        {
            return base.WhoAmI() + " Dog";
        }
        public override string Sound()
        {
            return "BARK";
        }

    }

    class Cat : Mammal
    {
        public Cat(string namePar) : base(namePar)
        { }

        public override string WhoAmI()
        {
            return base.WhoAmI() + " Cat";
        }
        public override string Sound()
        {
            return "MEOW";
        }

    }

    class Reptile : Animal
    {
        public Reptile(string namePar) : base(namePar)
        { }

        public override string WhoAmI()
        {
            return "Reptile";
        }

        public override string MyStory()
        {
            return "My name is " + name + ". I'm a " + WhoAmI();
        }

    }

}

class OopDemo
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Snoopy");
        System.Console.WriteLine(dog.MyStory());
        dog.Feed();
        System.Console.WriteLine(dog.MyStory());

        Cat cat = new Cat("Basil");
        System.Console.WriteLine(cat.MyStory());
        cat.Feed();
        System.Console.WriteLine(cat.MyStory());
        cat.MakeMyHungry();

        System.Console.WriteLine("---");

        Animal[] animals = new Animal[] { cat, dog, new Reptile("Lizard") };
        foreach (Animal animal in animals)
        {
            System.Console.WriteLine(animal.MyStory());
        }

    }
}
