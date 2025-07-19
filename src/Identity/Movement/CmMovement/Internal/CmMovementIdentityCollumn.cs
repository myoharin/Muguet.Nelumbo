using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement.Internal
{
    internal class CmMovementIdentityCollumn :
        ILsfePattern<LotusThread>,
        ILsfePatternContainer<LotusStrand>
    {
        public List<CmMovementIdentityRow> Rows { get; init; }

        public CmMovementIdentityCollumn(List<CmMovementIdentityRow> rows) {
            Rows = rows;
        }

        public bool MatchesExact(ILsfeParsable<LotusThread> thread) { // KEY
            var threadObj = thread.Get();
            var definedAntecedent = false;
            var definedConsequent = false;
            foreach (var row in Rows) {
                if (
                    threadObj.Antecedant.Roles.Contains(row.AntecedentRole)
                    && threadObj.Consequent.Roles.Contains(row.ConsequentRole)
                    && row.ThreadPattern.MatchContains(threadObj.Movement)
                ) {
                    definedAntecedent = definedAntecedent || row.DefinedAntecedent;
                    definedConsequent = definedConsequent || row.DefinedConsequent;
                }

                if (definedAntecedent && definedConsequent) return true;
            }
            return false;
        }

        public bool MatchesExact(ILsfeParsable<LotusStrand> strand) => false;
        public bool MatchContains(ILsfeParsable<LotusStrand> strand) { // Test
            var strandObj = strand.Get();
            foreach (var row in Rows) {
                if (
                    strandObj.AntecedantRole == row.AntecedentRole
                    && strandObj.ConsequentRole == row.ConsequentRole
                    && row.ThreadPattern.MatchContains(strandObj.Movement)
                ) return true;
            }

            return false;
        }

        public object Clone() => new CmMovementIdentityCollumn(new(Rows));
        
    }

}