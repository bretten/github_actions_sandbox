﻿using System.Text;

namespace buildAndTest.Lib2
{
    public class ConcatService
    {
        public string Concat(string a, string b)
        {
            return new StringBuilder(a)
                .Append(b)
                .ToString();
        }
    }
}