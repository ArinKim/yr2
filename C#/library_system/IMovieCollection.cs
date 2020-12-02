using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{

    // Arin Kim
    // n9908544

    interface IMovieCollection
    {
        void addMovie(Movie m);

        void removeMovie(string s);

        void displayAll();

        void displayTop10();

        Movie find(string title);

        bool isInLib(Movie m);
    }
}
