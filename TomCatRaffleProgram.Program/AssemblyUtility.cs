using System.Reflection;

namespace TomCatRaffleProgram.Program
{
    public static class AssemblyUtility
    {
        public static Assembly GetAssembly()
            => typeof(AssemblyUtility).Assembly;
    }
}
