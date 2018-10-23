﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniconGS.UI.Picon2.ModuleRequests.ModuleSpecification
{
    public class MSA962ModuleSpecification:IModuleSpecification
    {
        public string DeviceName
        {
            get { return "МСА962"; }
        }
        public byte ModuleType
        {
            get { return 0x05; }
        }
        public byte Command
        {
            get
            {
                return 0x20;
            }
        }
        public ushort ModuleParameterAddress
        {
            get
            {
                return 0x0000;
            }
        }
        public ushort FirstModuleDatabaseAddress
        {
            get
            {
                return 0x2000;
            }
        }
        public byte ParameterCount
        {
            get
            {
                return 0x0C;
            }
        }
        public MSA962ModuleSpecification()
        {

        }
    }
}
