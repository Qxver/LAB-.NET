using System;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zadanie_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("baza.xml");

            treeView1.Nodes.Clear();

            TreeNode root = new TreeNode(doc.DocumentElement.Name);
            treeView1.Nodes.Add(root);

            AddNodes(doc.DocumentElement, root);

            treeView1.ExpandAll();
        }

        private void AddNodes(XmlNode xmlNode, TreeNode treeNode)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                TreeNode newNode;

                if (node.NodeType == XmlNodeType.Element)
                {
                    newNode = new TreeNode(node.Name);

                    if (node.InnerText != "")
                        newNode.Text += ": " + node.InnerText;

                    treeNode.Nodes.Add(newNode);

                    AddNodes(node, newNode);
                }
            }
        }
    }
}