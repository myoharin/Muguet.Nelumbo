namespace SineVita.Muguet.Nelumbo {
    public enum LotusRole {
        ST = 0,
        S1 = 0,
        StructuralTonic = 0,

        Sm3 = 1,
        StructuralMinorMediant = 1,
        
        SM3 = 2,
        StructuralMajorMediant = 2,
        
        SD = 3,
        S5 = 3,
        StructuralDominant = 3,

        SO = 4,
        S8 = 4,
        S0 = 4,
        StructuralOctave = 4,

        sA = 5, StressAugmented = 5,
        sD = 6, StressDiminished = 6,

        // deriviation
        Lsus2 = 7, LimmaticSuspended2nd = 7, SuspendedLimmatic2nd = 7,
        Lsus4 = 8, LimmaticSuspended4th = 8, SuspendedLimmatic4th = 8,

        susM = 9,
        sus3 = 9,
        SuspendedMediant = 9,

        // microtonal 3rds
        Ssm3 = 10,
        Sd3 = 10,

        Sdm3 = 11,
        SUm3 = 11,

        SSM3 = 12,
        SA3 = 12,

        SUM3 = 13,
        SAM3 = 13,

        Sn3 = 14,
        Snu3 = 14,
        Sneu3 = 14,

    }
}