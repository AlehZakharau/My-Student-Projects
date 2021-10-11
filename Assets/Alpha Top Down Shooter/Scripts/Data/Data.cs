using System;
using Alpha.UI;

namespace Alpha.Data
{
    [Serializable]
    public class Data
    {
        public int score;
        public float soundVolume;
        public float musicVolume;
        public bool fullScreen;
        public ScreenResolutions16and9 resolution;
        public int resWidth;
        public int resHeight;
        public bool tutorialLearned;
    }
}