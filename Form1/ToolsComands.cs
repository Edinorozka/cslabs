using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace paint
{
    class ToolsComands
    {
        private static string formatname = "paintList";
        private static IDataObject data;

        private static void DeleteList(Form2 f)
        {
            int j = 0;
            for (int i = 0; i < f.changeArray.Count; i++)
            {
                while (j < f.array.Count)
                {
                    if (f.changeArray[i] == f.array[j] && i != 10000)
                    {
                        f.array.RemoveAt(j);
                        f.changeArray.RemoveAt(i);
                        i = 0;
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
                    if (f.changeArray.Count == 0) break;
                }
            }
        }

        public static void Delete(Form2 f)
        {
            DeleteList(f);
            f.get_pb().Invalidate();
        }

        public static void Copy(Form2 f)
        {
            if (f.changeArray.Count > 0)
            {
                Clipboard.SetData(formatname, f.changeArray);
            }
        }

        public static void Paste(Form2 f)
        {
            data = Clipboard.GetDataObject();
            if (data.GetDataPresent(formatname))
            {
                f.changeArray = (List<Figure>)data.GetData(formatname);
                foreach (Figure fig in f.changeArray)
                {
                    fig.ChangeZero();
                    if (fig.checkZone(fig.point1, f.Width, f.Height) && fig.checkZone(fig.point2, f.Width, f.Height))
                    {
                        DialogResult dr = MessageBox.Show("Объект выходит за границы рисунка", "Внимание", MessageBoxButtons.OK);
                        f.changeArray.Clear();
                        return;
                    }
                }

                foreach (Figure fig in f.changeArray)
                {
                    f.array.Add(fig);
                }
            }
            f.get_pb().Invalidate();
        }

        public static void Cut(Form2 f)
        {
            if (f.changeArray.Count > 0)
            {
                Clipboard.SetData(formatname, f.changeArray);
                DeleteList(f);
            }
            f.get_pb().Invalidate();
        }

        public static void CopyInMetafile(Form2 f)
        {
            
            IntPtr dc = f.get_g().GetHdc();
            using (Metafile mf = new Metafile(dc, EmfType.EmfOnly))
            {
                using (Graphics graphics = Graphics.FromImage(mf))
                {
                    foreach (Figure fig in f.changeArray) fig.Draw(graphics);
                }
                ClipboardMetafileHelper.PutEnhMetafileOnClipboard(f.Handle, mf);
            }
            f.get_g().ReleaseHdc(dc);
            f.get_g().Dispose();
            f.get_pb().Invalidate();
        }

        public static void Grid(Form2 f)
        {
            f.get_pb().Invalidate();
        }

        public static void GridAlignment(Form2 f)
        {
            foreach(Figure a in f.array)
            {
                a.GridChange();
            }
            f.get_pb().Invalidate();
        }
    }
}
