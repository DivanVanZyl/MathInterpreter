using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class NumberNode
    {
        private float _value;
        public override string ToString()
        {
            return _value.ToString();
        }
    }

    public abstract class Node
    {

    }


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
