using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPFEx3.Models
{
    public class MultipleModel
    {
        public Array Numbers { get; set; }

        public class Result
        {
            public Result(string number, bool isMultiple)
            {
                this.Number = number;
                this.IsMultiple = isMultiple;
            }
            public string Number { get; set; }
            public bool IsMultiple { get; set; } 
        }

        public MultipleModel(string inputJson)
        {
            var obj = JObject.Parse(inputJson);
            this.Numbers = obj["numbers"].ToArray();
        }

        public string GetMultipleResult()
        {
            if(this.Numbers != null && this.Numbers.Length > 0)
            {
                List<Result> resultList = new List<Result>();
                foreach(JToken s in this.Numbers)
                {
                    int i = int.Parse(s.ToString());
                    Result res = new Result(s.ToString(), CheckIsMultiple(i));
                    resultList.Add(res);
                }

                return JsonConvert.SerializeObject(resultList);
            }
            return null;
        }

        private bool CheckIsMultiple(int number)
        {
            string sNum = string.Empty;
            if(number > 10)
            {
                do
                {
                    sNum = number.ToString();
                    string strLast = sNum.Substring(sNum.Length - 1, 1);
                    sNum = sNum.Substring(0, sNum.Length-1);
                    int iFirst = int.Parse(sNum);
                    int iSecond = int.Parse(strLast);
                    number = iFirst - iSecond;
                } while (sNum.Length != 2);
                return number % 11 == 0;
            }
            return false;
        }
    }
}