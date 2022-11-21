namespace AreaCalc
{
    public static class AreaCalculator
    {
        public const string EdgeLessThanZeroMessage = "Egde of triangle < 0";
        public const string ImpossibleTriangleMessege = "One of edge more than sum other edges";
        public const string RadiusLessThanZeroMessage = "Radis can't be < 0";
        /// <summary>
        /// Calculates the area of a circle based on its radius
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static double GetArea(double radius)
        {
            if (radius <= 0)
            {
                throw new Exception(RadiusLessThanZeroMessage);
            }
            else
                return Math.PI * radius * radius;
        }

        /// <summary>
        /// Calculates the area of a triangle on its egdes
        /// </summary>
        /// <param name="triangleEgde1"></param>
        /// <param name="triangleEgde2"></param>
        /// <param name="triangleEgde3"></param>
        /// <returns></returns>
        public static double GetArea(double triangleEgde1, double triangleEgde2, double triangleEgde3)
        {
            if (!AllDataMoreThanZero(triangleEgde1, triangleEgde2, triangleEgde3))
            {
                throw new Exception(EdgeLessThanZeroMessage);
            }
            else if ((triangleEgde2 + triangleEgde3) - triangleEgde1 < 0 || (triangleEgde1 + triangleEgde3) - triangleEgde2 < 0 ||
                (triangleEgde1 + triangleEgde2) - triangleEgde3 < 0)
            {
                throw new Exception(ImpossibleTriangleMessege);
            }
            var semiPerimeter = (triangleEgde1 + triangleEgde2 + triangleEgde3) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - triangleEgde1) * (semiPerimeter - triangleEgde2) *
                (semiPerimeter - triangleEgde3));

        }
        public static bool IsTriangleRight(double triangleEgde1, double triangleEgde2, double triangleEgde3)
        {
            if (!AllDataMoreThanZero(triangleEgde1, triangleEgde2, triangleEgde3))
            {
                throw new Exception(EdgeLessThanZeroMessage);
            }
            var edge1Pow = triangleEgde1 * triangleEgde1;
            var edge2Pow = triangleEgde2 * triangleEgde2;
            var edge3Pow = triangleEgde3 * triangleEgde3;
            if (edge1Pow == (edge2Pow + edge3Pow) || edge2Pow == (edge2Pow + edge3Pow) || edge3Pow == (edge1Pow + edge2Pow))
            {
                return true;
            }
            return false;
        }
        public static bool AllDataMoreThanZero(params double[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}