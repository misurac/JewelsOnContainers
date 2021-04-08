using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WebMvc1.Models;

namespace WebMvc1.Services
{
    public interface IIdentityService<T>
    {
        T Get(IPrincipal principal);
    }
}
