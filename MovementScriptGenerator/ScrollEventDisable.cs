using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementScriptGenerator
{
    class ScrollEventDisable
    {
        public void DisableScrollForChainElementControls(object sender, EventArgs e, Control mainFlpOfControl)
        {
            foreach (Control ctl in mainFlpOfControl.Controls)
            {
                foreach (Control ctlOfctl in ctl.Controls)
                {
                    if (ctlOfctl.GetType() == typeof(NumericUpDown) || ctlOfctl.GetType() == typeof(ComboBox))
                    {
                        ctlOfctl.MouseWheel += Ctl_MouseWheel;
                    }
                }
            }
        }

        private void Ctl_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
