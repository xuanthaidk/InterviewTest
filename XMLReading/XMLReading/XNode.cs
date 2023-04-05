using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLReading
{
 public class XNode : TreeNode
{
    public string attribute1 { get; set; }
    public string attribute2 { get; set; }

        public XNode(string text, string attribute1, string attribute2) : base(text)
        {
            base.Text = text;
            this.attribute1 = attribute1;
            this.attribute2 = attribute2;
        }
    }
}
