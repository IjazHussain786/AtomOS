﻿/*
* PROJECT:          Atomix Development
* LICENSE:          Copyright (C) Atomix Development, Inc - All Rights Reserved
*                   Unauthorized copying of this file, via any medium is
*                   strictly prohibited Proprietary and confidential.
* PURPOSE:          cmpss x86 instruction
* PROGRAMMERS:      Aman Priyadarshi (aman.eureka@gmail.com)
*/

using System.IO;

namespace Atomix.Assembler.x86
{
    public class Cmpss : DestinationSource
    {
        public ComparePseudoOpcodes PseudoCode { get; set; }

        public Cmpss()
            : base("cmpss") { }

        public override void FlushText(StreamWriter aSW)
        {
            string des = DestinationReg.HasValue ? DestinationReg.ToString() : DestinationRef;
            string src = SourceReg.HasValue ? SourceReg.ToString() : SourceRef;

            if (DestinationDisplacement > 0)
                des = des + " + 0x" + ((uint)DestinationDisplacement).ToString("X");
            else if (DestinationDisplacement < 0)
                des = des + " - 0x" + ((int)(-1 * DestinationDisplacement)).ToString("X");

            if (SourceDisplacement > 0)
                src = src + " + 0x" + ((uint)SourceDisplacement).ToString("X");
            else if (SourceDisplacement < 0)
                src = src + " - 0x" + ((int)(-1 * SourceDisplacement)).ToString("X");

            if (DestinationIndirect)
                des = "[" + des + "]";

            if (SourceIndirect)
                src = "[" + src + "]";

            aSW.WriteLine(string.Format("{0} {1}, {2}, 0x{3}", Code, des, src, ((byte)PseudoCode).ToString("X")));
        }
    }
}
