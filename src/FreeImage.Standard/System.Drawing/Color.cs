using System;

namespace FreeImageAPI
{
    [Serializable]
    public struct Color : IEquatable<Color>
    {
        public static readonly Color Empty;
        public static Color Transparent => new Color(0x00, 0x00, 0x00, 0xFF);
        public static Color White => new Color(0xFF, 0xFF, 0xFF, 0xFF);

        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte r, byte g, byte b, byte a){
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static Color FromArgb(int argb)
        {
            unchecked
            {
                return new Color(
                    (byte) (argb >> 16),
                    (byte) (argb >> 8),
                    (byte) argb,
                    (byte) (argb >> 24)
                );
            }
        }

        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            unchecked
            {
                return new Color((byte) red, (byte) green, (byte) blue, (byte) alpha);
            }
        }

        public static Color FromArgb(int alpha, Color baseColor)
        {
            unchecked
            {
                return new Color(baseColor.R, baseColor.G, baseColor.B, (byte) baseColor.A);
            }
        }

        public static Color FromArgb(int red, int green, int blue) => FromArgb(255, red, green, blue);

        public int ToArgb(){
            unchecked
            {
                return (int) A << 24 |
                (int) R << 16 |
                (int) G << 8 |
                (int) B;
            }
        }


        public static bool operator ==(Color left, Color right){
            return left.R == right.R
                && left.G == right.G
                && left.B == right.B
                && left.A == right.A;
        }

        public static bool operator !=(Color left, Color right) => !(left == right);

        public override bool Equals(object obj) => obj is Color other && Equals(other);

        public bool Equals(Color other) => this == other;


        public override int GetHashCode(){
            return base.GetHashCode();
        }

    }
}