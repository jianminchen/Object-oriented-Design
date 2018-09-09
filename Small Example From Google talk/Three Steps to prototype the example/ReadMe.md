Here is the problem statement. 

Design classes for the binary expression tree with addition, multiplication operations. Try to apply S.O.L.I.D. principles, single responsibilit principle, open for extension and close for change principle, Open/ close principle. 

Original source: 

"The Clean Code Talks -- Inheritance, Polymorphism, & Testing"https://www.youtube.com/watch?v=4F72VULWFvc

action items:
1. put sample code in C#, and then, check in git;
2. write down key words, and easy for review and follow as rules.

Julia's sample code in C#:
Problem statement: 1 + 2*3, how to implement in OO design (using C# language)

Three solutions are provided, naive one, better one, optimal solution to apply S.O. principles.

1. Represent this as a tree

   +
/     \
1     *
    /    \
  2      3

Most of people come out solution like the following:
 Using conditionals

  class Node{
     char operator;
     double value;
     Node left;
     Node right;
     double evaluate(){
       switch(operator){
        case '#': return value;
        case '+': return left.evaluate() + right.evaluate();
        case '*" return left.evaluate() * right.evaluate();
        case ...  // edit this for each new operator
       }
    }
 }

 Big problem on this:
  graphic representation,
  Node
  op:char
  value: double
  left: Node
  right:Node
 --------------
   evaluate():double

Julia could not figure out the analysis here <- first time to memorize this analysis, and also try to learn reasoning

    Analyzing attributes

                           #      +        *
function                      yes     yes
value                  yes
left                              yes     yes
right                            yes     yes

Two different behaviors are fighting here, (see the above table), not matching Single Responsibility Principle.
if you are the operation node, then you need your left and right child; whereas value node, you just need value.

Reference: 
http://juliachencoding.blogspot.com/2015/12/oo-principle-solid-open-close-principle.html
