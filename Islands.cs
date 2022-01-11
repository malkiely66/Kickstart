using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KickStarter
{
    public class Islands
    {
        public static KickStartForm parentForm;
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        private int[,] Island_vals;
        public Islands(KickStartForm form)
        {
            parentForm = form;
        }
        public void LaunchInput(List<string> l_Input)
        {
            int i = 0;
            while (i < l_Input.Count())
            {
                if (l_Input[i] == "")
                {
                    ++i;
                    continue;
                }

                int i_x = Int32.Parse(l_Input[i].Split(' ')[0]);
                int i_y = Int32.Parse(l_Input[i].Split(' ')[1]);
                Island_vals = new int[i_y, i_x];

                if (l_Input.Count() <= (i + i_y))
                {
                    Console.WriteLine(Lo.g(parentForm,$"Invalid Input file"));
                    return;
                }
                ++i;

                for (int y = 0; y < i_y; ++y)
                {
                    string line = l_Input[i];
                    if ((line == "") || (line.Trim().Split(' ').Count() != i_x))
                    {
                        Console.WriteLine(Lo.g(parentForm,$"Invalid Input file"));
                        return;
                    }
                    for (int x = 0; x < i_x; ++x)
                    {
                        int val = Int32.Parse(line.Split(' ')[x]);
                        Island_vals[y,x] = val;
                    }
                    i++;
                }
                Island myIsland = new Island(Island_vals);
                myIsland.CalcIslandMax();
            }
        }
    }

    public class Island
    {
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        private int[,] Island_vals { get; set; }

        public Island()
        {
            Island_vals = new int[2,2];
        }
        public Island(int[,] matrix)
        {
            iHeight = matrix.GetLength(0);
            iWidth = matrix.GetLength(1);
            Island_vals = new int[iHeight, iWidth];
            for (int y = 0; y < iHeight; ++y)
                for (int x = 0; x < iWidth; ++x)
                    Island_vals[y,x] = matrix[y,x];
        }

        public long CalcIslandMax()
        {
            int i_x = this.iWidth;
            int i_y = this.iHeight;
            int[,] maxMat = new int[i_y, i_x];
            bool changed = true;
            int ind = 0;
            string ansMat = "";

            Print.Matrix(this.Island_vals, "Input Mat");

            for (int y = 0; y < i_y; ++y)
                for (int x = 0; x < i_x; ++x)
                    if ((x == 0) || (y == 0) || (x == i_x - 1) || (y == i_y - 1)) maxMat[y, x] = Island_vals[y, x];
                    else maxMat[y, x] = Math.Max(Math.Min(maxMat[y - 1, x], maxMat[y, x - 1]), Island_vals[y, x]);
            Print.Matrix(maxMat, $"Max Mat {ind}");

            while (changed)
            {
                changed = false;
                ind++;

                for (int y = 0; y < i_y; ++y)
                    for (int x = 0; x < i_x; ++x)
                        if (!((x == 0) || (y == 0) || (x == i_x - 1) || (y == i_y - 1)))
                        {
                            int[] nearMaxArr = { maxMat[y+1,x],maxMat[y-1,x],maxMat[y,x+1],maxMat[y,x-1]};
                            Array.Sort(nearMaxArr);
                            if (((nearMaxArr[0] < maxMat[y, x])&&(nearMaxArr[0] > Island_vals[y, x]))||(nearMaxArr[0] < maxMat[y, x]) && (Island_vals[y, x]) < maxMat[y, x])
                            {
                                maxMat[y, x] = Math.Max(nearMaxArr[0], Island_vals[y, x]);
                                changed = true;
                            }
                        }
                ansMat = Print.Matrix(maxMat, $"Max Mat {ind}");
            }

            int count = 0;
            for (int y = 0; y < i_y; ++y)
                for (int x = 0; x < i_x; ++x)
                    if (maxMat[y, x] > Island_vals[y, x])
                        count += maxMat[y, x] - Island_vals[y, x];
            Console.WriteLine(Lo.g($"Answer: {count}{Environment.NewLine}"));
            Console.WriteLine(Lo.g(Islands.parentForm, $"Answer: {count} {Environment.NewLine}" +
                            $"X={i_x},  Y={i_y},  {ind} Iterations.{Environment.NewLine}{Environment.NewLine}" +
                            $"Filled-up Matrix:{Environment.NewLine}" +
                            $"{ansMat}"));

            return count;
        }
    }
}
