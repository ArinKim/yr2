using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace library_system
{

    // Arin Kim
    // n9908544

    class Membercollection : IMemberCollection
    {
        const int ARRAY_SIZE = 10; // Maximum member is 10
        Member[] members;

        public Membercollection()
        {
            members = new Member[ARRAY_SIZE];
        }

        // Check the member is correctly login
        public bool loginCorrect(string id, string psw)
        {
            foreach (Member m in members)
            {
                if ((string)m.ID() == id && (string)m.Passwords() == psw) return true;
                else return false;
            }

            return false;
        }
        
        // Register the member
        public void registerMemeber(Member data)
        {
            if(count(members) >= 10)
            {
                Console.WriteLine("Sorry, we cannot hold over 10 members :(");
            }
            else if(hasRegistered(data.memberName()[0], data.memberName()[1]))
            {
                Console.WriteLine("This member is already registered");
            }
            else
            {
                members[count(members)] = data;
            }

        }

        // Find phone number of registered member
        public void findPhoneNum(string first, string last)
        {
            if (isCorrectName(first, last))
            {
                Member inf = members[memberIndex(first+last)];
                //inf.memberPhone();
                Console.WriteLine("Contact number of " + first + " " + last + " is " + inf.memberPhone());
            }
            else
            {
                Console.WriteLine("Cannot find member detail, please check the name");
            }
        }

        // Borrow DVD by memeber
        public void borrowDVD(Movie movie, string id)
        {
            Member m = members[memberIndex(id)];
            bool inList = false;

            if (m != null)
            {
                if (movie.printDetail()[7] == "0") // No more copies in library
                {
                    Console.WriteLine("sorry, you cannot borrow this dvd as low stocks");
                }
                foreach (Movie obj in m.allMovies())
                {
                    if (obj == movie)
                    {
                        inList = true; // If this movie already has been borrowed by this member
                        break;
                    }
                }
                if(m.countDVD() == 10)
                {
                    Console.WriteLine("Sorry, you cannot borrow over 10 DVDs");

                }
                else if (inList == false)
                {
                    m.addDVD(movie);
                    movie.hasBorrowed();
                    movie.numOfBorrowed();
                    Console.WriteLine(movie.getTitle() + " has been borrowed!");
                }
                else
                {
                    Console.WriteLine("Sorry, you already have borrowed this DVD");
                }
            }
        }

        // Return DVD
        public void returnDVD(Movie movie, string id)
        {
            Member m = members[memberIndex(id)];

            if (m != null)
            {
                m.deleteDVD(movie);
                movie.addCopy();
                Console.WriteLine(movie.getTitle() + " has been returned!");
            }
            else
            {
                Console.WriteLine("Please check the detail of movie or your borrowed list");
            }
        }
        
        // list of movies that are being hold by the member
        public void displayAllBorrowed(string id)
        {
            Member m = members[memberIndex(id)];
            if(m.allMovies().Length == 0)
            {
                Console.WriteLine("You haven't been borrowed any DVDs yet");

            } else
            {
                foreach(Movie obj in m.allMovies())
                {
                    string[] info = obj.printDetail();
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
                }
            }
            
        }

        // ---------------------------------------------
        // HELPER FUNCTIONS
        // ---------------------------------------------

        // Count the number of members in member array
        private int count(Member[] m)
        {
            int c = 0;


            while ( m[c] != null)
            {
                c++;
                if (c == 10) break;
            }

            return c;
        }

        // Check the memebr has been registered
        public bool hasRegistered(string first, string last)
        {
            bool has = false;

            for (int i = 0; i < count(members); i++)
            {
                if (members[i].ID().ToString() == (first+last).ToString())
                {
                    has = true;
                    break;
                }
            }

            return has;
        }

        // Check the member's name is correct or not
        private bool isCorrectName(string first, string last)
        {
            foreach(Member m in members)
            {
                if (m.memberName()[0] == first && m.memberName()[1] == last)
                {
                    return true;
                }
            }

            return false;
        }

        // Get the index of member where the memebr's information is stored
        private int memberIndex(string ID)
        {
            int count = 0;

            foreach (Member m in members)
            {
                if ((string)m.ID() == ID)
                {
                    return count;
                }

                count++;
            }

            return -1;

        }

    }
}
