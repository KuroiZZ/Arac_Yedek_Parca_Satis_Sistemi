//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    internal static class MyFile
    {
        //Adding user in desired txt path
        internal static void file_UserAdder(User User, string path)
        {
            File.AppendAllText(path, User.statu + "|");
            File.AppendAllText(path, User.id + "|");
            File.AppendAllText(path, User.password + "|");
            File.AppendAllText(path, User.name + "|");
            File.AppendAllText(path, User.mail + "|");
            File.AppendAllText(path, User.phone_no + "\n");
        }

        //Controlling if desired txt path already has this id in it
        internal static bool file_IdReader(string path, string id)
        {
            string[] fileContents = File.ReadAllLines(path);
            for(int i = 0; i<fileContents.Length; i++)
            {
                string[] words = fileContents[i].Split("|");
                string temp_id = words[1];
                if(temp_id == id)
                {
                    return true;
                }
            }

            return false;
        }

        //Controlling desired id's password is it equal to what we enters
        internal static bool file_PasswordReader(string path, string id, string password)
        {
            string[] fileContents = File.ReadAllLines(path);
            for(int i = 0; i<fileContents.Length; i++)
            {
                string[] words = fileContents[i].Split("|");
                string temp_id = words[1];
                string temp_password = words[2];
                if(temp_id == id)
                {
                    if(temp_password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Uses id to assign user
        internal static User file_UserAssign(string path, string id)
        {
            string[] fileContents = File.ReadAllLines(path);
            string[] UserContents = null;
            for(int i = 0; i<fileContents.Length; i++)
            {
                string[] words = fileContents[i].Split("|");
                string temp_id = words[1];
                if(temp_id == id)
                {
                    UserContents = words;
                    break;
                }
            }

            User Kc = new User(UserContents[1], UserContents[2], UserContents[3], UserContents[4], UserContents[5], UserContents[0]);
            
            return Kc;
        }

        //Adding car in desired txt path   
        internal static void file_CarAdder(Car car, string path)
        {
            File.AppendAllText(path, car.brand + "-");
            File.AppendAllText(path, car.model + "-");
            File.AppendAllText(path, car.package + "-");
            car.sparepart = car.sparepart.next;
            while(car.sparepart != null)
            {
                File.AppendAllText(path, "|");
                File.AppendAllText(path, car.sparepart.data);
                car.sparepart = car.sparepart.next;
            }
            File.AppendAllText(path, "\n");
        }

        //Controlling if desired txt path already has this car in it
        internal static bool file_CarReader(Car car, string path)
        {
            string controlCar = car.brand + car.model + car.package;
            string[] fileContents = File.ReadAllLines(path);
            for(int i = 0; i<fileContents.Length; i++)
            {
                string[] words = fileContents[i].Split("-");
                if(controlCar == words[0] + words[1] + words[2])
                {
                    return true;
                }
            }
            return false;
        } 

        //Uses car's brand, model and package to assign a car 
        internal static Car file_CarAssign(string path, string brand, string model, string package)
        {
            string[] fileContents = File.ReadAllLines(path);
            string[] carContents = null;
            LinkedList spareparts = new LinkedList();
            for(int i = 0; i<fileContents.Length; i++)
            {
                string[] words = fileContents[i].Split("-");
                string temp_car = words[0] + words[1] + words[2];
                if(temp_car == brand + model + package)
                {
                    carContents = words;
                    break;
                }
            }
            string [] spareParts = carContents[3].Split("|");
            for(int i = 1; i<spareParts.Length; i++)
            {
                LinkedList.addNode(spareparts, spareParts[i]);
            }

            Car cr = new Car(carContents[0],carContents[1], carContents[2], spareparts);

            return cr;
        }
    }
}