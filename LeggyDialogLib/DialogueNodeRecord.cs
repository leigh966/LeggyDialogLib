using LeggyDialogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeggyDialogueLib
{
    public class DialogueNodeRecord : DialogueOption
    {
        public string Id, ParentId;
        public List<string> childIds = new List<string>();
        public DialogueNodeRecord(string id, DialogueOption dialogue) : base(dialogue.PlayerDialog, dialogue.Response)
        {
            Id = id;
        }

        public override string ToString() // can't handle commas in any fields - big problem
        {
            string output = Id + "," + ParentId+","+PlayerDialog+","+Response+",";
            for(int i = 0; i < childIds.Count; i++)
            {
                if(i> 0) output += " ";
                output += childIds[i];
            }
            return output;
        }
    }
}
