using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContatos.Test.Utils;
internal static class AssertExtensions
{
    internal static void WithMessage(this Exception ex, string message)
    {
        Assert.Equal(message, ex.Message);
    }
}
