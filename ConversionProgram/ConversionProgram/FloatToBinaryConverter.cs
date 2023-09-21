using System;
namespace Conversion
{
    /// <summary>
    // creating a class for converting float values into binary value
    /// </summary>
    public class FloatToBinConverter
    {
        /// <summary>
        /// creating method for separating integral and decimal part from float value
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
         public string FloatToBinary(double m)
         {
            //finding integer value
            int value = (int)m;
            //finding decimal value
            double decimalValue=m-value; 
            decimalValue=Math.Round(decimalValue,10);
            //calling method for respective conversions
            string int_bin = IntToBinary(value);
            string float_bin = DecimalToBinary(decimalValue);
            //returning the value
            return int_bin+'.'+float_bin;
         }
        /// <summary>
        /// creating method for converting integer part to binary
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public string IntToBinary(int val)
        {
            string temp = "";
            string int_binary = "";
            while(val>0)
            {
                temp=temp+(val%2);
                val=val/2;
            }
            int right = temp.Length-1;
            while (right>=0)
            {
                int_binary=int_binary+temp[right];
                right--;
            }
            return int_binary;
        }
        /// <summary>
        /// creating a method for conversion of decimal part into binary and appending it to a list.
        /// </summary>
        /// <param name="deciVal"></param>
        /// <returns></returns>
        public string DecimalToBinary(double deciVal)
        {
            string temp = "";
            string deci_binary;
            string result = "";
            List<double> vals=new List<double>();
            vals.Add(deciVal);
            //iterating over the decimal value to find its respective binary value
            while (deciVal>0)
            {
                deciVal=deciVal*2;
                deciVal=Math.Round(deciVal,10);
                if (deciVal>=1)
                {
                    if(vals.Contains(deciVal-1))
                    {
                        break;
                    }
                    else
                    {
                        temp=temp+("1");
                        deciVal=deciVal-1;
                        vals.Add(deciVal);
                    }
                }
                else
                {
                    temp=temp+("0");
                    deciVal=deciVal-1+1;
                    vals.Add(deciVal);
                }
            }
            deci_binary='.'+temp;
            for(int i = 1; i<deci_binary.Length; i++)
            {
                result+=deci_binary[i];
            }
            //returing the result
            return result;
        }
    }
}
