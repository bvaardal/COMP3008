﻿namespace MetronomeWPF.Components
{
    class TimeSignature
    {
        public int BeatsPerBar { get; private set; }
        public int BeatLength { get; private set; }
        public int TotalBeats
        {
            get
            {
                return BeatLength * BeatsPerBar;
            }
        }


        public TimeSignature(int beatsPerBar, int beatLength)
        {
            BeatsPerBar = beatsPerBar;
            BeatLength = beatLength;
        }
    }
}
