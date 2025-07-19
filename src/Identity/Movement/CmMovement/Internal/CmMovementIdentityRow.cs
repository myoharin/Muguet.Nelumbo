using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement.Internal
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
        ) 
        {
            this.AntecedentRole = antecedentRole;
            this.ConsequentRole = consequentRole;
            this.DefinedAntecedent = definedAntecedent;
            this.DefinedConsequent = definedConsequent;
            
            ThreadPattern = new BiDirectionalGlmPattern(glm);
        }
    }

}