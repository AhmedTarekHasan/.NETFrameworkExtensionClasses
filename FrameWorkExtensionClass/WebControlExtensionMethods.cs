using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace DevelopmentSimplyPut.ExtensionMethods.WebControlEM
{
    public static class WebControlExtensionMethods
    {
        /// <summary>
        /// Adds a CSS class to a WebControl
        /// </summary>
        /// <param name="control">The WebControl</param>
        /// <param name="cssClass">CSS class name</param>
        public static void ext_AddCssClass(this WebControl control, string cssClass)
        {
            if (null != control && !string.IsNullOrEmpty(cssClass) && !string.IsNullOrWhiteSpace(cssClass))
            {
                if (string.IsNullOrEmpty(control.CssClass) || string.IsNullOrWhiteSpace(control.CssClass))
                {
                    control.CssClass = cssClass;
                }
                else
                {
                    bool found = false;
                    {
                        found = control.CssClass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Any<string>(classEntry => classEntry.Trim().ToUpperInvariant().Equals(cssClass.Trim().ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
                    }

                    if (!found)
                    {
                        control.CssClass += " " + cssClass;
                        control.CssClass.Trim();
                    }
                }
            }
        }
        /// <summary>
        /// Removes a CSS class from a WebControl
        /// </summary>
        /// <param name="control">The WebControl</param>
        /// <param name="cssClass">CSS class name</param>
        public static void ext_RemoveCssClass(this WebControl control, string cssClass)
        {
            if (null != control && !string.IsNullOrEmpty(cssClass) && !string.IsNullOrWhiteSpace(cssClass) && !string.IsNullOrEmpty(control.CssClass) && !string.IsNullOrWhiteSpace(control.CssClass))
            {
                if (control.CssClass.Trim().ToUpperInvariant().Equals(cssClass.Trim().ToUpperInvariant()))
                {
                    control.CssClass = string.Empty;
                }
                else
                {
                    var classes = control.CssClass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .SkipWhile<string>(classEntry => classEntry.Trim().ToUpperInvariant().Equals(cssClass.Trim().ToUpperInvariant(), StringComparison.OrdinalIgnoreCase))
                                  .ToArray<string>();

                    if (null != classes && classes.Length > 0)
                    {
                        control.CssClass = String.Join(" ", classes);
                        control.CssClass.Trim();
                    }
                }
            }
        }
        /// <summary>
        /// Gets an IEnumerable of all child WebControls
        /// </summary>
        /// <param name="source">WebControl</param>
        /// <returns></returns>
        public static IEnumerable<WebControl> ext_GetChildControlsRecursively(this WebControl source)
        {
            return source.ext_GetChildControlsRecursively(null);
        }
        /// <summary>
        /// Gets an IEnumerable of all child WebControls which satisfy a certain condition
        /// </summary>
        /// <param name="source">WebControl</param>
        /// <param name="selector">Selector method which decides if a certain WebControl should be selected</param>
        /// <returns></returns>
        public static IEnumerable<WebControl> ext_GetChildControlsRecursively(this WebControl source, Func<WebControl,bool> selector)
        {
            if (null != source)
            {
                if ((null == selector) || (null != selector && selector(source)))
                {
                    yield return source;
                }

                if (!source.HasControls())
                {
                    yield break;
                }

                foreach (WebControl ctrl in source.Controls)
                {
                    foreach (WebControl ctrl1 in ctrl.ext_GetChildControlsRecursively())
                    {
                        if ((null == selector) || (null != selector && selector(ctrl1)))
                        {
                            yield return ctrl1;
                        }
                    }
                }
            }
            else
            {
                yield break;
            }
        }
    }
}
