//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    //Creating dealer class with inheritance of user class
    internal class Dealer : User
    {
        internal Dealer(string id, string password, string name, string mail, string phone_no) :base(id,password,name,mail,phone_no)
        {
            this.statu = "@2";
        }
        internal Dealer(User User) :base(User.id, User.password, User.name, User.mail, User.phone_no)
        {
            this.statu = "@2";
        }

        internal void addCar()
        {
            Console.Clear();
            string control = "|";
            //Taking brand data
            string brand;
            while(true)
            {
                Console.Write("Please Enter Vehicle Brand: ");
                brand = Convert.ToString(Console.ReadLine());
                if(brand.Contains(control))
                {
                    Console.WriteLine("Car brand cannot contains '|'");
                    continue;
                }
                break;
            }
            
            

            //Taking model data
            string model;
            while(true)
            {
                Console.Write("Please Enter Vehicle Model: ");
                model = Convert.ToString(Console.ReadLine());
                if(model.Contains(control))
                {
                    Console.WriteLine("Car brand cannot contains'|'");
                    continue;
                }
                break;
            }

            string package;
            while(true)
            {
                //Taking package data.
                Console.Write("Please Enter Vehicle Package: ");
                package = Convert.ToString(Console.ReadLine());
                if(package.Contains(control))
                {
                    Console.WriteLine("Car package cannot contains'|'");
                    continue;
                }
                //Assigning new car with the data recieved.
                Car temp_cr = new Car(brand, model, package, null);
                //Controlling car if is already exist.
                if(MyFile.file_CarReader(temp_cr, Global.CarPath))
                {
                    Console.WriteLine("This car is already exist please enter new package!!!");
                    continue;
                }
                break;
            }

            //Creating spareparts list
            LinkedList spareparts = new LinkedList();
            while(true)
            {
                //Taking spare part name with desired pattern
                Console.Write("Please Enter Sparepart Name: ");
                string sparepart = Convert.ToString(Console.ReadLine());
                if(sparepart.Contains(control))
                {
                    Console.WriteLine("Car's sparepart cannot contains'|'");
                    continue;
                }
                if(Controller.WhiteSpaceController(sparepart))
                {
                    Console.WriteLine("Spare parts cant contains white space\nMust be in xxx_xxx format");
                    continue;
                }
                //Taking spare part quantity 
                string quantity;
                while(true)
                {
                    Console.Write("Please Enter Spareparts Quantity: ");
                    quantity = Convert.ToString(Console.ReadLine());
                    bool isnumber= int.TryParse(quantity, out int A);
                    if(isnumber)
                    {
                        if(Convert.ToInt32(quantity) < 0)
                        {
                            Console.WriteLine("You cant enter negative sparepart stock");
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

                //Creating final data and adding to list
                string final = sparepart + " " + quantity;
                LinkedList.addNode(spareparts, final);

                Console.Write("For Entering New Sparepart (1): ");
                int selectionNumber = Convert.ToInt32(Console.ReadLine());
                if(selectionNumber != 1)
                {
                    break;
                }
            }

            //Creating new car with received datas
            Car cr = new Car(brand, model, package, spareparts);

            //Adding car to the car file.
            MyFile.file_CarAdder(cr, Global.CarPath);

        }

        internal void UpdateSparePartQuantity()
        {
            Console.Clear();
            //Reading all txt to string array to use.
            string[] carfileContents = File.ReadAllLines(Global.CarPath);
            string[] words;
             //Creating Linkedlist for to listing cars.
            LinkedList carlist = new LinkedList(string.Empty);
            for(int i = 0; i<carfileContents.Length; i++)
            {
                //Dividing content to words and adding to list.
                words = carfileContents[i].Split("-");
                LinkedList.addNode(carlist, (words[0] + "-" + words[1]));
            }
            //Controlling for if the list is empty;
            if(LinkedList.findLinkedListsSize(carlist) == 0)
            {
                Console.WriteLine("Car list is Empty");
                return;
            }
            //Printing car list and select one of them.
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
            //Assigning selected car to variable for controls.
            string selectedCar = LinkedList.takeLinkedListsElement(carlist, selectionNumber+1);
            //Creating Linkedlist for to listing car packages.
            LinkedList packagelist = new LinkedList();
            for(int j = 0; j<carfileContents.Length; j++)
            {
                //Dividing content to words and adding to list while controlling with selectedCar.
                words = carfileContents[j].Split("-");
                if(selectedCar == (words[0] + "-" + words[1]))
                {
                    LinkedList.addNode(packagelist, (words[0] + "-" + words[1] + "-" + words[2]));
                }
            }
            //Printing car package list and select one of them.
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
            //Assigning selected car package to variable for controls.
            string selectedPackage = LinkedList.takeLinkedListsElement(packagelist, selectionNumber+1);
            //Creating Linkedlist for to listing spare parts.
            LinkedList sparePartlist = new LinkedList();
            for(int k = 0; k<carfileContents.Length; k++)
            {
                words = carfileContents[k].Split("-");
                if(selectedPackage == (words[0] + "-" + words[1] + "-"+ words[2]))
                {
                    //Dividing content to words and adding to list while controlling with selectedPackage.
                    string[] spareParts = words[3].Split("|");
                    for(int l = 1; l<spareParts.Length; l++)
                    {
                        LinkedList.addNode(sparePartlist, spareParts[l]);
                    }
                }
            }
            //Printing spare part list and select one of them.
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

            //Assigning selected spare part to variable for controls.
            string selecedSparepart = LinkedList.takeLinkedListsElement(sparePartlist, selectionNumber+1);
            words = selecedSparepart.Split(" ");
            //Taking new quantity and changing selected sparepart's quantity.

            int new_quantity;
            while(true)
            {
                Console.Write("Enter New Quantity: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out new_quantity);
                if(isnumber)
                {
                    if(new_quantity < 0)
                    {
                        Console.WriteLine("You cant enter negative stock number");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Invalid Entrance");
                    continue;
                }

                break;
            }

            words[1] = new_quantity.ToString();

            //Changing selected spare part's data in sparepart list.
            LinkedList temp_sparePartList = sparePartlist;
            for(int i = 1; i<selectionNumber+1; i++)
            {
                temp_sparePartList = temp_sparePartList.next;
            }
            temp_sparePartList.data = words[0] + " " + words[1];

            //Creating new car with new sparepart list.
            string new_car = selectedPackage + "-";

            sparePartlist = sparePartlist.next;
            while(sparePartlist != null)
            {
                new_car += "|";
                new_car += sparePartlist.data;
                sparePartlist = sparePartlist.next;
            }

            //assigning new car in file contents.
            for(int i = 0; i<carfileContents.Length; i++)
            {
                words = carfileContents[i].Split("|");
                if(words[0] == selectedPackage + "-")
                {
                    carfileContents[i] = new_car;
                    break;
                }
            }

            //Rewriting txt with new file contetnts.
            File.WriteAllText(Global.CarPath, "");
            for(int i = 0; i<carfileContents.Length; i++)
            {
                File.AppendAllText(Global.CarPath, carfileContents[i] + "\n");
            }
        }

        internal void UpdateCartState()
        {
            if(File.Exists(Global.shoppingCartPath))
            {
                Console.Clear();
                //Reading all txt to string array to use.
                string[] cartfileContents = File.ReadAllLines(Global.shoppingCartPath);
                string[] words;
                //Creating cart list for listing carts
                LinkedList cartlist = new LinkedList();
                for(int i = 0; i<cartfileContents.Length; i++)
                {
                    //Dividing content to words and adding to list if order is pending
                    words = cartfileContents[i].Split(":");
                    if(words[2] == "Pending")
                    {
                        LinkedList.addNode(cartlist, cartfileContents[i]);
                    }
                }
                //Controlling for if the list is empty;
                if(LinkedList.findLinkedListsSize(cartlist) == 0)
                {
                    Console.WriteLine("Shopping cart list is Empty");
                    return;
                }
                //Printing order list and select one of them
                Console.WriteLine("Order List");
                LinkedList.Print(cartlist);
                int selectionNumber;
                while(true)
                {
                    Console.Write("Select a Order: ");
                    string number = Convert.ToString(Console.ReadLine());
                    bool isnumber = int.TryParse(number, out selectionNumber);
                    if(isnumber)
                    {
                        if( selectionNumber < 1 || selectionNumber > LinkedList.findLinkedListsSize(cartlist))
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

                //Assigning selected order to variable for controls
                string selectedOrder = LinkedList.takeLinkedListsElement(cartlist, selectionNumber+1);

                for(int i = 0; i<cartfileContents.Length; i++)
                {
                    //
                    if(selectedOrder == cartfileContents[i])
                    {
                        //Dividing content to words for changing
                        words = cartfileContents[i].Split(":");
                        int operationNumber;
                        Console.WriteLine("For Accepting (1)\nFor Declining (2)\nFor Showing costurmer's informations (3)");
                        while(true)
                        {
                            Console.Write("Select: ");
                            string number = Convert.ToString(Console.ReadLine());
                            bool isnumber = int.TryParse(number, out operationNumber);
                            if(isnumber)
                            {
                                if(operationNumber < 0 || operationNumber >3)
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

                        if(operationNumber == 1)
                        {
                            words[2] = "Accepted";
                            
                            //Dividing content to element for assigning a car 
                            string[] elements = words[1].Split("-");
                            //Assigning car with elements
                            Car cr = MyFile.file_CarAssign(Global.CarPath, elements[0],elements[1],elements[2]);
                            //Creating temporary linked list for car's spareparts
                            LinkedList temp_sparepartlist = cr.sparepart;
                            
                            temp_sparepartlist = temp_sparepartlist.next;
                            while(temp_sparepartlist != null)
                            {
                                //Dividing spareparts to name and quantity and controlling with selected
                                string[] sparePartContents = temp_sparepartlist.data.Split(" ");
                                if(sparePartContents[0] == elements[3])
                                {
                                    //Creating new stock variable
                                    int new_stock = Convert.ToInt32(sparePartContents[1]) - Convert.ToInt32(elements[4]);
                                    if(new_stock < 0)
                                    {
                                        Console.WriteLine("We dont have much in stock pls update stocks");
                                        return;
                                    }
                                    sparePartContents[1] = new_stock.ToString();
                                    //Assignin new spare part stock to spare part
                                    temp_sparepartlist.data = sparePartContents[0] + " " + sparePartContents[1];                          
                                    break;
                                }
                                temp_sparepartlist = temp_sparepartlist.next;
                            }

                            //Reading all txt to string array to use.
                            string[] carfileContent = File.ReadAllLines(Global.CarPath);
                            for(int j = 0; j<carfileContent.Length; j++)
                            {
                                //Dividing car's data for controlling
                                string[] carcontents = carfileContent[j].Split("-");
                                if(carcontents[0] + "-" + carcontents[1] + "-" + carcontents[2] == cr.brand + "-" + cr.model + "-" + cr.package)
                                {
                                    //Creating new car and assign in filecontents
                                    string new_car = cr.brand + "-" + cr.model + "-" + cr.package + "-";
                                    cr.sparepart = cr.sparepart.next;
                                    while(cr.sparepart != null)
                                    {
                                        new_car += "|";
                                        new_car += cr.sparepart.data;
                                        cr.sparepart = cr.sparepart.next;
                                    }
                                    carfileContent[j] = new_car; 
                                    break;
                                }
                            }
                            //Rewriting txt with new filecontents.
                            File.WriteAllText(Global.CarPath, "");
                            for(int k = 0; k<carfileContent.Length; k++)
                            {
                                File.AppendAllText(Global.CarPath, carfileContent[k] + "\n");
                            }
                            

                        }

                        if(operationNumber == 2)
                        {
                            words[2] = "Declined";
                        }
                        //Assign updated cart to contents.
                        cartfileContents[i] = words[0] + ":" + words[1] + ":" + words[2];

                        if(operationNumber == 3)
                        {
                            User user = MyFile.file_UserAssign(Global.UserPath, words[0]);
                            Console.WriteLine("{0}-{1}-{2}-{3}",user.id, user.name, user.mail, user.phone_no);
                        }


                        break;
                    }
                }

                //Rewriting txt with new filecontents.
                File.WriteAllText(Global.shoppingCartPath, "");
                for(int i = 0; i<cartfileContents.Length; i++)
                {
                    File.AppendAllText(Global.shoppingCartPath, cartfileContents[i] + "\n");
                }
            }
           
        }

        internal void deleteCar()
        {
            Console.Clear();
            //Reading all txt to string array to use.
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

            //Reading all txt to string array to use.
            string[] cartfileContents = File.ReadAllLines(Global.shoppingCartPath);
            string[] OrderContent;

            for(int i = 0; i<cartfileContents.Length; i++)
            {
                //Dividing content to words and controlling if this car has a pending order if it is not deleting
                OrderContent = cartfileContents[i].Split(":");
                string[] OrderPart = OrderContent[1].Split("-");
                if(OrderContent[2] == "Pending")
                {
                    if(selectedPackage == OrderPart[0] + "-" + OrderPart[1]+ "-" + OrderPart[2])
                    {
                        Console.WriteLine("This car has a order please answer that first!!");
                        return;
                    }
                }
            }
            

            for(int i = 0; i<carfileContents.Length; i++)
            {
                //Dividing content to words for finding in txt.
                words = carfileContents[i].Split("-");
                if(selectedPackage == words[0] + "-" + words[1] + "-" + words[2])
                {
                    //When find it shifts array.
                    for(int j = i; j<carfileContents.Length-1; j++)
                    {
                        carfileContents[j] = carfileContents[j+1];
                    }
                    break;
                }  
            }

            //Rewriting txt with new filecontents.
            File.WriteAllText(Global.CarPath, "");
            for(int i = 0; i<carfileContents.Length-1; i++)
            {
                File.AppendAllText(Global.CarPath, carfileContents[i] + "\n");
            }
        }

        internal void deleteAccount()
        {
            //Reading all txt to string array to use.
            string[] userfileContents = File.ReadAllLines(Global.UserPath);
            string[] words;
            for(int i = 0; i<userfileContents.Length; i++)
            {
                //Dividing content to words for finding in txt.
                words = userfileContents[i].Split("|");
                if(this.id == words[1])
                {
                    //When find it shifts array.
                    for(int j = i; j<userfileContents.Length-1; j++)
                    {
                        userfileContents[j] = userfileContents[j+1];
                    }
                    break;
                }  
            }

            //Rewriting txt with new filecontents.
            File.WriteAllText(Global.UserPath, "");
            for(int i = 0; i<userfileContents.Length-1; i++)
            {
                File.AppendAllText(Global.UserPath, userfileContents[i] + "\n");
            }

        }
    }
}