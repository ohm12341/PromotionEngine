using System;
using System.Collections.Generic;
using System.Text;

namespace PE.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
