using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickStarter
{
    class Regions
    {
        public static KickStartForm parentForm;
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public Regions(KickStartForm form)
        {
            parentForm = form;
        }
        public void LaunchInput(int[][] in2dArr)
        {
            int n = in2dArr[0].Length;

            Region myReg = new Region(parentForm, in2dArr);
            myReg.CalcRegions(in2dArr);
        }
    }
    public class Region
    {
        public static KickStartForm parentForm;
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public long counter = 0;

        public Region(KickStartForm form, int[][] matrix)
        {
            parentForm = form;
            iHeight = matrix.Length;
            iWidth = matrix[0].Length;
        }

        public long CalcRegions(int[][] in2dArr)
        {
            if (iHeight == 0)
                return 0;
            return CalcRegions(in2dArr, 1, 0, 0);
        }
        public int CalcRegions(int[][] matrix, int maxReg, int h, int w)
        {
            counter++;
            if (matrix[h][w] == 1)
            {
                ++maxReg;
                MarkAllNegbours(matrix, maxReg, h, w);
            }
            if (w < iWidth - 1)
                return CalcRegions(matrix, maxReg, h, w + 1);
            else if (h < iHeight - 1)
                return CalcRegions(matrix, maxReg, h + 1, 0);
            else
            {
                parentForm.Output_txt.Text = $"maxReg=={maxReg - 1}, counter={counter}, h={h}, w={w} {Environment.NewLine}";
                parentForm.Output_txt.Text += Print.Matrix(matrix, $"matrix[h][w] == 0, last cell");
                return maxReg - 1;
            }
        }

        public void MarkAllNegbours(int[][] matrix, int maxReg, int h, int w)
        {
            counter++;
            if (matrix[h][w] == 1)
            {
                matrix[h][w] = maxReg;

                if (h > 0 && matrix[h - 1][w] == 1)
                    MarkAllNegbours(matrix, maxReg, h - 1, w);

                if (h < matrix.Length -1 && matrix[h + 1][w] == 1)
                    MarkAllNegbours(matrix, maxReg, h + 1, w);

                if (w > 0 && matrix[h][w - 1] == 1)
                    MarkAllNegbours(matrix, maxReg, h, w - 1);

                if (w < matrix[0].Length - 1 && matrix[h][w + 1] == 1)
                    MarkAllNegbours(matrix, maxReg, h, w + 1);
            }
        }
    }
}

