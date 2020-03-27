using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POISchedule.Data.Entities
{
    //Segundo commit
    public class Coordinator
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }

}

