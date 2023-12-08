using LeggyTreeLib;
namespace LeggyDialogLib
{
    public class DialogTreeNode :  TreeNode<Dialog>
    {
        public DialogTreeNode(Dialog dialog) : base(dialog) 
        {

        }
        public DialogTreeNode(Dialog dialog, DialogTreeNode parent) : base(dialog, parent)
        {

        }

        public DialogTreeNode(ITreeNode<Dialog> node) : base(node.Value, node.Parent)
        {
            _children = node.Children.ToList();
        }

        public DialogTreeNode[] GetOptions()
        {
            if(Value.Said)
            {
                DialogTreeNode[] output = { };
                foreach(ITreeNode<Dialog> child in _children) 
                {
                    output = output.Concat(new DialogTreeNode(child).GetOptions()).ToArray();
                }
                return output;
            }
            return [this];
        }
    }
}
