using System.Collections.Generic;
using System.Text.RegularExpressions;
using Julyee.JSON;
using Julyee.JSON.Serialization;

namespace Julyee.GUI.Layer
{
    /// <summary>
    /// Enum representing the different position type constraints that can be applied to a layer.
    /// </summary>
    public enum PositionConstraint
    {
        Default,
        Absolute,
        Relative,
        Snap,
        Elastic
    }

    /// <summary>
    /// Enum representing the different types of snap-to position constraints that can be applied to a layer.
    /// </summary>
    public enum SnapConstraint
    {
        Default,
        Left,
        Right,
        Top,
        Bottom
    }

    /// <summary>
    /// Serializable class to represent a layer in a layout.
    /// </summary>
    [Serializable]
    public class Layer
    {
        /// <summary>
        /// Static dictionary used to quickly convert strings to position constraint values.
        /// </summary>
        [SkipSerialize]
        private static readonly Dictionary<string, PositionConstraint> k_stringToPositionConstraint =
            new Dictionary<string, PositionConstraint>
            {
                { "P2GUI_absolute", PositionConstraint.Absolute },
                { "P2GUI_relative", PositionConstraint.Relative },
                { "P2GUI_snap", PositionConstraint.Snap },
                { "P2GUI_elastic", PositionConstraint.Elastic }
            };

        /// <summary>
        /// Static dictionary used to quickly convert strings to snap-to constraint values.
        /// </summary>
        [SkipSerialize]
        private static readonly Dictionary<string, SnapConstraint> k_stringToSnapConstraint =
            new Dictionary<string, SnapConstraint>
            {
                { "P2GUI_left", SnapConstraint.Left },
                { "P2GUI_right", SnapConstraint.Right },
                { "P2GUI_top", SnapConstraint.Top },
                { "P2GUI_bottom", SnapConstraint.Bottom }
            };

        /// <summary>
        /// This layer's name
        /// </summary>
        [SkipSerialize] public string Name { get { return m_name; }}
        [SerializeAlias("name")] private string m_name;

        /// <summary>
        /// This layer's id as specified in the creation tool
        /// </summary>
        [SkipSerialize] public string ID { get { return m_ID; }}
        [SerializeAlias("id")] private string m_ID;

        /// <summary>
        /// The class of object this layer represents. Maps to a C# class.
        /// </summary>
        [SkipSerialize] public string Class { get { return m_class; }}
        [SerializeAlias("class")] private string m_class;


        /// <summary>
        /// The miscellaneous information configured for this layer.
        /// TODO: Refactor to `metadata`
        /// </summary>
        [SkipSerialize] public Dictionary<string, object> Misc { get { return m_misc; }}
        [SkipSerialize] private Dictionary<string, object> m_misc;
        [SkipSerialize] private string m_miscRaw;
        [SerializeAlias("misc")]
        public string MiscRaw
        {
            get { return m_miscRaw; }
            set
            {
                m_miscRaw = value;
                if (string.IsNullOrEmpty(m_miscRaw))
                {
                    m_misc = null;
                }
                else
                {
                    m_misc = (Dictionary<string, object>)ParserTyped.Parse(Regex.Unescape(m_miscRaw));
                }
            }
        }

        /// <summary>
        /// Should this layer maintain it's relative scale.
        /// TODO: Re-evaluate the functionality of this property, seems like previous versions don't really use this property
        /// TODO: but an equivalent field in the misc field.
        /// </summary>
        [SkipSerialize] public bool RelativeScale { get { return m_relativeScale; }}
        [SerializeAlias("maintainRelativeScale")] private bool m_relativeScale;

        /// <summary>
        /// The horizontal position constraint of this layer.
        /// </summary>
        [SkipSerialize] public PositionConstraint HorizontalPosition { get { return m_horizontalPosition; }}
        [SkipSerialize] private PositionConstraint m_horizontalPosition;
        [SkipSerialize] private string m_horizontalPositionRaw;
        [SerializeAlias("horizontalPosition")]
        public string HorizontalPositionRaw
        {
            get { return m_horizontalPositionRaw; }
            set
            {
                m_horizontalPositionRaw = value;
                m_horizontalPosition = k_stringToPositionConstraint.ContainsKey(m_horizontalPositionRaw)
                    ? k_stringToPositionConstraint[m_horizontalPositionRaw]
                    : PositionConstraint.Default;
            }
        }

        /// <summary>
        /// If the position constraint of this layer is set to `relative`, this number represents the horizontal
        /// percentage of the layout t which the center of this layer should be located.
        /// </summary>
        [SkipSerialize] public float HorizontalRelative { get { return m_horizontalRelative; }}
        [SerializeAlias("horizontalRelative")] private float m_horizontalRelative;

        /// <summary>
        /// If the horizontal position constraint of thislayer is set to `snap` this property represents the snap
        /// constraint of this layer.
        /// TODO: Re-evaluate position and snap constraints, seems like they could be merged.
        /// </summary>
        [SkipSerialize] public SnapConstraint HorizontalSnapTo { get { return m_horizontalSnapTo; }}
        [SkipSerialize] private SnapConstraint m_horizontalSnapTo;
        [SkipSerialize] private string m_horizontalSnapToRaw;
        [SerializeAlias("horizontalSnapTo")]
        public string HorizontalSnapToRaw
        {
            get { return m_horizontalSnapToRaw; }
            set
            {
                m_horizontalSnapToRaw = value;
                m_horizontalSnapTo = k_stringToSnapConstraint.ContainsKey(m_horizontalSnapToRaw)
                    ? k_stringToSnapConstraint[m_horizontalSnapToRaw]
                    : SnapConstraint.Default;
            }
        }

        /// <summary>
        /// The vertical position constraint of this layer.
        /// </summary>
        [SkipSerialize] public PositionConstraint VerticalPosition { get { return m_verticalPosition; }}
        [SkipSerialize] private PositionConstraint m_verticalPosition;
        [SkipSerialize] private string m_verticalPositionRaw;
        [SerializeAlias("verticalPosition")]
        public string VerticalPositionRaw
        {
            get { return m_verticalPositionRaw; }
            set
            {
                m_verticalPositionRaw = value;
                m_verticalPosition = k_stringToPositionConstraint.ContainsKey(m_verticalPositionRaw)
                    ? k_stringToPositionConstraint[m_verticalPositionRaw]
                    : PositionConstraint.Default;
            }
        }

        /// <summary>
        /// If the position constraint of this layer is set to `relative`, this number represents the vertical
        /// percentage of the layout t which the center of this layer should be located.
        /// </summary>
        [SkipSerialize] public float VerticalRelative { get { return m_verticalRelative; }}
        [SerializeAlias("verticalRelative")] private float m_verticalRelative;

        /// <summary>
        /// If the horizontal position constraint of this layer is set to `snap` this property represents the snap
        /// constraint of this layer.
        /// </summary>
        [SkipSerialize] public SnapConstraint VerticalSnapTo { get { return m_verticalSnapTo; }}
        [SkipSerialize] private SnapConstraint m_verticalSnapTo;
        [SkipSerialize] private string m_verticalSnapToRaw;
        [SerializeAlias("verticalSnapTo")]
        public string VerticalSnapToRaw
        {
            get { return m_verticalSnapToRaw; }
            set
            {
                m_verticalSnapToRaw = value;
                m_verticalSnapTo = k_stringToSnapConstraint.ContainsKey(m_verticalSnapToRaw)
                    ? k_stringToSnapConstraint[m_verticalSnapToRaw]
                    : SnapConstraint.Default;
            }
        }

        /// <summary>
        /// A rect that represents this layer's boundaries.
        /// </summary>
        [SkipSerialize] public Geometry.Rect<int> Rect { get { return m_rect; }}
        [SerializeAlias("rect")] private Geometry.Rect<int> m_rect;

        /// <summary>
        /// The computed position of the center of this layer.
        /// </summary>
        [SkipSerialize] public Geometry.Point<float> Point { get { return m_position; }}
        [SerializeAlias("position")] private Geometry.Point<float> m_position;

        /// <summary>
        /// A properties object representing all the relevant properties of this layer.
        /// </summary>
        [SkipSerialize] public Properties Properties { get { return m_properties; }}
        [SerializeAlias("properties")] private Properties m_properties;

        /// <summary>
        /// The list of this layer's sub-layers (or childern)
        /// </summary>
        [SkipSerialize] public List<Layer> Children { get { return m_children; }}
        [SerializeAlias("children")] private List<Layer> m_children;
    }
}