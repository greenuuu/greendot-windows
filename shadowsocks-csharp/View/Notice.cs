using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace ShadowSocks.View
{
    public partial class Notice : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public Notice()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Amber900, Accent.Amber700, TextShade.WHITE);

        }
    }
}
