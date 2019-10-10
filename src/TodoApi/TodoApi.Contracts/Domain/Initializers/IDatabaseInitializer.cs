using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Contracts.Domain.Initializers
{
    public interface IDatabaseInitializer
    {
        void Initialize();
    }
}
