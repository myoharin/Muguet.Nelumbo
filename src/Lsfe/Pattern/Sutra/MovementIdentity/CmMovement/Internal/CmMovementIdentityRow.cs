using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement.Internal
{
    internal struct CmMovementIdentityRow
    {
        public bool DefinedAntecedent;
        public bool DefinedConsequent;
        public BiDirectionalGlmPattern ThreadPattern;
        public LotusRole AntecedentRole;
        public LotusRole ConsequentRole;

        public CmMovementIdentityRow(
            GenericLocalMovement glm,
            LotusRole antecedentRole,
            LotusRole consequentRole,
            bool definedAntecedent,
            bool definedConsequent
        ) {
            AntecedentRole = antecedentRole;
            ConsequentRole = consequentRole;
            DefinedAntecedent = definedAntecedent;
            DefinedConsequent = definedConsequent;

            ThreadPattern = new BiDirectionalGlmPattern(glm);
        }
    }
}