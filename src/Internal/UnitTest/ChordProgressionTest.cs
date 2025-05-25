using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Internal.UnitTest
{
    internal class ChordProgressionTest
    {
        internal class ChordProgression() {}

        internal void RunTest() {
            var chordFmVoicing
                = new Chord(new List<int>() {
                41, // F2
                48, // C3
                51, // Eb3
                56, // Ab3
                62, // D4
                67  // G4
            }.Select(i => (Pitch)(new MidiPitch(i))).ToList());
            var chordBb7Voicing = new Chord(new List<int>() {
                46, // Bb2
                53, // F2
                56, // Ab3
                59, // B3
                63, // Eb4
                67  // G4
            }.Select(i => (Pitch)(new MidiPitch(i))).ToList());
            var chordCMajor = new Chord(new List<int>() {
                48, // C3
                52, // E3
                59, // B3
                67, // G4
            }.Select(i => (Pitch)(new MidiPitch(i))).ToList());
            var chordFMajor = new Chord(new List<int>() {
                41, // F2
                52, // E3
                60, // C4
                67, // G4
            }.Select(i => (Pitch)(new MidiPitch(i))).ToList());
            
            NelumboAnalyser analyser = new NelumboAnalyser();
            analyser.AppendLantern(chordFmVoicing);
            analyser.AppendLantern(chordBb7Voicing);
            analyser.AppendLantern(chordCMajor);
            analyser.AppendLantern(chordFMajor);

            // PrintLantern(analyser.Sutra.Lanterns[0]);
            // PrintLantern(analyser.Sutra.Lanterns[1]);
            PrintLantern(analyser.Sutra.Lanterns[2]);
            PrintLantern(analyser.Sutra.Lanterns[3]);
            
            Console.WriteLine("\n\n");
            var threads = analyser.GetAllThreads(false);
            Console.WriteLine(LanternThreadWeightsAsString(threads[3]));
        }

        internal string LanternThreadWeightsAsString(LanternThread lanternThread) {
            var threads = lanternThread.GetLotusThreads(true);

            var returnStr = "";
            bool first = true;
            
            foreach (var thread in threads) {
                if (first) {
                    first = false;
                }
                else {
                    returnStr += "\n\n";
                }
                var threadString = $"{thread.Antecedant.Pitch.NoteName}" +
                                   $"->" +
                                   $"{thread.Consequent.Pitch.NoteName}";
                var lotusThreadTupletString = LotusThreadWeightsAsString(thread);//.Replace(" ", "\n");
                threadString += "\n" + lotusThreadTupletString;
                returnStr += threadString;
            }
            
            return returnStr;
        }

        internal string LotusThreadWeightsAsString(LotusThread lotusThread) {
            // [Movement] (\([Antecedent LotusRole] -> [Consequent LotusRole]\))+
            var strands = lotusThread.EnumerateStrands();
            var movementStr = $"{lotusThread.Movement.ToLsfe()} ";
            return string.Concat(
                movementStr,
                String.Join(
                    " ", strands.Select(s => $"({s.Weight.ToString("F3")})")
                    )
            // $"({LsfeHelper.ToShortString(s.AntecedantRole)}->{LsfeHelper.ToShortString(s.ConsequentRole)})"
                );
        }
        
        internal void PrintLantern(Lantern lantern) {
            Console.Out.Write($"\nPrinting Lantern");
            foreach (var lotus in lantern.Lotuses) {
                Console.Out.Write($" | {lotus.Pitch.ToPitch().NoteName}");
            }
            foreach (var lotus in lantern.Lotuses) {
                Console.WriteLine($"\n= = {lotus.Pitch.NoteName} = =");
                foreach (var role in lotus.Roles) {
                    Console.WriteLine($"{LsfeHelper.ToShortString(role)}: \t {lotus[role].ToString("F3")}");
                }
            }
            Console.WriteLine();
        }
    }
}