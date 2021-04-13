using Application.Locations.Queries.GetLocations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Trees.LocationTree
{
    public class Node
    {
        public double Key;
        public Node Left;
        public Node Right;
        public Node Parent;

        public LocationDto Location;

        public Node(LocationDto location)
        {
            this.Location = location;
            this.Key = location.Distance;
        }

        public void DisplayNode()
        {
            Console.Write(Key + " ");
        }
    }
}
