using Newtonsoft.Json;
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
using System.Xml.Linq;
using tools;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace code_tools.utils
{
    public class YamlUtils
    {

        /**
         * yaml文件转json 
         * server:
         *     port: 8090
         */
        public static string toJSONStr(string yamlStr) {
            if (string.IsNullOrEmpty(yamlStr)) { return "{}"; }
            var json = yamlToJsonStr(yamlStr);
            return json.ToString();
        }

        private static string yamlToJsonStr(string xmlStr)
        {
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(new StringReader(xmlStr));
            var serializer1 = new SerializerBuilder()
                    .JsonCompatible()
                    .Build();
            return serializer1.Serialize(yamlObject);
        }

        /**
         * yaml文件转json 
         * server:
         *     port: 8090
         */
        public static string toPropertiesStr(string yamlStr)
        {
            if (string.IsNullOrEmpty(yamlStr)) { return ""; }
            var json = yamlToJsonStr(yamlStr);
            JObject data = JObject.Parse(json);
            return JSONUtils.toProperties(data);
        }

        public static string toXmlStr(string yamlStr)
        {
            if (string.IsNullOrEmpty(yamlStr)) { return ""; }
            var json = yamlToJsonStr(yamlStr);
            JObject data = JObject.Parse(json);
            return JSONUtils.toXmlStr(data);

        }
    }
}
