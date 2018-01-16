﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class ConsoleReaderAndWriter : IReader, IWriter
    {
        public string Reader()
        {
            return Console.ReadLine();
        }

        public void LineWriter(string output)
        {
            Console.WriteLine(output);
        }
    }
}
