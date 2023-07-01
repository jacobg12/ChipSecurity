using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem.CustomExceptions
{
    public class ChipListNullOrEmpty : Exception
    {
        public ChipListNullOrEmpty()
        {
        }

        public ChipListNullOrEmpty(string message)
            : base(message)
        {
        }

        public ChipListNullOrEmpty(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
