using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeggyDialogLib
{
    public class DialogueTree
    {
        public DialogueTreeNode ConversationStart {  get; private set; }
        public DialogueTree(string opener, string response)
        {
            ConversationStart = new DialogueTreeNode(new DialogueOption(opener, response));
        }
        public DialogueTreeNode[] Options
        {
            get
            {
                return ConversationStart.GetOptions();

            }
        }
    }
}
