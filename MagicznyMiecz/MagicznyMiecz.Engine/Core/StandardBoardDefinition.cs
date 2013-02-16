using System.Collections.Generic;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core.Commands;

namespace MagicznyMiecz.Engine.Core
{
    public static class StandardBoardDefinition
    {
        static StandardBoardDefinition()
        {
            InitInnerCircle();
            InitMiddleCircle();
            InitOuterCircle();
        }

        private static void InitOuterCircle()
        {
            OuterCircle.Add(StandardPosition.New(OuterCircle, RowninaSnuId, BoardState.Cards, 1));
            OuterCircle.Add(StandardPosition.New(OuterCircle, KryptaUpiorowId, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, BagnaId, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, RuchomeSkalyId, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, WymarleMiastoId, BoardState.CardsOrSpecial, 1));
            OuterCircle.Add(StandardPosition.New(OuterCircle, ZamekId, BoardState.Special, 0, null, true));
            OuterCircle.Add(StandardPosition.New(OuterCircle, RozstajneDrogiId, BoardState.Cards, 1));
            OuterCircle.Add(StandardPosition.New(OuterCircle, RowninaTrawId, BoardState.Cards, 1));
            OuterCircle.Add(StandardPosition.New(OuterCircle, UrwiskoId, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, RuchomeSkaly2Id, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, Bagna2Id, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, DolinaCzaszekId, BoardState.CardsOrSpecial, 1));
            OuterCircle.Add(StandardPosition.New(OuterCircle, SwiatyniaTolimanaId, BoardState.Special, 0, null, true));
            OuterCircle.Add(StandardPosition.New(OuterCircle, RuinyTwierdzyId, BoardState.CardsOrSpecial, 1));
            OuterCircle.Add(StandardPosition.New(OuterCircle, Urwisko2Id, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, WilczyParowId, BoardState.Special, 0));
            OuterCircle.Add(StandardPosition.New(OuterCircle, KamiennyLasId, BoardState.Cards, 2));
            OuterCircle.Add(StandardPosition.New(OuterCircle, RozstajneDrogi2Id, BoardState.Cards, 1));
        }

        private static void InitMiddleCircle()
        {
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, LasBlednychOgniId, BoardState.CardsOrSpecial, 1,
                                                     new LasBlednychOgniCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, ZaczarowaneWzgorzaId, BoardState.Cards, 1));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, SwiatyniaBoginiNemedId, BoardState.Special, 0,
                                                     new SwiatyniaBoginiNemedCommand(), true));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, PlaskowyzMgielId, BoardState.Cards, 3));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, MagiczneWrotaId, BoardState.Special, 0, new MagiczneWrotaCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, StraznikMagicznychWrotId, BoardState.Special, 0,
                                                     new StraznikMagicznychWrotCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, WiezaPrzeznaczeniaId, BoardState.Special, 0,
                                                     new WiezaPrzeznaczeniaCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, WrzosowiskaId, BoardState.Cards, 2));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, DolinaCieniaId, BoardState.Cards, 1));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, PrzeprawaId, BoardState.Special, 0, new PrzeprawaCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, PrzeleczWichrowId, BoardState.CardsOrSpecial, 1, new PrzeleczWichrowCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, TwierdzaStrzegacaDrogId, BoardState.Special, 0,
                                                     new TwierdzaStrzegacaDrogCommand(), true));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, MrocznaPolanaId, BoardState.Cards, 1));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, Przeprawa2Id, BoardState.Special, 0, new PrzeprawaCommand()));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, RowninaSamotnychSkalId, BoardState.Cards, 2));
            MiddleCircle.Add(StandardPosition.New(MiddleCircle, PustelniaId, BoardState.Special, 0, new PustelniaCommand(), true));
        }

        private static void InitInnerCircle()
        {
            InnerCircle.Add(StandardPosition.New(InnerCircle, StepId, BoardState.Cards, 1));
            InnerCircle.Add(StandardPosition.New(InnerCircle, UroczyskoId, BoardState.CardsOrSpecial, 1, new UroczyskoCommand(), true));
            InnerCircle.Add(StandardPosition.New(InnerCircle, KarczmaId, BoardState.Special, 0, new KarczmaCommand()));
            InnerCircle.Add(StandardPosition.New(InnerCircle, MroznePustkowieId, BoardState.Cards, 1));
            InnerCircle.Add(StandardPosition.New(InnerCircle, GrodId, BoardState.Special, 0, new GrodCommand(), true));
            InnerCircle.Add(StandardPosition.New(InnerCircle, BezdrozaId, BoardState.Cards, 2));
            InnerCircle.Add(StandardPosition.New(InnerCircle, StudiaWiecznosciId, BoardState.Special, 0, new StudniaWiecznosciCommand(),
                                                    true));
            InnerCircle.Add(StandardPosition.New(InnerCircle, KragMocyId, BoardState.Special, 0, new KragMocyCommand()));
            InnerCircle.Add(StandardPosition.New(InnerCircle, CzarciMlynId, BoardState.Special, 0, new CzarciMlynCommand()));
            InnerCircle.Add(StandardPosition.New(InnerCircle, MokradlaId, BoardState.Cards, 1));
            InnerCircle.Add(StandardPosition.New(InnerCircle, Step2Id, BoardState.Cards, 1));
            InnerCircle.Add(StandardPosition.New(InnerCircle, OsadaId, BoardState.Special, 0, new OsadaCommand(), true));
            InnerCircle.Add(StandardPosition.New(InnerCircle, KurhanId, BoardState.Special, 0, new KurhanCommand()));
            InnerCircle.Add(StandardPosition.New(InnerCircle, Mokradla2Id, BoardState.Cards, 1));
        }

        internal static readonly int StepId = 0;
        internal static readonly int UroczyskoId = 1;
        internal static readonly int KarczmaId = 2;
        internal static readonly int MroznePustkowieId = 3;
        internal static readonly int GrodId = 4;
        internal static readonly int BezdrozaId = 5;
        internal static readonly int StudiaWiecznosciId = 6;
        internal static readonly int KragMocyId = 7;
        internal static readonly int CzarciMlynId = 8;
        internal static readonly int MokradlaId = 9;
        internal static readonly int Step2Id = 10;
        internal static readonly int OsadaId = 11;
        internal static readonly int KurhanId = 12;
        internal static readonly int Mokradla2Id = 13;

        internal static readonly Dictionary<int, string> InnerCircleNames = new Dictionary<int, string>
                                                                          {
                                                                              {StepId, "Step"},
                                                                              {UroczyskoId, "Uroczysko"},
                                                                              {KarczmaId, "Karczma"},
                                                                              {MroznePustkowieId, "Mroźne Pustkowie"},
                                                                              {GrodId, "Gród"},
                                                                              {BezdrozaId, "Bezdroża"},
                                                                              {StudiaWiecznosciId,"Studnia Wiecznośći"},
                                                                              {KragMocyId, "Krąg Mocy"},
                                                                              {CzarciMlynId, "Czarci Młyn"},
                                                                              {MokradlaId, "Mokradła"},
                                                                              {Step2Id, "Step 2"},
                                                                              {OsadaId, "Osada"},
                                                                              {KurhanId, "Kurhan"},
                                                                              {Mokradla2Id, "Mokradła 2"}
                                                                          };

        public static readonly List<IPosition> InnerCircle = new List<IPosition>();

        internal static readonly int LasBlednychOgniId = 0;
        internal static readonly int ZaczarowaneWzgorzaId = 1;
        internal static readonly int SwiatyniaBoginiNemedId = 2;
        internal static readonly int PlaskowyzMgielId = 3;
        internal static readonly int MagiczneWrotaId = 4;
        internal static readonly int StraznikMagicznychWrotId = 5;
        internal static readonly int WiezaPrzeznaczeniaId = 6;
        internal static readonly int WrzosowiskaId = 7;
        internal static readonly int DolinaCieniaId = 8;
        internal static readonly int PrzeprawaId = 9;
        internal static readonly int PrzeleczWichrowId = 10;
        internal static readonly int TwierdzaStrzegacaDrogId = 11;
        internal static readonly int MrocznaPolanaId = 12;
        internal static readonly int Przeprawa2Id = 13;
        internal static readonly int RowninaSamotnychSkalId = 14;
        internal static readonly int PustelniaId = 15;

        internal static readonly Dictionary<int, string> MiddleCircleNames = new Dictionary<int, string>
                                                                          {
                                                                              {LasBlednychOgniId, "Las Błędnych Ogni"},
                                                                              {ZaczarowaneWzgorzaId, "Zaczarowane Wzgórza"},
                                                                              {SwiatyniaBoginiNemedId, "Świątynia Bogini Nemed"},
                                                                              {PlaskowyzMgielId, "Płaskowyż Mgieł"},
                                                                              {MagiczneWrotaId, "Magiczne Wrota"},
                                                                              {StraznikMagicznychWrotId, "Strażnik Magicznych Wrót"},
                                                                              {WiezaPrzeznaczeniaId, "Wieża Przeznaczenia"},
                                                                              {WrzosowiskaId, "Wrzosowiska"},
                                                                              {DolinaCieniaId, "Dolina Cienia"},
                                                                              {PrzeprawaId, "Przeprawa"},
                                                                              {PrzeleczWichrowId, "Przełęcz Wichrów"},
                                                                              {TwierdzaStrzegacaDrogId, "Twierdza Strzegąca Dróg"},
                                                                              {MrocznaPolanaId, "Mroczna Polana"},
                                                                              {Przeprawa2Id, "Przeprawa 2"},
                                                                              {RowninaSamotnychSkalId, "Równina Samotnych Skał"},
                                                                              {PustelniaId, "Pustelnia"},
                                                                          };


        public static readonly List<IPosition> MiddleCircle = new List<IPosition>();

        internal static readonly int RowninaSnuId = 0;
        internal static readonly int KryptaUpiorowId = 1;
        internal static readonly int BagnaId = 2;
        internal static readonly int RuchomeSkalyId = 3;
        internal static readonly int WymarleMiastoId = 4;
        internal static readonly int ZamekId = 5;
        internal static readonly int RozstajneDrogiId = 6;
        internal static readonly int RowninaTrawId = 7;
        internal static readonly int UrwiskoId = 8;
        internal static readonly int RuchomeSkaly2Id = 9;
        internal static readonly int Bagna2Id = 10;
        internal static readonly int DolinaCzaszekId = 11;
        internal static readonly int SwiatyniaTolimanaId = 12;
        internal static readonly int RuinyTwierdzyId = 13;
        internal static readonly int Urwisko2Id = 14;
        internal static readonly int WilczyParowId = 15;
        internal static readonly int KamiennyLasId = 16;
        internal static readonly int RozstajneDrogi2Id = 17;

        internal static readonly Dictionary<int, string> OuterCircleNames = new Dictionary<int, string>
                                                                          {
                                                                              {RowninaSnuId, "Równina Snu"},
                                                                              {KryptaUpiorowId, "Krypta Upiorów"},
                                                                              {BagnaId, "Bagna"},
                                                                              {RuchomeSkalyId, "Ruchome Skały"},
                                                                              {WymarleMiastoId, "Wymarłe Miasto"},
                                                                              {ZamekId, "Zamek"},
                                                                              {RozstajneDrogiId, "Rozstajne Drogi"},
                                                                              {RowninaTrawId, "Równina Traw"},
                                                                              {UrwiskoId, "Urwisko"},
                                                                              {RuchomeSkaly2Id, "Ruchome Skały 2"},
                                                                              {Bagna2Id, "Bagna 2"},
                                                                              {DolinaCzaszekId, "Dolina Czaszek"},
                                                                              {SwiatyniaTolimanaId, "Świątynia Tolimana"},
                                                                              {RuinyTwierdzyId, "Ruiny Twierdzy"},
                                                                              {Urwisko2Id, "Urwisko 2"},
                                                                              {WilczyParowId, "Wilczy Parów"},
                                                                              {KamiennyLasId, "Kamienny Las"},
                                                                              {RozstajneDrogi2Id, "Rozstajne Drogi 2"},
                                                                          };


        public static readonly List<IPosition> OuterCircle = new List<IPosition>();
    }
}