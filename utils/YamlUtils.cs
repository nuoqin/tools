using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tools;
using YamlDotNet.Serialization;

namespace code_tools.utils
{
    public class YamlUtils
    {
        private static string DEFAULT_YAML_REPLACE="  ";

        private static string DEFAULT_YAML_PATTERN= "^[a-zA-Z0-9]\\S+$";  

        /**
         * yaml文件转json 
         * server:
         *     port: 8090
         */
        public static string toJSONStr(string yamlStr) {
            if (string.IsNullOrEmpty(yamlStr)) { return "{}"; }
            var deserializer = new DeserializerBuilder().Build();  
            var yamlObject = deserializer.Deserialize(new StringReader(yamlStr));
            var serializer1 = new SerializerBuilder()
                    .JsonCompatible()
                    .Build();
            var json = serializer1.Serialize(yamlObject);
            return json.ToString();
        }
       
    }
}
