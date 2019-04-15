using SolarWinds.InformationService.Contract2;
using System;

namespace Playground
{
    static class Program
    {
        static void Main(string[] args)
        {
            var proxy = new InfoServiceProxy(new Uri(""));
        }
    }
}
