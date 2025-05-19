namespace SineVita.Muguet.Nelumbo {
    public enum FunctionalIntervalSuffix{
        Second = 2,
        Third = 3,
        Fourth = 4,
        Tritone = 0,
        Fifth = 5,
        Sixth = 6,
        Seventh = 7,
    }
    public enum FunctionalIntervalPrefix{
        Ultraminor = -3, DiminishedMinor = -3, Um = -3, dm = -3,
        Subminor = -2, Diminished = -2, sm = -2, d = -2,
        Minor = -1, m = -1,
        Neutral = 0, n = 0, nu = 0, neu = 0, Perfect = 0, P = 0,
        Major = 1, M = 1,
        Supermajor = 2, Augmented = 2, SM = 2, A = 2,
        Ultramajor = 3, AugmentedMajor = 3, UM = 3, AM = 3
    }
    public enum ConstantInterval {
        Limma = 1, L = 1,
        Shimmer = 2, ShimmerDiesis = 2, S = 2, s = 2,
        Octave = 3, O = 3, o = 3
    }
}