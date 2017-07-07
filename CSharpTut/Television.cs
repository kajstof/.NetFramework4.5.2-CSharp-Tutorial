using System;
namespace CSharpTut
{
    class Television : IElectronicDevice
    {
        public int Volume { get; set; }

        public void Off()
        {
            Console.WriteLine("The TV is Off");
        }

        public void On()
        {
            Console.WriteLine("The TV is On");
        }

        public void VolumeDown()
        {
            if (Volume != 0)
            {
                Volume--;
            }
            Console.WriteLine($"The TV is at {Volume}");
        }

        public void VolumeUp()
        {
            if (Volume != 100)
            {
                Volume++;
            }
            Console.WriteLine($"The TV is at {Volume}");
        }
    }
}
