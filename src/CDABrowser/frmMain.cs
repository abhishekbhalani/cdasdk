using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL7SDK.Cda;
using System.Diagnostics;
using System.Reflection;
using HL7SDK;

namespace CDABrowser
{
    public partial class frmMain : Form
    {
        private Controller controller;

        public frmMain()
        {
            this.controller = new Controller();
            InitializeComponent();
            controller.SetView(this);
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            controller.OpenFile();
        }
      
        public void UpdateTree()
        {
            var data = new TreeNodeData(controller.Document);
            TreeNode root = new TreeNode() { Text = data.ToString(), Tag = data };
            tv.Nodes.Add(root);
            root.Nodes.Add("");
        }

        private void tv_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                tv.BeforeExpand -= tv_BeforeExpand;
                tv.BeginUpdate();
                Cursor.Current = Cursors.WaitCursor;
                var nodeData = e.Node.Tag as TreeNodeData;
                e.Node.Nodes.Clear();
                foreach (IHL73Object childObject in nodeData.Data.ChildObjects)
                {
                    var childNodeData = new TreeNodeData(childObject);
                    var childNode = new TreeNode() { Text = childNodeData.ToString(), Tag = childNodeData };
                    e.Node.Nodes.Add(childNode);
                    childNode.Nodes.Add("");
                }
            }
            finally
            {
                tv.EndUpdate();
                Cursor.Current = Cursors.Default;
                tv.BeforeExpand += tv_BeforeExpand;
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var data = e.Node.Tag as TreeNodeData;
            if (data == null) return;

            txtXml.Text = data.Data.Xml;
            pg.SelectedObject = data.Data;
        }
    }

    internal class TreeNodeData
    {
        public IHL73Object Data;

        public TreeNodeData(IHL73Object data)
        {
            Debug.Assert(data != null);

            this.Data = data;
        }

        public override string ToString()
        {
            return Data.GetType().Name;
        }
    }

    internal class Controller
    {
        private frmMain View;
        private string fileName;
        private ClinicalDocument document;

        public ClinicalDocument Document
        {
            get
            {
                return document;
            }
        }

        public void SetView(frmMain view)
        {
            Debug.Assert(view != null);

            this.View = view;
        }

        internal void OpenFile()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML files (*.xml)|*.xml";
                if (dlg.ShowDialog(View) == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    InternalLoadDocument(fileName);
                }
            }
        }

        private void InternalLoadDocument(string fileName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                document = new ClinicalDocument();
                document.Load(fileName);
                document.Lazy = false;
                InternalResetView();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void InternalResetView()
        {
            View.UpdateTree();
        }
    }
}
