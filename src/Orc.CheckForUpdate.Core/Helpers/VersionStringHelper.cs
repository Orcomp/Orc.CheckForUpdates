﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionStringHelper.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   The version string helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The version string helper.
    /// </summary>
    public static class VersionStringHelper
    {
        /// <summary>
        /// Checks whether provided string meets requirements to describe version number.
        /// </summary>
        /// <param name="versionNumber">
        /// The version number.
        /// </param>
        /// <returns>
        /// The version number validness.
        /// </returns>
        public static bool IsValidVersionString(string versionNumber)
        {
            string[] parts = versionNumber.Split('.');
            if (parts.Length != 4 && parts.Length != 3)
            {
                return false;
            }

            int i;
            return parts.All(part => int.TryParse(part, out i));
        }

        /// <summary>
        /// The try parse version string.
        /// </summary>
        /// <param name="versionNumber">
        /// The version number.
        /// </param>
        /// <param name="parts">
        /// All parsed parts .
        /// </param>
        /// <returns>
        /// True if string has been parsed successfully.
        /// </returns>
        public static bool TryParseVersionString(string versionNumber, out int[] parts)
        {
            parts = null;
            string[] stringParts = versionNumber.Split('.');

            if (stringParts.Length != 4 && stringParts.Length != 3)
            {
                return false;
            }

            try
            {
                parts = stringParts.Select(int.Parse).ToArray();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The version string comparer.
        /// </summary>
        public class VersionStringComparer : IComparer<string>
        {
            /// <summary>
            /// The compare.
            /// </summary>
            /// <param name="x">
            /// The number of first version as a string.
            /// </param>
            /// <param name="y">
            /// The number of second version as a string.
            /// </param>
            /// <returns>
            /// Result of comparison
            /// &gt;0 if x is bigger than y
            /// 0 if x is equal to
            /// less than 0 if x is less than y.
            /// </returns>
            public int Compare(string x, string y)
            {
                int[] xParts, yParts;
                if (!TryParseVersionString(x, out xParts))
                {
                    return 1;
                }

                if (!TryParseVersionString(y, out yParts))
                {
                    return -1;
                }

                for (int i = 0; i < 4; i++)
                {
                    int iX = i < xParts.Length ? xParts[i] : 0;
                    int iY = i < yParts.Length ? yParts[i] : 0;

                    if (iX != iY)
                    {
                        return (iX - iY);
                    }
                }

                return 0;
            }
        }
    }
}
