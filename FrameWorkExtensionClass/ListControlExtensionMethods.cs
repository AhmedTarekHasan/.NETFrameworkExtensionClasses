using System.Web.UI.WebControls;

namespace DevelopmentSimplyPut.ExtensionMethods.ListControlEM
{
    public static class ListControlExtensionMethods
    {
        /// <summary>
        /// Resets a ListControl
        /// </summary>
        /// <param name="control">ListControl</param>
        public static void ext_Reset(this ListControl control)
        {
            if (null != control)
            {
                control.Items.Clear();
                control.DataSource = null;
            }
        }
        /// <summary>
        /// Resets a ListControl and adds a default option
        /// </summary>
        /// <param name="control">ListControl</param>
        /// <param name="defaultText">Default option display text</param>
        /// <param name="defaultValue">Default option value</param>
        public static void ext_Reset(this ListControl control, string defaultText, string defaultValue)
        {
            if (null != control)
            {
                control.ext_Reset();
                control.Items.Add(new ListItem() { Text = defaultText, Value = defaultValue });
            }
        }
    }
}
