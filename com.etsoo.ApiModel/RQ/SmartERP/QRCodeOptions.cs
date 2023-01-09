using System.Drawing;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// QR code options
    /// 二维码选项
    /// </summary>
    public record QRCodeOptions
    {
        /// <summary>
        /// Background color
        /// 背景颜色
        /// </summary>
        public Color Background { get; set; } = Color.Transparent;

        /// <summary>
        /// Background color text
        /// 背景颜色文本
        /// </summary>
        public string BackgroundText
        {
            set
            {
                Background = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// Foreground color
        /// 前景颜色
        /// </summary>
        public Color Foreground { get; set; } = Color.Black;

        /// <summary>
        /// Foreground color text
        /// 前景颜色文本
        /// </summary>
        public string ForegroundText
        {
            set
            {
                Foreground = ColorTranslator.FromHtml(value);
            }
        }

        /// <summary>
        /// Type
        /// 类型
        /// </summary>
        /// <see cref="ZXing.BarcodeFormat"/>
        public string Type { get; init; } = "QRCode";

        /// <summary>
        /// Content
        /// 内容
        /// </summary>
        public string Content { get; init; } = string.Empty;

        /// <summary>
        /// Width
        /// 宽度
        /// </summary>
        public int Width { get; init; } = 180;

        /// <summary>
        /// Height
        /// 高度
        /// </summary>
        public int Height { get; init; } = 180;

        /// <summary>
        /// Don't put the content string into the output image
        /// 不要将内容字符串放入输出图像中
        /// </summary>
        public bool PureBarcode { get; init; }

        /// <summary>
        /// Margin
        /// 边距
        /// </summary>
        public int Margin { get; init; }
    }
}
