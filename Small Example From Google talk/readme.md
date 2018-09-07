 Dec. 15, 2015
 
 Julia works on the code based on the talk:
  
 Talk:
 
 https://www.youtube.com/watch?v=4F72VULWFvc
 
 blog:
 
 http://juliachencoding.blogspot.ca/2015/11/the-clean-code-talks.html
 
  
 The implementation is not naive version, 
 see the implementation:
 
https://github.com/jianminchen/Object-oriented-Design/blob/master/Small%20Example%20From%20Google%20talk/ConditionalVersion.cs

  
 instead, OpNode and ValueNode are designed to bring in polymorphism. Good pratice: 
 Node (better called: AbstractNode, differentiate from Node), OpNode, ValueNode
 
 
 The blog is here to document the practice. 
 
 http://juliachencoding.blogspot.com/search?q=clean+code+talks
 
 
 Julia put together C# code based on clean code talk, and also wrote a blog in Dec. 2015. 
 
 http://juliachencoding.blogspot.com/2015/12/oo-principle-solid-open-close-principle.html
 
 
Sept. 7, 2018
Add a new folder with those three examples, one is conditional version, naive one, break Single responsiblity principle; second one is to separate OpNode and ValueNode; third one is to apply polymorphic solution, for each operator, there is one class for the oeprator. 
