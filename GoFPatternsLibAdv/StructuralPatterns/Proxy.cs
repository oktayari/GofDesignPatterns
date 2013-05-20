using System;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     A proxy, in its most general form, is a class functioning as an interface to something else.
    ///     The proxy could interface to anything: a network connection, a large object in memory,
    ///     a file, or some other resource that is expensive or impossible to duplicate.
    /// </summary>
    internal class ProxyPattern
    {
        public void TestProxy()
        {
            IImage image1 = new ProxyImage("HiRes_10MB_Photo1");
            IImage image2 = new ProxyImage("HiRes_10MB_Photo2");

            image1.DisplayImage(); // loading necessary
            image1.DisplayImage(); // loading unnecessary
            image2.DisplayImage(); // loading necessary
            image2.DisplayImage(); // loading unnecessary
            image1.DisplayImage(); // loading unnecessary
        }

        private interface IImage
        {
            void DisplayImage();
        }

        //on System A 


        //on System B 
        private class ProxyImage : IImage
        {
            private readonly String _filename;
            private RealImage _image;
            /**
             * Constructor
             * @param FILENAME
             */

            public ProxyImage(String filename)
            {
                _filename = filename;
            }

            /**
             * Displays the image
             */

            public void DisplayImage()
            {
                if (_image == null)
                {
                    _image = new RealImage(_filename);
                }
                _image.DisplayImage();
            }
        }

        private class RealImage : IImage
        {
            private readonly String _filename;
            /**
             * Constructor
             * @param FILENAME
             */

            public RealImage(String filename)
            {
                _filename = filename;
                LoadImageFromDisk();
            }

            /**
             * Loads the image from the disk
             */

            /**
             * Displays the image
             */

            public void DisplayImage()
            {
                Console.WriteLine("Displaying " + _filename);
            }

            private void LoadImageFromDisk()
            {
                Console.WriteLine("Loading   " + _filename);
            }
        }
    }
}