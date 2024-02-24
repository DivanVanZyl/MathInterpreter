using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace Interpreter
{
    public class SimpleInterpreter: IInterpreter<double>
    {
        /// <summary>
        /// Pass a root node of a tree. The interpreter will then process the tree and return a number.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double Visit(Node node)
        {
            if(node.GetType() == typeof(NumberNode))
            {
                return double.Parse(VisitNumberNode((NumberNode)node).ToString());
            }
            if (node.GetType() == typeof(AddNode))
            {
                return double.Parse(VisitAddNode((AddNode)node).ToString());
            }
            if (node.GetType() == typeof(SubtractNode))
            {
                return double.Parse(VisitSubtractNode((SubtractNode)node).ToString());
            }
            if (node.GetType() == typeof(MultiplyNode))
            {
                return double.Parse(VisitMultiplyNode((MultiplyNode)node).ToString());
            }
            if (node.GetType() == typeof(DivideNode))
            {
                return double.Parse(VisitDivideNode((DivideNode)node).ToString());
            }
            if (node.GetType() == typeof(PlusNode))
            {
                return double.Parse(VisitPlusNode((PlusNode)node).ToString());
            }
            if (node.GetType() == typeof(DivideNode))
            {
                return double.Parse(VisitDivideNode((DivideNode)node).ToString());
            }
            else
            {
                return 0.0;
            }
        }

        private Number VisitNumberNode(NumberNode node)
        {
            return new Number(node.Value);
        }

        private Number VisitAddNode(AddNode node)
        {
            
            return new Number(Visit(node.Node1) + Visit(node.Node2));
        }
        private Number VisitSubtractNode(SubtractNode node)
        {
            return new Number(Visit(node.Node1) - Visit(node.Node2));
        }
        private Number VisitMultiplyNode(MultiplyNode node)
        {
            return new Number(Visit(node.Node1) * Visit(node.Node2));
        }
        private Number VisitDivideNode(DivideNode node)
        {
            try
            {
                return new Number(Visit(node.Node1) / Visit(node.Node2));
            }
            catch (Exception ex)
            {
                throw new ArithmeticException("Division error: " + ex);
            }
        }
        private Number VisitPlusNode(PlusNode node)
        {
            return new Number(Visit(node.Node));
        }
        private Number VisitMinusNode(MinusNode node)
        {
            return new Number(-(Visit(node.Node)));
        }
    }
}
