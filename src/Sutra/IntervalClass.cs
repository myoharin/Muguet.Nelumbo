namespace SineVita.Muguet.Nelumbo {
    public enum IntervalClass {
        Shimmer = 0, S = 0, s = 0, // 30
        Limma = 1, L = 1, l = 1,// 100
        
        Subminor2nd = 2, sm2 = 2, d2 = 2, // 50
        Minor2nd = 3, // 100
        Neutral2nd = 4, // 150
        Major2nd = 5, // 200
        Supermajor2nd = 6, SM2 = 6, A2 = 6,// 250

        Subminor3rd = 7, sm3 = 7, d3 = 7, // 250
        Minor3rd = 8, // 300
        Neutral3rd = 9, // 350
        Major3rd = 10, // 400
        Supermajor3rd = 11, SM3 = 11, A3 = 11, // 450

        Subminor4th = 12, sm4 = 12, d4 = 12, // 450
        Minor4th = 13, // 475
        Perfect4th = 14, // 500
        Major4th = 15, // 550
        Supermajor4th = 16, SM4 = 16, A4 = 16, // 750

        SubminorTritone = 17, smT = 17, dT = 17,  // 585
        MinorTritone = 18, // 585
        Tritone = 19, // 600
        MajorTritone = 20, // 615
        SupermajorTritone = 21, SMT = 21, AT = 21, // 615

        Subminor5th = 22, sm5 = 22, d5 = 22, // 625
        Minor5th = 23, // 650
        Perfect5th = 24, // 700
        Major5th = 25, // 725
        Supermajor5th = 26, SM5 = 26, A5 = 26, // 750

        Subminor6th = 27, sm6 = 27, d6 = 27, // 750
        Minor6th = 28, // 800
        Neutral6th = 29, // 850
        Major6th = 30, // 900
        Supermajor6th = 31, SM6 = 31, A6 = 31, // 950

        Subminor7th = 32, sm7 = 32, d7 = 32, // 950
        Minor7th = 33, // 1000
        Neutral7th = 34, // 1050
        Major7th = 35, // 1100
        Supermajor7th = 36, SM7 = 36, A7 = 36, // 1150

        Octave = 37 // 1200
    }
}