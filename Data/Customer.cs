//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    //Creating customer class with inheritance of user class
    internal class Customer : User
    {
        internal Customer(string id, string password, string name, string mail, string phone_no) :base(id,password,name,mail,phone_no)
        {
            this.statu = "@1";
        }

        internal Customer(User User) :base(User.id, User.password, User.name, User.mail, User.phone_no)
        {
            this.statu = "@1";
        }   
        
        //Select a car and it's sparepart to buy
        internal void list_cars()
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

            Console.Clear();
            //Assigning selected car package to variable for controls
            string selectedPackage = LinkedList.takeLinkedListsElement(packagelist, selectionNumber+1);
            //Creating Linkedlist for to listing spare parts
            LinkedList sparePartlist = new LinkedList();
            for(int k = 0; k<carfileContents.Length; k++)
            {
                //Dividing content to words and adding to list while controlling with selectedPackage
                words = carfileContents[k].Split("-");
                if(selectedPackage == (words[0] + "-" + words[1] + "-"+ words[2]))
                {
                    string[] spareParts = words[3].Split("|");
                    for(int l = 1; l<spareParts.Length; l++)
                    {
                        LinkedList.addNode(sparePartlist, spareParts[l]);
                    }
                }
            }
            //Printing spare part list and select one of them
            Console.WriteLine("Sparepart List");
            LinkedList.Print(sparePartlist);
            while(true)
            {
                Console.Write("Select a Sparepart: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out selectionNumber);
                if(isnumber)
                {
                    if( selectionNumber < 1 || selectionNumber > LinkedList.findLinkedListsSize(sparePartlist))
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

            //Assigning selected spare part to variable for controls
            string selecedSparepart = LinkedList.takeLinkedListsElement(sparePartlist, selectionNumber+1);
            words = selecedSparepart.Split(" ");
            while(true)
            {
                //Selecting quantity and controlling for if spare part has this much
                while(true)
                {
                    Console.Write("Select Quantity:");
                    string number = Convert.ToString(Console.ReadLine());
                    bool isnumber = int.TryParse(number, out selectionNumber);
                    if(isnumber)
                    {
                        if(selectionNumber <0)
                        {
                            Console.WriteLine("You cant buy negative part");
                            continue;
                        }
                        if(selectionNumber == 0)
                        {
                            Console.WriteLine("You cant buy '0' item");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR:Invalid Entrance");
                        continue;
                    }

                    break;
                }

                if(selectionNumber <= Convert.ToInt32(words[1]))
                {
                    //Creating order and appending to shoppingcart txt
                    string final = this.id + ":" + selectedPackage + "-" + words[0] + "-" + selectionNumber.ToString() + ":Pending" + "\n";
                    File.AppendAllText(Global.shoppingCartPath, final);
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR: We dont have this much item please select new quantity.");
                }
            }

        }

        internal void list_cart(string id)
        {
            Console.Clear();
            if(File.Exists(Global.shoppingCartPath))
            {
                Console.WriteLine("Shopping Cart");
                //Reading all txt to string array for printing
                string[] cartfileContents = File.ReadAllLines(Global.shoppingCartPath);
                string[] words;
                for(int i = 0; i<cartfileContents.Length; i++)
                {
                    //Controlling for prints current customers shopping cart
                    words = cartfileContents[i].Split(":");
                    if(words[0] == id)
                    {
                        Console.WriteLine("{0}:{1}",words[1],words[2]);
                    }
                }
            }
        }      

        internal void deleteAccount()
        {
            //Reading all txt to string array for controlling
            string[] userfileContents = File.ReadAllLines(Global.UserPath);
            string[] cartfileContents = File.ReadAllLines(Global.shoppingCartPath);
            string[] words;
            for(int i = 0; i<userfileContents.Length; i++)
            {
                //Dividing content to words for controlling
                words = userfileContents[i].Split("|");
                if(this.id == words[1])
                {
                    //When it find current customer's location it shifts contents
                    for(int j = i; j<userfileContents.Length-1; j++)
                    {
                        userfileContents[j] = userfileContents[j+1];
                    }
                    break;
                }  
            }

            for(int i = 0; i<cartfileContents.Length; i++)
            {
                 //Dividing content to words for controlling
                words = cartfileContents[i].Split(":");
                //When it find current customer's order it makes empty
                if(this.id == words[0])
                {
                    cartfileContents[i] = " ";
                }
            }
            
            //Rewriting txt with shifted contents
            File.WriteAllText(Global.UserPath, "");
            for(int i = 0; i<userfileContents.Length-1; i++)
            {
                File.AppendAllText(Global.UserPath, userfileContents[i] + "\n");
            }

            //Rewriting txt with empty contents
            File.WriteAllText(Global.shoppingCartPath, "");
            for(int i = 0; i<cartfileContents.Length; i++)
            {
                //Controlling not empty contents and adds to txt
                if(cartfileContents[i] != " ")
                {
                    File.AppendAllText(Global.shoppingCartPath, cartfileContents[i] + "\n");
                }            
            }

        }
    }

}