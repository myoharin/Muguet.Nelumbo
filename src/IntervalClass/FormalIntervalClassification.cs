namespace SineVita.Muguet.Nelumbo.IntervalClass {
    public abstract class FormalIntervalClassification : 
        IEquatable<FormalIntervalClassification>
    {
        public abstract bool Equals(FormalIntervalClassification? other);

        // * ConstantInterval
        public static ConstantIntervalClass Unison => new ConstantIntervalClass(ConstantInterval.Unison);
        public static ConstantIntervalClass U => Unison;
        public static ConstantIntervalClass u => Unison;
        
        public static ConstantIntervalClass Limma => new ConstantIntervalClass(ConstantInterval.Limma);
        public static ConstantIntervalClass L => Limma;

        public static ConstantIntervalClass Shimmer => new ConstantIntervalClass(ConstantInterval.Shimmer);
        public static ConstantIntervalClass ShimmerDiesis => Shimmer;
        public static ConstantIntervalClass S => Shimmer;
        public static ConstantIntervalClass s => Shimmer;

        public static ConstantIntervalClass Octave => new ConstantIntervalClass(ConstantInterval.Octave);
        public static ConstantIntervalClass O => Octave;
        public static ConstantIntervalClass o => Octave;

        // * Original Full Names - FunctionalIntervalClass
        public static FunctionalIntervalClass Ultraminor2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Second);
        public static FunctionalIntervalClass Subminor2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Second);
        public static FunctionalIntervalClass Minor2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Second);
        public static FunctionalIntervalClass Neutral2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Neutral, FunctionalIntervalSuffix.Second);
        public static FunctionalIntervalClass Major2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Second);
        public static FunctionalIntervalClass Supermajor2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Second);
        public static FunctionalIntervalClass Ultramajor2nd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Second);

        public static FunctionalIntervalClass Ultraminor3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Third);
        public static FunctionalIntervalClass Subminor3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Third);
        public static FunctionalIntervalClass Minor3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Third);
        public static FunctionalIntervalClass Neutral3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Neutral, FunctionalIntervalSuffix.Third);
        public static FunctionalIntervalClass Major3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Third);
        public static FunctionalIntervalClass Supermajor3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Third);
        public static FunctionalIntervalClass Ultramajor3rd => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Third);

        public static FunctionalIntervalClass Ultraminor4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Fourth);
        public static FunctionalIntervalClass Subminor4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Fourth);
        public static FunctionalIntervalClass Minor4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Fourth);
        public static FunctionalIntervalClass Perfect4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Perfect, FunctionalIntervalSuffix.Fourth);
        public static FunctionalIntervalClass Major4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Fourth);
        public static FunctionalIntervalClass Supermajor4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Fourth);
        public static FunctionalIntervalClass Ultramajor4th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Fourth);

        public static FunctionalIntervalClass UltraminorTritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Tritone);
        public static FunctionalIntervalClass SubminorTritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Tritone);
        public static FunctionalIntervalClass MinorTritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Tritone);
        public static FunctionalIntervalClass Tritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Perfect, FunctionalIntervalSuffix.Tritone);
        public static FunctionalIntervalClass MajorTritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Tritone);
        public static FunctionalIntervalClass SupermajorTritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Tritone);
        public static FunctionalIntervalClass UltramajorTritone => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Tritone);

        public static FunctionalIntervalClass Ultraminor5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Fifth);
        public static FunctionalIntervalClass Subminor5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Fifth);
        public static FunctionalIntervalClass Minor5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Fifth);
        public static FunctionalIntervalClass Perfect5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Perfect, FunctionalIntervalSuffix.Fifth);
        public static FunctionalIntervalClass Major5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Fifth);
        public static FunctionalIntervalClass Supermajor5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Fifth);
        public static FunctionalIntervalClass Ultramajor5th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Fifth);

        public static FunctionalIntervalClass Ultraminor6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Sixth);
        public static FunctionalIntervalClass Subminor6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Sixth);
        public static FunctionalIntervalClass Minor6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Sixth);
        public static FunctionalIntervalClass Neutral6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Neutral, FunctionalIntervalSuffix.Sixth);
        public static FunctionalIntervalClass Major6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Sixth);
        public static FunctionalIntervalClass Supermajor6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Sixth);
        public static FunctionalIntervalClass Ultramajor6th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Sixth);

        public static FunctionalIntervalClass Ultraminor7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultraminor, FunctionalIntervalSuffix.Seventh);
        public static FunctionalIntervalClass Subminor7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Subminor, FunctionalIntervalSuffix.Seventh);
        public static FunctionalIntervalClass Minor7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Minor, FunctionalIntervalSuffix.Seventh);
        public static FunctionalIntervalClass Neutral7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Neutral, FunctionalIntervalSuffix.Seventh);
        public static FunctionalIntervalClass Major7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Major, FunctionalIntervalSuffix.Seventh);
        public static FunctionalIntervalClass Supermajor7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Supermajor, FunctionalIntervalSuffix.Seventh);
        public static FunctionalIntervalClass Ultramajor7th => new FunctionalIntervalClass(FunctionalIntervalPrefix.Ultramajor, FunctionalIntervalSuffix.Seventh);

        // * Long names alt
        public static FunctionalIntervalClass DiminishedMinor2nd => Ultraminor2nd;
        public static FunctionalIntervalClass Diminished2nd => Subminor2nd;
        public static FunctionalIntervalClass Augmented2nd => Supermajor2nd;
        public static FunctionalIntervalClass AugmentedMajor2nd => Ultramajor2nd;

        public static FunctionalIntervalClass DiminishedMinor3rd => Ultraminor3rd;
        public static FunctionalIntervalClass Diminished3rd => Subminor3rd;
        public static FunctionalIntervalClass Augmented3rd => Supermajor3rd;
        public static FunctionalIntervalClass AugmentedMajor3rd => Ultramajor3rd;

        public static FunctionalIntervalClass DiminishedMinor4th => Ultraminor4th;
        public static FunctionalIntervalClass Diminished4th => Subminor4th;
        public static FunctionalIntervalClass Augmented4th => Supermajor4th;
        public static FunctionalIntervalClass AugmentedMajor4th => Ultramajor4th;

        public static FunctionalIntervalClass DiminishedMinorTritone => UltraminorTritone;
        public static FunctionalIntervalClass DiminishedTritone => SubminorTritone;
        public static FunctionalIntervalClass AugmentedTritone => SupermajorTritone;
        public static FunctionalIntervalClass AugmentedMajorTritone => UltramajorTritone;

        public static FunctionalIntervalClass DiminishedMinor5th => Ultraminor5th;
        public static FunctionalIntervalClass Diminished5th => Subminor5th;
        public static FunctionalIntervalClass Augmented5th => Supermajor5th;
        public static FunctionalIntervalClass AugmentedMajor5th => Ultramajor5th;

        public static FunctionalIntervalClass DiminishedMinor6th => Ultraminor6th;
        public static FunctionalIntervalClass Diminished6th => Subminor6th;
        public static FunctionalIntervalClass Augmented6th => Supermajor6th;
        public static FunctionalIntervalClass AugmentedMajor6th => Ultramajor6th;

        public static FunctionalIntervalClass DiminishedMinor7th => Ultraminor7th;
        public static FunctionalIntervalClass Diminished7th => Subminor7th;
        public static FunctionalIntervalClass Augmented7th => Supermajor7th;
        public static FunctionalIntervalClass AugmentedMajor7th => Ultramajor7th;

        // * Short names alt
        public static FunctionalIntervalClass um2 => Ultraminor2nd;
        public static FunctionalIntervalClass dm2 => Ultraminor2nd;
        public static FunctionalIntervalClass sm2 => Subminor2nd;
        public static FunctionalIntervalClass d2 => Subminor2nd;
        public static FunctionalIntervalClass m2 => Minor2nd;
        public static FunctionalIntervalClass n2 => Neutral2nd;
        public static FunctionalIntervalClass nu2 => Neutral2nd;
        public static FunctionalIntervalClass neu2 => Neutral2nd;
        public static FunctionalIntervalClass M2 => Major2nd;
        public static FunctionalIntervalClass A2 => Supermajor2nd;
        public static FunctionalIntervalClass SM2 => Supermajor2nd;
        public static FunctionalIntervalClass AM2 => Ultramajor2nd;
        public static FunctionalIntervalClass UM2 => Ultramajor2nd;

        public static FunctionalIntervalClass um3 => Ultraminor3rd;
        public static FunctionalIntervalClass dm3 => Ultraminor3rd;
        public static FunctionalIntervalClass sm3 => Subminor3rd;
        public static FunctionalIntervalClass d3 => Subminor3rd;
        public static FunctionalIntervalClass m3 => Minor3rd;
        public static FunctionalIntervalClass n3 => Neutral3rd;
        public static FunctionalIntervalClass nu3 => Neutral3rd;
        public static FunctionalIntervalClass neu3 => Neutral3rd;
        public static FunctionalIntervalClass M3 => Major3rd;
        public static FunctionalIntervalClass A3 => Supermajor3rd;
        public static FunctionalIntervalClass SM3 => Supermajor3rd;
        public static FunctionalIntervalClass AM3 => Ultramajor3rd;
        public static FunctionalIntervalClass UM3 => Ultramajor3rd;

        public static FunctionalIntervalClass um4 => Ultraminor4th;
        public static FunctionalIntervalClass dm4 => Ultraminor4th;
        public static FunctionalIntervalClass sm4 => Subminor4th;
        public static FunctionalIntervalClass d4 => Subminor4th;
        public static FunctionalIntervalClass m4 => Minor4th;
        public static FunctionalIntervalClass P4 => Perfect4th;
        public static FunctionalIntervalClass M4 => Major4th;
        public static FunctionalIntervalClass A4 => Supermajor4th;
        public static FunctionalIntervalClass SM4 => Supermajor4th;
        public static FunctionalIntervalClass AM4 => Ultramajor4th;
        public static FunctionalIntervalClass UM4 => Ultramajor4th;

        public static FunctionalIntervalClass umT => UltraminorTritone;
        public static FunctionalIntervalClass dmT => UltraminorTritone;
        public static FunctionalIntervalClass smT => SubminorTritone;
        public static FunctionalIntervalClass dT => SubminorTritone;
        public static FunctionalIntervalClass mT => MinorTritone;
        public static FunctionalIntervalClass T => Tritone;
        public static FunctionalIntervalClass MT => MajorTritone;
        public static FunctionalIntervalClass AT => SupermajorTritone;
        public static FunctionalIntervalClass SMT => SupermajorTritone;
        public static FunctionalIntervalClass AMT => UltramajorTritone;
        public static FunctionalIntervalClass UMT => UltramajorTritone;

        public static FunctionalIntervalClass um5 => Ultraminor5th;
        public static FunctionalIntervalClass dm5 => Ultraminor5th;
        public static FunctionalIntervalClass sm5 => Subminor5th;
        public static FunctionalIntervalClass d5 => Subminor5th;
        public static FunctionalIntervalClass m5 => Minor5th;
        public static FunctionalIntervalClass P5 => Perfect5th;
        public static FunctionalIntervalClass M5 => Major5th;
        public static FunctionalIntervalClass A5 => Supermajor5th;
        public static FunctionalIntervalClass SM5 => Supermajor5th;
        public static FunctionalIntervalClass AM5 => Ultramajor5th;
        public static FunctionalIntervalClass UM5 => Ultramajor5th;

        public static FunctionalIntervalClass um6 => Ultraminor6th;
        public static FunctionalIntervalClass dm6 => Ultraminor6th;
        public static FunctionalIntervalClass sm6 => Subminor6th;
        public static FunctionalIntervalClass d6 => Subminor6th;
        public static FunctionalIntervalClass m6 => Minor6th;
        public static FunctionalIntervalClass n6 => Neutral6th;
        public static FunctionalIntervalClass nu6 => Neutral6th;
        public static FunctionalIntervalClass neu6 => Neutral6th;
        public static FunctionalIntervalClass M6 => Major6th;
        public static FunctionalIntervalClass A6 => Supermajor6th;
        public static FunctionalIntervalClass SM6 => Supermajor6th;
        public static FunctionalIntervalClass AM6 => Ultramajor6th;
        public static FunctionalIntervalClass UM6 => Ultramajor6th;

        public static FunctionalIntervalClass um7 => Ultraminor7th;
        public static FunctionalIntervalClass dm7 => Ultraminor7th;
        public static FunctionalIntervalClass sm7 => Subminor7th;
        public static FunctionalIntervalClass d7 => Subminor7th;
        public static FunctionalIntervalClass m7 => Minor7th;
        public static FunctionalIntervalClass n7 => Neutral7th;
        public static FunctionalIntervalClass nu7 => Neutral7th;
        public static FunctionalIntervalClass neu7 => Neutral7th;
        public static FunctionalIntervalClass M7 => Major7th;
        public static FunctionalIntervalClass A7 => Supermajor7th;
        public static FunctionalIntervalClass SM7 => Supermajor7th;
        public static FunctionalIntervalClass AM7 => Ultramajor7th;
        public static FunctionalIntervalClass UM7 => Ultramajor7th;
        
        // * ToString
        public abstract override string ToString();
        public abstract override int GetHashCode();
    }
}