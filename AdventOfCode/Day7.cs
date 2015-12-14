using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day7
    {
        enum LightMode
        {
            ON,
            OFF,
            TOGGLE
        };

        const int maxX = 1000;
        const int maxY = 1000;

        static BitArray[] lights = new BitArray[maxY];
        static int[,] brightLights = new int[maxX, maxY];

        public static int ProcessDay7(out long count2)
        {
            int count = 0;
            count2 = 0;

            string filePath = "..\\..\\Data\\Day7.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                }
            }

            return count;
        }
    }
}

