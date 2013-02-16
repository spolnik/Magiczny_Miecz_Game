using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Core;

namespace MagicznyMiecz.Engine.Data
{
    public class SimpleCharacterRepositoryInitializer : IRepositoryInitializer<ICharacter>
    {
        #region Implementation of IRepositoryInitializer

        public void Init(IEditableRepository<ICharacter> repository)
        {
            var newCharacter = Character.Create("Książe", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.GrodId],
                                                Nature.Chaotic, 4, 3);
            ((IEditableCharacter)newCharacter).AddGold(4);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Zdobywca", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.OsadaId], Nature.Chaotic,
                                            4, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Demon", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.CzarciMlynId], Nature.Bad,
                                            2, 4);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Mag", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.KragMocyId], Nature.Chaotic,
                                            2, 5);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Spryciarz", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.GrodId], Nature.Good, 4,
                                            3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Obbol", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.MokradlaId], Nature.Chaotic,
                                            2, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Olbrzym", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.StepId], Nature.Chaotic,
                                            4, 2);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Rycerz Ciemności", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.CzarciMlynId],
                                            Nature.Bad, 4, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Kapłan", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.KragMocyId],
                                            Nature.Chaotic, 2, 4);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Hummit", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.BezdrozaId], Nature.Good,
                                            2, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Troll", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.MroznePustkowieId],
                                            Nature.Chaotic, 6, 1);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Elf", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.UroczyskoId], Nature.Good, 3,
                                            4);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Awanturnik", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.KarczmaId],
                                            Nature.Chaotic, 3, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Pustelnik", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.UroczyskoId],
                                            Nature.Good, 2, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Łotr", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.KarczmaId], Nature.Bad, 5, 1);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Quark", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.MroznePustkowieId],
                                            Nature.Chaotic, 3, 3);
            repository.Add(newCharacter);

            newCharacter = Character.Create("Czarodziej", StandardBoardDefinition.InnerCircle[StandardBoardDefinition.StudiaWiecznosciId],
                                            Nature.Good, 4, 3);
            repository.Add(newCharacter);

            repository.Init();
        }

        #endregion
    }
}
