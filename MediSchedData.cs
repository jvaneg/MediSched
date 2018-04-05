using System;
using System.Collections.Generic;

namespace P3
{
    public class MediSchedData
    {
        public MediSchedData(){

        }

        private List<Doctor> docList = new List<Doctor>();

        public getDocList()
        {
            return this.docList;
        }
        public addDocToList(string docName, string workingdays, string workingTime)
        {
            docList.Add(new Doctor() { Name = docName, Days = workingdays, Hours = workingTime });
        }
    }
}
