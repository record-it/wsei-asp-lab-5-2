using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public enum Colors
    {
        RED=1, WHITE=4, BLACK=6
    }

    public class EnumDemo
    {
        Colors color = Colors.RED;
        public Colors get()
        {
            return (Colors) Enum.Parse(typeof(Colors), "RED");
        }
    }
}
