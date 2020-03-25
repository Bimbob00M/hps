using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Home_Planning_Studio.Model.Grid;
using Home_Planning_Studio.View;

namespace Home_Planning_Studio.Model
{
    public class Loader
    {
        public DialogResult Save(string fileName, DwgPanel dwg)
        {
            try
            {
                if (fileName == null)
                {
                    //save as...
                    var sfd = new SaveFileDialog() { Filter = "Binary file|*.dat" };
                    if (sfd.ShowDialog() == DialogResult.OK)
                        fileName = sfd.FileName;
                    else
                        return DialogResult.Cancel;
                }
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream($"{fileName}", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, dwg);
                }
                
                return DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DialogResult.No;
            }
        }

        public DwgPanel Load()
        {
            string fileName;
            try
            {
                var ofd = new OpenFileDialog() { Filter = "Binary file|*.dat" };
                if (ofd.ShowDialog() == DialogResult.OK)
                    fileName = ofd.FileName;
                else
                    return null;

                DwgPanel dwg;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    dwg = formatter.Deserialize(fs) as DwgPanel;
                }

                return dwg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
}
    }
}
