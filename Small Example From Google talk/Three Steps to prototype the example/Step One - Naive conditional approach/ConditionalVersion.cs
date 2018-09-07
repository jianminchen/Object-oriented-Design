using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theCleanCodeTalks_ConditionalVersion
{
    class Node
    {
        public char op;
        public double value;
        Node left;
        Node right;

        /*
         * julia's comment: 
         * 1. bug 001 - need to add '#' for value node 
         */
        public Node(string s)
        {
            if (s.CompareTo("#") == 0 || s.CompareTo("+") == 0 || s.CompareTo("*") == 0)
                op = s.Substring(0, 1).ToCharArray()[0];
            else
            {
                op = '#';  // bug 001 
                value = Convert.ToDouble(s);
            }
        }

        public double evaluate(){
            switch(op){
                case '#': 
                    return value;
                case '+': 
                    return left.evaluate() + right.evaluate();
                case '*': 
                    return left.evaluate() * right.evaluate();
                default: 
                    return 0; 
            }
        }

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
            Node n1 = new Node("+");
            n1.left = new Node("1");
            n1.right = new Node("*");
            n1.right.left = new Node("2");
            n1.right.right = new Node("3");

            double result =  calculate(n1);
            Console.WriteLine("Test result is "+result.ToString()); 
        }

        public static double calculate(Node root)
        {
            if (root == null) return 0;

            return root.evaluate();
        }
    }
}
