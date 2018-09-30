using PdfSharp.Fonts;
using System;
using System.IO;

namespace AspNetCorePdf.PdfProvider
{
    //This implementation is obviously not very good --> Though it should be enough for everyone to implement their own.
    public class FontResolver : IFontResolver
    {
        private string _resourcesPath = string.Empty;
        public FontResolver(string resourcesPath)
        {
            _resourcesPath = resourcesPath;
        }

        
        public string DefaultFontName => throw new NotImplementedException();

        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(faceName, FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("OpenSans", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    return new FontResolverInfo($"{_resourcesPath}\\Tinos-BoldItalic.ttf");
                }
                else if (isBold)
                {
                    return new FontResolverInfo($"{_resourcesPath}\\Tinos-Bold.ttf");
                }
                else if (isItalic)
                {
                    return new FontResolverInfo($"{_resourcesPath}\\Tinos-Italic.ttf");
                }
                else
                {
                    return new FontResolverInfo($"{_resourcesPath}\\Tinos-Regular.ttf");
                }
            }
            return null;
        }
    }
}