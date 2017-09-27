using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace DevelopmentSimplyPut.ExtensionMethods.StringEM
{
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Repeats a string for a given number of times
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="numberOfTimes">Number of times</param>
        /// <returns></returns>
        public static string ext_RepeatNoOfTimes(this string source, int numberOfTimes)
        {
            string result = string.Empty;
            for (int i = 0; i < numberOfTimes; i++)
            {
                result += source;
            }
            return result;
        }
        /// <summary>
        /// Formats numbers inside a string into a given number of digits with extra preceeding zeros
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="numOfDigits">Number of digits</param>
        /// <returns></returns>
        public static string ext_PutNumbersIntoNoOfDigits(this string source, int numOfDigits)
        {
            string result = source;
            result = Regex.Replace(result, @"\d+", new MatchEvaluator(delegate(Match match)
            {
                if (match.Length < numOfDigits)
                {
                    string zero = "0";
                    result = zero.ext_RepeatNoOfTimes(numOfDigits - match.Length) + match.Value;
                    return result;
                }
                else
                {
                    result = match.Value;
                    return result;
                }
            }));

            return result;
        }
        /// <summary>
        /// Gets the {n} first characters of a string
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="NumOfChars">Number of characters</param>
        /// <returns></returns>
        public static string ext_First(this string source, int NumOfChars)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= NumOfChars)
            {
                return source;
            }

            return source.Substring(0, NumOfChars);
        }
        /// <summary>
        /// Gets the {n} last characters of a string
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="NumOfChars">Number of characters</param>
        /// <returns></returns>
        public static string ext_Last(this string source, int NumOfChars)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= NumOfChars)
            {
                return source;
            }

            return source.Substring(source.Length - NumOfChars, NumOfChars);
        }
        /// <summary>
        /// Splits a string into two parts, the first one is the string part before the last existance of a certain character,
        /// the second one is the string part after the last existance of the same character
        /// </summary>
        /// <param name="source"></param>
        /// <param name="splitAtChar"></param>
        /// <returns></returns>
        public static string[] ext_SplitAtLastCharExistance(this string source, char splitAtChar)
        {
            string[] result = { string.Empty, string.Empty };
            if (string.IsNullOrEmpty(source))
            {
                //string is empty
                return result;
            }

            if (!(source.Contains(splitAtChar)))
            {
                //character doesn't exist in the string
                result[0] = source;
                return result;
            }

            if (source.Length == 1)
            {
                //the string is only the character itself
                return result;
            }

            int temp = source.LastIndexOf(splitAtChar);

            if (temp == 0)
            {
                //the character is at the start
                result[0] = string.Empty;
                result[1] = source.Substring(temp + 1, source.Length - temp - 1);
            }
            else if (temp == source.Length - 1)
            {
                //the character is at the end
                result[0] = source.Substring(0, temp);
                result[1] = string.Empty;
            }
            else
            {
                //the character is in the middle
                result[0] = source.Substring(0, temp);
                result[1] = source.Substring(temp + 1, source.Length - temp - 1);
            }

            return result;
        }
        /// <summary>
        /// Gets the preceding part of a string except the last given number of characters
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="NumOfChars">Number of characters</param>
        /// <returns></returns>
        public static string ext_ExceptLastNoOfChars(this string source, int NumOfChars)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= NumOfChars)
            {
                return string.Empty;
            }

            return source.Substring(0, source.Length - NumOfChars);
        }
        /// <summary>
        /// Gets the succeeding part of a string except the first given number of characters
        /// </summary>
        /// <param name="source"></param>
        /// <param name="NumOfChars"></param>
        /// <returns></returns>
        public static string ext_ExceptFirstNoOfChars(this string source, int NumOfChars)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= NumOfChars)
            {
                return string.Empty;
            }

            return source.Substring(NumOfChars, source.Length - NumOfChars);
        }
        /// <summary>
        /// Formats a string with one literal placeholder.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="arg0">Argument 0</param>
        /// <returns>The formatted string</returns>
        public static string ext_FormatWith(this string text, object arg0)
        {
            return string.Format(text, arg0);
        }
        /// <summary>
        /// Formats a string with two literal placeholders.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="arg0">Argument 0</param>
        /// <param name="arg1">Argument 1</param>
        /// <returns>The formatted string</returns>
        public static string ext_FormatWith(this string text, object arg0, object arg1)
        {
            return string.Format(text, arg0, arg1);
        }
        /// <summary>
        /// Formats a string with tree literal placeholders.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="arg0">Argument 0</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <returns>The formatted string</returns>
        public static string ext_FormatWith(this string text, object arg0, object arg1, object arg2)
        {
            return string.Format(text, arg0, arg1, arg2);
        }
        /// <summary>
        /// Formats a string with a list of literal placeholders.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="args">The argument list</param>
        /// <returns>The formatted string</returns>
        public static string ext_FormatWith(this string text, params object[] args)
        {
            return string.Format(text, args);
        }
        /// <summary>
        /// Formats a string with a list of literal placeholders.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="provider">The format provider</param>
        /// <param name="args">The argument list</param>
        /// <returns>The formatted string</returns>
        public static string ext_FormatWith(this string text, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, text, args);
        }
        /// <summary>
        /// Deserialises an xml string in to an object of Type T
        /// </summary>
        /// <typeparam name="T">Any class type</typeparam>
        /// <param name="xml">Xml as string to deserialise from</param>
        /// <returns>A new object of type T is successful, null if failed</returns>
        public static T ext_XmlDeserialize<T>(this string xml) where T : class
        {
            var serialiser = new XmlSerializer(typeof(T));
            T newObject;

            using (var stringReader = new StringReader(xml))
            {
                using (var xmlReader = new XmlTextReader(stringReader))
                {
                    try
                    {
                        newObject = serialiser.Deserialize(xmlReader) as T;
                    }
                    catch (InvalidOperationException) // String passed is not Xml, return null
                    {
                        return null;
                    }

                }
            }

            return newObject;
        }
        /// <summary>
        /// Parses a string into an Enum
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T ext_ToEnum<T>(this string value)
        {
            return ext_ToEnum<T>(value, false);
        }
        /// <summary>
        /// Parses a string into an Enum
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <param name="ignorecase">Ignore the case of the string being parsed</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T ext_ToEnum<T>(this string value, bool ignorecase)
        {
            if (value == null)
                throw new ArgumentNullException("Value");

            value = value.Trim();

            if (value.Length == 0)
                throw new ArgumentNullException("Must specify valid information for parsing in the string.", "value");

            Type t = typeof(T);
            if (!t.IsEnum)
                throw new ArgumentException("Type provided must be an Enum.", "T");

            return (T)Enum.Parse(t, value, ignorecase);
        }
        /// <summary>
        /// Toes the integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultvalue">The defaultvalue.</param>
        /// <returns></returns>
        public static int ext_ToInteger(this string value, int defaultvalue)
        {
            return (int)ext_ToDouble(value, defaultvalue);
        }
        /// <summary>
        /// Toes the integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int ext_ToInteger(this string value)
        {
            return ext_ToInteger(value, 0);
        }
        /// <summary>
        /// Toes the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultvalue">The defaultvalue.</param>
        /// <returns></returns>
        public static double ext_ToDouble(this string value, double defaultvalue)
        {
            double result;
            if (double.TryParse(value, out result))
            {
                return result;
            }
            else return defaultvalue;
        }
        /// <summary>
        /// Toes the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ext_ToDouble(this string value)
        {
            return ext_ToDouble(value, 0);
        }
        /// <summary>
        /// Toes the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultvalue">The defaultvalue.</param>
        /// <returns></returns>
        public static DateTime? ext_ToDateTime(this string value, DateTime? defaultvalue)
        {
            DateTime result;
            if (DateTime.TryParse(value, out result))
            {
                return result;
            }
            else return defaultvalue;
        }
        /// <summary>
        /// Toes the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime? ext_ToDateTime(this string value)
        {
            return ext_ToDateTime(value, null);
        }
        /// <summary>
        /// Converts a string value to bool value, supports "T" and "F" conversions.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>A bool based on the string value</returns>
        public static bool? ext_ToBoolean(this string value)
        {
            if (string.Compare("T", value, true) == 0)
            {
                return true;
            }
            if (string.Compare("F", value, true) == 0)
            {
                return false;
            }
            bool result;
            if (bool.TryParse(value, out result))
            {
                return result;
            }
            else return null;
        }
        /// <summary>
        /// Gets the string value or a default value
        /// </summary>
        /// <param name="value">String</param>
        /// <returns></returns>
        public static string ext_GetValueOrEmpty(this string value)
        {
            return ext_GetValueOrDefault(value, string.Empty);
        }
        /// <summary>
        /// Gets the string value or a default value
        /// </summary>
        /// <param name="value">String</param>
        /// <param name="defaultvalue">Default value</param>
        /// <returns></returns>
        public static string ext_GetValueOrDefault(this string value, string defaultvalue)
        {
            if (value != null) return value;
            return defaultvalue;
        }
        /// <summary>
        /// Converts string to a Name-Format where each first letter is Uppercase.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns></returns>
        public static string ext_ToUpperLowerNameVariant(this string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            char[] valuearray = value.ToLower().ToCharArray();
            bool nextupper = true;
            for (int i = 0; i < (valuearray.Count() - 1); i++)
            {
                if (nextupper)
                {
                    valuearray[i] = char.Parse(valuearray[i].ToString().ToUpper());
                    nextupper = false;
                }
                else
                {
                    switch (valuearray[i])
                    {
                        case ' ':
                        case '-':
                        case '.':
                        case ':':
                        case '\n':
                            nextupper = true;
                            break;
                        default:
                            nextupper = false;
                            break;
                    }
                }
            }
            return new string(valuearray);
        }
        /// <summary>
        /// Encryptes a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToEncrypt">String that must be encrypted.</param>
        /// <param name="key">Encryptionkey.</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string ext_Encrypt(this string stringToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
            cspp.KeyContainerName = key;

            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);

            return BitConverter.ToString(bytes);
        }
        /// <summary>
        /// Decryptes a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="key">Decryptionkey.</param>
        /// <returns>The decrypted string or null if decryption failed.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string ext_Decrypt(this string stringToDecrypt, string key)
        {
            string result = null;

            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            try
            {
                System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
                cspp.KeyContainerName = key;

                System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
                rsa.PersistKeyInCsp = true;

                string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
                byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));


                byte[] bytes = rsa.Decrypt(decryptByteArray, true);

                result = System.Text.UTF8Encoding.UTF8.GetString(bytes);

            }
            finally
            {
                // no need for further processing
            }

            return result;
        }
        /// <summary>
        /// Determines whether it is a valid URL.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is valid URL] [the specified text]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ext_IsValidUrl(this string text)
        {
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(text);
        }
        /// <summary>
        /// Determines whether it is a valid email address
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is valid email address] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ext_IsValidEmailAddress(this string email)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
        /// <summary>
        /// Send an email using the supplied string.
        /// </summary>
        /// <param name="body">String that will be used i the body of the email.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="sender">The email address from which the message was sent.</param>
        /// <param name="recipient">The receiver of the email.</param> 
        /// <param name="server">The server from which the email will be sent.</param>  
        /// <returns>A boolean value indicating the success of the email send.</returns>
        public static bool ext_Email(this string body, string subject, string sender, string recipient, string server)
        {
            try
            {
                // To
                MailMessage mailMsg = new MailMessage();
                mailMsg.To.Add(recipient);

                // From
                MailAddress mailAddress = new MailAddress(sender);
                mailMsg.From = mailAddress;

                // Subject and Body
                mailMsg.Subject = subject;
                mailMsg.Body = body;

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient(server);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not send mail from: " + sender + " to: " + recipient + " thru smtp server: " + server + "\n\n" + ex.Message, ex);
            }

            return true;
        }
        /// <summary>
        /// Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="maxLength">total length of characters to maintain before the truncate happens</param>
        /// <returns>truncated string</returns>
        public static string ext_Truncate(this string text, int maxLength)
        {
            // replaces the truncated string to a ...
            const string suffix = "...";
            string truncatedString = text;

            if (maxLength <= 0) return truncatedString;
            int strLength = maxLength - suffix.Length;

            if (strLength <= 0) return truncatedString;

            if (text == null || text.Length <= maxLength) return truncatedString;

            truncatedString = text.Substring(0, strLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;
            return truncatedString;
        }
        /// <summary>
        /// Converts to a HTML-encoded string
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string ext_HtmlEncode(this string data)
        {
            return System.Web.HttpUtility.HtmlEncode(data);
        }
        /// <summary>
        /// Converts the HTML-encoded string into a decoded string
        /// </summary>
        public static string ext_HtmlDecode(this string data)
        {
            return System.Web.HttpUtility.HtmlDecode(data);
        }
        /// <summary>
        /// Parses a query string into a System.Collections.Specialized.NameValueCollection
        /// using System.Text.Encoding.UTF8 encoding.
        /// </summary>
        public static System.Collections.Specialized.NameValueCollection ext_ParseQueryString(this string query)
        {
            return System.Web.HttpUtility.ParseQueryString(query);
        }
        /// <summary>
        /// Encode an Url string
        /// </summary>
        public static string ext_UrlEncode(this string url)
        {
            return System.Web.HttpUtility.UrlEncode(url);
        }
        /// <summary>
        /// Converts a string that has been encoded for transmission in a URL into a
        /// decoded string.
        /// </summary>
        public static string ext_UrlDecode(this string url)
        {
            return System.Web.HttpUtility.UrlDecode(url);
        }
        /// <summary>
        /// Encodes the path portion of a URL string for reliable HTTP transmission from
        /// the Web server to a client.
        /// </summary>
        public static string ext_UrlPathEncode(this string url)
        {
            return System.Web.HttpUtility.UrlPathEncode(url);
        }
        /// <summary>
        /// Replaces the format item in a specified System.String with the text equivalent
        /// of the value of a specified System.Object instance.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <param name="additionalArgs">The additional args.</param>
        public static string ext_Format(this string format, object arg, params object[] additionalArgs)
        {
            if (additionalArgs == null || additionalArgs.Length == 0)
            {
                return string.Format(format, arg);
            }
            else
            {
                return string.Format(format, new object[] { arg }.Concat(additionalArgs).ToArray());
            }
        }
        /// <summary>
        /// Determines whether [is not null or empty] [the specified input].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is not null or empty] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ext_IsNotNullOrEmpty(this string input)
        {
            return !String.IsNullOrEmpty(input);
        }
    }
}
