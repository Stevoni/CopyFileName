using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CopyFileUtility
{
    public partial class frmMain : Form
    {

        private System.IO.FileInfo currentFile;

        public frmMain(System.IO.FileInfo file)
        {
            InitializeComponent();

            currentFile = file;

            PopulateListBox();
            UpdateColumnWidths();
        }

        private void CheckFileExistsOrClose()
        {
            if (currentFile.Exists == false)
            {
                Environment.Exit(-1);
            }
        }

        private void UpdateColumnWidths()
        {
            lvPaths.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            colOutput.Width = -2;
        }
        private void PopulateListBox()
        {
            foreach (KeyValuePair<PathMappingAttribute, MethodInfo> pair in GetAttributes())
            {
                string output = pair.Value.Invoke(this, null) as string;

                ListViewItem item = new ListViewItem(new string[] { pair.Key.OutputType, output });
                item.Tag = output;

                lvPaths.Items.Add(item);
            }
        }

        private List<KeyValuePair<PathMappingAttribute, MethodInfo>> GetAttributes()
        {
            List<KeyValuePair<PathMappingAttribute, MethodInfo>> result = new List<KeyValuePair<PathMappingAttribute, MethodInfo>>();
            MethodInfo[] methods = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                PathMappingAttribute[] attributes = method.GetCustomAttributes(typeof(PathMappingAttribute), true) as PathMappingAttribute[];

                if (attributes != null)
                {
                    foreach (PathMappingAttribute attribute in attributes)
                    {
                        result.Add(new KeyValuePair<PathMappingAttribute, MethodInfo>(attribute, method));
                    }
                }
            }

            return result;
        }

        #region File resolution

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        private class PathMappingAttribute : Attribute
        {
            public PathMappingAttribute(string outputType)
            {
                OutputType = outputType;
            }

            public string OutputType { get; private set; }
        }

        [PathMapping("Full Path")]
        private string GetFullPath()
        {
            return currentFile.FullName;
        }

        [PathMapping("File Name")]
        private string GetFileName()
        {
            return currentFile.Name;
        }

        [PathMapping("Short Path")]
        private string GetShortPath()
        {
            const int MAX_PATH = 255;
            StringBuilder result = new StringBuilder(MAX_PATH);

            if (GetShortPathName(currentFile.FullName, result, MAX_PATH) > 0)
            {
                return result.ToString();
            }
            else
            {
                return currentFile.FullName;
            }
        }

        [PathMapping("URL")]
        private string GetURL()
        {
            return new Uri(currentFile.FullName).ToString();
        }

        [PathMapping("UNC")]
        private string GetUNC()
        {
            return string.Empty;
        }

        [PathMapping("UNC URL")]
        private string GetUNCURL()
        {
            return string.Empty;
        }

        #region Imports
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)]string path, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder shortPath, int shortPathLength);
        #endregion

        #endregion

        private void lvPaths_ItemActivate(object sender, EventArgs e)
        {
            CopyCurrentItemToClipboard();
        }

        private void CopyCurrentItemToClipboard()
        {
            if (lvPaths.SelectedItems.Count == 1)
            {
                Hide();

                string output = lvPaths.SelectedItems[0].Tag as string;
                if (string.IsNullOrEmpty(output) == false)
                {
                    Clipboard.SetText(output);
                }
                
                Close();
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CopyCurrentItemToClipboard();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (lvPaths.Items.Count > 0)
            {
                lvPaths.Items[0].Selected = true;
            }
        }
    }
}
