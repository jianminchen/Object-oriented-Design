using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesign_CleanCodeTalk_OpNodeValueNodeAndMore
{
    /*
    * Dec. 15, 2015
    * Julia works on the code based on the talk:
    * 
    * Talk:
    * https://www.youtube.com/watch?v=4F72VULWFvc
    * blog:
    * http://juliachencoding.blogspot.ca/2015/11/the-clean-code-talks.html
    * 
    * The implementation is not naive version, 
    * see the implementation:
    * https://github.com/jianminchen/OODesignPractice/blob/master/ConditionalVersion.cs
    * 
    * instead, OpNode and ValueNode are designed to bring in polymorphism. Good pratice: 
    * Node (better called: AbstractNode, differentiate from Node), OpNode, ValueNode
    *
     * https://github.com/jianminchen/OODesignPractice-1-2-3-B/blob/master/OODesign_CleanCodeTalk_OpNodeValueNode.cs
     * 
     * Optimal solution:
     * 
     * Node, ValueNode, OpNode, AdditionNode, MultiplicationNode
    * 
    * 
    */
    abstract public class Node
    {

        /*
         * use abstract to declare the function 
         * C++ pure virtual  <->  C#   abstract method 
         * http://stackoverflow.com/questions/4948992/pure-virtual-methods-in-c
         * */
        public abstract double evaluate();
    }

    class ValueNode : Node
    {
        public double value;        

        public ValueNode(string s)
        {          
            value = Convert.ToDouble(s);
        }

        override public double evaluate()
        {
            return value;
        }
    }

    /*
     * Dec. 15, 2015, Julia plays with C# inheritance, fixed a compile error: 
     * bug001:
     * class OpNode -> compile error: OpNode does not implement inherited abstract member evaluate()
     * so, add 'abstract' before class OpNode
     *  class OpNode        vs     abstract class OpNode
     *  compile error               compile ok 
     */
    abstract class OpNode : Node
    {
        public char op;
        public Node left;
        public Node right;     
    }

    class AddtionNode : OpNode
    {      
        override public double evaluate()
        {            
             return left.evaluate() + right.evaluate();             
        }        
    }

    class MultiplcationNode : OpNode
    {           
        override public double evaluate()
        {
            return left.evaluate() * right.evaluate();
        }
    }

    class OODesign_CleanCodeTalk_OpNodeValueNodeAndMore
    {
        /*
        * Problem statement:
        *   1+2*3
        * Optimal solution is to use polymorphism, design ValueNode, OpNode, AdditionNode, MultiplcationNode classes. 
        * Naive solution (most people do) is to use a lot of conditionals
        * Pseudo code as following:
        * 
        * 
        * Google talk:
        *   https://www.youtube.com/watch?v=4F72VULWFvc
        * Reference:
        *   http://juliachencoding.blogspot.ca/2015/11/the-clean-code-talks.html
        *   Naive solution: one class called Node, use conditional if to cover polymorphism. 
        *   https://github.com/jianminchen/OODesignPractice/blob/master/ConditionalVersion.cs
        * 
        *       +
        *   /       \
        *   1        *
        *          /   \ 
        *          2   3
        */
        static void Main(string[] args)
        {
            //string input = "1+2*3";  
           
            OpNode n1   = new AddtionNode();
            n1.left     = new ValueNode("1");            

            OpNode n2   = new MultiplcationNode();
            n2.left     = new ValueNode("2");
            n2.right    = new ValueNode("3");

            n1.right = n2;

            double result = calculate(n1);
            Console.WriteLine("Test result is " + result.ToString());
        }

        public static double calculate(Node root)
        {
            if (root == null) return 0;

            return root.evaluate();
        }
    }
}
