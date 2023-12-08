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
        public DialogTreeNode(string text, string response, DialogTreeNode parent) : base(text, )
        {
            _response= response;
        }
    }
}
