using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Filtr
{
    public class DisableBasicAuthorization: Attribute, IFilterMetadata
    {
    }
}
