using System.Drawing;

namespace RentXpress
{
    public static class AppTheme
    {
        // Colors matching Figma dark theme
        public static readonly Color BgDark       = Color.FromArgb(26, 26, 26);
        public static readonly Color BgCard        = Color.FromArgb(38, 38, 38);
        public static readonly Color BgInput       = Color.FromArgb(48, 48, 48);
        public static readonly Color BgNav         = Color.FromArgb(20, 20, 20);
        public static readonly Color Accent        = Color.FromArgb(32, 201, 151);   // teal
        public static readonly Color AccentHover   = Color.FromArgb(25, 170, 128);
        public static readonly Color TextPrimary   = Color.White;
        public static readonly Color TextSecondary = Color.FromArgb(160, 160, 160);
        public static readonly Color TextMuted     = Color.FromArgb(100, 100, 100);
        public static readonly Color BorderColor   = Color.FromArgb(60, 60, 60);
        public static readonly Color DangerColor   = Color.FromArgb(220, 53, 69);
        public static readonly Color WarningColor  = Color.FromArgb(255, 193, 7);
        public static readonly Color StarColor     = Color.FromArgb(255, 193, 7);

        public static readonly Font FontTitle   = new Font("Segoe UI", 20f, FontStyle.Bold);
        public static readonly Font FontH2      = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font FontBody    = new Font("Segoe UI", 9.5f);
        public static readonly Font FontSmall   = new Font("Segoe UI", 8.5f);
        public static readonly Font FontNav     = new Font("Segoe UI", 10f);
        public static readonly Font FontButton  = new Font("Segoe UI", 10f, FontStyle.Bold);
    }
}

