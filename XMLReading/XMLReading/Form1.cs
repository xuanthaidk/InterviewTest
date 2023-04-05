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
        TreeNode treeNode;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadXmlIntoTreeView(string xmlFilePath)
        {
            XDocument xDoc = XDocument.Load(xmlFilePath);
            if (xDoc.Root.HasElements)
            {
                if (xDoc.Root.HasAttributes)
                {
                    TreeNode treeNode = new TreeNode(xDoc.Root.FirstAttribute.Value.ToString());
                    treeNode.Name = xDoc.Root.FirstAttribute.NextAttribute.Value.ToString();
                    treeView.Nodes.Add(treeNode);
                    AddNodes(xDoc.Root, treeNode);
                }
                else
                {
                    MessageBox.Show("This XML file doesn't have attributes!");
                }
            }
            else
            {
                MessageBox.Show("This XML file doesn't have elements!");
            }
        }

        private void AddNodes(XElement xElement, TreeNode treeNode)
        {
            foreach (XElement element in xElement.Elements())
            {
                TreeNode node = new TreeNode(element.FirstAttribute.Value.ToString());
                if(element.FirstAttribute.NextAttribute != null)
                {
                    node.Name = element.FirstAttribute.NextAttribute.Value.ToString();
                }
               
                treeNode.Nodes.Add(node);
                if (element.HasElements)
                {
                    AddNodes(element, node);
                }
                else
                {
                    node.Text = element.FirstAttribute.Value.ToString();
                    node.Name = element.FirstAttribute.NextAttribute.Value.ToString();
                }
            }
        }

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
                writer.Flush();
                //writer.Close();
            }
        }

        private void WriteSelectedNode(TreeNode node, XmlTextWriter writer)
        {
            writer.WriteStartElement("Node");
            writer.WriteAttributeString("Text", node.Text);
            writer.WriteAttributeString("id", node.Name);

            foreach (TreeNode childNode in node.Nodes)
            {
                WriteSelectedNode(childNode, writer);
            }

            writer.WriteEndElement();
        }

        private void ExportSelectedNodeToXml(TreeNode selectedNode, string filePath)
        {
            using (XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                WriteSelectedNode(selectedNode, writer);
                writer.WriteEndDocument();
            }
        }

        private void saveNodesButton_Click(object sender, EventArgs e)
        {
            if (treeView != null)
            {
                saveFileDialog.Filter = "XML File | *.xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    ExportTreeViewToXml(saveFileDialog.FileName);
                }

            }
            else
            {
                MessageBox.Show("No file yet!");
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
            if (treeView != null)
            {
                saveFileDialog.Filter = "XML File | *.xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportSelectedNodeToXml(treeView.SelectedNode, saveFileDialog.FileName);

                }

            }
            else
            {
                MessageBox.Show("No file yet!");
            }
        }
    }
}