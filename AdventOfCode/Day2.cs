using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode
{
    public static class Day2
    {
        public static int ProcessDay2(out int ribbon)
        {
            int squareFeet = 0;
            ribbon = 0;

            string filePath = "..\\..\\Data\\Day2.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int packageRibbon = 0;
                    squareFeet += CountArea(line, out packageRibbon);
                    ribbon += packageRibbon;
                }
            }

            return squareFeet;
        }

        static int CountArea(string entry, out int ribbon)
        {
            ribbon = 0;

            if (string.IsNullOrEmpty(entry))
            {
                return 0;
            }

            int area1 = 0;
            int area2 = 0;
            int area3 = 0;
            int minArea = 0;

            List<int> sides = new List<int>();

            string sideNum = "";

            foreach (char c in entry)
            {
                if (c == 'x')
                {
                    sides.Add(int.Parse(sideNum));
                    sideNum = "";
                }
                else
                {
                    sideNum += c;
                }
            }

            sides.Add(int.Parse(sideNum));
            sides.Sort();

            area1 = sides[0] * sides[1];
            area2 = sides[0] * sides[2];
            area3 = sides[1] * sides[2];

            minArea = area1 < area2 ? area1 : area2;
            minArea = minArea < area3 ? minArea : area3;

            ribbon = 2 * sides[0] + 2 * sides[1];
            ribbon += sides[0] * sides[1] * sides[2];
            
            return 2 * area1 + 2 * area2 + 2 * area3 + minArea;
        }
    }
}
