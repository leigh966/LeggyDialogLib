using LeggyDialogLib;
using System.Net.Http.Headers;
namespace TestLeggyDialogLib
{
    [TestClass]
    public class TestDialogTree
    {
        [TestMethod]
        public void TestGetOptions()
        {
            DialogTree tree = new DialogTree("Hello", "Hi there!");
            tree.ConversationStart.AddChild(new Dialog("How are you?", "I'm good thanks!"));
            var node1 = tree.ConversationStart.Children[0];
            node1.AddChild(new Dialog("Are you sure?", "Yep"));
            tree.ConversationStart.AddChild(new Dialog("Weater is good huh?", "Nope"));
            var node2 = tree.ConversationStart.Children[1];
            node2.AddChild(new Dialog("Why?", "It's raining"));
            Assert.AreEqual(1, tree.Options.Length);
            tree.ConversationStart.Value.Said = true;
            Assert.AreEqual(2, tree.Options.Length);

        }
    }
}