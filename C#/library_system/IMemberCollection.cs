using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{

    // Arin Kim
    // n9908544

    interface IMemberCollection
    {
        bool loginCorrect(string id, string psw);

        void registerMemeber(Member data);

        void findPhoneNum(string first, string last);

        void borrowDVD(Movie movie, string name);

        void returnDVD(Movie movie, string id);

        void displayAllBorrowed(string name);

        bool hasRegistered(string first, string last);
    }
}
