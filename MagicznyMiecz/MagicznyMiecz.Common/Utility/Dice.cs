using System;
using System.Threading;

namespace MagicznyMiecz.Common.Utility
{
    public static class Dice
    {
        public static int Throw()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(10+random.Next(5));
            return random.Next(GameConstants.CubeSize) + 1;
        }
    }
}