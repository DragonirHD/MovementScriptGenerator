using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovementScriptGenerator.Modules.OtherChainElements;

namespace MovementScriptGenerator
{
    public partial class RepeatControl : UserControl
    {
        public RepeatControl()
        {
            InitializeComponent();
        }

        private void RepeatControl_Load(object sender, EventArgs e)
        {
            ScrollEventDisable scrollEventDisable = new ScrollEventDisable();
            scrollEventDisable.DisableScrollForChainElementControls(sender, e, Controls[0]);
        }

        public bool Populate(Repeat original)
        {
            try
            {
                numStartElement.Value = original.StartElement;
                numEndElement.Value = original.EndElement;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ValidateInputs()
        {
            if(numStartElement.Value <= numEndElement.Value)
            {
                return true;
            }
            return false;
        }

        public Repeat CreateElement(string elementName)
        {
            Repeat repeat = new Repeat(
                elementName,
                (int)numStartElement.Value,
                (int)numEndElement.Value
                );

            return repeat;
        }
    }
}
