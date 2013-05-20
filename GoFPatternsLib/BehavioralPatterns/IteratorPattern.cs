using System;
using System.Collections;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Provide a way to access the elements of an aggregate object sequentially
    ///     without exposing its underlying representation.
    ///     The C++ and Java standard library abstraction that makes it
    ///     possible to decouple collection classes and algorithms.
    ///     Promote to “full object status” the traversal of a collection.
    ///     Polymorphic traversal
    ///     Problem Need to “abstract” the traversal of wildly different data structures
    ///     so that algorithms can be defined that are capable of interfacing with each transparently.
    /// </summary>
    internal class IteratorPattern
    {
        // "Aggregate" 
        public void TestIteratorPattern()
        {
            var a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate 
            var i = new ConcreteIterator(a);

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user 
            Console.Read();
        }

        private abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        // "ConcreteAggregate" 
        private class ConcreteAggregate : Aggregate
        {
            private readonly ArrayList _items = new ArrayList();

            // Property 
            public int Count
            {
                get { return _items.Count; }
            }

            // Indexer 
            public object this[int index]
            {
                get { return _items[index]; }
                set { _items.Insert(index, value); }
            }

            public override Iterator CreateIterator()
            {
                return new ConcreteIterator(this);
            }
        }

        // "Iterator" 

        // "ConcreteIterator" 
        private class ConcreteIterator : Iterator
        {
            private readonly ConcreteAggregate _aggregate;
            private int _current;

            // Constructor 
            public ConcreteIterator(ConcreteAggregate aggregate)
            {
                this._aggregate = aggregate;
            }

            public override object First()
            {
                return _aggregate[0];
            }

            public override object Next()
            {
                object ret = null;
                if (_current < _aggregate.Count - 1)
                {
                    ret = _aggregate[++_current];
                }

                return ret;
            }

            public override object CurrentItem()
            {
                return _aggregate[_current];
            }

            public override bool IsDone()
            {
                return _current >= _aggregate.Count;
            }
        }

        private abstract class Iterator
        {
            public abstract object First();
            public abstract object Next();
            public abstract bool IsDone();
            public abstract object CurrentItem();
        }
    }
}