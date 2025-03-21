using System.Speech.Recognition;

namespace GenAI_ImageGenerator.Services
{
    public static class CognitiveServices
    {
        public static readonly SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

        public static void DetectSpeech()
        {
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Single);
        }
    }
}
