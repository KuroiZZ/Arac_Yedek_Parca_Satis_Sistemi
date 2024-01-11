//220229026_HabilTataroğulları
using System;

namespace Workspace
{
    //Creating car class
    internal class Car
    {
        internal string brand;
        internal string model;
        internal string package;
        internal LinkedList sparepart;
        internal Car(string brand, string model, string package, LinkedList sparepart)
        {
            this.brand = brand;
            this.model = model;
            this.package = package;
            this.sparepart = sparepart;
        }
    }
}