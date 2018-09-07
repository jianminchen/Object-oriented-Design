using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesign_CleanCodeTalk_OpNodeValueNode
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
     * 
     */
    abstract public class Node{

        /*
         * use abstract to declare the function 
         * C++ pure virtual  <->  C#   abstract method 
         * http://stackoverflow.com/questions/4948992/pure-virtual-methods-in-c
         * */
        public abstract double evaluate() ; 
    }

    class ValueNode : Node{
        public double value;        

        public ValueNode(string s)
        {                      
            value = Convert.ToDouble(s);            
        }

        override public double evaluate(){
            return value; 
        }
    }

    /*
     * bug001: 
     * ValueNode left
     * ValueNode right
     * Should be:
     * Node left, right; 
     * Reason: left, right child can be value node or op node. 
     * 
     * bug002:
     * evaluate() cannot be private -> public 
     * Reason: default is private 
     * 
     * bug003:
     * left, right -> should be public, instead of nothing in declaration. 
     */
    class OpNode : Node{
        public char op;
        public Node left;
        public Node right; 
        
        public OpNode(string s)
        {
            if ( s.CompareTo("+") == 0 || s.CompareTo("*") == 0)
                op = s.Substring(0, 1).ToCharArray()[0];
        }

        override public double evaluate(){
            switch(op){
                case '+': return left.evaluate() + right.evaluate(); 
                case '*': return left.evaluate() * right.evaluate(); 
                default: return 0; 
            }
        }
    }

    class OODesign_CleanCodeTalk_OpNodeValueNode
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
            OpNode n1   = new OpNode("+");
            n1.left     = new ValueNode("1");
            //n1.right.left = new ValueNode("2");   //bug001: error: Node does not contain a definition for 'left'
                
            OpNode n2   = new OpNode("*");
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
