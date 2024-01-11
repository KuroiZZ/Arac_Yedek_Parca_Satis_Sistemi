//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    internal static class Starter
    {
        //Assigns default elements
        internal static void assignDefaultUsers()
        {
            if(!File.Exists(Global.UserPath))
            {
                Manager manager1 = new Manager("KaplanK", "KaplanK124*", "Kaplan Kaplan", "KaplanK@", "123-123-1234");
                Dealer dealer1 = new Dealer("Yusuf", "Yusuf4141*", "Yusuf Kozan", "Yusuf@", "214-214-2145");
                Dealer delaer2 = new Dealer("Erkut", "Erkut2121*", "Erkut Yildirim", "Erkut@", "215-215-2156");
                Customer costumer1 = new Customer("Habil", "Habil01*", "Habil Tatarogullari", "Habil@", "124-124-1245");
                Customer costumer2 = new Customer("Gunes", "Gunes01*", "Gunes Balci", "Gunes@", "125-125-1256");

                MyFile.file_UserAdder(manager1, Global.UserPath);
                MyFile.file_UserAdder(dealer1, Global.UserPath);
                MyFile.file_UserAdder(delaer2, Global.UserPath);
                MyFile.file_UserAdder(costumer1, Global.UserPath);
                MyFile.file_UserAdder(costumer2, Global.UserPath);
            }
        }

        internal static void assignDefaultCars()
        {
            if(!File.Exists(Global.CarPath))
            {
                LinkedList spareparts = new LinkedList();
                LinkedList.addNode(spareparts, "Exhaust 20");
                LinkedList.addNode(spareparts, "Shaft 12");
                LinkedList.addNode(spareparts, "Brake_pad 38");
                LinkedList.addNode(spareparts, "Chassis 92");
                LinkedList.addNode(spareparts, "Gearbox 21");
                LinkedList.addNode(spareparts, "Shock_absorber 128");
                LinkedList.addNode(spareparts, "Radiator 321");
                

                Car car1 = new Car("Toyota", "Corolla", "Hybrid", spareparts);
                Car car2 = new Car("Toyota", "Corolla", "Trim", spareparts);

                Car car3 = new Car("Nissan", "Qashqai", "EPower", spareparts);
                Car car4 = new Car("Nissan", "Qashqai", "Trim", spareparts);

                Car car5 = new Car("Opel", "Corsa", "Hybrid", spareparts);
                Car car6 = new Car("Opel", "Corsa", "Trim", spareparts);

                Car car7 = new Car("Tesla", "Model Y", "Hybrid", spareparts);
                Car car8 = new Car("Tesla", "Model Y", "Trim", spareparts);

                Car car9 = new Car("Mercedes", "Benz", "Hybrid", spareparts);
                Car car10 = new Car("Mercedes", "Benz", "Trim", spareparts);

                Car car11 = new Car("Honda", "Civic", "Hybrid", spareparts);
                Car car12 = new Car("Honda", "Civic", "Trim", spareparts);

                Car car13 = new Car("BMW", "i5", "Hybrid", spareparts);
                Car car14 = new Car("BMW", "i5", "Trim", spareparts);

                Car car15 = new Car("Ford", "Focus", "Hybrid", spareparts);
                Car car16 = new Car("Ford", "Focus", "Trim", spareparts);

                Car car17 = new Car("Volkswagen", "Polo", "Hybrid", spareparts);
                Car car18 = new Car("Volkswagen", "Polo", "Trim", spareparts);

                Car car19 = new Car("Volvo", "XC40", "Hybrid", spareparts);
                Car car20 = new Car("Volvo", "XC40", "Trim", spareparts);

                MyFile.file_CarAdder(car1, Global.CarPath);
                MyFile.file_CarAdder(car2, Global.CarPath);
                MyFile.file_CarAdder(car3, Global.CarPath);
                MyFile.file_CarAdder(car4, Global.CarPath);
                MyFile.file_CarAdder(car5, Global.CarPath);
                MyFile.file_CarAdder(car6, Global.CarPath);
                MyFile.file_CarAdder(car7, Global.CarPath);
                MyFile.file_CarAdder(car8, Global.CarPath);
                MyFile.file_CarAdder(car9, Global.CarPath);
                MyFile.file_CarAdder(car10, Global.CarPath);
                MyFile.file_CarAdder(car11, Global.CarPath);
                MyFile.file_CarAdder(car12, Global.CarPath);
                MyFile.file_CarAdder(car13, Global.CarPath);
                MyFile.file_CarAdder(car14, Global.CarPath);
                MyFile.file_CarAdder(car15, Global.CarPath);
                MyFile.file_CarAdder(car16, Global.CarPath);
                MyFile.file_CarAdder(car17, Global.CarPath);
                MyFile.file_CarAdder(car18, Global.CarPath);
                MyFile.file_CarAdder(car19, Global.CarPath);
                MyFile.file_CarAdder(car20, Global.CarPath);
            }

        }

        internal static void assignDefaultOrders()
        {
            if(!File.Exists(Global.shoppingCartPath))
            {
                File.AppendAllText(Global.shoppingCartPath, "Habil:Opel-Corsa-Hybrid-Shock_absorber-25:Pending\n");
                File.AppendAllText(Global.shoppingCartPath, "Habil:Mercedes-Benz-Hybrid-Shock_absorber-25:Pending\n");
            }
        }
    }
}