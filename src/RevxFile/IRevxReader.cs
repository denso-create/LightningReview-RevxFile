﻿using LightningReview.RevxFile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightningReview.RevxFile
{
    interface IRevxReader
    {
        Review Read(string filepath);
    }
}
