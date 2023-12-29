using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArvore
{
    internal class Program
    {
        class Node
        {
            public int Value { get; }
            public List<Node> Children { get; }

            public Node(int value)
            {
                Value = value;
                Children = new List<Node>();
            }
        }

        static void Main(string[] args)
        {
            Node rootNode = CreateTree(1, 2000);

            int nodeToFind = 100;
            int parentNodeValue = FindParentNode(rootNode, nodeToFind);

        }

        static int FindParentNode(Node root, int targetNodeValue)
        {
            return FindParentNodeHelper(root, targetNodeValue, null);
        }

        static int FindParentNodeHelper(Node node, int targetNodeValue, Node parent)
        {
            if (node.Value == targetNodeValue)
            {
                return parent != null ? parent.Value : -1;
            }

            foreach (Node child in node.Children)
            {
                int result = FindParentNodeHelper(child, targetNodeValue, node);
                if (result != -1)
                {
                    return result;
                }
            }

            return -1;
        }

        static Node CreateTree(int startValue, int maxNodeValue)
        {
            Node rootNode = new Node(startValue);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(rootNode);

            while (startValue < maxNodeValue)
            {
                Node parent = queue.Dequeue();
                int numChildren = Math.Min(parent.Value, maxNodeValue - startValue);

                for (int i = 0; i < numChildren; i++)
                {
                    Node child = new Node(++startValue);
                    parent.Children.Add(child);
                    queue.Enqueue(child);
                }
            }

            return rootNode;
        }
    }
}
