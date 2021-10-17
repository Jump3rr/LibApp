using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; } 
        public List<Customer> Customers { get; set; }
    }
}
