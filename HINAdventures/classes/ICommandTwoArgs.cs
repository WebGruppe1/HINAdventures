using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HINAdventures.classes
{
    interface ICommandTwoArgs
    {
        string RunCommand(string arg, string id);
    }
}
