﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MetronomeWPF.Helpers
{
    public static class SoundVolume
    {

        public static uint left;      // Left Volume
        public static uint right;     // Right Volume
        public static uint total      // Total Volume
        {
            get
            {
                return (leftMuted ? 0 : left) + (rightMuted ? 0 : (right << 16));
            }
        }

        public static bool rightMuted = false;  // True if the right volume is muted
        public static bool leftMuted = false;   // True if the left volume is muted
        public static bool soundMuted = false;  // true if the sound is currently muted

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);

        // Public functions
        public static void SetVolume(uint value)
        {
            left  = value;
            right = value;

            WaveOutSetVolume(IntPtr.Zero, total);
            Console.WriteLine("Setting up the sound volume to: " + total);
        }

        public static void Mute()
        {
            soundMuted = true;
            WaveOutSetVolume(IntPtr.Zero, 0);
        }

        public static void Unmute()
        {
            soundMuted = false;
            WaveOutSetVolume(IntPtr.Zero, total);
        }

        public static void MuteRight()
        {
            if (soundMuted == false)
            {
                rightMuted = true;
                WaveOutSetVolume(IntPtr.Zero, total);
            }
                         
        }

        public static void UnmuteRight()
        {
            if (soundMuted == true)
            {
                rightMuted = false;
                WaveOutSetVolume(IntPtr.Zero, total);
            }
        }

        public static void MuteLeft()
        {
            if (soundMuted == false)
            {
                leftMuted = true;
                WaveOutSetVolume(IntPtr.Zero, total);
            }
        }

        public static void UnmuteLeft()
        {
            if (soundMuted == false)
            {
                leftMuted = false;
                WaveOutSetVolume(IntPtr.Zero, total);
            }
        }
    }
}
