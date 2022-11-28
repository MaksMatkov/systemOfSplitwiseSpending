using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.CustomExceptions
{
    public class EntityNotFoundException : Exception
    {
        public int _entityKey { get; set; }
        public EntityNotFoundException(string message, int entityKey)
            : base(message)
        {
            this._entityKey = entityKey;
        }
    }
}
