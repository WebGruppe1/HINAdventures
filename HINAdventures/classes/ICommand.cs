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
    /// interface which is inherited from commands. Since there are several commands doing
    /// the Same thing, but returns different answer. (Factory Pattern)
    /// </summary>
    public interface ICommand
    {
        string RunCommand(String argument);
    }
}
