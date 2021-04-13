using Application.Locations.Queries.GetLocations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Trees.LocationTree
{
    /// <summary>
    /// A class to implement a binary search tree having locations
    /// </summary>
    public class LocationTree
    {
        public Node root;
        public Node current;
        public Node tempParent;

        public LocationTree()
        {
            root = null;
        }

        public IList<LocationDto> Search(int maxDistance, int maxResults)
        {
            IList<LocationDto> results = new List<LocationDto>();
            SearchLocations(root, maxDistance, maxResults, results);
            return results;
        }

        private void SearchLocations(Node root, double maxDistance, int maxResults, IList<LocationDto> results)
        {
            if (root == null) return;

            if (root.Key <= maxDistance)
            {
                results.Add(root.Location);
                SearchLocations(root.Left, maxDistance, maxResults, results);
                SearchLocations(root.Right, maxDistance, maxResults, results);
            }
            else
            {
                SearchLocations(root.Left, maxDistance, maxResults, results);
            }
        }

        /// <summary>
        /// Method to insert location to the tree
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public void Insert(LocationDto location)
        {
            Node newNode = new Node(location);
            if (root == null) //First node insertion 
            {
                root = newNode;
            }
            else
            {
                current = root;
                while (true)
                {
                    tempParent = current;
                    if (newNode.Key < current.Key)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            tempParent.Left = newNode;
                            newNode.Parent = tempParent;

                            return;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            tempParent.Right = newNode;
                            newNode.Parent = tempParent;

                            return;
                        }
                    }
                }
            }
        }
    }
}
