using CodeTools.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

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

        /**
         * 
         * 生成java对象
         */
        public static string generateCSharpObjectStr(string sourceStr, GenerateClass prop)
        {
            string str = "";
            try
            {
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
                }
                else if (sourceStr.StartsWith("{"))
                {
                    var obj = JObject.Parse(sourceStr);

                    str = generate(obj, prop);
                }
            }
            catch (Exception e)
            {
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
            string objStr = "import lombok.Setter;\r\nimport lombok.Getter;\r\nimport lombok.AllArgsConstructor;\r\nimport lombok.NoArgsConstructor;\r\n\r\n";
            var date = new DateTime();
            string dateStr = date.ToString("yyyy-MM-dd HH:mm:ss");
            objStr += "/**\r\n * @description TODO\r\n * @author " + prop.getAuthor() + "\r\n * @DATA " + dateStr + "\r\n */\r\n";
            objStr += "@Setter \r\n@Getter \r\n @NoArgsConstructor\r\n @AllArgsConstructor\r\n";
            return objStr;
        }

        public static string toProperties(JObject data)
        {
            var propStr = new StringBuilder();
            render(propStr,"",-1, data);
            return propStr.ToString();
        }


        private static void render(StringBuilder propStr,string prekey,int mask, JObject data) {
            data.Properties().ToList().ForEach(p =>
            {
                var nextKey = new StringBuilder();
                nextKey.Append(prekey)
                        .Append(p.Name);
                var value = p.Value;
                var type = data[p.Name].Type;
                switch (type)
                {
                    case JTokenType.Object:
                        var childObj = (JObject)data[p.Name];
                        render(propStr,nextKey.Append(".").ToString(),-1, childObj);
                        break;
                    case JTokenType.Array:
                        var childArray = (JArray)data[p.Name];
                        if (childArray != null)
                        {   
                            var count=childArray.Count;
                            var preKey = nextKey.Append(".").ToString();
                            for (int i = 0; i < count; i++) {
                                var arrObj = (JObject)childArray[i];
                                render(propStr, preKey, i, arrObj);
                            }
                        }
                        break;
                    case JTokenType.Null:
                    case JTokenType.Date:
                    case JTokenType.Integer:
                    case JTokenType.Float:
                    default:
                        if (mask != -1) {
                            nextKey.Append("[").Append(mask).Append("]");
                        }
                        nextKey.Append("=").Append(value);
                        propStr
                            .Append(nextKey.ToString())
                            .Append("\n");
                        break;
                }
                
            });
        }

        public static string toXmlStr(JObject data)
        {
            var xDocument = new XDocument();
            var rootElement = new XElement("Root");
            ConvertJObjectToXElement(data, rootElement);
            xDocument.Add(rootElement);
            return xDocument.ToString();

        }


        private static XElement ConvertJObjectToXElement(JObject jObject, XElement parent)
        {
            foreach (var property in jObject.Properties())
            {
                var propertyElement = new XElement(property.Name);

                if (property.Value.Type == JTokenType.Object)
                {
                    // 如果是子JObject则递归调用
                    ConvertJObjectToXElement((JObject)property.Value, propertyElement);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    // 如果是JArray则递归遍历所有元素
                    foreach (var item in property.Value.Children())
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            var arrayItemElement = new XElement(property.Name);
                            ConvertJObjectToXElement((JObject)item, arrayItemElement);
                            parent.Add(arrayItemElement);
                        }
                        else
                        {
                            var arrayItemElement = new XElement(property.Name, item.ToString());
                            parent.Add(arrayItemElement);
                        }
                    }
                }
                else
                {
                    // 处理基本数据类型
                    propertyElement.Value = property.Value.ToString();
                }
                parent.Add(propertyElement);
            }

            return parent;
        }

       
    }
}
