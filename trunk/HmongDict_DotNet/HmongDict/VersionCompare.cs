using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HmongDict
{
    class VersionCompare
    {
        public enum CompareResult
        {
            Less,
            Identical,
            Greater
        }

        public static CompareResult Compare(string strVerLeft, string strVerRight)
        {
            int[] nArrVerLeft = new int[4];
            int[] nArrVerRight = new int[4];

            string[] strArrVerLeft = strVerLeft.Split('.');
            for (int i = 0; i < 4; i++)
            {
                nArrVerLeft[i] = int.Parse(strArrVerLeft[i]);
            }

            string[] strArrVerRight = strVerRight.Split('.');
            for (int i = 0; i < 4; i++)
            {
                nArrVerRight[i] = int.Parse(strArrVerRight[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                if (nArrVerLeft[i] > nArrVerRight[i])
                    return CompareResult.Greater;

                if (nArrVerLeft[i] < nArrVerRight[i])
                    return CompareResult.Less;
            }

            return CompareResult.Identical;
        }
    }
}
