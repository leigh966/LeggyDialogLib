using LeggyDialogueLib;
using LeggyTreeLib;
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

        public DialogueTreeNode[] ToNodeArray()
        {
            return ConversationStart.ToNodeArray();
        }

        private DialogueNodeRecord[] GenerateRecords()
        {
            List<DialogueNodeRecord> records = new List<DialogueNodeRecord>();
            var dialogueArray = ConversationStart.ToNodeArray();
            for (int i = 0; i < dialogueArray.Length; i++)
            {
                var thisDialogue = dialogueArray[i];
                records.Add(new DialogueNodeRecord(i.ToString(), thisDialogue.Value));
                // for all previous records
                for (int scanBack = i - 1; scanBack >= 0; scanBack--)
                {
                    // swap information with the previous records
                    var previousDialogue = dialogueArray[scanBack];
                    if (previousDialogue.Parent == thisDialogue) // this node is the parent of the previous
                    {
                        records[scanBack].ParentId = i.ToString();
                    }
                    if (previousDialogue.Children.Contains(thisDialogue)) // this node is a child of the previous
                    {
                        records[scanBack].childIds.Add(i.ToString());
                    }
                    if (thisDialogue.Parent == previousDialogue) // the previous node is the parent of this one
                    {
                        records[i].ParentId = scanBack.ToString();
                    }
                    if (thisDialogue.Children.Contains(previousDialogue)) // the previous node is a child of this one
                    {
                        records[i].childIds.Add(scanBack.ToString());
                    }
                }
            }
            return records.ToArray();
        }

        public void Save(string path)
        {
            var records = GenerateRecords();

            // Generate the csv text
            string outputText = "";
            for(int i  = 0; i < records.Length; i++) // can't handle \n in any fields!
            {
                outputText += records[i].ToString();
                if(i < records.Length - 1) outputText += "\n";
            }

            // Write csv text to file
            using (FileStream fs = File.Create(path))
            {
                // writing data in string
                byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                fs.Write(info, 0, info.Length);

                // writing data in bytes already
                byte[] data = new byte[] { 0x0 };
                fs.Write(data, 0, data.Length);
            }
        }

    }
}
