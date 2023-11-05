﻿namespace BicycleRESTforCD.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string? Color { get; set; }

        public void ValidateColor()
        {
            if (Color == null)
            {
                throw new ArgumentNullException("Color cannot be null");
            }
            if (Color.Length < 3)
            {
                throw new ArgumentException("Color must be at least 3 characters long");
            }
        }

        internal void Validate()
        {
            ValidateColor();
        }
    }
}
