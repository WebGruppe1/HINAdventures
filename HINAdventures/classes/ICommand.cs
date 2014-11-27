using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HINAdventures.classes
{
    /// <summary>
    /// ICommand.cs
    /// 
    /// interface som blir arvet fra kommandoer. Siden det er flere kommandoer som gjør 
    /// samme ting, men returnerer forskjellig. (Factory Pattern)
    /// </summary>
    public interface ICommand
    {
        string RunCommand(String argument);
    }
}
