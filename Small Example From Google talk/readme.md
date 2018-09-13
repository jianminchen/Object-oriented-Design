 Dec. 15, 2015
 
 Julia works on the code based on the talk:
  
 Talk: [Clean code](https://www.youtube.com/watch?v=4F72VULWFvc)
 
 blog: [the clean code talks](http://juliachencoding.blogspot.ca/2015/11/the-clean-code-talks.html)
 
  
 The implementation is not naive version, 
 see the implementation: [Conditional version C sharp](https://github.com/jianminchen/Object-oriented-Design/blob/master/Small%20Example%20From%20Google%20talk/ConditionalVersion.cs)

  
 instead, OpNode and ValueNode are designed to bring in polymorphism. Good pratice: 
 Node (better called: AbstractNode, differentiate from Node), OpNode, ValueNode 
 
 The blogs are [here](http://juliachencoding.blogspot.com/search?q=clean+code+talks) to document the practice.  
 
 Julia put together C# code based on clean code talk, and also wrote a blog titled [Object-oriented principle: solid principles, open-close principle](http://juliachencoding.blogspot.com/2015/12/oo-principle-solid-open-close-principle.html) in Dec. 2015. 

 
Sept. 7, 2018

Add a new folder with those three examples, one is conditional version, naive one, break Single responsiblity principle; second one is to separate OpNode and ValueNode; third one is to apply polymorphic solution, for each operator, there is one class for the oeprator. 
