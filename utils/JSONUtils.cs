using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tools
{
    public class JSONUtils
    {
        /**
         * 格式化json
         * 
         */
        public static string formatJson(string sourceStr) 
        {
            string str = "";
            //判断josn数据时数组还是对象
            if (sourceStr.StartsWith("["))
            {
                var arr = JArray.Parse(sourceStr);
                str = arr.ToString();
            }
            else if (sourceStr.StartsWith("{"))
            {
                var obj = JObject.Parse(sourceStr);
                str = obj.ToString();
            }
            else
            {
                throw new Exception("错误的json");
            }
            return str;

        }

        /**
         * 
         * 生成java对象
         */
        public static string generateJavaObjectStr(string sourceStr,GenerateClass prop){
            string str = "";
            try { 
                if (sourceStr.StartsWith("["))
                {
                    var arr = JArray.Parse(sourceStr);
                    JToken token = arr[0];
                    if (token != null && token is JObject obj)
                    {
                        str = generate(obj, prop);
                    }
                    else
                    {
                        return null;
                    }
                }else if (sourceStr.StartsWith("{")){
                    var obj = JObject.Parse(sourceStr);
                    str = generate(obj, prop);
                }
            } catch(Exception e) {
                throw e;
            }
            
            return str;
        }

        private static string generate(JObject obj, GenerateClass prop)
        {
            var list=new List<string>();
            string objStr = generateHeader(prop);
            objStr += "public class " + prop.getName() + "{\r\n";
            var keys = obj.Properties().Select(p => p.Name).ToList();
            keys.ForEach(p =>
            {
                var type = obj[p].Type;
                var javaType = "String";
                switch (type)
                {
                    case JTokenType.Date:
                        javaType = "Date";
                        break;
                    case JTokenType.Integer:
                        javaType = "Integer";
                        break;
                    case JTokenType.Float:
                        javaType = "float";
                        break;
                    case JTokenType.Object:
                        var childObj = (JObject)obj[p];
                        changeJavaName(p,prop);
                        list.Add(generate(childObj, prop));
                        break;
                    case JTokenType.Array:
                        var childArray = (JArray)obj[p];
                        JToken token = childArray[0];
                        if (childArray != null && token is JObject o) {
                            changeJavaName(p, prop);
                            list.Add(generate(o, prop));
                        }
                        break;
                    case JTokenType.Null:
                    default:
                        break;
                }
                objStr += "     private " + javaType + " " + p.Trim().Replace("\"", "") + ";\r\n";
            });
            objStr += "}\n\n\n";

            if (list.Count() > 0)
            {
                list.ForEach(data =>
                {
                    objStr += data;
                });
            }
            

            return objStr;
        }
        private static void changeJavaName(string p, GenerateClass prop)
        {
            var cName = p.ToLower();
            var length=cName.Length;
            var firstName = cName.Substring(0, 1).ToUpper();
            firstName += cName.Substring(1);
            prop.setName(firstName);
        }

        /**
        * 
        * 生成头部信息
        */
        private static string generateHeader(GenerateClass prop)
        {
            string objStr = "import lombok.Data;\r\nimport lombok.AllArgsConstructor;\r\nimport lombok.NoArgsConstructor;\r\n\r\n";
            var date = new DateTime();
            string dateStr = date.ToString("yyyy-MM-dd HH:mm:ss");
            objStr += "/**\r\n * @Description TODO\r\n * @Author " + prop.getAuthor() + "\r\n * @DATA " + dateStr + "\r\n */\r\n";
            objStr += "@Data\r\n@NoArgsConstructor\r\n@AllArgsConstructor\r\n";
            return objStr;
        }
    }
}
