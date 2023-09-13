using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace EnxamePhobos.UI.utilities
{
    public static class Limpar
    {
        public static void ClearControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                //else if (c is Label)
                //{
                //    ((Label)c).Text = string.Empty;
                //}
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedItem = -1;
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                ClearControl(c);

            }
        }
    }
}