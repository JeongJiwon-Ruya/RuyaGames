#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("ZPEbWe1ai4THpumdsSfm9Nio4TRMz8HO/kzPxMxMz8/Oc3AdMs8U3b+SzzU/rBvBMRg0KGtELYJnxrpsDKZYBEOSPSRAAb5u/SJDjD9SNUwZJVtYJsHOfJpSe6CeNtRP0w1mK/5Mz+z+w8jH5EiGSDnDz8/Py87NwEoY1OISmgwW69TSAalyff0Rn5jAY9umPwu6snP7xlpu8hPV25TT7KMczJk+Jt073JCJuHz8sGFttte7rGLT/KQUwnVHvEJLYHHuWv1N0fR8ZeOSGDCRWmUOh51kG3uyfLTl74ZpHzow7/Qwb5ju1yu6QA6UCz3bG0fpWoi5icZ859SnQNfVUMumpWygiYsrs4F+biYU1MYxgUtfS939XRMLiJOXyA+GlczNz87P");
        private static int[] order = new int[] { 2,1,9,4,12,9,8,9,13,12,12,13,12,13,14 };
        private static int key = 206;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
