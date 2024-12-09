using CodeTools.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.utils
{
    public class CsvUtils
    {

        public static ParseData readCsv(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                using (var sr = new StreamReader(stream,Encoding.GetEncoding("gb2312"))) {
                    string strLine = null;
                    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                    string[] dataLine = null;
                    string[] header = null;
                    int i = 0;
                    
                    string[] separators = { ",", "\t" };

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strLine = strLine.Trim();
                        dataLine = strLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                       
                        if (null != header && header.Length > 0)
                        {
                            Dictionary<string, object> d = new Dictionary<string, object>();
                            for (int j = 0; j < header.Length; j++)
                            {
                                d.Add(header[j], dataLine[j]);
                            }
                            list.Add(d);
                           
                        }
                        if (i == 0)
                        {
                            header = dataLine;
                        }
                        i++;

                    }
                    ParseData parse = new ParseData();
                    parse.size = i;
                    parse.list = list;
                    return parse;
                }
            }
        }



        public static Dictionary<string, object> readCsvWuData(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                using (var sr = new StreamReader(stream, Encoding.GetEncoding("gb2312")))
                {
                    string strLine = null;
                    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                    List<Dictionary<string, object>> headerList = new List<Dictionary<string, object>>();
                    string[] dataLine = null;
                    string[] header = null;
                    int i = 0;

                    string[] separators = { ",", "\t" };

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strLine = strLine.Trim();
                        dataLine = strLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        if (null != header && header.Length > 0)
                        {
                            
                          
                            Dictionary<string, object> d = new Dictionary<string, object>();
                            for (int j = 0; j < header.Length; j++)
                            {
                                if (i == 1)
                                {
                                    Dictionary<string, object> headerMap = new Dictionary<string, object>();
                                    headerMap.Add("label", dataLine[j]);
                                    headerMap.Add("prop", header[j]);
                                    headerList.Add(headerMap);
                                    continue;
                                }
                                else{
                                    d.Add(header[j], dataLine[j]);
                                }
                            }
                            if (i > 1) {
                                list.Add(d);
                            }
                           
                        }
                        if (i == 0)
                        {
                            header = dataLine;
                        }
                        i++;

                    }
                    Dictionary<string, object> data=new Dictionary<string, object>();
                    WuData parse = new WuData();
                    parse.columns = headerList;
                    parse.data = list;
                    data.Add("data", parse);
                    return data;
                }
            }
        }

        public static Dictionary<string, object> readCsv(string fileName, bool flag)
        {
            if (flag)
            {
               return readCsvWuData(fileName);
            }
            else
            {
                ParseData parseData= readCsv(fileName);
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("data", parseData.list);
                return data;
            }
        }
    }
}
