using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickSearch.Classes.UiElements
{
    public partial class CustomProgressBar : UserControl
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private float _value = 0; // Use float for finer granularity
        private Color _progressBarColor = Color.FromArgb(0, 204, 204); // Default color (Teal)
        private Color _backgroundColor = Color.FromArgb(71, 71, 71); // Default background color (Luminosity 28 gray)

        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate(); // Redraw control when property changes
            }
        }

        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate(); // Redraw control when property changes
            }
        }

        public float Value
        {
            get { return _value; }
            set
            {
                // Clamp the value between Minimum and Maximum
                _value = Math.Max(_minimum, Math.Min(_maximum, value));
                Invalidate(); // Redraw control when property changes
            }
        }

        public Color ProgressBarColor
        {
            get { return _progressBarColor; }
            set
            {
                _progressBarColor = value;
                Invalidate(); // Redraw control when property changes
            }
        }

        public CustomProgressBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.MinimumSize = new Size(30, 10); // Set a minimum size for the control
            this.BackColor = _backgroundColor; // Set default background color
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Calculate dimensions for drawing
            float range = _maximum - _minimum;
            float percentage = (_value - _minimum) / range;
            int barWidth = (int)(percentage * this.Width);
            int barHeight = this.Height;

            // Draw background
            e.Graphics.Clear(this.BackColor);

            // Draw progress bar with custom color
            Rectangle barRect = new Rectangle(0, 0, barWidth, barHeight);
            using (SolidBrush brush = new SolidBrush(_progressBarColor))
            {
                e.Graphics.FillRectangle(brush, barRect);
            }
        }
    }
}
