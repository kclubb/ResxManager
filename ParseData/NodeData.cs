using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseData
{
    public class NodeData
    {
        public string KeyName { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public string TranslateComment { get; set; }
        public int Version { get; set; }
        public string ToString()
        {
            return Version.ToString();
        }
    }
}
