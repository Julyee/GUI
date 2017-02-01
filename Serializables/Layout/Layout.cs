using System.Collections.Generic;
using Julyee.JSON.Serialization;

namespace Julyee.GUI
{
    /// <summary>
    /// Base serializable class to load layout information from a JSON export.
    /// </summary>
    [Serializable]
    public class Layout
    {
        /// <summary>
        /// The exporter version used to create this layout.
        /// </summary>
        [SkipSerialize] public string ExporterVersion { get { return m_exporterVersion; }}
        [SerializeAlias("exporter-version")] private string m_exporterVersion;

        /// <summary>
        /// The name of this layout.
        /// </summary>
        [SkipSerialize] public string ExportName { get { return m_exportName; }}
        [SerializeAlias("export-name")] private string m_exportName;

        /// <summary>
        /// A rect representing the original size at which this layout was created.
        /// </summary>
        [SkipSerialize] public Geometry.Rect<int> Rect { get { return m_rect; }}
        [SerializeAlias("export-rect")] private Geometry.Rect<int> m_rect;

        /// <summary>
        /// A list of the child elements of this layout.
        /// </summary>
        [SkipSerialize] public List<Layer.Layer> Children { get { return m_children;  }}
        [SerializeAlias("layout")] private List<Layer.Layer> m_children;
    }
}