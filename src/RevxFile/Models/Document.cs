﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LightningReview.RevxFile.Models
{
    [XmlRoot]
    public class Document : EntityBase
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public OutlineTree OutlineTree { get; set; } = new OutlineTree();

    }
}
