using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement.Internal
{
    internal static class CmMovementInternalData
    {
        // * Internal Data
        internal static readonly Dictionary<CmMovementIdentityEnum, CmMovementIdentityCollumn> Evaluations;

        internal static readonly List<CmMovementIdentityRow> EvaluationRows = new() {
            new CmMovementIdentityRow(GenericLocalMovement.DL, LotusRole.ST, LotusRole.SD, false, false), // # 0
            new CmMovementIdentityRow(GenericLocalMovement.DL, LotusRole.ST, LotusRole.Sm3, false, true), // # 1
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.ST, LotusRole.Sm3, false, true),  // # 2
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.ST, LotusRole.SM3, false, true),  // # 3
            new CmMovementIdentityRow(GenericLocalMovement.UL, LotusRole.ST, LotusRole.SM3, false, true), // # 4
            new CmMovementIdentityRow(GenericLocalMovement.U5, LotusRole.ST, LotusRole.Sm3, false, true), // # 5
            new CmMovementIdentityRow(GenericLocalMovement.U5, LotusRole.ST, LotusRole.SM3, false, true), // # 6
            new CmMovementIdentityRow(GenericLocalMovement.D5, LotusRole.SD, LotusRole.Sm3, false, true), // # 7
            new CmMovementIdentityRow(GenericLocalMovement.D5, LotusRole.SD, LotusRole.SM3, false, true), // # 8
            new CmMovementIdentityRow(GenericLocalMovement.DL, LotusRole.SD, LotusRole.Sm3, false, true), // # 9
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.SD, LotusRole.Sm3, false, true),  // # 10
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.SD, LotusRole.SM3, false, true),  // # 11
            new CmMovementIdentityRow(GenericLocalMovement.UL, LotusRole.SD, LotusRole.SM3, false, true), // # 12
            new CmMovementIdentityRow(GenericLocalMovement.UL, LotusRole.SD, LotusRole.ST, false, false), // # 13
            new CmMovementIdentityRow(GenericLocalMovement.D5, LotusRole.Sm3, LotusRole.ST, true, false), // # 14
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.Sm3, LotusRole.ST, true, false),  // # 15
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.Sm3, LotusRole.SD, true, false),  // # 16
            new CmMovementIdentityRow(GenericLocalMovement.UL, LotusRole.Sm3, LotusRole.ST, true, false), // # 17
            new CmMovementIdentityRow(GenericLocalMovement.UL, LotusRole.Sm3, LotusRole.SD, true, false), // # 18
            new CmMovementIdentityRow(GenericLocalMovement.U4, LotusRole.Sm3, LotusRole.SM3, true, true), // # 19
            new CmMovementIdentityRow(GenericLocalMovement.U5, LotusRole.Sm3, LotusRole.SD, true, false), // # 20
            new CmMovementIdentityRow(GenericLocalMovement.D5, LotusRole.SM3, LotusRole.ST, true, false), // # 21
            new CmMovementIdentityRow(GenericLocalMovement.D4, LotusRole.SM3, LotusRole.Sm3, true, true), // # 22
            new CmMovementIdentityRow(GenericLocalMovement.DL, LotusRole.SM3, LotusRole.ST, true, false), // # 23
            new CmMovementIdentityRow(GenericLocalMovement.DL, LotusRole.SM3, LotusRole.SD, true, false), // # 24
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.SM3, LotusRole.ST, true, false),  // # 25
            new CmMovementIdentityRow(GenericLocalMovement.U, LotusRole.SM3, LotusRole.SD, true, false),  // # 26
            new CmMovementIdentityRow(GenericLocalMovement.U5, LotusRole.SM3, LotusRole.SD, true, false)  // # 27
        };

        static CmMovementInternalData() {
            var e = EvaluationRows;

            Evaluations = new Dictionary<CmMovementIdentityEnum, CmMovementIdentityCollumn> {
                {
                    CmMovementIdentityEnum.mDm3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[2], e[7], e[18]
                    })
                }, {
                    CmMovementIdentityEnum.mDM3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[1], e[13], e[14], e[16]
                    })
                }, {
                    CmMovementIdentityEnum.mUm3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[9], e[15], e[20]
                    })
                }, {
                    CmMovementIdentityEnum.mUM3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[0], e[5], e[10], e[17]
                    })
                }, {
                    CmMovementIdentityEnum.mDm3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[4], e[18]
                    })
                }, {
                    CmMovementIdentityEnum.mDM3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[3], e[8], e[13], e[14], e[16]
                    })
                }, {
                    CmMovementIdentityEnum.mUm3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[6], e[11], e[15], e[20]
                    })
                }, {
                    CmMovementIdentityEnum.mUM3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[0], e[12], e[17], e[19]
                    })
                }, {
                    CmMovementIdentityEnum.MDm3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[2], e[7], e[21], e[26]
                    })
                }, {
                    CmMovementIdentityEnum.MDM3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[1], e[13], e[22], e[24]
                    })
                }, {
                    CmMovementIdentityEnum.MUm3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[9], e[23]
                    })
                }, {
                    CmMovementIdentityEnum.MUM3m, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[0], e[5], e[10], e[25], e[27]
                    })
                }, {
                    CmMovementIdentityEnum.MDm3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[4], e[21], e[26]
                    })
                }, {
                    CmMovementIdentityEnum.MDM3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[3], e[8], e[13], e[24]
                    })
                }, {
                    CmMovementIdentityEnum.MUm3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[6], e[11], e[23]
                    })
                }, {
                    CmMovementIdentityEnum.MUM3M, new CmMovementIdentityCollumn(new List<CmMovementIdentityRow> {
                        e[0], e[12], e[25], e[27]
                    })
                }
            };
        }
    }
}