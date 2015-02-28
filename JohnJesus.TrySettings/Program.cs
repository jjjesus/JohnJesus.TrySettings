using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.TrySettings
{
    class Program
    {
        static void Main(string[] args)
        {
            int frameMax = VideoSettings.FrameMax;
            string videoDir = VideoSettings.VideoDir;

            Console.WriteLine("FrameMax:{0} VideoDir:{1}",
                frameMax, videoDir);


            int gainDb = AudioSettings.GainDB;
            string audioDir= AudioSettings.AudioDir;

            Console.WriteLine("GainDB:{0} AudioDir:{1}",
                gainDb, audioDir);



            Console.WriteLine("Hit ENTER to continue");
            Console.ReadLine();
        }
    }
}
