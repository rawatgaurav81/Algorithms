using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// This heap  tree will function as my Priority Queue
    /// </summary>
    public struct Edge
    {
        public string edgeName;
        public int distance;
    }
    public class HeapTree
    {
        int size = 0;
        int capacity = 0;
        int[] items;
        public HeapTree(int capacity)
        {
            this.capacity = capacity;
            items = new int[this.capacity];
        }
        private void EnsureCapacity()
        {
            if (size == capacity)
            {
                int[] temp = items;
                items = new int[2 * capacity];
                Array.Copy(temp, items, capacity);
            }
        }
        private int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private Boolean hasLeftChild(int index) { return (getLeftChildIndex(index) < size); }
        private Boolean hasRightChild(int index) { return (getRightChildIndex(index) < size); }
        private Boolean hasParent(int index) { return (getParentIndex(index) >= 0); }

        private int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        private int rightChild(int index) { return items[getRightChildIndex(index)]; }
        private int parent(int index) { return items[getParentIndex(index)]; }

        public void Add(int number)
        {
            this.EnsureCapacity();
            size++;
            items[size] = number;
            ShiftUp();
        }
        public void Poll()
        {
            if (size == 0) throw new Exception("The queue is empty");
            int returnedValue = items[0];

            // Now we need to rearrange the tree
            items[0] = items[size - 1];
            items[size - 1] = 0;
            size--;
            ShiftDown();
        }
        private void ShiftDown()
        {

        }

        private void ShiftUp()
        {
            int childIndex = size - 1;
            int child = items[childIndex];
            int parentIndex = 0;
            while (hasParent(childIndex))
            {
                parentIndex = getParentIndex(childIndex);
                if (items[parentIndex] > child)
                {
                    items[childIndex] = items[parentIndex];
                    items[parentIndex] = child;
                    childIndex = parentIndex;
                }
                else
                    break;
            }
        }

    }
    public class PriorityQueue
    {
        List<KeyValuePair<string, int>> values;
        private int size;
        public int Size()
        {
            return size;
        }
        public PriorityQueue()
        {
            values = new List<KeyValuePair<string, int>>();
        }       
        public int GetDistance(string key)
        {
            return values.Find(x => x.Key == key).Value;
        }
        public void Enqueue(string val, int distance)
        {                      
            values.Add(new KeyValuePair<string, int>(val, distance));           
            values.Sort((x, y) => (x.Value.CompareTo(y.Value)));
            size++;
        }
        public KeyValuePair<string, int> Dequeue()
        {
            KeyValuePair<string, int> val = values.First();
            values.RemoveAt(0);
            size--;
            return val;
        }
        public void Update(string val,  int newDistance)
        {
            int index = 0;
            for (int i = 0; i < values.Count(); i++)
            {
                if (values.ElementAt(i).Key == val)
                {
                    index = i;
                    break;
                }
            }
            values.RemoveAt(index);
            this.size--;
            this.Enqueue(val, newDistance);
        }
    }
    public class WeightedGraph
    {
        // We will be using a hashtable and an object array to hold the graph nodes
        Hashtable hs;        
        public WeightedGraph()
        {
            hs = new Hashtable();
        }
        public void addVertex(string vertex)
        {
            if (!hs.Contains(vertex))
                hs[vertex] = new Dictionary<string, int>();
        }
        public void AddEdge(string vertex1, string vertex2,int weight)
        {
            // Check to see if these vertexes are present or not
            addVertex(vertex1);
            addVertex(vertex2);
            Dictionary<string, int>  arr = hs[vertex1] as Dictionary<string, int>;
            if (!arr.ContainsKey(vertex2))
                arr.Add(vertex2, weight);
            arr = hs[vertex2] as Dictionary<string, int>;
            if (!arr.ContainsKey(vertex1))
                arr.Add(vertex1,weight);
        }
        public string Dijkstras(string start, string end)
        {
            PriorityQueue distancesQueue = new PriorityQueue();
            distancesQueue.Enqueue(start, 0);

            // Initializes a datastructure to store the path history
            Hashtable history = new Hashtable();

            // Initializes a data structure to store the distances
            Hashtable distances = new Hashtable();
            distances.Add(start, 0);
            // Initializes the priority queue with all the vertices
            foreach (var key in this.hs.Keys)
            {
                if (key.ToString() != start)
                { distancesQueue.Enqueue(key.ToString(), Int32.MaxValue); distances.Add(key.ToString(), Int32.MaxValue); }
                history.Add(key, null);
            }

            // Initializes a list to track visited nodes
            List<string> visited = new List<string>();

            // Now iterate till there is a value in the distances queue
            KeyValuePair<string, int> smallest;
            while (distancesQueue.Size() > 0)
            {
                smallest = distancesQueue.Dequeue();
                visited.Add(smallest.Key);
                if (smallest.Key == end) break;

                // Get all the adjacent vertices of this vertex
                Dictionary<string,int> adjacentVertices = hs[smallest.Key] as Dictionary<string,int>;
                Dictionary<string, int> temp;
                foreach (string childVertex in adjacentVertices.Keys)
                {
                    if (!visited.Contains(childVertex))
                    {
                        temp = hs[childVertex] as Dictionary<string, int>;
                        int distanceFromStart = temp[smallest.Key] + GetDistanceFormStart(smallest.Key,history,distances);
                        int distance = (int)distances[childVertex];
                        if (distanceFromStart < distance)
                        {
                            distances[childVertex] = distanceFromStart;
                            distancesQueue.Update(childVertex, distanceFromStart);
                        }
                        history[childVertex] = smallest.Key;                     
                    }
                }
            }
            return "";
        }
        private int GetDistanceFormStart(string parentVertex, Hashtable history,Hashtable distances)
        {
            if (distances[parentVertex] == null)
                return 0;
            else
            {
                return (int)distances[parentVertex];
            }
        }
    }
    public class Graph
    {
        // We will be using a hashtable and an object array to hold the graph nodes
        Hashtable hs;
        public Graph()
        {
            hs = new Hashtable();
        }
        public void addVertex(string vertex)
        {
            if (!hs.Contains(vertex))
                hs[vertex] = new List<string>();
            //else
              //  throw new Exception("The vertex "+vertex+" is already present in the graph");
        }
        public void AddEdge(string vertex1, string vertex2)
        {
            // Check to see if these vertexes are present or not
            addVertex(vertex1);
            addVertex(vertex2);
            List<string> arr = hs[vertex1] as List<string>;
            if (!arr.Contains(vertex2))
                arr.Add(vertex2);
            arr = hs[vertex2] as List<string>;
            if (!arr.Contains(vertex1))
                arr.Add(vertex1);
        }
        public void RemoveEdge(string vertex)
        {
            // Remove all reference of this vertex from other vertices
            List<string> arr;
            foreach (var key in hs)
            {
                arr = (List<string>)hs[key];
                if (arr.Contains(vertex)) arr.Remove(vertex);
            }
            hs.Remove(vertex);
        }
        public string  Print()
        {
            List<string> arr;
            string line = "";
            // This function is to see what exactly is the structure of our graph.
            foreach (DictionaryEntry key in hs)
            {
                arr = (List<string>)hs[key.Key];
                line+= key.Key.ToString() + " : ";
                for (int i = 0; i < arr.Count; i++)
                {
                    line += arr[i].ToString() + " ";
                }
                line += "\n";
            }
            return line;
        }       
        public string DFS(string vertex,List<string> visited,List<string> result)
        {
            if (visited == null) visited = new List<string>();
            if (result == null) result = new List<string>();
            if (visited.Contains(vertex)) return null;
            visited.Add(vertex);
            result.Add(vertex);
            List<string> adjacentVertices = hs[vertex] as List<string>;
            if (adjacentVertices != null)
                foreach (string adjacentVertex in adjacentVertices)
                    DFS(adjacentVertex, visited, result);
            string r = string.Empty;
            foreach (string s in result)
            {
                r += s + " ";
            }
            return r;
        }
        public string BFS(string vertex, List<string> visited, List<string> result)
        {
            if (result == null) result = new List<string>();
            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue(vertex);
            while (myQueue.Count > 0)
            {
                vertex = myQueue.Dequeue();
                if (!result.Contains(vertex))
                {
                    result.Add(vertex);                   
                    List<string> adjacentVertices = hs[vertex] as List<string>;
                    foreach (string adjacentVertex in adjacentVertices)
                    {
                        if (!result.Contains(adjacentVertex))
                            myQueue.Enqueue(adjacentVertex);
                    }
                }
            }
            string r = string.Empty;
            foreach (string s in result)
            {
                r += s + " ";
            }
            return r;
        }
    }
}
