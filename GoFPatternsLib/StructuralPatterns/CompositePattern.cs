using System;
using System.Collections;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     IntentCompose objects into tree structures to represent whole-part hierarchies.
    ///     Composite lets clients treat individual objects and compositions of objects uniformly.
    ///     Recursive composition
    ///     “Directories contain entries, each of which could be a directory.”
    ///     1-to-many “has a” up the “is a” hierarchy
    ///     Problem
    ///     Application needs to manipulate a hierarchical collection of “primitive” and “composite” objects.
    ///     Processing of a primitive object is handled one way,
    ///     and processing of a composite object is handled differently.
    ///     Having to query the “type” of each object before attempting to process it is not desirable.
    /// </summary>
    internal class CompositePattern
    {
        // "Component" 
        public void TestCompositePattern()
        {
            // Create a tree structure 
            var root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf 
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree 
            root.Display(1);

            // Wait for user 
            Console.Read();
        }

        private abstract class Component
        {
            protected readonly string Name;

            // Constructor 
            public Component(string name)
            {
                Name = name;
            }

            public abstract void Add(Component c);
            public abstract void Remove(Component c);
            public abstract void Display(int depth);
        }

        // "Composite" 
        private class Composite : Component
        {
            private readonly ArrayList _children = new ArrayList();

            // Constructor 
            public Composite(string name)
                : base(name)
            {
            }

            public override void Add(Component component)
            {
                _children.Add(component);
            }

            public override void Remove(Component component)
            {
                _children.Remove(component);
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + Name);

                // Recursively display child nodes 
                foreach (Component component in _children)
                {
                    component.Display(depth + 2);
                }
            }
        }

        // "Leaf" 
        private class Leaf : Component
        {
            // Constructor 
            public Leaf(string name)
                : base(name)
            {
            }

            public override void Add(Component c)
            {
                Console.WriteLine("Cannot add to a leaf");
            }

            public override void Remove(Component c)
            {
                Console.WriteLine("Cannot remove from a leaf");
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + Name);
            }
        }
    }
}