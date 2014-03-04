﻿using OpenLR.Model;
using System;

namespace OpenLR.Binary.Data
{
    /// <summary>
    /// Represents a form of way convertor that encodes/decodes into the binary OpenLR format.
    /// </summary>
    public static class FormOfWayConvertor
    {
        /// <summary>
        /// Decodes a form of way type from binary data.
        /// </summary>
        /// <param name="data">The binary data.</param>
        /// <param name="byteIndex">The index of the data in the first byte.</param>
        /// <returns></returns>
        public static FormOfWay Decode(byte[] data, int byteIndex)
        {
            return FormOfWayConvertor.Decode(data, 0, byteIndex);
        }

        /// <summary>
        /// Decodes a form of way type from binary data.
        /// </summary>
        /// <param name="data">The binary data.</param>
        /// <param name="startIndex">The index of the byte in data.</param>
        /// <param name="byteIndex">The index of the data in the given byte.</param>
        public static FormOfWay Decode(byte[] data, int startIndex, int byteIndex)
        {
            if (byteIndex > 5) { throw new ArgumentOutOfRangeException("byteIndex", "byteIndex has to be a value in the range of [0-5]."); }

            byte classData = data[startIndex];

            // create mask.
            int mask = 7 << (5 - byteIndex);
            int value = (classData & mask) >> (5 - byteIndex);

            switch(value)
            {
                case 0:
                    return FormOfWay.Undefined;
                case 1:
                    return FormOfWay.Motorway;
                case 2:
                    return FormOfWay.MultipleCarriageWay;
                case 3:
                    return FormOfWay.SingleCarriageWay;
                case 4:
                    return FormOfWay.Roundabout;
                case 5:
                    return FormOfWay.TrafficSquare;
                case 6:
                    return FormOfWay.SlipRoad;
                case 7:
                    return FormOfWay.Other;
            }
            throw new InvalidOperationException("Decoded a value from three bits not in the range of [0-7]?!");
        }
    }
}