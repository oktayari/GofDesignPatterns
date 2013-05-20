using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     A flyweight is an object that minimizes memory use by sharing as much data as possible with other
    ///     similar objects; it is a way to use objects
    ///     in large numbers when a simple repeated representation would use an unacceptable amount of memory.
    /// </summary>
    internal class Flyweigth
    {
        public class CoffeeFlavour
        {
            private readonly string _flavour;

            public CoffeeFlavour(string flavour)
            {
                _flavour = flavour;
            }

            public string Flavour
            {
                get { return _flavour; }
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is CoffeeFlavour && Equals((CoffeeFlavour) obj);
            }

            public bool Equals(CoffeeFlavour other)
            {
                return string.Equals(_flavour, other._flavour);
            }

            public override int GetHashCode()
            {
                return (_flavour != null ? _flavour.GetHashCode() : 0);
            }

            public static bool operator ==(CoffeeFlavour a, CoffeeFlavour b)
            {
                return Equals(a, b);
            }

            public static bool operator !=(CoffeeFlavour a, CoffeeFlavour b)
            {
                return !Equals(a, b);
            }
        }

        public class TestFlyWeight
        {
            public interface ICoffeeFlavourFactory
            {
                CoffeeFlavour GetFlavour(string flavour);
            }

            public class MinimumMemoryFootprint : ICoffeeFlavourFactory
            {
                private readonly ConcurrentDictionary<string, CoffeeFlavour> _cache =
                    new ConcurrentDictionary<string, CoffeeFlavour>();

                public CoffeeFlavour GetFlavour(string flavour)
                {
                    return _cache.GetOrAdd(flavour, flv => new CoffeeFlavour(flv));
                }
            }

            public class ReducedMemoryFootprint : ICoffeeFlavourFactory
            {
                private readonly IDictionary<string, CoffeeFlavour> _cache = new Dictionary<string, CoffeeFlavour>();
                private readonly object _cacheLock = new object();

                public CoffeeFlavour GetFlavour(string flavour)
                {
                    if (_cache.ContainsKey(flavour)) return _cache[flavour];
                    var coffeeFlavour = new CoffeeFlavour(flavour);
                    ThreadPool.QueueUserWorkItem(AddFlavourToCache, coffeeFlavour);
                    return coffeeFlavour;
                }

                private void AddFlavourToCache(object state)
                {
                    var coffeeFlavour = (CoffeeFlavour) state;
                    if (_cache.ContainsKey(coffeeFlavour.Flavour)) return;

                    lock (_cacheLock)
                    {
                        if (!_cache.ContainsKey(coffeeFlavour.Flavour))
                            _cache.Add(coffeeFlavour.Flavour, coffeeFlavour);
                    }
                }
            }
        }
    }
}