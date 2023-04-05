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
    public string newText { get; set; }

        public XNode(string text, string newText) : base(text)
        {
            base.Text = text;
            this.newText = newText;
        }
    }
}
