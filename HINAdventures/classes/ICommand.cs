using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HINAdventures.classes
{
    public interface ICommand
    {
        string RunCommand(String argument);
    }
}
