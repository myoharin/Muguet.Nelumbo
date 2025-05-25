using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Identity.Movement
{
    public class CmMovementIdentityMatcher :
        INelumboIdentityMatcher<LotusThread>,
        INelumboIdentityMatcher<LotusStrand>
    {
        // * Properties
        public CmMovementIdentity CmMovementIdentity { init; get; }
        public Identity Identity => CmMovementIdentity;

        public CmMovementIdentityMatcher(CmMovementIdentity value) {
            CmMovementIdentity = value;
        }
        
        // * Internal Data
        private static readonly Dictionary<CmMovementIdentityEnum, CmMovementIdentityCollumn> Evaluations;
        private static readonly List<CmMovementIdentityRow> EvaluationRow;

        static CmMovementIdentityMatcher() {
            var evaluationRowsAsTable = new List<Tuple<int, GenericLocalMovement, LotusRole, LotusRole, bool, bool>>()
            { // index, GLM, antecedentRole, consequentRole, antecedentDefined, consequentDefined
                new(0, GenericLocalMovement.DL, LotusRole.ST, LotusRole.SD, false, false),
                new(1, GenericLocalMovement.DL, LotusRole.ST, LotusRole.Sm3, false, true),
                new(2, GenericLocalMovement.U, LotusRole.ST, LotusRole.Sm3, false, true),
                new(3, GenericLocalMovement.U, LotusRole.ST, LotusRole.SM3, false, true),
                new(4, GenericLocalMovement.UL, LotusRole.ST, LotusRole.SM3, false, true),
                new(5, GenericLocalMovement.U5, LotusRole.ST, LotusRole.Sm3, false, true),
                new(6, GenericLocalMovement.U5, LotusRole.ST, LotusRole.SM3, false, true),
                new(7, GenericLocalMovement.D5, LotusRole.SD, LotusRole.Sm3, false, true),
                new(8, GenericLocalMovement.D5, LotusRole.SD, LotusRole.SM3, false, true),
                new(9, GenericLocalMovement.DL, LotusRole.SD, LotusRole.Sm3, false, true),
                new(10, GenericLocalMovement.U, LotusRole.SD, LotusRole.Sm3, false, true),
                new(11, GenericLocalMovement.U, LotusRole.SD, LotusRole.SM3, false, true),
                new(12, GenericLocalMovement.UL, LotusRole.SD, LotusRole.SM3, false, true),
                new(13, GenericLocalMovement.UL, LotusRole.SD, LotusRole.ST, false, false),
                new(14, GenericLocalMovement.D5, LotusRole.Sm3, LotusRole.ST, true, false),
                new(15, GenericLocalMovement.U, LotusRole.Sm3, LotusRole.ST, true, false),
                new(16, GenericLocalMovement.U, LotusRole.Sm3, LotusRole.SD, true, false),
                new(17, GenericLocalMovement.UL, LotusRole.Sm3, LotusRole.ST, true, false),
                new(18, GenericLocalMovement.UL, LotusRole.Sm3, LotusRole.SD, true, false),
                new(19, GenericLocalMovement.U4, LotusRole.Sm3, LotusRole.SM3, true, true),
                new(20, GenericLocalMovement.U5, LotusRole.Sm3, LotusRole.SD, true, false),
                new(21, GenericLocalMovement.D5, LotusRole.SM3, LotusRole.ST, true, false),
                new(22, GenericLocalMovement.D4, LotusRole.SM3, LotusRole.Sm3, true, true),
                new(23, GenericLocalMovement.DL, LotusRole.SM3, LotusRole.ST, true, false),
                new(24, GenericLocalMovement.DL, LotusRole.SM3, LotusRole.SD, true, false),
                new(25, GenericLocalMovement.U, LotusRole.SM3, LotusRole.ST, true, false),
                new(26, GenericLocalMovement.U, LotusRole.SM3, LotusRole.SD, true, false),
                new(27, GenericLocalMovement.U5, LotusRole.SM3, LotusRole.SD, true, false),
            };

            EvaluationRow = new();
            foreach (var row in evaluationRowsAsTable) {
                EvaluationRow.Add(new CmMovementIdentityRow(
                    row.Item2, // GLM
                    row.Item3, // antecedentRole
                    row.Item4,  // consequentRole
                    row.Item5, // antecedentDefined
                    row.Item6  // consequentDefined
                    )
                );
            }

            var e = EvaluationRow;
            
            Evaluations = new() {
                { CmMovementIdentityEnum.mDm3m, new CmMovementIdentityCollumn(new() {
                    e[2], e[7], e[18]
                }) },
                { CmMovementIdentityEnum.mDM3m, new CmMovementIdentityCollumn(new() {
                    e[1], e[13], e[14], e[16]
                }) },
                { CmMovementIdentityEnum.mUm3m, new CmMovementIdentityCollumn(new() {
                    e[9], e[15], e[20]
                }) },
                { CmMovementIdentityEnum.mUM3m, new CmMovementIdentityCollumn(new() {
                    e[0], e[5], e[10], e[17]
                }) },
                { CmMovementIdentityEnum.mDm3M, new CmMovementIdentityCollumn(new() {
                    e[4], e[18]
                }) },
                { CmMovementIdentityEnum.mDM3M, new CmMovementIdentityCollumn(new() {
                    e[3], e[8], e[13], e[14], e[16]
                }) },
                { CmMovementIdentityEnum.mUm3M, new CmMovementIdentityCollumn(new() {
                    e[6], e[11], e[15], e[20]
                }) },
                { CmMovementIdentityEnum.mUM3M, new CmMovementIdentityCollumn(new() {
                    e[0], e[12], e[17], e[19]
                }) },
                { CmMovementIdentityEnum.MDm3m, new CmMovementIdentityCollumn(new() {
                    e[2], e[7], e[21], e[26]
                }) },
                { CmMovementIdentityEnum.MDM3m, new CmMovementIdentityCollumn(new() {
                    e[1], e[13], e[22], e[24]
                }) },
                { CmMovementIdentityEnum.MUm3m, new CmMovementIdentityCollumn(new() {
                    e[9], e[23]
                }) },
                { CmMovementIdentityEnum.MUM3m, new CmMovementIdentityCollumn(new() {
                    e[0], e[5], e[10], e[25], e[27]
                }) },
                { CmMovementIdentityEnum.MDm3M, new CmMovementIdentityCollumn(new() {
                    e[4], e[21], e[26]
                }) },
                { CmMovementIdentityEnum.MDM3M, new CmMovementIdentityCollumn(new() {
                    e[3], e[8], e[13], e[24]
                }) },
                { CmMovementIdentityEnum.MUm3M, new CmMovementIdentityCollumn(new() {
                    e[6], e[11], e[23]
                }) },
                { CmMovementIdentityEnum.MUM3M, new CmMovementIdentityCollumn(new() {
                    e[0], e[12], e[25], e[27]
                }) },
            };
        }
        
        // * Matches
        public bool Matches(ILsfeParsable<LotusThread> thread) => Evaluations[CmMovementIdentity.EnumValue].MatchesExact(thread);
        public bool Matches(ILsfeParsable<LotusStrand> strand) => Evaluations[CmMovementIdentity.EnumValue].MatchContains(strand);
    }
    
      

    internal class CmMovementIdentityCollumn :
        ILsfePattern<LotusThread>,
        ILsfePatternContainer<LotusStrand>
    {
        public List<CmMovementIdentityRow> Rows { get; init; }

        public CmMovementIdentityCollumn(List<CmMovementIdentityRow> rows) {
            Rows = rows;
        }

        public bool MatchesExact(ILsfeParsable<LotusThread> thread) {
            throw new NotImplementedException();
        }

        public bool MatchesExact(ILsfeParsable<LotusStrand> strand) => false;
        public bool MatchContains(ILsfeParsable<LotusStrand> strand) {
            throw new NotImplementedException();
        }

        public object Clone() => new CmMovementIdentityCollumn(new(Rows));
        
    }
    
    internal struct CmMovementIdentityRow
    {
        public bool DefinedAntecedent;
        public bool DefinedConsequent;
        public MultiThreadPattern ThreadPattern;
       
        public CmMovementIdentityRow(
            GenericLocalMovement glm,
            LotusRole antecedentRole,
            LotusRole consequentRole,
            bool definedAntecedent,
            bool definedConsequent
            ) 
        {
            this.DefinedAntecedent = definedAntecedent;
            this.DefinedConsequent = definedConsequent;
            
            ThreadPattern = new MultiThreadPattern(glm);
        }
    }

    internal class MultiThreadPattern : ILsfePatternContainer<ThreadMovement>
    {
        public Tuple<ThreadMovementPattern, ThreadMovementPattern, ThreadMovementPattern> ThreadPatterns;
        
        public object Clone() {
            return new MultiThreadPattern(ThreadPatterns.Item1.Movement);
        }
        
        public bool MatchesExact(ILsfeParsable<ThreadMovement> t) => false;
        public bool MatchContains(ILsfeParsable<ThreadMovement> t) {
            return ThreadPatterns.Item1.MatchesExact(t) ||
                   ThreadPatterns.Item2.MatchesExact(t) ||
                   ThreadPatterns.Item3.MatchesExact(t);
        }

        public MultiThreadPattern(
            GenericLocalMovement movement
        ) {
            this.ThreadPatterns = movement switch {
                GenericLocalMovement.D8 => new(new(GenericLocalMovement.D8), new(GenericLocalMovement.U), new(GenericLocalMovement.U8)),
                GenericLocalMovement.D5 => new(new(GenericLocalMovement.D5), new(GenericLocalMovement.U4), new(GenericLocalMovement.U4)),
                GenericLocalMovement.D4 => new(new(GenericLocalMovement.D4), new(GenericLocalMovement.D4), new(GenericLocalMovement.U5)),
                GenericLocalMovement.U  => new(new(GenericLocalMovement.D8), new(GenericLocalMovement.U), new(GenericLocalMovement.U8)),
                GenericLocalMovement.U4 => new(new(GenericLocalMovement.D5), new(GenericLocalMovement.U4), new(GenericLocalMovement.U4)),
                GenericLocalMovement.U5 => new(new(GenericLocalMovement.D4), new(GenericLocalMovement.D4), new(GenericLocalMovement.U5)),
                GenericLocalMovement.U8 => new(new(GenericLocalMovement.D8), new(GenericLocalMovement.U), new(GenericLocalMovement.U8)),
                
                _                       => new(new(movement), new(movement), new(movement))
            };
        }
        
    }
    
    
}