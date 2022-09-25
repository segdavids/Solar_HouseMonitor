using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace solar_monitor.Models
{
    public class Basics
    {
    }

    public class Goat
    {
        public int id { get; set; }
        public string Name { get; set; }

        //public Goat(string id, string name)
        //{
        //    id = this.id.ToString();

        //}
        public void Getgoat()
        {
            var gotten = new Goat();
            gotten.id = 2;
            gotten.Name = "Test goat";
        }
    }

    //  encaosulation is protecting or hiding data about a class from the public using identifiers access modifiers
    // inheritance when a child class inherits the attributes of a base class 

    class Dust : Goat
    {

        public Dust(string id, string name)
        {

        }
        
    }

    class Animal
    {
        public virtual void animalsound()
        {
            Console.Write("the animal makes a sound");
        }
    }

    class Dog : Animal
    {

    }
    class program
    {
        static void Main(string[] args)
        {
            Dust t = new Dust("femi","ok");
            t.Getgoat();
            var dg = new Dog();
            dg.animalsound();
        }
    }
}