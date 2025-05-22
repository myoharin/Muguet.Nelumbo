using SineVita.Muguet.Nelumbo.Lily;

namespace SineVita.Muguet.Nelumbo.Lsfe {
    internal class LsfeHelper {
        public static String ToString(LotusRole role) {
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
    }
}