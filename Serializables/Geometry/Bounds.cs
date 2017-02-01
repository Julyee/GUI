using System;
using Julyee.JSON.Serialization;

namespace Julyee.GUI.Geometry
{
    /// <summary>
    /// Utility class that represents the bounds of an object.
    /// </summary>
    /// <typeparam name="T">Type used to store the bounds values, tipically int or float</typeparam>
    [JSON.Serialization.Serializable]
    public class Bounds<T>
    {
        /// <summary>
        /// Default constructor, initializes the class' properties whith the default values for the type
        /// </summary>
        public Bounds() : this(default(T)) {}

        /// <summary>
        /// Constructor that initializes the class' properties with the given values.
        /// </summary>
        /// <param name="top">The Y coordinate of the top side of the bounds</param>
        /// <param name="bottom">The y coordinate of the bottom side of the bounds</param>
        /// <param name="left">The X coordinates of the left side of the bounds</param>
        /// <param name="right">The X coordinate of the  right side of the bounds</param>
        /// <param name="width">The width of the bounds</param>
        /// <param name="height">The height of the bounds</param>
        public Bounds(T top    = default(T),
                      T bottom = default(T),
                      T left   = default(T),
                      T right  = default(T),
                      T width  = default(T),
                      T height = default(T))
        {
            m_top = top;
            m_bottom = bottom;
            m_left = left;
            m_right = right;
            m_width = width;
            m_height = height;
        }

        /// <summary>
        /// Y coordinate of the top of the bounds
        /// </summary>
        [SkipSerialize] public T Top { get { return m_top; } set { m_top = value; }}
        [SerializeAlias("top")] private T m_top;

        /// <summary>
        /// Y coordinate of the bottom of the bounds
        /// </summary>
        [SkipSerialize] public T Bottom { get { return m_bottom; } set { m_bottom = value; }}
        [SerializeAlias("bottom")] private T m_bottom;

        /// <summary>
        /// X coordinate of the left side of the bounds
        /// </summary>
        [SkipSerialize] public T Left { get { return m_left; } set { m_left = value; }}
        [SerializeAlias("left")] private T m_left;

        /// <summary>
        /// X coordinates of the right side of the bounds
        /// </summary>
        [SkipSerialize] public T Right { get { return m_right; } set { m_right = value; }}
        [SerializeAlias("right")] private T m_right;

        /// <summary>
        /// Width value of the bounds
        /// </summary>
        [SkipSerialize] public T Width { get { return m_width; } set { m_width = value; }}
        [SerializeAlias("width")] private T m_width;

        /// <summary>
        /// Height value of the bounds
        /// </summary>
        [SkipSerialize] public T Height { get { return m_height; } set { m_height = value; }}
        [SerializeAlias("height")] private T m_height;

        /// <summary>
        /// Formats the contents of this object for human readability
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return string.Format("Top:{0} Bottom:{1} Left:{2} Right:{3} Width:{4} Height:{5}",
                                 m_top,
                                 m_bottom,
                                 m_left,
                                 m_right,
                                 m_width,
                                 m_height);
        }
    }
}