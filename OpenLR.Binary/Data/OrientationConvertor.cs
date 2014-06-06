﻿using OpenLR.Model;
using System;

namespace OpenLR.Binary.Data
{
    /// <summary>
    /// Represents a orientation convertor that encodes/decodes orientation info into the binary OpenLR format.
    /// </summary>
    public static class OrientationConverter
    {
        /// <summary>
        /// Decodes binary OpenLR orientation data into an orientation.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteIndex"></param>
        /// <returns></returns>
        public static Orientation Decode(byte[] data, int byteIndex)
        {
            return OrientationConverter.Decode(data, 0, byteIndex);
        }

        /// <summary>
        /// Decodes binary OpenLR orientation data into an orientation.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <param name="byteIndex"></param>
        /// <returns></returns>
        public static Orientation Decode(byte[] data, int startIndex, int byteIndex)
        {
            if (byteIndex > 6) { throw new ArgumentOutOfRangeException("byteIndex", "byteIndex has to be a value in the range of [0-6]."); }

            byte classData = data[startIndex];

            // create mask.
            int mask = 7 << (6 - byteIndex);
            int value = (classData & mask) >> (6 - byteIndex);

            switch(value)
            {
                case 0:
                    return Orientation.NoOrientation;
                case 1:
                    return Orientation.FirstToSecond;
                case 2:
                    return Orientation.SecondToFirst;
                case 3:
                    return Orientation.BothDirections;
            }
            throw new InvalidOperationException("Decoded a value from three bits not in the range of [0-3]?!");
        }

        /// <summary>
        /// Encodes an OpenLR orientation into a binary representation.
        /// </summary>
        /// <param name="orientation"></param>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <param name="byteIndex"></param>
        public static void Encode(Orientation orientation, byte[] data, int startIndex, int byteIndex)
        {
            if (byteIndex > 6) { throw new ArgumentOutOfRangeException("byteIndex", "byteIndex has to be a value in the range of [0-6]."); }

            int value = 0;
            switch (orientation)
            {
                case Orientation.NoOrientation:
                    value = 0;
                    break;
                case Orientation.FirstToSecond:
                    value = 1;
                    break;
                case Orientation.SecondToFirst:
                    value = 2;
                    break;
                case Orientation.BothDirections:
                    value = 3;
                    break;
            }

            data[startIndex] = (byte)(value << (6 - byteIndex));
        }
    }
}