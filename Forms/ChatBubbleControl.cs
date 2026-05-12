using System;
using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    public partial class ChatBubbleControl : UserControl
    {
        public ChatBubbleControl()
        {
            InitializeComponent();
        }

        public void BindMessage(string senderName, string message, DateTime createdAt, bool fromCurrentUser, int width)
        {
            Width = Math.Max(220, width);
            BackColor = fromCurrentUser ? Color.FromArgb(24, 95, 78) : AppTheme.BgCard;
            Margin = fromCurrentUser ? new Padding(35, 6, 0, 6) : new Padding(0, 6, 35, 6);

            lblHeader.Text = $"{senderName}  |  {createdAt:g}";
            lblBody.Text = message;
            lblHeader.Size = new Size(Width - 20, 18);
            lblBody.MaximumSize = new Size(Width - 20, 0);
            lblBody.Size = new Size(Width - 20, 0);
            lblBody.Height = TextRenderer.MeasureText(message, lblBody.Font, new Size(lblBody.Width, 0), TextFormatFlags.WordBreak).Height + 8;
            Height = lblBody.Bottom + 10;
        }
    }
}
