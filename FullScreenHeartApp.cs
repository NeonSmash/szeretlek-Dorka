using System;
using System.Drawing;
using System.Windows.Forms;

public class FullScreenHeartApp : Form
{
    public FullScreenHeartApp()
    {
        // Full screen settings
        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;
        this.BackColor = Color.Black; // Set background color
        this.Paint += new PaintEventHandler(DrawHeartAndText); // Attach the paint event
        this.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Escape) this.Close(); }; // Exit on ESC
    }

    private void DrawHeartAndText(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Define the size and position of the heart
        int heartWidth = 200;
        int heartHeight = 180;
        int centerX = this.ClientSize.Width / 2;
        int centerY = this.ClientSize.Height / 3;

        // Draw the heart shape
        DrawHeart(g, centerX, centerY, heartWidth, heartHeight, Color.Red);

        // Draw the text below the heart
        string message = "Szeretlek Dorka";
        Font font = new Font("Arial", 24, FontStyle.Bold);
        SizeF textSize = g.MeasureString(message, font);
        g.DrawString(message, font, Brushes.White, centerX - textSize.Width / 2, centerY + heartHeight / 2 + 10);
    }

    private void DrawHeart(Graphics g, int x, int y, int width, int height, Color color)
    {
        // This will draw a simple heart using Bezier curves and FillEllipse for simplicity
        using (Pen pen = new Pen(color, 3))
        {
            // Left circle for heart
            g.FillEllipse(new SolidBrush(color), x - width / 2, y - height / 4, width / 2, height / 2);
            // Right circle for heart
            g.FillEllipse(new SolidBrush(color), x, y - height / 4, width / 2, height / 2);

            // Bottom triangle for heart
            Point[] points = {
                new Point(x - width / 2, y),
                new Point(x + width / 2, y),
                new Point(x, y + height / 2)
            };
            g.FillPolygon(new SolidBrush(color), points);
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FullScreenHeartApp());
    }
}
