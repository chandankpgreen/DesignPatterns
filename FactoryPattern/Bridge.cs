using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    interface Device
    {
        bool isEnabled();
        void Enable();
        void Disable();
        int GetVolume();
        void SetVolume(int volume);
        int GetChannel();
        void SetChannel(int channel);

    }
    class Remote
    {
        public Device Device { get; set; }
        public Remote(Device device)
        {
            Device = device;
        }
        public void TogglePower()
        {
            if (Device.isEnabled())
            {
                Device.Disable();
            }
            else
            {
                Device.Enable();
            }
        }
        public void VolumeDown(int volume)
        {
            var devVolume = Device.GetVolume();
            Device.SetVolume(volume + devVolume);

        }
    }

    class Tv : Device
    {
        private int channel;
        private int volume;
        private bool enabled;
        public void Disable()
        {
            enabled = false;
            Console.WriteLine("Tv switched off");
        }

        public void Enable()
        {
            enabled = true;
            Console.WriteLine("Tv switched on");
        }

        public int GetChannel()
        {
            return channel;
        }

        public int GetVolume()
        {
            return volume;
        }

        public bool isEnabled()
        {
            return enabled;
        }

        public void SetChannel(int channel)
        {
            this.channel = channel;
        }

        public void SetVolume(int volume)
        {
            this.volume = volume;
        }
    }

    class Radio : Device
    {
        private int channel;
        private int volume;
        private bool enabled;
        public void Disable()
        {
            enabled = false;
            Console.WriteLine("Radio switched off");
        }

        public void Enable()
        {
            enabled = true;
            Console.WriteLine("Radio switched on");
        }

        public int GetChannel()
        {
            return channel;
        }

        public int GetVolume()
        {
            return volume;
        }

        public bool isEnabled()
        {
            return enabled;
        }

        public void SetChannel(int channel)
        {
            this.channel = channel;
        }

        public void SetVolume(int volume)
        {
            this.volume = volume;
        }
    }

}
