﻿using System.Reflection;

namespace CleanArchitecture.API
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly; 
    }
}
