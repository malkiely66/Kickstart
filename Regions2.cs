using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickStarter
{
    class Regions2
    {
        public static KickStartForm parentForm;
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public Regions2(KickStartForm form)
        {
            parentForm = form;
        }
        public void LaunchInput2(int[][] in2dArr)
        {
            int n = in2dArr[0].Length;

            Region2 myReg = new Region2(parentForm, in2dArr);
            myReg.CalcRegions(in2dArr);
        }
    }
    public class Region2
    {
        public static KickStartForm parentForm;
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public long counter=0;

        public Region2(KickStartForm form, int[][] matrix2)
        {
            parentForm = form;
            iHeight = matrix2.Length;
            iWidth = matrix2[0].Length;
        }

        public long CalcRegions(int[][] in2dArr)
        {
            if (iHeight == 0)
                return 0;
            return CalcRegions(in2dArr, 1, 0, 0);
        }
        public int CalcRegions(int[][] matrix2, int maxReg, int h, int w)
        {
            int neigboursMin;
            counter++;

            if (matrix2[h][w] == 0)
            {
                if (w < iWidth - 1)
                    return CalcRegions(matrix2, maxReg, h, w + 1);
                else if (h < iHeight - 1)
                    return CalcRegions(matrix2, maxReg, h + 1, 0);
                else
                {
                    parentForm.Output_txt.Text = $"maxReg=={maxReg - 1}, counter={counter}, h={h}, w={w} {Environment.NewLine}";
                    parentForm.Output_txt.Text += Print.Matrix(matrix2, $"matrix2[h][w] == 0, last cell");
                    return maxReg - 1;
                }
            }
            else /// matrix2[h][w] > 0
            {
                neigboursMin = GetNegboursMin(matrix2, h, w);

                if (neigboursMin == 999)
                {
                    if (matrix2[h][w] == 1)
                    {
                        matrix2[h][w] = ++maxReg;
                        Print.Matrix(matrix2, $"matrix2[h][w] == 1, neigboursMin == 999,  counter={counter}, h={h}, w={w}, maxReg=={maxReg}");
                    }
                    else
                        if (matrix2[h][w] > maxReg) maxReg++;
                        // maxReg = Math.Max(maxReg, matrix2[h][w]);

                    if (w < iWidth - 1)
                        return CalcRegions(matrix2, maxReg, h, w + 1);
                    else if (h < iHeight - 1)
                        return CalcRegions(matrix2, maxReg, h + 1, 0);
                    else
                    {
                        parentForm.Output_txt.Text = $"maxReg=={maxReg - 1}, counter={counter}, h={h}, w={w} {Environment.NewLine}";
                        parentForm.Output_txt.Text += Print.Matrix(matrix2, $"matrix2[h][w] > 1, neigboursMin == 999 || neigboursMin == matrix2[h][w]");
                        return maxReg - 1;
                    }
                }
                else // neigboursMin > 0
                {
                    if (neigboursMin > matrix2[h][w] && matrix2[h][w] > 1)
                    {
                        if (h > 0 && matrix2[h - 1][w] > matrix2[h][w])
                        {
                            matrix2[h - 1][w] = matrix2[h][w];
                            Print.Matrix(matrix2, $"neigboursMin > matrix2[h][w], matrix2[h - 1][w] > 0,  counter={counter}, h={h}, w={w}, maxReg=={maxReg}");
                            return CalcRegions(matrix2, 1, 0, 0);
                        }
                        if (w > 0 && matrix2[h][w - 1] > matrix2[h][w])
                        {
                            matrix2[h][w - 1] = matrix2[h][w];
                            Print.Matrix(matrix2, $"neigboursMin > matrix2[h][w], matrix2[h - 1][w] > 0,  counter={counter}, h={h}, w={w}, maxReg=={maxReg}");
                            return CalcRegions(matrix2, 1, 0, 0);
                        }

                        Print.Matrix(matrix2, $"neigboursMin > matrix2[h][w], counter={counter}, h={h}, w={w}, maxReg=={maxReg}");
                        return CalcRegions(matrix2, 1, 0, 0);
                    }
                    else if (neigboursMin == matrix2[h][w])
                    {
                        if (w < iWidth - 1)
                            return CalcRegions(matrix2, maxReg, h, w + 1);
                        else if (h < iHeight - 1)
                            return CalcRegions(matrix2, maxReg, h + 1, 0);
                        else
                        {
                            parentForm.Output_txt.Text = $"maxReg=={maxReg - 1}, counter={counter}, h={h}, w={w} {Environment.NewLine}";
                            parentForm.Output_txt.Text += Print.Matrix(matrix2, $"neigboursMin > 0, neigboursMin == matrix2[h][w]");
                            return maxReg - 1;
                        }
                    }
                    else /// (neigboursMin < matrix2[h][w] 
                    {
                        matrix2[h][w] = neigboursMin;
                        if (h > 0 && matrix2[h - 1][w] > matrix2[h][w])
                        {
                            matrix2[h - 1][w] = matrix2[h][w];
                        }
                        if (w > 0 && matrix2[h][w - 1] > matrix2[h][w])
                        {
                            matrix2[h][w - 1] = matrix2[h][w];
                        }
                        Print.Matrix(matrix2, $"neigboursMin < matrix2[h][w], counter={counter}, h={h}, w={w}, maxReg=={maxReg}");
                        return CalcRegions(matrix2, 1, 0, 0);
                    }
                }
            }
        }

        public int GetNegboursMin(int[][] matrix2, int h, int w)
        {
            counter++;
            int tempMin = 999;
            if (h > 0 && matrix2[h - 1][w] > 1)
                tempMin = Math.Min(tempMin, matrix2[h - 1][w]);

            if (w > 0 && matrix2[h][w-1] > 1)
                tempMin = Math.Min(tempMin, matrix2[h][w-1]);

            return tempMin;
        }        
    }
}

