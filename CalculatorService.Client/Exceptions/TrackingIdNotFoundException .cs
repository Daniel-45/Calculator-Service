using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client.Exceptions
{
    [Serializable]
    class TrackingIdNotFoundException : Exception
    {
        public TrackingIdNotFoundException() { }

        public TrackingIdNotFoundException(string message) : base(message) { }
    }
}
