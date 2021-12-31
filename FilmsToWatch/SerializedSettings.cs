using System;
using System.Drawing;

namespace FilmsToWatch
{
    [Serializable]
    public class SerializedSettings
    {
        public Size WindowSize { get; set; }
        public int BackgroundColorArgb { get; set; }
        public string CityName { get; set; }
    }
}