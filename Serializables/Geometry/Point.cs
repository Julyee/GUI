using Julyee.JSON.Serialization;

namespace Julyee.GUI.Geometry
{
    /// <summary>
    /// Utility class to reperesent a position in 2D space.
    /// </summary>
    /// <typeparam name="T">Type used to store the point values, tipically int or float</typeparam>
    [Serializable]
    public class Point<T>
    {
        /// <summary>
        /// Default constructor, initializes the class' properties whith the default values for the type
        /// </summary>
        public Point() : this(default(T)) {}

        /// <summary>
        /// Constructor that initializes the class' properties with the given values.
        /// </summary>
        /// <param name="x">The X coordinate of this point</param>
        /// <param name="y">The Y coordinate of this point</param>
        public Point(T x = default(T), T y = default(T))
        {
            m_x = x;
            m_y = y;
        }

        /// <summary>
        /// X coordinate of the point
        /// </summary>
        [SkipSerialize] public T X { get { return m_x; } set { m_x = value;  }}
        [SerializeAlias("x")] private T m_x;

        /// <summary>
        /// Y coordinate of the point
        /// </summary>
        [SkipSerialize] public T Y { get { return m_y; } set { m_y = value;  }}
        [SerializeAlias("y")]private T m_y;

        /// <summary>
        /// Formats the contents of this object for human readability
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return string.Format("X:{0} Y:{1}", m_x, m_y);
        }
    }
}