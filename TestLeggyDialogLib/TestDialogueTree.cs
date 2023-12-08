using LeggyDialogLib;
using System.Net.Http.Headers;
namespace TestLeggyDialogLib
{
    [TestClass]
    public class TestDialogueTree
    {
        [TestMethod]
        public void TestGetOptions()
        {
            DialogueTree tree = new DialogueTree("Hello", "Hi there!");
            tree.ConversationStart.AddChild(new DialogueOption("How are you?", "I'm good thanks!"));
            var node1 = tree.ConversationStart.Children[0];
            node1.AddChild(new DialogueOption("Are you sure?", "Yep"));
            tree.ConversationStart.AddChild(new DialogueOption("Weater is good huh?", "Nope"));
            var node2 = tree.ConversationStart.Children[1];
            node2.AddChild(new DialogueOption("Why?", "It's raining"));
            Assert.AreEqual(1, tree.Options.Length);
            tree.ConversationStart.Value.Said = true;
            Assert.AreEqual(2, tree.Options.Length);
        }

        [TestMethod]
        public void TestSaveBasic()
        {
            DialogueTree tree = new DialogueTree("Hello", "Hi there!");
            tree.ConversationStart.AddChild(new DialogueOption("How are you?", "I'm good thanks!"));
            var node1 = tree.ConversationStart.Children[0];
            node1.AddChild(new DialogueOption("Are you sure?", "Yep"));
            tree.ConversationStart.AddChild(new DialogueOption("Weater is good huh?", "Nope"));
            var node2 = tree.ConversationStart.Children[1];
            node2.AddChild(new DialogueOption("Why?", "It's raining"));
            tree.Save("test.dtree");
        }

        [TestMethod]
        public void TestToNodeArray()
        {
            DialogueTree tree = new DialogueTree("Hello", "Hi there!");
            tree.ConversationStart.AddChild(new DialogueOption("How are you?", "I'm good thanks!"));
            var node1 = tree.ConversationStart.Children[0];
            node1.AddChild(new DialogueOption("Are you sure?", "Yep"));
            tree.ConversationStart.AddChild(new DialogueOption("Weater is good huh?", "Nope"));
            var node2 = tree.ConversationStart.Children[1];
            node2.AddChild(new DialogueOption("Why?", "It's raining"));
            Assert.AreEqual(5, tree.ToNodeArray().Length);
        }
    }
}