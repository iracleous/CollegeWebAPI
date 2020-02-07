using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeWebAPI.dtos
{

    /*
     * 
     {"Name":"Dimitris Iracleous",
     "Reference":"Mr Smith",
     "Address":"Abelokipoi",
     "Dob": "1990-07-23",
     "Department":"Computer Science"
     }
     */
    public class StudentDto
    {
        public string Name { get; set; }
        public string Reference { get; set; }

        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string Department { get; set; }

    }

    public class DepartmentDto
    {
        public string Name { get; set; }
    }

    public class MarksDto 
    {
        public List<Tuple<string, int>> Marks  { get; set; }
    }

}
