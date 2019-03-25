
namespace Zord_4_MC_v1_WL
{
    static class CamouflageParameters
    {
     static int LeftSampleLimit;
     static int RightSampleLimit;
     static int TopSampleLimit;
     static int DownSampleLimit;
     static int PixelQuantityInSamples;
     static int Area;

        public static int LeftLimit { get => LeftSampleLimit; set => LeftSampleLimit = value; }
        public static int RightLimit { get => RightSampleLimit; set => RightSampleLimit = value; }
        public static int TopLimit { get => TopSampleLimit; set => TopSampleLimit = value; }
        public static int DownLimit { get => DownSampleLimit; set => DownSampleLimit = value; }
        public static int PixelQuantity { get => PixelQuantityInSamples; set => PixelQuantityInSamples = value; }
        public static int AreaProp { get => Area; set => Area = value; }
    }
}
