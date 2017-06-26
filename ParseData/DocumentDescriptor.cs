using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParseData
{
    class DocumentDescriptor
    {
        public XDocument Document { get; set; }
        public string Filename { get; set; }
        public bool IsEnglish { get; set; }

        public DocumentDescriptor(XDocument doc, string filename)
        {
            this.Document = doc;
            this.Filename = filename;
            if (Filename.ToLower().Contains(".en.") || Filename.ToLower().Contains(".en-us."))
            {
                IsEnglish = true;
            }
        }

        public static XDocument DocFromTag(object tag)
        {
            DocumentDescriptor desc = (DocumentDescriptor)tag;
            return desc.Document;
        }
        public static string FilenameFromTag(object tag)
        {
            DocumentDescriptor desc = (DocumentDescriptor)tag;
            return desc.Filename;
        }
        public static bool IsEnglishFromTag(object tag)
        {
            DocumentDescriptor desc = (DocumentDescriptor)tag;
            return desc.IsEnglish;
        }

    }
}
