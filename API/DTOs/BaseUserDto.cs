using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.DTOs
{
    public class BaseUserDto : IdentityUser<int>
    {
        
    }
}