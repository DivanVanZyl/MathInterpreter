using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parser
{
    public abstract class Node
    {

    }

    //Binary simple nodes
    public class NumberNode(double number) : Node
    {
        private double _value = number;
        public double Value => _value;
        public override string ToString()
        {
            return _value.ToString();
        }
    }

    public class AddNode(Node node1, Node node2) : Node
    {
        private Node _node1 = node1;
        private Node _node2 = node2;
        public Node Node1 => _node1;
        public Node Node2 => _node2;

        public override string ToString()
        {
            return "(" + _node1 + "+" + _node2 + ")";
        }
    }

    public class SubtractNode(Node node1, Node node2) : Node
    {
        private Node _node1 = node1;
        private Node _node2 = node2;
        public Node Node1 => _node1;
        public Node Node2 => _node2;

        public override string ToString()
        {
            return "(" + _node1 + "-" + _node2 + ")";
        }
    }

    public class MultiplyNode(Node node1, Node node2) : Node
    {
        private Node _node1 = node1;
        private Node _node2 = node2;
        public Node Node1 => _node1;
        public Node Node2 => _node2;

        public override string ToString()
        {
            return "(" + _node1 + "*" + _node2 + ")";
        }
    }

    public class DivideNode(Node node1, Node node2) : Node
    {
        private Node _node1 = node1;
        private Node _node2 = node2;
        public Node Node1 => _node1;
        public Node Node2 => _node2;

        public override string ToString()
        {
            return "(" + _node1 + "/" + _node2 + ")";
        }
    }
    //Unary simple nodes
    public class PlusNode(Node node) : Node
    {
        private Node _node = node;
        public Node Node => _node;

        public override string ToString()
        {
            return "(+" + _node + ")";
        }
    }
    public class MinusNode(Node node) : Node
    {
        private Node _node = node;
        public Node Node => _node;

        public override string ToString()
        {
            return "(-" + _node + ")";
        }
    }
    //Set theory nodes
    public class UnionNode : Node
    {
        private SetNode _set1;
        private SetNode _set2;

        public UnionNode(SetNode set1, SetNode set2)
        {
            _set1 = set1;
            _set2 = set2;
        }
        public override string ToString()
        {
            string text = "{";
            foreach (string s in _set1.Values)
            {
                text += (s + ",");
            }
            text = text.Remove(text.Length - 1, 1);
            text += "} ";
            text += " ∪ {";
            foreach (string s in _set2.Values)
            {
                text += (s + ",");
            }
            text = text.Remove(text.Length - 1, 1);
            text += "}";
            return text;
        }
    }

    public class IntersectNode : Node
    {
        private SetNode _set1;
        private SetNode _set2;

        public IntersectNode(SetNode set1, SetNode set2)
        {
            _set1 = set1;
            _set2 = set2;
        }

        public override string ToString()
        {
            string text = "{";
            foreach (string s in _set1.Values)
            {
                text += (s + ",");
            }
            text = text.Remove(text.Length - 1, 1);
            text += "} ";
            text += " ∩ {";
            foreach (string s in _set2.Values)
            {
                text += (s + ",");
            }
            text = text.Remove(text.Length - 1, 1);
            text += "}";
            return text;
        }
    }

    public class SetNode : Node
    {
        private List<string> _set = new List<string>();
        public List<string> Values => _set;

        public SetNode(List<string> set) { _set = set; }
        public override string ToString()
        {
            string text = "{";
            foreach (string s in _set)
            {
                text += (s + ",");
            }
            text = text.Remove(text.Length - 1, 1);
            text += "}";
            return text;
        }
    }
}
