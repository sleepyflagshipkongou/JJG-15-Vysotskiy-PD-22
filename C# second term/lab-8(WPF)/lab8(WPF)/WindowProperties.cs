using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_WPF_
{
    [Serializable]
    class WindowProperties
    {
        public double windowWidth = 400;
        public double windowHeight = 300;
        public string textBoxContent = "";
        public bool? checkBox1IsChecked = false;
        public bool? checkBox2IsChecked = true;
    }
}
