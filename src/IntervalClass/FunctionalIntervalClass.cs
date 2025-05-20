using System.Runtime.CompilerServices;

namespace SineVita.Muguet.Nelumbo.IntervalClass {
    public sealed class FunctionalIntervalClass : FormalIntervalClassification {
        public FunctionalIntervalPrefix Prefix { init; get; }
        public FunctionalIntervalSuffix Suffix { init; get; }

        public FunctionalIntervalClass(FunctionalIntervalPrefix prefix, FunctionalIntervalSuffix suffix) {
            Prefix = prefix;
            Suffix = suffix;
        }

        public override bool Equals(FormalIntervalClassification? other) {
            if (other is FunctionalIntervalClass intervalClass) {
                return this.Prefix == intervalClass.Prefix && this.Suffix == intervalClass.Suffix;
            }
            return false;
        }

        // * Relational Manipulation 
        public FunctionalIntervalClass Inverted { get {
            var prefix = this.Prefix switch {
                FunctionalIntervalPrefix.dm => FunctionalIntervalPrefix.AM,
                FunctionalIntervalPrefix.sm => FunctionalIntervalPrefix.SM,
                FunctionalIntervalPrefix.m => FunctionalIntervalPrefix.M,
                FunctionalIntervalPrefix.n => FunctionalIntervalPrefix.n,
                FunctionalIntervalPrefix.M => FunctionalIntervalPrefix.m,
                FunctionalIntervalPrefix.SM => FunctionalIntervalPrefix.sm,
                FunctionalIntervalPrefix.AM => FunctionalIntervalPrefix.dm,
                _ => this.Prefix
            };

            var suffix = this.Suffix switch {
                FunctionalIntervalSuffix.Second => FunctionalIntervalSuffix.Seventh,
                FunctionalIntervalSuffix.Third => FunctionalIntervalSuffix.Sixth,
                FunctionalIntervalSuffix.Fourth => FunctionalIntervalSuffix.Fifth,
                FunctionalIntervalSuffix.Tritone => FunctionalIntervalSuffix.Tritone,
                FunctionalIntervalSuffix.Fifth => FunctionalIntervalSuffix.Fourth,
                FunctionalIntervalSuffix.Sixth => FunctionalIntervalSuffix.Third,
                FunctionalIntervalSuffix.Seventh => FunctionalIntervalSuffix.Second,
                _ => this.Suffix
            };
            return new FunctionalIntervalClass(prefix, suffix);
        } }
 
        public FunctionalIntervalClass? UpFifth => this.DownFourth;
        public FunctionalIntervalClass? DownFourth { get { // only considers 2 / 3 / 6
            FunctionalIntervalSuffix? newSuffix = Suffix switch {
                FunctionalIntervalSuffix.Second => FunctionalIntervalSuffix.Sixth,
                FunctionalIntervalSuffix.Sixth => FunctionalIntervalSuffix.Third,
                FunctionalIntervalSuffix.Third => FunctionalIntervalSuffix.Seventh,
                _ => null
            };
            if (newSuffix == null) {
                return null;
            }
            else {
                return new FunctionalIntervalClass(this.Prefix, (FunctionalIntervalSuffix)newSuffix);
            }
        } }   
        
        public FunctionalIntervalClass? DownFifth => this.UpFourth;
        public FunctionalIntervalClass? UpFourth { get { // only considers 3 / 6 / 7
            FunctionalIntervalSuffix? newSuffix = Suffix switch {
                FunctionalIntervalSuffix.Seventh => FunctionalIntervalSuffix.Third,
                FunctionalIntervalSuffix.Third => FunctionalIntervalSuffix.Sixth,
                FunctionalIntervalSuffix.Sixth => FunctionalIntervalSuffix.Second,
                _ => null
                    
            };
            if (newSuffix != null) {
                return new FunctionalIntervalClass(this.Prefix, (FunctionalIntervalSuffix)newSuffix);;
            }
            else { // is null, so check for all other diatonic conversions
                return null;                
            }
            
        } }

        
    
    }
}