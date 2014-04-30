﻿using OpenLR.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLR.Decoding
{
    /// <summary>
    /// Abstract representation of a decoder.
    /// </summary>
    public abstract class Decoder
    {
        /// <summary>
        /// Decodes a byte array into a location reference.
        /// </summary>
        /// <returns></returns>
        public abstract ILocation Decode(string data);
    }
}