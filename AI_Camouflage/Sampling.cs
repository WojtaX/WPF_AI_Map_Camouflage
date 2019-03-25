using System.Collections.Generic;
using System.Drawing;

namespace Zord_4_MC_v1_WL
{
    class MonteCarloSampler:CamouflageAlgorithm
    {        
        List<GridPoint> ZaznaczonePunkty;
        System.Drawing.Color ProbkaKoloru;

        public List<GridPoint> UpdateCheckedPoints
        {
            get { return ZaznaczonePunkty; }
        }
        
        public void DeletingSelectedPoints()
        {
            this.ZaznaczonePunkty.Clear();
        }

        public void SetPoint(GridPoint WybranyPunkt)
        {
            ZaznaczonePunkty.Add(WybranyPunkt);
        }

        public void UncheckPoint(GridPoint OdznaczanyPunkt)
        {
            ZaznaczonePunkty.Remove(OdznaczanyPunkt);
        }
      
        public MonteCarloSampler(int iter, int probka, int obszar):base(iter)
        {
            this.ZaznaczonePunkty = new List<GridPoint>();
            CamouflageParameters.PixelQuantity = probka;
            CamouflageParameters.AreaProp = obszar;
        }

        public override void SettingSamplingArea(int i)
        {
            CamouflageParameters.LeftLimit = ZaznaczonePunkty[i].X - CamouflageParameters.AreaProp;
            CamouflageParameters.RightLimit = ZaznaczonePunkty[i].X + CamouflageParameters.AreaProp;
            CamouflageParameters.TopLimit = ZaznaczonePunkty[i].Y - CamouflageParameters.AreaProp;
            CamouflageParameters.DownLimit = ZaznaczonePunkty[i].Y + CamouflageParameters.AreaProp;
        }

        public override Bitmap Algorithm(Bitmap Mapa)
        {
            RandomMersenne rand = new RandomMersenne(2828282);  
            for (int k = 0; k < ZaznaczonePunkty.Count; k++)
            {
                for (int i = 0; i < IterationsQuantity; i++)
                {
                    for (int j = 1; j <CamouflageParameters.PixelQuantity + 1; j++)
                    {
                        ZaznaczonePunkty[k].Background = null;
                        SettingSamplingArea(k);

                        int XProbki = rand.IRandom(CamouflageParameters.LeftLimit, CamouflageParameters.RightLimit);
                        int YProbki = rand.IRandom(CamouflageParameters.TopLimit, CamouflageParameters.DownLimit);

                        this.ProbkaKoloru = Mapa.GetPixel(XProbki, YProbki);  

                        
                        int   WysokoscObszaru = rand.IRandom(CamouflageParameters.TopLimit, CamouflageParameters.DownLimit);  
                        int   SzerokoscObszaru = rand.IRandom(CamouflageParameters.LeftLimit, CamouflageParameters.RightLimit);  


                        int KanalAlpha = this.ProbkaKoloru.A;    
                        int Red = this.ProbkaKoloru.R;   
                        int Green = this.ProbkaKoloru.G;  
                        int Blue = this.ProbkaKoloru.B; 
                        
                        Mapa.SetPixel(SzerokoscObszaru + j, WysokoscObszaru + j, System.Drawing.Color.FromArgb(KanalAlpha, Red, Green, Blue)); 
                        
                    }
                }
            }
            
            Mapa.Save("testMapa.png");
            return Mapa;
        }

       
    }
}
