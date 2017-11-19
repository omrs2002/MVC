using MVCCourse2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCourse2017.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}