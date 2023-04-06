using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLReading
{
    public partial class Form1 : Form
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadXmlIntoTreeView(string xmlFilePath)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            if(xDoc.Root==null)
            {
                MessageBox.Show("This XML file doesn't have root!");
                return;
            }
            if (!xDoc.Root.HasElements)
            {
                MessageBox.Show("This XML file doesn't have elements!");
                return;
            }
            if (!xDoc.Root.HasAttributes)
            {
                MessageBox.Show("This XML file doesn't have attributes!");
                return;
            }
            TreeNode treeNode = new TreeNode(xDoc.Root.FirstAttribute.Value.ToString());
            if (xDoc.Root.FirstAttribute.NextAttribute != null)
            {
                treeNode.Name = xDoc.Root.FirstAttribute.NextAttribute.Value.ToString();
            }
            treeView.Nodes.Add(treeNode);
            AddNodes(xDoc.Root, treeNode);
        }

        private void AddNodes(XElement xElement, TreeNode treeNode)
        {
            foreach (XElement element in xElement.Elements())
            {

                //XNode xnode = new XNode(element.FirstAttribute.Value.ToString(), element.FirstAttribute.Value.ToString(), element.FirstAttribute.NextAttribute.Value.ToString());

                TreeNode node = new TreeNode(element.FirstAttribute.Value.ToString());
                node.Name = element.FirstAttribute.NextAttribute.Value.ToString();           
                treeNode.Nodes.Add(node);
                if (element.HasElements)
                {
                    AddNodes(element, node);
                }
                else
                {
                    node.Text = element.FirstAttribute.Value.ToString();
                    node.Name = element.FirstAttribute.NextAttribute.Value.ToString();

                    //xnode.attribute1 = element.FirstAttribute.Value.ToString();
                    //xnode.attribute2 = element.FirstAttribute.NextAttribute.Value.ToString();
                }
            }
        }

        private void WriteSelectedNode(TreeNode selectedNode, XmlTextWriter writer)
        {
            writer.WriteStartElement("node");
            writer.WriteAttributeString("Text", selectedNode.Text);
            writer.WriteAttributeString("id", selectedNode.Name);

            foreach (TreeNode childNode in selectedNode.Nodes)
            {
                WriteSelectedNode(childNode, writer);
            }

            writer.WriteEndElement();
        }

        private void ExportSelectedNodeToXml(TreeNode selectedNode, string filePath)
        {
            //XmlWriter writer = XmlWriter.Create(filePath);
            using (XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                WriteSelectedNode(selectedNode, writer);
                writer.WriteEndDocument();
            }
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML file | *.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadXmlIntoTreeView(openFileDialog.FileName);
            }
        }

        private void selectedSaveNodesButton_Click(object sender, EventArgs e)
        {
            if (treeView == null)
            {
                MessageBox.Show("No file yet!");
                return;
            }
            saveFileDialog.Filter = "XML File | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(treeView.SelectedNode==null)
                {
                    MessageBox.Show("no node chose!");
                    return;
                }
                ExportSelectedNodeToXml(treeView.SelectedNode, saveFileDialog.FileName);
            }
        }


        /// <summary>
        /// ///////////////////////////////////////////////////
        /// </summary>
        /// <param name="nodesCollection"></param>
        /// <param name="writer"></param>
        private void WriteNode(TreeNodeCollection nodesCollection, XmlWriter writer)
        {

            foreach (TreeNode node in nodesCollection)
            {
                writer.WriteStartElement("node");
                writer.WriteAttributeString("text", node.Text);
                writer.WriteAttributeString("id", node.Name);
                WriteNode(node.Nodes, writer);
                writer.WriteEndElement();
            }
        }

        private void ExportTreeViewToXml(string filePath)
        {
            XmlWriter writer = XmlWriter.Create(filePath);
            {

                writer.WriteStartDocument();
                WriteNode(treeView.Nodes, writer);
                writer.WriteEndDocument();
                //writer.Flush();
                //writer.Close();
            }
        }
        private void saveNodesButton_Click(object sender, EventArgs e)
        {
            if (treeView == null)
            {
                MessageBox.Show("No file yet!");
            }
            saveFileDialog.Filter = "XML File | *.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                ExportTreeViewToXml(saveFileDialog.FileName);
            }
        }
    }
}