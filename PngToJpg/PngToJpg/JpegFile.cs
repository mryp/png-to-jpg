using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PngToJpg
{
    /// <summary>
    /// JPEGファイル操作クラス
    /// </summary>
    public class JpegFile
    {
        /// <summary>
        /// 指定した品質でJPEGファイルを作成する
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="image">画像ビットマップ</param>
        /// <param name="quality">品質（1～100）を指定する。なお100が最高品質</param>
        /// <returns>成功時はtrue</returns>
        public static bool SaveImageQuality(string filePath, Image image, int quality)
        {
            var jpgEncoder = getEncoder(ImageFormat.Jpeg);
            if (jpgEncoder == null)
            {
                return false;
            }

            var eps = new EncoderParameters();
            var ep = new EncoderParameter(Encoder.Quality, quality);
            eps.Param[0] = ep;
            image.Save(filePath, jpgEncoder, eps);
            return true;
        }

        /// <summary>
        /// 指定したフォーマットのエンコーダーを取得する
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private static ImageCodecInfo? getEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
