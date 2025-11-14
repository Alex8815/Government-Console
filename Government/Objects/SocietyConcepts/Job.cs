using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects.SocietyConcepts
{
    public class Job
    {
        //there would be some requirements to get, match to person skills of some kind maybe?
        public string Title { get; private set; }
        public long Salary { get; private set; }

        public Job(string title, long salary) {
            Title = title;
            Salary = salary;
        }
    }
}
