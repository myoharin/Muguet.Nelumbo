using SineVita.Muguet.Nelumbo.Lily;

namespace SineVita.Muguet.Nelumbo.Lsfe {
    internal class LsfeHelper {
        public static String ToShortString(LotusRole role) {
            return role switch {
                LotusRole.ST       => "ST",
                LotusRole.Sm3      => "Sm3",
                LotusRole.SM3      => "SM3",
                LotusRole.SD       => "SD",
                LotusRole.S0       => "S0",
                LotusRole.sA       => "sA",
                LotusRole.sD       => "sD",
                LotusRole.Lsus2    => "Lsus2",
                LotusRole.Lsus4    => "Lsus4",
                LotusRole.susM     => "susM",
                
                LotusRole.Ssm3     => "Ssm3",
                LotusRole.Sdm3     => "Sdm3",
                LotusRole.SSM3     => "SSM3",
                LotusRole.SAM3     => "SAM3",
                LotusRole.Sneu3 => "Sneu3",
                _ => ""

            };
        }
        
        public static String ToFullString(LotusRole role) {
            return role switch {
                LotusRole.ST    => "StructuralTonic",
                LotusRole.Sm3   => "StructuralMinor3rd",
                LotusRole.SM3   => "StructuralMajor3rd",
                LotusRole.SD    => "StructuralDominant",
                LotusRole.S0    => "StructuralOctave",
                LotusRole.sA    => "stressAugmented",
                LotusRole.sD    => "stressDiminished",
                LotusRole.Lsus2 => "LimmaticallySuspended2nd",
                LotusRole.Lsus4 => "LimmaticallySuspended4th",
                LotusRole.susM  => "suspendedMediant",
                
                LotusRole.Ssm3  => "StructuralSubminor3rd",
                LotusRole.Sdm3  => "StructuralDiminishedMinor3rd",
                LotusRole.SSM3  => "StructuralSuperMajor3rd",
                LotusRole.SAM3  => "StructuralAugmentedMajor3rd",
                LotusRole.Sneu3 => "StructuralNeutral3rd",
                _               => ""

            };
        }

        
    }
}