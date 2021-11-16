namespace SideCar.DTOs
{
    /// <summary>
    /// Class that representes a view coordinate
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Coordinate on x-axis
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Coordinate on y-axis
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Coordinate on z-axis
        /// </summary>
        public float Z { get; set; }

        public Point(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}