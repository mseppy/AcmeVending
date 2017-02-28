using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataAnnotationsExtensions;

namespace AcmeVending.Domain
{
    public class Cash
    {
        public static decimal[] ValidValues = new decimal[] { 5, 1, .25M, .10M, .05M };


        public string Denomination { get { return string.Format("{0, X.00}", Value); } }

        [Required()]
        public decimal Value
        {
            get { return Value; }

            set
            {
                if (!ValidValues.Contains(value))
                    throw new ArgumentOutOfRangeException("Not a valid value.");
            }
        }

        [Min(0)]
        public int Quantity { get; set; }
    }
}