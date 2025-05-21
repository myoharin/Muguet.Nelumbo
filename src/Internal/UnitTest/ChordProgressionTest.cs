using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Internal.UnitTest
{
    internal class ChordProgressionTest
    {
        internal class ChordProgression() {}

        internal void RunTest() {
            
            var chord1MidiIndices = new List<int>() {
                41, // F2
                48, // C3
                51, // Eb3
                56, // Ab3
                62, // D4
                67 // G4
            };
            var chord2MidiIndices = new List<int>() {
                46, // Bb2
                53, // F2
                56, // Ab3
                59, // B3
                63, // Eb4
                67  // G4
            };
            
            var chord1 = new Chord(chord1MidiIndices.Select(i => (Pitch)(new MidiPitch(i))).ToList());
            var chord2 = new Chord(chord2MidiIndices.Select(i => (Pitch)(new MidiPitch(i))).ToList());
            
            NelumboAnalyser analyser = new NelumboAnalyser();
            analyser.AppendLantern(chord1);
            analyser.AppendLantern(chord2);
            
            var lantern1 = analyser.Sutra.Lanterns[0];
            foreach (var lotus in lantern1.Lotuses) {
                Console.WriteLine($"\n= = {lotus.Pitch.NoteName} = =");
                foreach (var role in lotus.Roles) {
                    Console.Write(" | ");
                    Console.Write(LsfeHelper.ToString(role));
                }
            }
            
            var threads = analyser.GetAllThreads(false);
            foreach (var thread in threads) {
                Console.WriteLine(thread.ToLsfe());
            }
        }
    }
}