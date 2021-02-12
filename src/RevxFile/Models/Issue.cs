﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Issue : EntityBase
    {
        [XmlElement]
        public string Description { get; set; }
    }
}
