
//Copyright 1997-2009 Syrinx Development, Inc.
//This file is part of the Syrinx Web Application Framework (SWAF).
// == BEGIN LICENSE ==
//
// Licensed under the terms of any of the following licenses at your
// choice:
//
//  - GNU General Public License Version 3 or later (the "GPL")
//    http://www.gnu.org/licenses/gpl.html
//
//  - GNU Lesser General Public License Version 3 or later (the "LGPL")
//    http://www.gnu.org/licenses/lgpl.html
//
//  - Mozilla Public License Version 1.1 or later (the "MPL")
//    http://www.mozilla.org/MPL/MPL-1.1.html
//
// == END LICENSE ==
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace ProjectLab.Helpers
{
    /// <summary>
    /// Used to create unique passwords that conform to a client's password policy, and validate
    ///those passwords against a regex also built from the password policy.
    /// </summary>
    public class RandomStringGenerator
    {
        private int m_minSize = 6; // minimum password length
        private int m_maxSize = 15; // maximum password length
        private string m_exclusionSet = "^&*("; // characters not to include in the output
        private bool m_requireNonAlpha = true; // require non alpha

        private const int UBoundDigit = 61;
        private RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); // random generator.  Use this because System.Random uses a linear algorithm.


        private char[] pwdCharArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // char array
        private char[] pwdCharNonAlphaArray = "~!@//#$%)-_=+[]{}\\|;:'\",<.>/?".ToCharArray(); // non numeric char array
        private char[] pwdNumericArray = "0123456789".ToCharArray(); // numeric array
        private char[] pwdMultiNumericArray = "121211221122111222".ToCharArray();

        // set the state to the defaults
        public RandomStringGenerator()
        {
        }

        public RandomStringGenerator(int minLength, int maxLength, string excludeSet, bool requireNonAlpha)
        {
            m_minSize = minLength;
            m_maxSize = maxLength;
            Exclusions = excludeSet;
            m_requireNonAlpha = requireNonAlpha;
        }

        /// <summary>
        /// Gets a random number
        /// </summary>
        /// <param name="lBound">Lower bound</param>
        /// <param name="uBound">Upper bound</param>
        /// <returns>A random integer between lBound and uBound</returns>
        private int getCryptographicRandomNumber(int lBound, int uBound)
        {
            // Assumes lBound >= 0 && lBound < uBound
            // returns an int >= lBound and < uBound
            uint urndnum;
            byte[] rndnum = new Byte[4];
            if (lBound == uBound - 1)
            {
                // test for degenerate case where only lBound can be returned
                return lBound;
            }

            uint xcludeRndBase = (uint.MaxValue -
                (uint.MaxValue % (uint)(uBound - lBound)));

            do
            {
                rng.GetBytes(rndnum);
                urndnum = System.BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);

            return (int)(urndnum % (uBound - lBound)) + lBound;
        }

        /// <summary>
        /// Converts the first char to a random number
        /// </summary>
        private bool changeFirstCHARtoNumeric()
        {
            int upperBound = pwdMultiNumericArray.GetUpperBound(0);
            int randomCharPosition;
            char randomChar;

            randomCharPosition = getCryptographicRandomNumber(
                pwdMultiNumericArray.GetLowerBound(0), upperBound);

            randomChar = pwdMultiNumericArray[randomCharPosition];

            if (randomChar.ToString() == "1")
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Returns a random character
        /// </summary>
        /// <returns>A random character</returns>
        private char getRandomNumericCharacter()
        {
            int upperBound = pwdNumericArray.GetUpperBound(0);
            int randomCharPosition;
            char randomChar;
            bool FoundinExclusions = false;
            bool NonAlphaFound = false;

            do
            {
                randomCharPosition = getCryptographicRandomNumber(
                    pwdNumericArray.GetLowerBound(0), upperBound);

                randomChar = pwdNumericArray[randomCharPosition];
                foreach (char chr in m_exclusionSet)
                    if (randomChar == chr)
                        FoundinExclusions = true;
                if (!FoundinExclusions)
                    NonAlphaFound = true;

            }
            while (!NonAlphaFound);
            return randomChar;

        }

        /// <summary>
        /// Returns a random non-alpha character
        /// </summary>
        /// <returns>A random non-alpha character</returns>
        private char getRandomNonAlphaCharacter()
        {
            int upperBound = pwdCharNonAlphaArray.GetUpperBound(0);
            int randomCharPosition;
            char randomChar;
            bool FoundinExclusions = false;
            bool NonAlphaFound = false;

            do
            {

                randomCharPosition = getCryptographicRandomNumber(
                    pwdCharNonAlphaArray.GetLowerBound(0), upperBound);

                randomChar = pwdCharNonAlphaArray[randomCharPosition];
                foreach (char chr in m_exclusionSet)
                {
                    if (randomChar == chr)
                    {
                        FoundinExclusions = true;
                    }
                }
                if (!FoundinExclusions)
                {
                    NonAlphaFound = true;
                }
            }
            while (!NonAlphaFound);
            return randomChar;

        }

        /// <summary>
        /// Returns a random character
        /// </summary>
        /// <returns>A random character</returns>
        private char getRandomCharacter()
        {
            int upperBound = pwdCharArray.GetUpperBound(0);

            int randomCharPosition = getCryptographicRandomNumber(
                pwdCharArray.GetLowerBound(0), upperBound);

            char randomChar = pwdCharArray[randomCharPosition];

            return randomChar;
        }

        /// <returns>A generated random string</returns>
        public string generateRandomString()
        {
            // Pick random length between minimum and maximum   
            int pwdLength = getCryptographicRandomNumber(Minimum, Maximum);

            StringBuilder pwdBuffer = new StringBuilder();
            pwdBuffer.Capacity = Maximum;

            // Generate random characters
            char lastCharacter, nextCharacter;

            // Initial dummy character flag
            lastCharacter = nextCharacter = '\n';

            for (int i = 0; i < pwdLength; i++)
            {
                nextCharacter = getRandomCharacter();

                if ((null != Exclusions))
                {
                    while (-1 != Exclusions.IndexOf(nextCharacter))
                    {
                        nextCharacter = getRandomCharacter();
                    }
                }

                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }

            if (null != pwdBuffer)
            {
                if (m_requireNonAlpha)
                {
                    nextCharacter = getRandomNonAlphaCharacter();
                    pwdBuffer.Remove(pwdBuffer.Length - 1, 1);
                    pwdBuffer.Append(nextCharacter);
                    // insert another char
                    nextCharacter = getRandomNonAlphaCharacter();
                    pwdBuffer.Remove(1, 1);
                    pwdBuffer.Insert(1, nextCharacter);

                    // At random, change first character to numeric as well as the last character.
                    if (changeFirstCHARtoNumeric())
                    {
                        nextCharacter = getRandomNumericCharacter();
                        // Replace first character with a Numeric Character.
                        pwdBuffer.Remove(0, 1);
                        pwdBuffer.Insert(0, nextCharacter);
                    }
                }
                return pwdBuffer.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        //Properties
        public bool RequireNonAlpha
        {
            get { return m_requireNonAlpha; }
            set { m_requireNonAlpha = value; }
        }

        public string Exclusions
        {
            get { return m_exclusionSet; }
            set
            {
                // declare a string to pull the values out of
                if (m_exclusionSet != value && value != null)
                {
                    m_exclusionSet = value;
                    string chars = new String(pwdCharArray);
                    string charsNonAlpha = new string(pwdCharNonAlphaArray);
                    foreach (char chr in m_exclusionSet.ToCharArray())
                    {
                        //remove the value of the exclusion char from the string
                        chars = chars.Replace(chr.ToString(), "");
                        charsNonAlpha = charsNonAlpha.Replace(chr.ToString(), "");
                    }

                    //reset the char array to contain only the non-excluded chars.
                    pwdCharArray = chars.ToCharArray();
                    pwdCharNonAlphaArray = charsNonAlpha.ToCharArray();
                }
            }
        }

        public int Minimum
        {
            get { return m_minSize; }
            set
            {
                m_minSize = value;
            }
        }

        public int Maximum
        {
            get { return m_maxSize; }
            set
            {
                m_maxSize = value;
            }
        }
    }
}
