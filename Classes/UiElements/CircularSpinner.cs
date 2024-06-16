using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickSearch.Classes.UiElements
{
    public partial class CircularSpinner : UserControl
    {
        private System.Windows.Forms.Timer timer;
        private int frame;
        private const int DotCount = 10;
        private const int MaxDotSize = 8;
        private const int MinDotSize = 3;
        private const double Frequency = 4 * Math.PI / DotCount; // Frequency for sine wave

        private Color foreColor = Color.FromArgb(36,36,36);
        private Color backColor = Color.FromArgb(36, 36, 36);
        private float colorThreshold = 0.50f; // Default threshold

        // Explicit interface implementation for ForeColor and BackColor
        public new Color ForeColor
        {
            get => foreColor;
            set => foreColor = value;
        }

        public new Color BackColor
        {
            get => backColor;
            set => backColor = value;
        }

        public float ColorThreshold
        {
            get => colorThreshold;
            set
            {
                // Ensure threshold is within valid range
                colorThreshold = Math.Max(0f, Math.Min(1f, value));
                Invalidate(); // Redraw control when property changes
            }
        }

        public CircularSpinner()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Adjust the interval for desired speed
            timer.Tick += Timer_Tick;
        }

        public void StartSpinning()
        {
            foreColor = Color.FromArgb(0, 204, 204);
            backColor = Color.FromArgb(21, 21, 21);
            timer?.Start();
        }

        public void StopSpinning()
        {                       
            timer?.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            frame = (frame + 1) % DotCount; // Update the frame counter
            this.Invalidate(); // Trigger repaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = Math.Min(this.Width, this.Height) - MaxDotSize;
            PointF center = new PointF(this.Width / 2f, this.Height / 2f);
            float radius = size / 2f;

            for (int i = 0; i < DotCount; i++)
            {
                double angle = (Math.PI * 2 / DotCount) * i;
                float x = center.X + radius * (float)Math.Cos(angle);
                float y = center.Y + radius * (float)Math.Sin(angle);

                // Calculate the scale factor using a sine wave
                double scale = (Math.Sin(Frequency * (i + frame)) + 1) / 2; // Value between 0 and 1
                int dotSize = (int)(MinDotSize + (MaxDotSize - MinDotSize) * scale);

                // Determine the threshold adjusted scale factor
                double adjustedScale = scale >= colorThreshold ? (scale - colorThreshold) / (1 - colorThreshold) : 0;

                // Interpolate the color based on the adjusted scale factor
                Color dotColor = InterpolateColor(backColor, foreColor, adjustedScale);

                RectangleF rect = new RectangleF(x - dotSize / 2f, y - dotSize / 2f, dotSize, dotSize);

                using (Brush brush = new SolidBrush(dotColor))
                {
                    e.Graphics.FillEllipse(brush, rect);
                }
            }
        }

        private Color InterpolateColor(Color color1, Color color2, double factor)
        {
            byte r = (byte)(color1.R + (color2.R - color1.R) * factor);
            byte g = (byte)(color1.G + (color2.G - color1.G) * factor);
            byte b = (byte)(color1.B + (color2.B - color1.B) * factor);
            return Color.FromArgb(r, g, b);
        }
    }
}
