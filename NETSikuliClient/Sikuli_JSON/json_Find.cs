﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETSikuliClient.Sikuli_JSON
{
    public class json_Find
    {
        public json_Pattern jPattern { get; set; }
        public bool highlight { get; set; }

        public json_Find(json_Pattern pattrn, bool hghlght = false)
        {
            jPattern = pattrn;
            highlight = hghlght;
        }
    }
}
