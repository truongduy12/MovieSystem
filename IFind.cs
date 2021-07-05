using System;
using System.Collections.Generic;

namespace AS
{
    public interface IFind
    {
        List<IMovie> Find(string key, List<IMovie> list);
    }
}