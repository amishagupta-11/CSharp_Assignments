using System;
namespace Conversion
{
    /// <summary>
    /// creating a class for addition operation of binary strings and converting them to the requried value.
    /// </summary>
     public class Binary_Addition
    {
        /// <summary>
        /// creating a method to check whether both strings are of same length or not
        /// </summary>
        /// <param name="firstBinary"></param>  
        /// <param name="secondBinary"></param>
        /// <returns></returns>
        public double AddBinary(string firstBinary, string secondBinary)
        {
            double result = Check_binary(ref firstBinary, ref secondBinary);
            return result;
        }
        /// <summary>
        /// creating a method to make sure that both the strings are of same length by appending zeros at starting and ending
        /// </summary>
        /// <param name="firstBinary"></param>
        /// <param name="secondBinary"></param>
        /// <returns></returns>
        public double Check_binary(ref string firstBinary, ref string secondBinary)
        {
            // declaring the required variables
            int fLen = firstBinary.Length;
            int sLen = secondBinary.Length;
            int i = 0;
            int l = 0;
            int j = fLen-1;
            int k = sLen-1;
            //declaring the strings to store binary values
            string firstStr = "";
            string secondStr= "";
            string thirdStr = "";
            string fourthStr = "";
            //declaring the lengths of each string variable
            int fStrLen = 0;
            int seStrLen = 0;
            int thStrLen = 0;
            int foStrLen = 0;
            while (firstBinary[i]!= '.')
            {
                firstStr=firstStr+firstBinary[i];
                fStrLen += 1;
                i += 1;
            }
            while (secondBinary[l] != '.')
            {
                secondStr = secondStr + secondBinary[l];
                l += 1;
                seStrLen += 1;
            }
            while (firstBinary[j] != '.')
            {
                thirdStr = thirdStr + firstBinary[j];
                j -= 1;
                thStrLen += 1;
            }
            while (secondBinary[k] != '.')
            {
                fourthStr = fourthStr + secondBinary[k];
                k -= 1;
                foStrLen += 1;
            }
            if (firstStr.Length>secondStr.Length)
            {
                for (int loop = 0;loop < fStrLen - seStrLen; loop++)
                {
                    secondStr = '0' + secondStr;
                }
            }
            else
            {
                for (int loop = 0; loop < seStrLen - fStrLen; loop++)
                {
                    firstStr = '0' + firstStr;
                }
            }
            if (thirdStr.Length > fourthStr.Length)
            {
                for (int loop = 0; loop < thStrLen - foStrLen; loop++)
                {
                    fourthStr =  fourthStr+'0';
                }
            }
            else
            {
                for (int loop= 0; loop < foStrLen - thStrLen; loop++)
                {
                    thirdStr = thirdStr + '0';
                }
            }
            firstBinary = firstStr + '.' + thirdStr;
            secondBinary = secondStr + '.' + fourthStr;
            double final_result = add_binary(firstStr, secondStr, thirdStr, fourthStr);
            return final_result;
        }
        /// <summary>
        /// creating a method for adding the binary strings obtained 
        /// </summary>
        /// <param name="firstStr"></param>
        /// <param name="secondStr"></param>
        /// <param name="thirdStr"></param>
        /// <param name="fourthStr"></param>
        /// <returns></returns>
        public double add_binary(string firstStr, string secondStr, string thirdStr, string fourthStr)
        {
            int carry = 0;
            string result = "";
            //Add decimal points of the binary numbers
            for (int i = thirdStr.Length-1; i >= 0; i--)
            {
                if (carry == 0)
                {
                    if (thirdStr[i] == '0' && fourthStr[i] == '0')
                    {
                        if (carry==0)
                        {
                            if (thirdStr[i]=='0'&&fourthStr[i]=='0')
                            {
                                result="0+res1";
                                continue;
                            }
                            else if ((thirdStr[i] == '1' && fourthStr[i] == '0') || (thirdStr[i] == '0' && fourthStr[i] == '1'))
                            {
                                result = "1" + result;
                                carry = 0;
                                continue;
                            }
                            else if ((thirdStr[i] == '1' && fourthStr[i] == '1'))
                            {
                                result = "0" + result;
                                carry = 1;
                                continue;
                            }
                        }
                        else if (carry==1)
                        {
                            if (thirdStr[i] == '0' && fourthStr[i] == '0')
                            {
                                result = "1" + result;
                                carry = 0;
                                continue;
                            }
                            else if ((thirdStr[i] == '1' && fourthStr[i] == '1'))
                            {
                                result = "1" + result;
                                carry = 1;
                                continue;
                            }
                            else if ((thirdStr[i] == '1' && fourthStr[i] == '0') || (thirdStr[i] == '0' && fourthStr[i] == '1'))
                            {
                                result = "0" + result;
                                carry = 1;
                                continue;
                            }
                        }
                    }
                }
            }
                string secRes = "";
                //Add  int values of the binary numbers
                for (int i = firstStr.Length - 1; i >= 0; i--)
                {
                    if (carry == 0)
                    {
                        if (firstStr[i] == '0' && secondStr[i] == '0')
                        {
                            secRes = "0" + secRes;
                            continue;
                        }
                        else if ((firstStr[i] == '1' && secondStr[i] == '1'))
                        {
                            secRes = "0" + secRes;
                            carry = 1;
                            continue;
                        }
                        else if ((firstStr[i] == '1' && secondStr[i] == '0') || (firstStr[i] == '0' && secondStr[i] == '1'))
                        {
                            secRes = "1" + secRes;
                            carry = 0;
                            continue;
                        }
                    }
                    else if (carry == 1)
                    {
                        if (firstStr[i] == '0' && secondStr[i] == '0')
                        {
                            secRes = "1" + secRes;
                            carry = 0;
                            continue;
                        }
                        else if ((firstStr[i] == '1' && secondStr[i] == '0') || (firstStr[i] == '0' && secondStr[i] == '1'))
                        {
                            secRes = "0" + secRes;
                            carry = 1;
                            continue;
                        }
                        else if ((firstStr[i] == '1' && secondStr[i] == '1'))
                        {
                            secRes = "1" + secRes;
                            carry = 1;
                            continue;
                        }
                    }
                }
                secRes= carry + secRes;
                double final_result = BinaryToDecimal(result, secRes);
                return final_result;
            }
        /// <summary>
        /// creating a method for converting binary to required dataType
        /// </summary>
        /// <param name="res1"></param>
        /// <param name="res2"></param>
        /// <returns></returns>
            public double BinaryToDecimal(string res_first, string res_second)
            {
                double int_result = 0;
                int temp = 0;
                for (int i = res_second.Length - 1; i >= 0; i--)
                {
                    if (res_second[i] == '1')
                    {
                        int_result += Math.Pow(2, temp);
                    }
                    temp = temp + 1;
                }
                double decimal_result = 0;
                temp = -1;
                int end = res_first.Length - 1;
                int start = 0;
                while (start <= end)
                {
                    if (res_first[start] == '1')
                    {
                        decimal_result += Math.Pow(2, temp);
                    }

                    start=start+1;
                    temp=temp-1;
                }
                double final_result = 0.0;
                final_result = int_result +decimal_result;
                return final_result;
            }
     }
}
