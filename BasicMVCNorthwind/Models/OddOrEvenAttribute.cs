using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicMVCNorthwind.Models
{
    public class OddOrEvenAttribute: ValidationAttribute
    {
        public enum Mode
        {
            Odd,
            Even
        };

        public Mode mode { get; set; }

        public OddOrEvenAttribute(Mode m)
        {
            mode = m;
        }

        public override bool IsValid(object value)
        {
            try
            {
                if (int.Parse(value.ToString()) % 2 == 0)
                {
                    return mode == Mode.Even;
                }
                else
                {
                    return mode == Mode.Odd;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}