using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWorkshop.Core.Exercise02SMS
{
    public interface IUserNamePasswordValidator
    {
        bool TryValidate(string username, string password, out User user);
    }
}
