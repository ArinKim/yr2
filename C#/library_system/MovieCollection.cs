using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{

    // Arin Kim
    // n9908544

    public class BST
    {
        private Movie item; // value
        private BST left; // reference to its left child 
        private BST right; // reference to its right child

        public BST(Movie item)
        {
            this.item = item;
            left = null;
            right = null;
        }

        public Movie Item
        {
            get { return item; }
            set { item = value; }
        }

        public BST Left
        {
            get { return left; }
            set { left = value; }
        }

        public BST Right
        {
            get { return right; }
            set { right = value; }
        }
    }


    class MovieCollection : IMovieCollection
    {
        private BST node;
        private int ind;
        const int ARRAY_SIZE = 50;

        // Binary search tree
        public MovieCollection()
        {
            node = null;
        }
        
        // Add DVD
        public void addMovie(Movie m)
        {
            if(node == null)
            {
                node = new BST(m);
            } else if (isInLib(m))
            {
                Movie movie = find(m.getTitle());
                movie.addUsrCopy(int.Parse(m.printDetail()[7]));
            }
            else
            {
                node =addMovie(m, node);

            }
        }

        // Remove DVD
        public void removeMovie(string s)
        {
            Movie m = find(s);
            if (m == null)
            {
                Console.WriteLine("Sorry, the title is incorrect. Please check the title");
            }
            else
            {
                node = removeMovie(m, node);
            }
        }



        // Display every moview currently in this library
        public void displayAll()
        {
            if (node != null)
            {
                inOrder(node);
            }
            else
            {
                Console.WriteLine("Sorry, this library is empty :(");
            }
        }

        // Display most frenquently borrowed Movie DVDs
        public void displayTop10()
        {
            // Convert BST to array for sorting
            Movie[] m = BSTtoArray(node);
            QuickSort(m, 0, ind - 1); // Sort array

            // if index of array is over 10
            if (ind > 10)
            {
                ind = 10; // Set it to a value of 10
            }

            if (ind == 0) Console.WriteLine("Sorry, the movie list is empty");
            

            Top10inOrder(sortedMovieToBST(m, 0, ind - 1)); // Print out by in-order traverse

        }

        // ---------------------------------------------
        // HELPER FUNCTIONS
        // ---------------------------------------------

      

        //1. when node doesn't have any child
        //2. has one child
        //3. has both childrens
        private BST removeMovie(Movie m, BST root)
        {
            // Base case: empty tree
            if (root == null) return root;
            else if (m.getTitle().CompareTo(root.Item.getTitle()) < 0)
            {
                root.Left = removeMovie(m, root.Left);
            }
            else if (m.getTitle().CompareTo(root.Item.getTitle()) > 0)
            {
                root.Right = removeMovie(m, root.Right);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else
                {
                    return root.Left;
                }
            }

            return root;
        }


        private BST addMovie(Movie m, BST root)
        {
            // Add movie with alphabetical order into BST
            if (root == null)
            {
                root = new BST(m);
                return root;
            }
            else
            {
                if (m.getTitle().CompareTo(root.Item.getTitle()) < 0)
                {
                    root.Left = addMovie(m, root.Left);
                }
                else
                {
                    root.Right = addMovie(m, root.Right);
                }
                return root;
            }

        }

        // Sonvert sorted array to binary search tree
        private BST sortedMovieToBST(Movie[] m, int start, int end)
        {
            //// Base case
            if (start > end) return null;
            BST tree = new BST(m[start]);
            tree.Right = sortedMovieToBST(m, start + 1, end);

            return tree;
        }

        // To print out the BST under the condition of in-order
        public void inOrder(BST node)
        {
            if (node == null) {
                
                return;
            }
            inOrder(node.Left);
            string[] info = node.Item.printDetail();
            Console.WriteLine();
            Console.WriteLine("Title: " + info[0]);
            Console.WriteLine("Starring: " + info[1]);
            Console.WriteLine("Director: " + info[2]);
            Console.WriteLine("Genre: " + info[3]);
            Console.WriteLine("Classification: " + info[4]);
            Console.WriteLine("Duration: " + info[5]);
            Console.WriteLine("Released date: " + info[6]);
            Console.WriteLine("Copies Available: " + info[7]);
            Console.WriteLine("Times rented: " + info[8]);
            Console.WriteLine();
            inOrder(node.Right);
        }

        // Print top 10 values by in-order traversal
        private void Top10inOrder(BST node)
        {
            if (node == null) return;
            Top10inOrder(node.Left);
            Console.WriteLine(node.Item.getTitle() + " borrowed " + node.Item.getBorrowed().ToString() + " Times");
            Top10inOrder(node.Right);
        }

        // Quick Sorting
        private void QuickSort(Movie[] movies, int start, int end)
        {
            int pivot;

            // Recursion
            if (start < end)
            {
                pivot = partition(movies, start, end);

                QuickSort(movies, start, pivot - 1);
                QuickSort(movies, pivot + 1, end);
            }
        }

        // Get the value of partiton to quick sort
        private int partition(Movie[] movies, int start, int end)
        {
            Movie temp;
            int pivotVal = movies[end].getBorrowed();
            int s = start - 1;

            for (int i = start; i <= end - 1; i++)
            {
                if (movies[i].getBorrowed() >= pivotVal)
                {
                    s++;
                    temp = movies[s];
                    movies[s] = movies[i];
                    movies[i] = temp;
                }
            }

            temp = movies[s + 1];
            movies[s + 1] = movies[end];
            movies[end] = temp;

            return s + 1;
        }
        
        // Return array
        private Movie[] BSTtoArray(BST root)
        {
            Movie[] movieArray = new Movie[ARRAY_SIZE];

            ind = 0;

            BSTtoArray(root, movieArray);

            return movieArray;
        }

        // Set the BST into array recursively
        private void BSTtoArray(BST root, Movie[] array)
        {
            //Base case
            if (root != null)
            {
                if(root.Left != null) BSTtoArray(root.Left, array);
                array[ind] = root.Item;
                ind++;
                if (root.Right != null) BSTtoArray(root.Right, array);
            }
        }
        
        // Find the node that has the given title
        public Movie find(string title)
        {
            return find(title, node);
        }

        private Movie find(string title, BST root)
        {
            if (root == null)
                return null;

            else if (title.CompareTo(root.Item.getTitle()) < 0)
                return find(title, root.Left);

            else if (title.CompareTo(root.Item.getTitle()) > 0)
                return find(title, root.Right);

            return root.Item;
        }

        // This function only search the movie depends on title
        // So, when the title of movies are same and they have different director,
        // this application operates they are same movies
        public bool isInLib(Movie m)
        {
            return isInLib(m, node);
        }

        private bool isInLib(Movie m, BST root)
        {
            if (root == null)
                return false;
            else if (m.getTitle().CompareTo(root.Item.getTitle()) < 0)
                return isInLib(m, root.Left);
            else if (m.getTitle().CompareTo(root.Item.getTitle()) > 0)
                return isInLib(m, root.Right);

            return true;
        }
    }
}
