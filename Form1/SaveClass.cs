using System;
using System.Collections.Generic;

namespace paint
{
    [Serializable] class SaveClass
    {
        private List<Figure> array;
        private int w, h;

        public void set_Save(List<Figure> array, int w, int h)
        {
            this.array = array;
            this.w = w;
            this.h = h;
        }

        public List<Figure> get_Save_mas()
        {
            return array;
        }

        public int get_Save_wight()
        {
            return w;
        }

        public int get_Save_height()
        {
            return h;
        }
    }
}
