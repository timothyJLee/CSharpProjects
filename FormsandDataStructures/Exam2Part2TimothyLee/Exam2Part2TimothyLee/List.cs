using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * I put all three classes into this one file -- this is the only one you need if you 
 * want to just copy and paste into another project.  This file includes:  List, ListNode, 
 * and EmptyListException.
 * 
 * Alternatively, you could just add you code and rezip for submission.  I set the 
 * exam to allow 4 (or was it 5?!?) file uploads.  Either way your choice.  I 
 * really don't care.  Whatever is your favorite.
 * 
 */

namespace Exam2Part2TimothyLee
    {
        class List
        {

            private ListNode firstNode;
            private ListNode lastNode;
            private string name;

            public List(string listName) { name = listName; firstNode = lastNode = null; }

            public List() : this("list") { }

            //This method will swap the first two nodes
            //Why?  Because someone wanted an example dealing with nodes
            //      (And I couldn't otherwise think of anything to do)
            //
            //OK so what I am doing (since mind-melding is not a function)
            //      I am taking the first node and the second node and
            //      swapping their order.  (I.e., in the new linked list the
            //      second node will be the first node)
            //
            //"Picture" or as close as I can get in a text version:
            //  Key:  numbers are the data, -> is the self-referencial (i.e., pointer)
            //  Original Linked List:
            //      3 -> 5 -> 6 -> 2 -> 1
            //  After this method runs:
            //      5 -> 3 -> 6 -> 2 -> 1
            //
            //  Completely un-exciting I know.  But, I am guess that this might be helpful
            //  (without giving you the complete assignment).  Yes, I am tired but not
            //  that tired.
            //
            //  Questions?  Email me.  I will be looking for valid procastenation.
            //  (While waiting for my response, I suggest lots of candy and soda).
            public void swapFirstTwoNodes()
            {
                if (IsEmpty())  //if the list is empty there are no nodes to more
                    return;

                if (firstNode.Next == null)
                {//there is only one thing in the linked list so I still cannot swap
                    return;
                }

                //OK, so we are finally at a point where I can do some swapping
                Console.WriteLine("Let's Swap!");
                ListNode oldFirst = firstNode;  //the first ListNode in the List
                ListNode newFirst = firstNode.Next;  //the second ListNode in the List

                /* Picture Time!
                 * 
                 * This is the current list:
                 *  John Smith -->  Jane Smith -->  Snow White
                 * 
                 * oldFirst is John Smith  (i.e., the contents of data from the node that firstNode was pointing to)
                 * newFirst is Jane Smith  (i.e., the data of the node that was after the node that firstNode was pointing to)
                 * 
                 * I want the list to be (after the method is run):
                 *  Jane Smith --> John Smith --> Snow White
                 * 
                 * So I want to take the ListNode (John Smith -->) and I want to re-point it to the ListNode (Snow White -->)
                 *  How do I get to that list node?  Well it is what newFirst is pointing to!  (Remember newFirst is the second 
                 *  list node).  Anyway, newFirst.Next is what newFirst is pointing to which is the third node in the list.
                 *  All of this gets you the next line of code:
                 */
                oldFirst.Next = newFirst.Next;

                /* One down.  So currently both oldFirst.Next and newFirst.Next are pointing to the same thing.  Something like
                 * this (i.e., picture format):
                 * 
                 *  John Smith -->  
                 *                  Snow White
                 *  Jane Smith -->
                 * 
                 * (Yes, the picture is a little weird.  I am trying to do this in the comments.  Pretend it is a really nice
                 * diagram drawn in word or something).
                 * 
                 * Now I need to get the newFirst to be pointing to the oldFirst.  In other words, I want (Jane Smith -->) to 
                 * be pointing to (John Smith -->).  The "pointing to" is the Next, hence newFirst.Next.  The list node 
                 * (John Smith -->) is oldFirst.  So you get the next line of code:
                 */
                newFirst.Next = oldFirst;

                /* Clean up!
                 * 
                 * Because I moved what firstNode (which keeps track of the first node in my list) I need to update.
                 * What am I updating to?  The newFirst list node.  This gives you the following code:
                 */
                firstNode = newFirst;

                //QED  :-)

            }

            /* Bonus method:  Length of the linked list!
             * 
             * If you need this as a helper method....
             */
            public int lengthOfList()
            {
                int length = 0;

                if (IsEmpty()) { return 0; }//nothing in the list, so size is 0, I could skip this...

                ListNode current = firstNode;

                while (current != null)
                {
                    length++;
                    current = current.Next;
                }

                return length;
            }

            public void InsertAtFront(object insertItem)
            {
                if (IsEmpty())
                    firstNode = lastNode = new ListNode(insertItem);
                else
                    firstNode = new ListNode(insertItem, firstNode);
            }

            public void InsertAtBack(object insertItem)
            {
                if (IsEmpty())
                    firstNode = lastNode = new ListNode(insertItem);
                else
                    lastNode = lastNode.Next = new ListNode(insertItem);
            }

            public object RemoveFromFront()
            {
                if (IsEmpty())
                    throw new EmptyListException(name);

                object removeItem = firstNode.Data;

                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                    firstNode = firstNode.Next;

                return removeItem;
            }

            public object RemoveFromBack()
            {
                if (IsEmpty())
                    throw new EmptyListException(name);

                object removeItem = lastNode.Data;

                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                {
                    ListNode current = firstNode;

                    while (current.Next != lastNode)
                        current = current.Next;

                    lastNode = current;
                    current.Next = null;
                }

                return removeItem;
            }

            public static List ReverseListOrder(List oldList)
            {
                List newList = new List();
                while (!oldList.IsEmpty())
                {
                    newList.InsertAtFront(oldList.RemoveFromBack());
                }
                return newList;
            }
            public List CombineTwoLists(List y)
            {
                List combinedList = new List();

                    ListNode current = firstNode;

                    while (current.Next != lastNode)
                        this.InsertAtFront(y.RemoveFromBack());
                        current = current.Next;

                    lastNode = current;
                    current.Next = null;


                return combinedList;
            }

            public bool IsEmpty() { return firstNode == null; }

            public void Print()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Empty " + name);
                    return;
                }

                Console.Write("The " + name + " is: ");
                ListNode current = firstNode;

                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                }

                Console.WriteLine("\n");
            }
        }



        class EmptyListException : ApplicationException
        {
            public EmptyListException(string name)
                : base("The " + name + " is empty") { }  // end constructor
        }

        class ListNode
        {
            private object data;
            private ListNode next;

            //public ListNode(Employee dataValue)
            //{
            //    data = dataValue;
            //    next = null;
            //}

            public ListNode(object dataValue) : this(dataValue, null) { }

            public ListNode(object dataValue, ListNode nextNode)
            { data = dataValue; next = nextNode; }


            public ListNode Next
            { get { return next; } set { next = value; } }

            public object Data
            { get { return data; } set { data = value; } }

        }
    }

