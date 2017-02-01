using Julyee.JSON.Serialization;

namespace Julyee.GUI.Geometry
{
    /// <summary>
    /// Utility class that represents a size.
    /// </summary>
    /// <typeparam name="T">Type used to store the size values, tipically int or float</typeparam>
    [Serializable]
    public class Size<T>
    {
        /// <summary>
        /// Default constructor, initializes the class' properties whith the default values for the type
        /// </summary>
        public Size() : this(default(T)) {}

        /// <summary>
        /// Constructor that initializes the class' properties with the given values.
        /// </summary>
        /// <param name="width">Value for the `width` property</param>
        /// <param name="height">Value for the `height` property</param>
        public Size(T width = default(T), T height = default(T))
        {
            m_width = width;
            m_height = height;
        }

        /// <summary>
        /// The `width` represented by this object.
        /// </summary>
        [SkipSerialize] public T Width { get { return m_width; } set { m_width = value;  }}
        [SerializeAlias("width")] private T m_width;

        /// <summary>
        /// The `height` represented by this object.
        /// </summary>
        [SkipSerialize] public T Height { get { return m_height; } set { m_height = value;  }}
        [SerializeAlias("height")] private T m_height;

        /// <summary>
        /// Formats the contents of this object for human readability
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return string.Format("Width:{0} Height:{1}", m_width, m_height);
        }
    }
}