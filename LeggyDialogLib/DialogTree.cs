using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeggyDialogLib
{
    public class DialogTree
    {
        public DialogTreeNode ConversationStart {  get; private set; }
        public DialogTree(string opener, string response)
        {
            ConversationStart = new DialogTreeNode(opener, response);
        }

    }
}
