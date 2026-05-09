using System;
using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    public partial class AboutPanel : UserControl
    {
        public AboutPanel()
        {
            this.BackColor = AppTheme.BgDark;
            this.AutoScroll = true;
            InitializeComponent();
            this.Resize += AboutPanel_Resize;
            CenterContent();
        }

        private void AboutPanel_Load(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void AboutPanel_Resize(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void CenterContent()
        {
            if (pnlHero == null || pnlStats == null || pnlStory == null || pnlValues == null) return;

            int contentWidth = Math.Max(0, ClientSize.Width - Padding.Horizontal);
            int maxWidth = Math.Min(950, Math.Max(320, contentWidth - 80));
            int left = Math.Max(40, (ClientSize.Width - maxWidth) / 2);

            CenterInParent(lblTitle, pnlHero, 40);
            CenterInParent(lblSub, pnlHero, 92);

            pnlStats.SetBounds(left, 180, maxWidth, pnlStats.Height);
            pnlStory.SetBounds(left, 366, maxWidth, pnlStory.Height);
            pnlValues.SetBounds(left, 562, maxWidth, pnlValues.Height);

            CenterLabel(lblStory, 330);
            CenterLabel(lblValues, 526);
            LayoutEqualColumns(pnlStats, 10, stat1, stat2, stat3, stat4);
            LayoutEqualColumns(pnlValues, 10, value1, value2, value3, value4);

            lblStory1.Width = Math.Max(240, pnlStory.ClientSize.Width - pnlStory.Padding.Horizontal);
        }

        private void CenterLabel(Label label, int top)
        {
            label.Location = new Point(Math.Max(20, (ClientSize.Width - label.Width) / 2), top);
        }

        private static void CenterInParent(Control child, Control parent, int top)
        {
            child.Location = new Point(Math.Max(20, (parent.ClientSize.Width - child.Width) / 2), top);
        }

        private static void LayoutEqualColumns(Panel panel, int gap, params Label[] labels)
        {
            if (labels.Length == 0) return;

            int width = Math.Max(120, (panel.ClientSize.Width - (gap * (labels.Length - 1))) / labels.Length);
            int x = 0;

            foreach (var label in labels)
            {
                label.SetBounds(x, 0, width, label.Height);
                x += width + gap;
            }
        }
    }
}



