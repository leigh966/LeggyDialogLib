using LeggyTreeLib;
namespace LeggyDialogLib
{
    public class DialogTreeNode :  TreeNode<string>
    {
        private string _response;
        public string Response { get { return _response; } }
        private bool said = false;
        public DialogTreeNode(string text, string response) : base(text) 
        {
            _response = response;
        }
        public DialogTreeNode(string text, string response, DialogTreeNode parent) : base(text, parent)
        {
            _response= response;
        }
        public void Say()
        {
            said = true;
        }

        public DialogTreeNode[] GetOptions()
        {
            if(said)
            {
                DialogTreeNode[] output = { };
                foreach(DialogTreeNode child in _children) 
                {
                    output = output.Concat(child.GetOptions()).ToArray();
                }
                return output;
            }
            return new DialogTreeNode[1] { this };
        }
    }
}
