using System.Reflection.Metadata;

namespace AreaCalc
{
    public static class AreaCalc
    {
        /// <summary>
        /// Calculates the area of a circle based on its radius
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static double GetArea(double radius)
        {
            if (radius <= 0)
            {
                throw new Exception("Radis can't be < 0");
            }
            else

                try
                {
                    checked
                    {
                        return Math.PI * radius * radius;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
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
            if (triangleEgde1 < 0 || triangleEgde2 < 0 || triangleEgde3 < 0)
            {
                throw new Exception("Egde can't be < 0");
            }
            else
            {
                var semiPerimeter = (triangleEgde1 + triangleEgde2 + triangleEgde3) / 2;
                try
                {
                    checked
                    {
                        return Math.Sqrt(semiPerimeter * (semiPerimeter - triangleEgde1) * (semiPerimeter - triangleEgde2) *
                            (semiPerimeter - triangleEgde3));
                    }
                }
                catch (Exception e) 
                {
                    throw;
                }
            }
        }
    }
}