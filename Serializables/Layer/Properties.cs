using Julyee.GUI.Geometry;
using Julyee.JSON.Serialization;

namespace Julyee.GUI.Layer
{
    /// <summary>
    /// Class that represents the properties of a given layer in the layout.
    /// </summary>
    [Serializable]
    public class Properties
    {
        /// <summary>
        /// The layer's name.
        /// </summary>
        [SkipSerialize] public string Name { get { return m_name; }}
        [SerializeAlias("name")] private string m_name;

        /// <summary>
        /// Is the layer visible.
        /// </summary>
        [SkipSerialize] public bool Visible { get { return m_visible; }}
        [SerializeAlias("visible")] private bool m_visible;

        /// <summary>
        /// A number between 0 and 100 (?) describing the opacity of this layer.
        /// </summary>
        [SkipSerialize] public int Opacity { get { return m_opacity; }}
        [SerializeAlias("opacity")] private int m_opacity;

        /// <summary>
        /// The index of this layer in its parent's hierarchy.
        /// </summary>
        [SkipSerialize] public int Index { get { return m_index; }}
        [SerializeAlias("itemIndex")] private int m_index;

        /// <summary>
        /// A count of the layer's objects (?)
        /// </summary>
        [SkipSerialize] public int Count { get { return m_count; }}
        [SerializeAlias("count")] private int m_count;

        /// <summary>
        /// Are the effects applied to this layer visible.
        /// </summary>
        [SkipSerialize] public bool FXVisible { get { return m_fxVisible; }}
        [SerializeAlias("layerFXVisible")] private bool m_fxVisible;

        /// <summary>
        /// The global light angle used for effects in the layout this layer pertains to.
        /// </summary>
        [SkipSerialize] public float GlobalAngle { get { return m_globalAngle; }}
        [SerializeAlias("globalAngle")] private float m_globalAngle;

        /// <summary>
        /// Whether this layer is a group of layers or a graphical layer.
        /// </summary>
        [SkipSerialize] public bool IsGroup { get { return m_isGroup; }}
        [SerializeAlias("group")] private bool m_isGroup;

        /// <summary>
        /// The computed bounds of this layer.
        /// </summary>
        [SkipSerialize] public Bounds<float> Bounds;
        [SerializeAlias("bounds")] private Bounds<float> m_bounds;

        /// <summary>
        /// The computed bounds of this layer if all its effects are removed.
        /// </summary>
        [SkipSerialize] public Bounds<float> BoundsNoFX { get { return m_boundsNoFX; }}
        [SerializeAlias("boundsNoEffects")] private Bounds<float> m_boundsNoFX;
    }
}