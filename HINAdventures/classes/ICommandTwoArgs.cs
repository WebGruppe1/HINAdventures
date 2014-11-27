using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HINAdventures.classes
{
    /// <summary>
    /// ICommandTwoArgs.cs
    /// 
    /// interface som blir arvet fra kommandoer. Siden det er flere kommandoer som gjør 
    /// samme ting, men returnerer forskjellig. (Factory Pattern)
    /// </summary>
    interface ICommandTwoArgs
    {
        string RunCommand(string arg, string id);
    }
}
