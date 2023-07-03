using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2LinkedListCode
{
    class List
    {
        private ListNode firstNode;                          
		private ListNode lastNode;                           
		private string name;

        public List( string listName )  {  name = listName;  firstNode = lastNode = null; } 
	      
        public List()  : this( "list" )  { }
		   
	    public void InsertAtFront( Employee insertItem )
	    {
	        if ( IsEmpty() )
	            firstNode = lastNode = new ListNode( insertItem );
	        else
		        firstNode = new ListNode( insertItem, firstNode );
	    } 

	    public void InsertAtBack( Employee insertItem )
	    {
	        if ( IsEmpty() )
	            firstNode = lastNode = new ListNode( insertItem );
	        else
	            lastNode = lastNode.Next = new ListNode( insertItem );
	    }
	
	    public object RemoveFromFront()
	    {
	        if ( IsEmpty() )                        
	            throw new EmptyListException( name );
	
	        Employee removeItem = firstNode.Data;
	
            if ( firstNode == lastNode )
	                firstNode = lastNode = null;
	        else 
		            firstNode = firstNode.Next;
	
            return removeItem;
	    }

        public object RemoveFromBack()
	    {
	        if ( IsEmpty() )                        
	            throw new EmptyListException( name );
	
	        object removeItem = lastNode.Data;
	
            if ( firstNode == lastNode )
	            firstNode = lastNode = null;
	        else 
	        {
	            ListNode current = firstNode;
	
	            while ( current.Next != lastNode )             
	                current = current.Next; 
	
		        lastNode = current; 
		        current.Next = null;
	        }

            return removeItem;
	    }
		
	    public bool IsEmpty()  {  return firstNode == null;  }
		
	    public void Print()
	    {
	        if ( IsEmpty() ) 
	        {
	            Console.WriteLine( "Empty " + name );
		        return;
	        } 
		
	        Console.Write( "The " + name + " is: " );
	        ListNode current = firstNode;
	        
            while ( current != null ) 
            {
                Console.Write( current.Data + " " );
		        current = current.Next;
	        }

            Console.WriteLine( "\n" );
	    }

        public void SortList()
        {
            ListNode current = firstNode;
            ListNode nextNode = firstNode;
            ListNode linkNode = new ListNode();
            ListNode temp = new ListNode();
            int count = 0;

            linkNode = firstNode;

            while (linkNode.Next != null)
            {
                count++;
                linkNode = linkNode.Next;
            }

            for (int i = 0; i < count; i++)
            {
                current = firstNode;
                while (current.Next != null)
                {
                    nextNode = current.Next;

                    if (current > nextNode)
                    {
                        temp.Data = current.Data;
                        current.Data = nextNode.Data;
                        nextNode.Data = temp.Data;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }//end sort
        }




        
    }    
}
