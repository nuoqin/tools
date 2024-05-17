using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace code_tools.utils
{
    public class TextUtils
    {
        /**
         * 
         * 获取 RichTextBox 文本
         */
        public static string getStr(RichTextBox source) {
            TextRange documentTextRange = new TextRange(source.Document.ContentStart, source.Document.ContentEnd);
            return documentTextRange.Text;
        }


        /**
         * 
         * 获取 RichTextBox 文本
         */
        public static string getStr(TextBox source)
        {
            return source.Text;
        }

        /**
         * 
         * 设置 RichTextBox 文本数据
         */
        public static void setStr(RichTextBox newCode, string text)
        {
            FlowDocument flowDoc = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            Run r = new Run(text);
            paragraph.Inlines.Add(r);
            flowDoc.Blocks.Add(paragraph);
            newCode.Document = flowDoc;
        }

    }
}
