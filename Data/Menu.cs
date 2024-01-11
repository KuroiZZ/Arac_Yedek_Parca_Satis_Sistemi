//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    internal static class Menu
    {
        internal static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Spare Part Sale System\n(1)-Login\n(2)-Register\n(3)-Close Program");
            while(true)
            {
                Console.Write("Select: ");
                string number = Convert.ToString(Console.ReadLine());
                int menuNumber;
                bool isnumber = int.TryParse(number, out menuNumber);
                if(isnumber)
                {
                    if(menuNumber == 1)
                    {
                        UserLoginMenu();
                        break;
                    }
                    if(menuNumber == 2)
                    {
                        UserRegisterMenu();
                        break;
                    }
                    if(menuNumber == 3)
                    {
                        return;
                    }
                    if(menuNumber < 1 || menuNumber > 3)
                    {
                        Console.WriteLine("ERROR:Invalid Selection");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR:Invalid Selection");
                }
            }

        }
        
        internal static void UserRegisterMenu()
        {
            int UserType;
            Console.Clear();
            Console.WriteLine("Please select user type");
            Console.WriteLine("(1)-Customer\n(2)-Dealer");
            //Checks that the entered value is within the desired range
            while(true)
            {
                Console.Write("Select: ");
                string number = Convert.ToString(Console.ReadLine());
                bool isnumber = int.TryParse(number, out UserType);
                if(isnumber)
                {
                    if(!(UserType == 1 || UserType == 2))
                    {
                        Console.WriteLine("ERROR:Invalid selection");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR:Invalid selection");
                }
            }
            Console.Clear();
            string id, password, name, mail, phone_no;
            //Defines id rules
            Console.WriteLine("Enter your Id\nRules\nId need to be in 5 to 20 character.");
            Console.WriteLine("Id can only contain numeric or alphabetic characters.\nFirst character of the Id must be an alphabetic character.");
            //It is repeated until the entered value is as desired.
            while(true)
            {
                Console.Write("İd: ");
                id = Convert.ToString(Console.ReadLine());
                if(MyFile.file_IdReader(Global.UserPath, id))
                {
                    Console.WriteLine("ERROR:This Id is already taken");
                }
                else
                {
                    if(Controller.idController(id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ERROR:Id is not in the desired pattern.");
                    }
                }

            }

            Console.Clear();
            Console.WriteLine("Your ID has been assigned: {0}\n",id);

            //Defines password rules
            Console.WriteLine("Enter your Password\nRules\nPassword need to be in 8 to 20 character\nPassword need has at least one number.");
            Console.WriteLine("Password must contain at least one uppercase letter.\nPassword must contain at least one lowercase letter.");
            Console.WriteLine("Pssword must contain at least one special character consisting of the characters '!@#$%&*-+'.\nPassword cannot contain any spaces");
            //It is repeated until the entered value is as desired.
            while(true)
            {
                Console.Write("password: ");
                password = Convert.ToString(Console.ReadLine());
                if(Controller.passwordController(password))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR:Password is not in the desired pattern.");
                    
                }
            }

            Console.Clear();
            Console.WriteLine("Your Id has been assigned: {0}",id);
            Console.WriteLine("Your password has been assigned: {0}\n",password);

            //Defines name rules
            Console.WriteLine("Enter your name\nRules\nName must start with an uppercase or lowercase lette.\nName cannot contain any special characters.");
            //It is repeated until the entered value is as desired.
            while(true)
            {
                Console.Write("name: ");
                name = Convert.ToString(Console.ReadLine());
                if(Controller.nameController(name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR:Name is not in the desired pattern.");
                }
            }

            Console.Clear();
            Console.WriteLine("Your Id has been assigned: {0}",id);
            Console.WriteLine("Your password has been assigned: {0}",password);
            Console.WriteLine("Your name has been assigned: {0}\n",name);

            //Defines mail rules
            Console.WriteLine("Enter your mail\nRules\nMail cannot start with special charachters\nMail must contain '@' symbol");
            //It is repeated until the entered value is as desired.
            while(true)
            {
                Console.Write("Mail: ");
                mail = Convert.ToString(Console.ReadLine());
                if(Controller.mailController(mail))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR:Mail is not in the desired pattern.");
                }
            }

            Console.Clear();
            Console.WriteLine("Your Id has been assigned: {0}",id);
            Console.WriteLine("Your password has been assigned: {0}",password);
            Console.WriteLine("Your name has been assigned: {0}",name);
            Console.WriteLine("Your mail has been assigned: {0}\n",mail);

            //Defines phone number rules
            Console.WriteLine("Enter your phone number\nRules\nPhone number must be in 'xxx-xxx-xxxx' format\nPhone number cannot contain any letter");
            //It is repeated until the entered value is as desired.
            while(true)
            {
                Console.Write("Telefon No: ");
                phone_no = Convert.ToString(Console.ReadLine());
                if(Controller.phone_noController(phone_no))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR:Phone number is not in the desired pattern.");
                }
            }
            
            if(UserType == 1)
            {
                Customer User = new Customer(id, password, name, mail, phone_no);
                MyFile.file_UserAdder(User , Global.UserPath);
                Menu.customerMenu(User);
            }
            if(UserType == 2)
            {
                Dealer User = new Dealer(id, password, name, mail, phone_no);
                MyFile.file_UserAdder(User , Global.UserPath);
                Menu.dealerMenu(User);
            }
        }

        internal static void UserLoginMenu()
        {
            Console.Clear();
            string id, password;
            Console.WriteLine("Please enter your Id and Password. ");
            //It is repeated until the entered values is as desired.
            while(true)
            {
                Console.Write("Id: ");
                id = Convert.ToString(Console.ReadLine());
                Console.Write("password: ");
                password = Convert.ToString(Console.ReadLine());
                if(MyFile.file_IdReader(Global.UserPath, id) && MyFile.file_PasswordReader(Global.UserPath,id,password))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Id or Password is wrong please try again!!!");
                }
            }
            //Assigning user with id
            User kc = MyFile.file_UserAssign(Global.UserPath, id);
            //Checks the user is customer, delaer or manager
            if(kc.statu == "@1")
            {
                Customer cr = new Customer(kc);
                Menu.customerMenu(cr);
            }
            else if(kc.statu == "@2")
            {
                Dealer dl = new Dealer(kc);
                Menu.dealerMenu(dl);
            }
            else if(kc.statu == "@3")
            {
                Manager mg = new Manager(kc);
                Menu.managerMenu(mg);
            }
        }

        internal static void customerMenu(Customer customer)
        {
            int action = 0;
            bool isnumber = true;
            if(isnumber)
            {
                if(action == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Customer Menu-{0}",customer.name);
                    Console.WriteLine("(1)-Buy car's sparepart");
                    Console.WriteLine("(2)-Show my shopping cart");
                    Console.WriteLine("(3)-Delete my account");
                    Console.WriteLine("(4)-Exit my account");
                    Console.Write("Your Choice: ");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                }
                if(action == 1)
                {
                    
                    customer.list_cars();
                    Console.Write("\n(0)-Return customer menu\n(4)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.customerMenu(customer);
                        }
                        if(action == 4)
                        {}
                        else
                        {
                            return;
                        }
                    }

                }

                if(action == 2)
                {
                    customer.list_cart(customer.id);
                    Console.Write("\n(0)-Return customer menu\n(4)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.customerMenu(customer);
                        }
                        if(action == 4)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }

                if(action == 3)
                {
                    customer.deleteAccount();
                    Menu.MainMenu();
                }

                if(action == 4)
                {
                    Console.Clear();
                    Menu.MainMenu();
                }

                if(action > 4 || action < 0)
                {
                    Menu.customerMenu(customer);
                }
            }

        }

        internal static void dealerMenu(Dealer dealer)
        {
            int action = 0;
            bool isnumber =true;
            if(isnumber)
            {
                if(action == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Dealer Menu-{0}",dealer.name);
                    Console.WriteLine("(1)-Adding new car");
                    Console.WriteLine("(2)-Update spare part stock");
                    Console.WriteLine("(3)-Update shopping carts");
                    Console.WriteLine("(4)-Delete car");
                    Console.WriteLine("(5)-Delete my account");
                    Console.WriteLine("(6)-Exit my account");
                    Console.Write("Your Choice: ");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                }

                if(action == 1)
                {
                    dealer.addCar();
                    Console.Write("\n(0)-Return dealer menu\n(6)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.dealerMenu(dealer);
                        }
                        if(action == 6)
                        {}
                        else
                        {
                            return;
                        }
                    }

                }

                if(action == 2)
                {

                    dealer.UpdateSparePartQuantity();
                    Console.Write("\n(0)-Return dealer menu\n(6)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.dealerMenu(dealer);
                        }
                        if(action == 6)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }

                if(action == 3)
                {
                    dealer.UpdateCartState();
                    Console.Write("\n(0)-Return dealer menu\n(6)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.dealerMenu(dealer);
                        }
                        if(action == 6)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }

                if(action == 4)
                {
                    dealer.deleteCar();
                    Console.Write("\n(0)-Return dealer menu\n(6)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.dealerMenu(dealer);
                        }
                        if(action == 6)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }

                if(action == 5)
                {

                    dealer.deleteAccount();
                    Menu.MainMenu();
                }

                if(action == 6)
                {
                    Menu.MainMenu();
                }

                if(action > 6 || action < 0)
                {
                    Menu.dealerMenu(dealer);
                }
            }

        }
        
        internal static void managerMenu(Manager manager)
        {
            int action = 0;
            bool isnumber = true;
            if(isnumber)
            {
                if(action == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Manager Menu-{0}",manager.name);
                    Console.WriteLine("(1)-Delete Car");
                    Console.WriteLine("(2)-Delete Customer");
                    Console.WriteLine("(3)-Delete Dealer");
                    Console.WriteLine("(4)-Exit my account");
                    Console.Write("Your Choice: ");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                }

                if(action == 1)
                {
                    manager.deleteCar();
                    Console.Write("\n(0)-Return manager menu\n(4)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.managerMenu(manager);
                        }
                        if(action == 4)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }

                if(action == 2)
                {
                    manager.deleteCustomer();
                    Console.Write("\n(0)-Return manager menu\n(4)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.managerMenu(manager);
                        }
                        if(action == 4)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }

                if(action == 3)
                {
                    manager.deleteDealer();
                    Console.Write("\n(0)-Return manager menu\n(4)-Exit my account\nSelect:");
                    string number = Convert.ToString(Console.ReadLine());
                    isnumber = int.TryParse(number, out action);
                    if(isnumber)
                    {
                        if(action == 0)
                        {
                            Menu.managerMenu(manager);
                        }
                        if(action == 4)
                        {}
                        else
                        {
                            return;
                        }
                    }
                }
                
                if(action == 4)
                {
                    Console.Clear();
                    Menu.MainMenu();
                }
                
                if(action > 4 || action < 0)
                {
                    Menu.managerMenu(manager);
                }
            }

        }
    }
}
