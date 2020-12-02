using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{

    // Arin Kim
    // n9908544

    public class Movie
    {
        private string[] detail;


        public Movie(string t, string s, string d, string g, string c, string du, string r, string co)
        {
            // detail = {Title, Starring, Dirctor, Genre, Classification, Number of copies, Times of borrowing}
            detail = new string[] { t, s, d, g, c, du, r, co, "0" };
        }
        
        ~Movie() => detail = null;

        // Get title
        public string getTitle()
        {
            return detail[0];
        }

        // Get times of borrowing
        public int getBorrowed()
        {
            return int.Parse(detail[8]);
        }

        // Set strings to print details
        public string[] printDetail()
        {
            return detail;
        }

        // Add more copies depends on user input
        public void addUsrCopy(int co)
        {
            int copies = int.Parse(detail[7]) + co;
            detail[7] = copies.ToString();
        }

        // Add one more copy of DVD
        public void addCopy()
        {
            int pre = int.Parse(detail[7]) + 1;

            detail[7] = pre.ToString();
        }

        // Delete the number of copies which currently holded by library as it is borrowed
        public void hasBorrowed()
        {
            int pre = int.Parse(detail[7]) - 1;

            detail[7] = pre.ToString();
        }

        // Add one more time of borrowing
        public void numOfBorrowed()
        {
            int pre = int.Parse(detail[8]) + 1;

            detail[8] = pre.ToString();
        }
    }
}
