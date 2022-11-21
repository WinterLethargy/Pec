using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pec
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        private Address _address;
        public Address Address 
        { 
            get => _address;
            set
            {
                if (value != null)
                { 
                    if (value.City == null && value.Street == null && value.Building == 0)
                        _address = null; 
                    else
                        _address = value;
                }
                else _address = value;
            } 
        }
    }
}
