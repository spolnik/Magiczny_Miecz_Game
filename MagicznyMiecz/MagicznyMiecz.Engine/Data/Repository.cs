using System;
using System.Collections.Generic;
using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Engine.Data
{
    public abstract class Repository<TElement> : IRepository, IEditableRepository<TElement>, IDisplayElement<TElement> where TElement : INamedElement
    {
        protected readonly Dictionary<string, TElement> GameRepository;
        protected readonly Dictionary<string, TElement> OriginalRepository;

        protected Repository()
        {
            this.OriginalRepository = new Dictionary<string, TElement>();
            this.GameRepository = new Dictionary<string, TElement>();
        }

        #region IDisplayElement<TElement> Members

        public TElement this[string key]
        {
            get { return this.GameRepository[key]; }
        }

        #endregion

        #region IEditableRepository<TElement> Members

        public void Add(TElement card)
        {
            if (this.OriginalRepository.Keys.Contains(card.Name))
                throw new ApplicationException("You must specify unique name for any element.");

            this.OriginalRepository.Add(card.Name, card);
        }

        public void Init()
        {
            if (this.GameRepository.Count > 0)
                throw new ApplicationException("Repository is being initialized.");

            foreach (var element in this.OriginalRepository)
                this.GameRepository.Add(element.Key, element.Value);
        }

        #endregion

        #region IRepository Members

        public int Count
        {
            get { return this.GameRepository.Count; }
        }

        public List<string> Names
        {
            get { return this.GameRepository.Keys.ToList(); }
        }

        public abstract IPlayer Assign(IPlayer player, string name);

        public abstract IPlayer Detach(IPlayer player, string name);

        #endregion
    }
}
