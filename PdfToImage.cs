using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Drawing_Dimension_Tool
{
    class PdfToImage
    {
        [DllImport(@"pdf2image.dll", CharSet = CharSet.Auto)]
        static extern uint PDFToImageConverter(
            [MarshalAs(UnmanagedType.LPStr)] string FileName,
            [MarshalAs(UnmanagedType.LPStr)] string OutputName,
            IntPtr UserPassword, IntPtr OwnPassword,
            int xresolution, int yresolution, int bitcount,
            int compression, int quality, int grayscale,
            int multipage, int firstPage, int lastPage);

        [DllImport(@"pdf2image.dll", CharSet = CharSet.Ansi)]
        static extern uint PDFToImageSetCode(string lpRegcode);

        const int TRUE = 1;
        const int FALSE = 0;
        const int COMPRESSION_NONE = 1;			// dump mode
        const int COMPRESSION_CCITTRLE = 2;		// CCITT modified Huffman RLE
        const int COMPRESSION_CCITTFAX3 = 3;	// CCITT Group 3 fax encoding
        const int COMPRESSION_CCITTFAX4 = 4;	// CCITT Group 4 fax encoding
        const int COMPRESSION_LZW = 5;			// Lempel-Ziv  & Welch
        const int COMPRESSION_JPEG = 7;			// %JPEG DCT compression
        const int COMPRESSION_PACKBITS = 32773;	// Macintosh RLE

        public static string Convert( string SourceName )
        {
            IntPtr UserPassword = IntPtr.Zero;
            IntPtr OwnPassword = IntPtr.Zero;
            //string SourceName = "C:\\DoesntWork.pdf";
            //string DestName = "C:\\DoesntWork.jpg";
            int idx = SourceName.LastIndexOf('\\');
            string DestName = @"c:\temp\";
            DestName += SourceName.Substring(idx + 1);// + ".tif" );
            DestName += ".tif";

            uint result = 1;
            Console.WriteLine("CSharp, converting " + SourceName + " to " + DestName);
            try
            {
                PDFToImageSetCode("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                result = PDFToImageConverter(SourceName, DestName, UserPassword, OwnPassword, 200, 200, 8,
                    COMPRESSION_LZW, 70, FALSE, TRUE, -1, -1);
//                result = PDFToImageConverter(SourceName, DestName, UserPassword, OwnPassword, 200, 200, 8,
  //                  COMPRESSION_CCITTFAX4, 70, FALSE, TRUE, -1, -1);
                Console.Write("Result: " + result.ToString());
            }
            catch (Exception ex)
            {
                Console.Write("Error: " + ex.Message);
            }
            Console.Write(", press enter...");
            //Console.ReadLine();
            if (result == 1)
                return null;

            return DestName;
            //return (int)result;
        }
    }


}
