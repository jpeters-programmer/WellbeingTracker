using System;

namespace Model
{
    public abstract class InitGuid : IGuid
    {
        public Guid Id {get;set;}

        protected InitGuid()
        {
            Id = Guid.NewGuid();
        }
    }
}