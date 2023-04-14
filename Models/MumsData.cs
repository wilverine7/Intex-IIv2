using Microsoft.ML.OnnxRuntime.Tensors;

namespace Mummies.Models
{
    public class MumsData
    {
        public float depth { get; set; }
        public float length { get; set; }
        public float sex_F { get; set; }
        public float sex_M { get; set; }
        public float sex_U { get; set; }
        public float facebundles_N { get; set; }
        public float facebundles_Y { get; set; }
        public float goods_N { get; set; }
        public float goods_Y { get; set; }
        public float Wrapping_B { get; set; }
        public float Wrapping_H { get; set; }
        public float Wrapping_Other { get; set; }
        public float Wrapping_U { get; set; }
        public float Wrapping_W { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_Other { get; set; }
        public float ageatdeath_U { get; set; }


        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            depth, length, sex_F, sex_M, sex_U, facebundles_N, facebundles_Y, goods_N, goods_Y, Wrapping_B,
            Wrapping_H, Wrapping_Other, Wrapping_U, Wrapping_W, ageatdeath_A, ageatdeath_C, ageatdeath_I, ageatdeath_Other, ageatdeath_U
    };
            int[] dimensions = new int[] { 1, 19 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}