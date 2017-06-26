using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseData
{
    public class NodeSorter : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = (TreeNode)x;
            TreeNode ty = (TreeNode)y;

            if (tx.Level <= 1)
            {
                return string.Compare(tx.Text, ty.Text);
            }
            else
            {
                return string.Compare(tx.Name, ty.Name);
            }
        }

    }

}