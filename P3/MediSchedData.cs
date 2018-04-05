using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    
    public static class MediSchedData
    {
        private static List<Doctor> docList = new List<Doctor>();

        public static List<Doctor> getDocList()
        {
            return docList;
        }

        public static void addDocToList(string docName, string workingdays, string workingTime)
        {
            docList.Add(new Doctor() { Name = docName, Days = workingdays, Hours = workingTime });
        }
        
    }
}
