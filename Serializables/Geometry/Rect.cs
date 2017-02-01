using Julyee.JSON.Serialization;

namespace Julyee.GUI.Geometry
{
    /// <summary>
    /// Utility function to represent a rect.
    /// </summary>
    /// <typeparam name="T">Type used to store the rect values, tipically int or float</typeparam>
    [Serializable]
    public class Rect<T>
    {
        /// <summary>
        /// Default constructor, initializes the class' properties whith the default values for the type
        /// </summary>
        public Rect() : this(default(T)) {}

        /// <summary>
        /// Constructor that initializes the class' properties with the given values.
        /// </summary>
        /// <param name="x">The rect's x coordinate of its origin</param>
        /// <param name="y">The rect's y coordinate of its origin</param>
        /// <param name="width">The width of the rect</param>
        /// <param name="height">The height of the rect</param>
        public Rect(T x = default(T), T y = default(T), T width = default(T), T height = default(T))
        {
            m_position = new Point<T>(x, y);
            m_size = new Size<T>(width, height);
        }

        /// <summary>
        /// Structure that represents the coordinates of the rect's origin.
        /// </summary>
        [SkipSerialize] public Point<T> Position { get { return m_position; }}
        [SkipSerialize] private Point<T> m_position;

        /// <summary>
        /// Structure that represents the size of the rect
        /// </summary>
        [SkipSerialize] public Size<T> Size { get { return m_size; }}
        [SkipSerialize] private Size<T> m_size;

        /// <summary>
        /// X coordinate of the rect's origin
        /// </summary>
        [SerializeAlias("x")]
        public T X { get { return m_position.X; } set { m_position.X = value; }}

        /// <summary>
        /// Y coordinate of the rect's origin
        /// </summary>
        [SerializeAlias("y")]
        public T Y { get { return m_position.Y; } set { m_position.Y = value; }}

        /// <summary>
        /// The rect's width
        /// </summary>
        [SerializeAlias("width")]
        public T Width { get { return m_size.Width; } set { m_size.Width = value; }}

        /// <summary>
        /// The rect's height
        /// </summary>
        [SerializeAlias("height")]
        public T Height { get { return m_size.Height; } set { m_size.Height = value; }}

        /// <summary>
        /// Formats the contents of this object for human readability
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return string.Format("X:{0} Y:{1} Width:{2} Height:{3}", m_position.X, m_position.Y, m_size.Width, m_size.Height);
        }
    }
}