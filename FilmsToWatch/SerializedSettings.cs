using System;
using System.Drawing;

namespace FilmsToWatch
{
    [Serializable]
    public class SerializedSettings
    {
        public SerializedSettings() { }
        public Size WindowSize { get; set; }
        public byte AlphaChannel { get; set; }
        public byte RedChannel { get; set; }
        public byte GreenChannel { get; set; }
        public byte BlueChannel { get; set; }
        public string CityName { get; set; }
    }
}