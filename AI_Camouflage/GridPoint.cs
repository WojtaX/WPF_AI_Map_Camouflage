using System.Windows.Controls;


namespace Zord_4_MC_v1_WL
{
    public class GridPoint : Button
    {
        bool wybrany;
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }
        public bool selected
        {
            get { return wybrany; }
            set { this.wybrany = value; }
        }
    }
}
