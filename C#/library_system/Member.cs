using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{

    // Arin Kim
    // n9908544

    class Member
    {
        private object[] detail;


        // One of the data members is a data structure storing the information abt all movies that the member is currently holding
        public Member(string first, string last, string ID, string Passwords, string address, string phone)
        {
            // detail = {firstnameSurname, address, phone number, borrowed movie up to 10}
            detail = new object[17];
            detail[0] = first;
            detail[1] = last;
            detail[2] = ID;
            detail[3] = Passwords;
            detail[4] = address;
            detail[5] = phone;
        }

        ~Member() => detail = null;
        
        // Every movies by holding this member to store array
        public Object[] allMovies()
        {
            List<object> movieList = new List<object>();

            foreach(object obj in detail)
            {
                if (obj == null || obj.GetType() == typeof(string)) continue;
                else if (obj.GetType() != typeof(string)) movieList.Add(obj);
            }

            return movieList.ToArray();
            
        }

        // Get member name
        public string[] memberName()
        {
            string[] name = { (string)detail[0], (string)detail[1] };
            return name;
        }

        // Get Member Id
        public object ID()
        {
            return detail[2];
        }

        // Get Phone number
        public object memberPhone()
        {
            return detail[5];
        }
        
        // Get passwords
        public object Passwords()
        {
            return detail[3];
        }
        
        // Add a movie DVD into member detail
        public void addDVD(Movie m)
        {
            for(int i = 7; i < detail.Length; i++)
            {
                if (detail[i] == null)
                {
                    detail[i] = m;
                    break;
                }
            }
            
        }

        // Count how many DVDs the member holds
        public int countDVD()
        {
            int c = 0;
            for (int i = 7; i < detail.Length; i++)
            {
                if (detail[i] == null)
                {
                    break;
                }

                c++;
            }

            return c;
        }

        // Delete DVD as it's returned
        public void deleteDVD(Movie m)
        {
            int i = 0;
            foreach(Object item in detail)
            {
                if(m == item)
                {
                    detail[i] = null;
                }
                i++;
            }
        }
    }
}
