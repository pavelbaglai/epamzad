using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework_7.Task3
{
    public class URL
    {
        static bool updFlag;

        protected static void ParseUrlString(string[] keyValue, string[] keyValueNew, ref StringBuilder strOutput)
        {
            
            for (int i = 0; i < keyValue.Length; i++)
            {
                if (keyValue[i].Equals(keyValueNew[0]))
                {
                    updFlag = true;
                    strOutput.AppendFormat("{0}={1}&", keyValueNew[0], keyValueNew[1]);
                }
                else
                {
                    strOutput.AppendFormat("{0}={1}&", keyValue[0], keyValue[1]);
                }
                i++;
            }
        }

        protected static void addNewValue(string[] keyValueNew, StringBuilder strOutput)
        {
            if (!updFlag) strOutput.AppendFormat("{0}={1}&", keyValueNew[0], keyValueNew[1]);
        }

        public string AddOrChangeUrlParameter(string url, string str)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentOutOfRangeException(nameof(url));
            if (string.IsNullOrEmpty(str)) throw new ArgumentOutOfRangeException(nameof(str));

            string[] origStr = url.Split('?'); //"www.example.com?key=value&key2=value2" +  "key3=value3" 
            string[] keyValueNew = null;
            string[] keyValue = null;
            string[] sevKeyValue = null;

            StringBuilder strOutput = new StringBuilder(); 
            strOutput.AppendFormat("{0}?", origStr[0]);
            keyValueNew = str.Split('=');       // key3 value3

            if (origStr.Length > 1) // передается с ключами в url или нет //2
            {
                sevKeyValue = origStr[1].Split('&'); // key=value&key2=value2
                if (sevKeyValue.Length > 1)
                {
                    for (int j = 0; j < sevKeyValue.Length; j++)
                    {
                        keyValue = sevKeyValue[j].Split('='); // key value
                        ParseUrlString(keyValue, keyValueNew, ref strOutput);
                    }
                }
                else
                {// key=value
                    keyValue = origStr[1].Split('=');   // key value
                    ParseUrlString(keyValue, keyValueNew, ref strOutput);
                }
            }

            addNewValue(keyValueNew, strOutput);
            return strOutput.ToString().TrimEnd('&');
        }
    }
}