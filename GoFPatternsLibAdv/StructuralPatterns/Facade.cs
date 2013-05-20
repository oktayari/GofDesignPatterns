using System;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     The name is by analogy to an architectural facade.
    ///     A facade is an object that provides a simplified interface to a larger body of code, such as a class library
    /// </summary>
    internal class FacadePattern
    {
        /* Complex parts */

        public void TestFacade()
        {
            var facade = new Computer(12, 12, 12);
            facade.Start();
        }

        private class Computer
        {
            private readonly long _bootAddress;
            private readonly long _bootSector;
            private readonly int _sectorSize;
            private Cpu _processor;
            private Memory _ram;

            public Computer(int sectorSize, long bootSector, long bootAddress)
            {
                _sectorSize = sectorSize;
                _bootSector = bootSector;
                _bootAddress = bootAddress;
                Processor = new Cpu();
                Ram = new Memory();
                Hd = new HardDrive();
            }

            public HardDrive Hd { get; set; }

            public Memory Ram
            {
                get { return _ram; }
                set { _ram = value; }
            }

            public Cpu Processor
            {
                get { return _processor; }
                set { _processor = value; }
            }

            public void Start()
            {
                Cpu.Freeze();
                Memory.Load(_bootAddress, HardDrive.Read(_bootSector, _sectorSize));
                Cpu.Jump(_bootAddress);
                Cpu.Execute();
            }
        }

        private class Cpu
        {
            public static void Freeze()
            {
                Console.WriteLine("Freezing");
            }

            public static void Jump(long position)
            {
                Console.WriteLine("Jumping to " + position);
            }

            public static void Execute()
            {
                Console.WriteLine("Execute");
            }
        }

        private class HardDrive
        {
            public static byte[] Read(long lba, int size)
            {
                Console.WriteLine("read " + lba + "size " + size);
                return new byte[5];
            }
        }

        private class Memory
        {
            public static void Load(long position, byte[] data)
            {
                Console.WriteLine("load " + position + data);
            }
        }

        /* Facade */
    }
}