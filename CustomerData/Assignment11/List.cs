using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment11
{
    class List
    {
        private ListNode firstNode;
        private ListNode lastNode;
        private String name;

        public List() : this("list") { }

        public List(String listName)
        {
            name = listName;
            firstNode = lastNode = null;
        }

        public void Insert(Customer newItem)
        {
            if (IsEmpty())
            {
                firstNode = lastNode = new ListNode(newItem);
            }
            else
            {
                ListNode current = firstNode;

                try
                {
                    while (current != null)
                    {
                        if (newItem > current.Data)
                        {
                            if (current.Next == null)
                            {
                                lastNode = lastNode.Next = new ListNode(newItem, null, lastNode);
                                break;
                            }
                            else
                            {
                                current = current.Next;
                            }
                        }
                        else if (newItem < current.Data)
                        {
                            if (current == firstNode)
                            {
                                firstNode = firstNode.Previous = new ListNode(newItem, firstNode, null);
                            }
                            //else if (current == lastNode)
                            //{
                            //    lastNode = lastNode.Next = new ListNode(newItem, null, lastNode);
                            //}
                            else
                            {
                                current = current.Previous = new ListNode(newItem, current, current.Previous);
                                current.Previous.Next = current;
                            }

                            break;
                        }
                        else
                        {
                            throw new DuplicateCustomerException("Customer " + newItem.Name + " already exist. Entry has been skipped");
                        }
                    }
                }
                catch (DuplicateCustomerException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public bool IsEmpty()
        {
            return firstNode == null;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty " + name);
            }
            else
            {
                Console.WriteLine("The " + name + " is:");
                ListNode current = firstNode;

                while (current != null)
                {
                    Console.WriteLine("   "+current.Data);
                    //if (current.Previous != null)
                    //{
                    //    Console.WriteLine("\tPrevious: " + current.Previous.Data);
                    //}
                    //if (current.Next != null)
                    //{
                    //    Console.WriteLine("\tNext: " + current.Next.Data);
                    //}

                    current = current.Next;
                }
            }

        }

    }

    class DuplicateCustomerException : Exception
    {
        public DuplicateCustomerException() { }

        public DuplicateCustomerException(String msg)
            : base(msg) { }

        public DuplicateCustomerException(String msg, Exception ex)
            : base(msg, ex) { }
    }
}
