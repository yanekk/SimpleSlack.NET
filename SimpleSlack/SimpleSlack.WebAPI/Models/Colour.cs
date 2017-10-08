using System;

namespace SimpleSlack.WebAPI.Models
{
    public class Colour
    {
        public string Value { get; private set; }

        public static Colour Good = new Colour("good");
        public static Colour Warning = new Colour("warning");
        public static Colour Danger = new Colour("danger");

        private Colour(string colour)
        {
            Value = colour;
        }

        public static Colour FromRGB(int r, int g, int b)
        {
            if (r > 255 || g > 255 || b > 255)
                throw new ArgumentException("all colour values must be less or equal 255");

            return new Colour($"#{r.ToString("X")}{g.ToString("X")}{b.ToString("X")}");
        }
    }
}
