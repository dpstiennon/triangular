using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangular.Models
{
    public class TriangleLogic
    {
        public string Classify(List<decimal> sides)
        {
            if (sides == null || IsNotATriangle(sides))
            {
                return "Not a Triangle";
            }
            if (IsEquilateral(sides))
            {
                return "Equilateral";
            }
            if (IsIsosceles(sides))
            {
                return "Isosceles";
            }
            return ScaleneClass(sides);
        }

        public string ScaleneClass(List<decimal> sides)
        {
            //Pythagorean Theorem used to classify Scalene triangles
            var maxSide = sides.Max();
            var othersSides = sides.OrderByDescending(x => x).Skip(1);
            var aSquaredPlusBSquared = othersSides.Sum(x => x * x);
            var cSquared = maxSide*maxSide;
            if (aSquaredPlusBSquared == cSquared)
            {
                return "Scalene: Right";
            }
            if (aSquaredPlusBSquared < cSquared)
            {
                return "Scalene: Obtuse";
            }
            return "Scalene: Acute";
        }

        public bool IsIsosceles(List<decimal> sides)
        {
            return sides.Distinct().Count() < 3;
        }

        public bool IsEquilateral(List<decimal> sides)
        {
            return sides.Distinct().Count() < 2;
        }

        public bool IsNotATriangle(List<decimal> sides)
        {
            var maxSide = sides.Max();
            var othersSides = sides.OrderByDescending(x => x).Skip(1);
            return sides.Count() != 3
                   || sides.Any(s => s <= 0)
                   || maxSide >= othersSides.Sum();
        }
    }
}
