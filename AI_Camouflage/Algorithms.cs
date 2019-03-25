using System.Drawing;


namespace Zord_4_MC_v1_WL
{
  abstract class CamouflageAlgorithm
    {
        int Iterations;
     
        public int IterationsQuantity { get => Iterations; set => Iterations = value; }

        public CamouflageAlgorithm(int iterations)
        {
            this.IterationsQuantity = iterations;
        }
        abstract public void SettingSamplingArea(int i);
        abstract public Bitmap Algorithm(Bitmap Mapa); 
        
    }
}
