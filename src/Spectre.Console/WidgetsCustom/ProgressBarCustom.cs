#pragma warning disable
using System.Collections.Generic;
using System.Reflection;

namespace Spectre.Console
{
    public class ProgressBarCustom : IRenderable
    {
        /// <summary>
        /// Width of <see cref="ProgressBarCustom"/> instance.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Text label of progress bar
        /// </summary>
        public Markup TextLabel { get; }
        /// <summary>
        /// Text label of progress bar
        /// </summary>
        public Markup CompleteLabel { get; }
        /// <summary>
        /// Progress bar
        /// </summary>
        public ProgressBar ProgressBar { get; } = new ProgressBar();
        /// <summary>
        /// 
        /// </summary>
        private Table _table;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarCustom"/> class.
        /// </summary>
        public ProgressBarCustom(string textLabel, string completeLabel = "0%", int? width = null)
        {
            Width = width;
            TextLabel = new Markup(textLabel);
            CompleteLabel = new Markup(completeLabel);
            _table = new Table
            {
                Border = TableBorder.None,
                ShowHeaders = false,
                IsGrid = true,
                PadRightCell = true,
                Width = Width,
            };
            _table.AddColumns("Label", "ProgressBar", "CompleteLabel");
            _table.AddRow(TextLabel, ProgressBar, CompleteLabel);
        }

        public Measurement Measure(RenderOptions options, int maxWidth)
        {
            return _table.GetMeasure(options, maxWidth);
        }

        public IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
        {
            return _table.GetRender(options, maxWidth);
        }
    }
}
#pragma warning restore SA0000