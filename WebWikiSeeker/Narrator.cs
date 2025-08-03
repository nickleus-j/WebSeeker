using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace WebWikiSeeker
{
    public class Narrator
    {
        public static void Narrate(string textToNarrate,int volume=100,int rate=1)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Volume = volume;
                synthesizer.Rate = rate;
                if (!string.IsNullOrEmpty(textToNarrate))
                {
                    synthesizer.Speak(textToNarrate);
                }
            }
        }
    }
}
