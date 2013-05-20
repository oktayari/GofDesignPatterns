using System;
using System.Collections;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     the iterator pattern is a design pattern in which an iterator is used to traverse a container and
    ///     access the container's elements. The iterator pattern decouples algorithms from containers;
    ///     in some cases, algorithms are necessarily container-specific and thus cannot be decoupled.
    /// </summary>
    internal class IteratorPattern
    {
        public void TestIterator()
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

            Console.ReadKey();
        }

        /// <summary>
        ///     The 'Aggregate' abstract class
        /// </summary>
        private abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        /// <summary>
        ///     The 'ConcreteAggregate' class
        /// </summary>
        private class ConcreteAggregate : Aggregate
        {
            private readonly ArrayList _items = new ArrayList();


            // Gets item count

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


        /// <summary>
        ///     The 'ConcreteIterator' class
        /// </summary>
        private class ConcreteIterator : Iterator
        {
            private readonly ConcreteAggregate _aggregate;

            private int _current;


            // Constructor

            public ConcreteIterator(ConcreteAggregate aggregate)
            {
                _aggregate = aggregate;
            }


            // Gets first iteration item

            public override object First()
            {
                return _aggregate[0];
            }


            // Gets next iteration item

            public override object Next()
            {
                object ret = null;

                if (_current < _aggregate.Count - 1)
                {
                    ret = _aggregate[++_current];
                }


                return ret;
            }


            // Gets current iteration item

            public override object CurrentItem()
            {
                return _aggregate[_current];
            }


            // Gets whether iterations are complete

            public override bool IsDone()
            {
                return _current >= _aggregate.Count;
            }
        }

        /// <summary>
        ///     The 'Iterator' abstract class
        /// </summary>
        private abstract class Iterator
        {
            public abstract object First();

            public abstract object Next();

            public abstract bool IsDone();

            public abstract object CurrentItem();
        }
    }
}