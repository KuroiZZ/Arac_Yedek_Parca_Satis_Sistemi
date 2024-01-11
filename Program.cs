//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    internal class Global
    {
        //adding file paths
        internal static string UserPath = "Users.txt";
        internal static string CarPath = "Cars.txt";
        internal static string shoppingCartPath = "ShoppingCart.txt";
    }

    //Creating User class
    internal class User
    {
        internal string id;
        internal string password;
        internal string name;
        internal string mail;
        internal string phone_no;
        internal string statu;

        internal User(string id, string password, string name, string mail, string phone_no)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.mail = mail;
            this.phone_no = phone_no;
        }

        internal User(string id, string password, string name, string mail, string phone_no, string statu)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.mail = mail;
            this.phone_no = phone_no;
            this.statu = statu;
        }
        

    }

    //Creating Linked list for using selection menus
    internal class LinkedList
    {
        internal string data;

        internal LinkedList next;

        internal LinkedList(string data)
        {
            this.data = data;
            this.next = null;
        }

        internal LinkedList()
        {
            this.next = null;
        }

        internal static void addNode(LinkedList list, string data)
        {
            LinkedList new_list = new LinkedList(data);
            
            if(list == null)
            {
                list = new_list;
            }
            else    
            {
                LinkedList temp = list;
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                if(!LinkedList.checkList(list, data))
                {
                    temp.next = new_list;
                }
            } 
        }

        internal static void Print(LinkedList list)
        {
            int counter = 1;
            LinkedList temp = list;
            temp = temp.next;
            while(temp != null)
            {
                Console.WriteLine("{0}-{1}",counter,temp.data);
                temp = temp.next;
                counter++;
            }
        }

        internal static bool checkList(LinkedList list, string data)
        {
            LinkedList new_list = new LinkedList(data);
            LinkedList temp = list;
            while(temp != null)
            {
                if(temp.data == data)
                {
                    return true;
                }
                temp = temp.next;
            }

            return false;
            
        }

        internal static string takeLinkedListsElement(LinkedList list, int number)
        {
            LinkedList temp = list;
            for(int i = 1; i<number; i++)
            {
                temp = temp.next;
            }
            return temp.data;
        }

        internal static int findLinkedListsSize(LinkedList list)
        {
            int counter = 0;
            LinkedList temp = list;
            while(temp != null)
            {
                counter++;
                temp = temp.next;
            }
            return counter-1;
        }
    } 

    internal class Program
    {
        internal static void Main()
        {
            //Assigning default users and cars and opening shopping cart txt
            Starter.assignDefaultUsers();
            Starter.assignDefaultCars();
            Starter.assignDefaultOrders();

            //Starting program
            Menu.MainMenu();


        }
    }
}