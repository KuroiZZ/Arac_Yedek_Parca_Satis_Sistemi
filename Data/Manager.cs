//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    //Creating manager class with inheritance of user class
    internal class Manager : User
    {
        internal Manager(string id, string password, string name, string mail, string phone_no) :base(id,password,name,mail,phone_no)
        {
            this.statu = "@3";
        }

        internal Manager(User User) :base(User.id, User.password, User.name, User.mail, User.phone_no)
        {
            this.statu = "@3";
        }

        internal void deleteCar()
        {
            Console.Clear();
            //Reading all txt to string array to use
            string[] carfileContents = File.ReadAllLines(Global.CarPath);
            string[] words;
            //Creating Linkedlist for to listing cars
            LinkedList carlist = new LinkedList(string.Empty);
            for(int i = 0; i<carfileContents.Length; i++)
            {
                //Dividing content to words and adding to list
                words = carfileContents[i].Split("-");
                LinkedList.addNode(carlist, (words[0] + "-" + words[1]));
            }
            //Controlling for if the list is empty;
            if(LinkedList.findLinkedListsSize(carlist) == 0)
            {
                Console.WriteLine("Car list is Empty");
                return;
            }
            //Printing car list and select one of them
            Console.WriteLine("Car List");
            LinkedList.Print(carlist);
            int selectionNumber;
            while(true)
            {
                Console.Write("Select a Car: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out selectionNumber);
                if(isnumber)
                {
                    if( selectionNumber < 1 || selectionNumber > LinkedList.findLinkedListsSize(carlist))
                    {
                        Console.WriteLine("ERROR:Invalid Selection");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR:Invalid Selection");
                    continue;
                }

                break;
            }

            Console.Clear();
            //Assigning selected car to variable for controls
            string selectedCar = LinkedList.takeLinkedListsElement(carlist, selectionNumber+1);
            //Creating Linkedlist for to listing car packages
            LinkedList packagelist = new LinkedList();
            for(int j = 0; j<carfileContents.Length; j++)
            {
                //Dividing content to words and adding to list while controlling with selectedCar
                words = carfileContents[j].Split("-");
                if(selectedCar == (words[0] + "-" + words[1]))
                {
                    LinkedList.addNode(packagelist, (words[0] + "-" + words[1] + "-" + words[2]));
                }
            }
            //Printing car package list and select one of them
            Console.WriteLine("Package List");
            LinkedList.Print(packagelist);
            while(true)
            {
                Console.Write("Select a Package: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out selectionNumber);
                if(isnumber)
                {
                    if( selectionNumber < 1 || selectionNumber > LinkedList.findLinkedListsSize(packagelist))
                    {
                        Console.WriteLine("ERROR:Invalid Selection");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR:Invalid Selection");
                    continue;
                }

                break;
            }

            //Assigning selected car package to variable for controls
            string selectedPackage = LinkedList.takeLinkedListsElement(packagelist, selectionNumber+1);
            
            int counter = 0;

            
            //Reading all txt to string array to delete 

            string[] cartfileContents = File.ReadAllLines(Global.shoppingCartPath);
            for(int i = 0; i<cartfileContents.Length; i++)
            {
                //Dividing content to words and comparing with selected package and making them empty for shopping cart
                words = cartfileContents[i].Split(":");
                string[] OrderPart = words[1].Split("-");
                if(selectedPackage == OrderPart[0] + "-" + OrderPart[1]+ "-" + OrderPart[2])
                {
                    counter++;
                    cartfileContents[i] = " ";
                }
            }
            
            for(int i = 0; i<carfileContents.Length; i++)
            {
                //Dividing content to words and comparing with selected package and making them shift for cars
                words = carfileContents[i].Split("-");
                if(selectedPackage == words[0] + "-" + words[1] + "-" + words[2])
                {
                    for(int j = i; j<carfileContents.Length-1; j++)
                    {
                        carfileContents[j] = carfileContents[j+1];
                    }
                    break;
                }  
            }

            //Rewriting txt with new filecontents
            File.WriteAllText(Global.shoppingCartPath, "");
            for(int i = 0; i<cartfileContents.Length; i++)
            {
                if(cartfileContents[i] != " ")
                {
                    File.AppendAllText(Global.shoppingCartPath, cartfileContents[i] + "\n");
                }            
            }
            
            

            //Rewriting txt with new filecontents
            File.WriteAllText(Global.CarPath, "");
            for(int i = 0; i<carfileContents.Length-1; i++)
            {
                File.AppendAllText(Global.CarPath, carfileContents[i] + "\n");
            }


        }

        internal void deleteCustomer()
        {
            Console.Clear();
            //Reading all txt to string array to use
            string[] userfileContents = File.ReadAllLines(Global.UserPath);
            string[] words;
            //Creating Linkedlist for to listing cars
            LinkedList customerList = new LinkedList();
            for(int i = 0; i<userfileContents.Length; i++)
            {
                //Dividing content to words and adding to list
                words = userfileContents[i].Split("|");
                if(words[0] == "@1")
                {
                    LinkedList.addNode(customerList, userfileContents[i]);
                }
            }
            //Controlling for if the list is empty;
            if(LinkedList.findLinkedListsSize(customerList) == 0)
            {
                Console.WriteLine("Customer list is Empty");
                return;
            }
            //Printing customer list and select one of them
            Console.WriteLine("Customer List");
            LinkedList.Print(customerList);
            int selectionNumber;
            while(true)
            {
                Console.Write("Select a Customer: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out selectionNumber);
                if(isnumber)
                {
                    if( selectionNumber < 1 || selectionNumber > LinkedList.findLinkedListsSize(customerList))
                    {
                        Console.WriteLine("ERROR:Invalid Selection");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR:Invalid Selection");
                    continue;
                }

                break;
            }

            //Assigning selected customer to variable for deleting
            string selectedCustomer = LinkedList.takeLinkedListsElement(customerList, selectionNumber+1);
            words = selectedCustomer.Split("|");
            //Assign customer class and delete
            Customer customer = new Customer(MyFile.file_UserAssign(Global.UserPath, words[1]));
            customer.deleteAccount();     
        }

        internal void deleteDealer()
        {
            Console.Clear();
            //Reading all txt to string array to use
            string[] userfileContents = File.ReadAllLines(Global.UserPath);
            string[] words;
            //Creating Linkedlist for to listing cars
            LinkedList dealerList = new LinkedList();
            for(int i = 0; i<userfileContents.Length; i++)
            {
                //Dividing content to words and adding to list
                words = userfileContents[i].Split("|");
                if(words[0] == "@2")
                {
                    LinkedList.addNode(dealerList, userfileContents[i]);
                }
            }
            //Controlling for if the list is empty;
            if(LinkedList.findLinkedListsSize(dealerList) == 0)
            {
                Console.WriteLine("Dealer list is Empty");
                return;
            }
             //Printing dealer list and select one of them
            Console.WriteLine("Dealer List");
            LinkedList.Print(dealerList);
            int selectionNumber;
            while(true)
            {
                Console.Write("Select a Dealer: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out selectionNumber);
                if(isnumber)
                {
                    if( selectionNumber < 1 || selectionNumber > LinkedList.findLinkedListsSize(dealerList))
                    {
                        Console.WriteLine("ERROR:Invalid Selection");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR:Invalid Selection");
                    continue;
                }

                break;
            }

            //Assigning selected dealer to variable for deleting
            string selectedDealer = LinkedList.takeLinkedListsElement(dealerList, selectionNumber+1);
            words = selectedDealer.Split("|");
            //Assign dealer class and delete
            Dealer dealer = new Dealer(MyFile.file_UserAssign(Global.UserPath, words[1]));
            dealer.deleteAccount();
            
        }
    }
}