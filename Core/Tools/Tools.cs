using AngleSharp.Html;
using AngleSharp.Html.Parser;
using Core.Exceptions;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using QRCoder;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Core.Tools
{
    public static class Funciones
    {
        public static string GetCodigoUnico(string CodigoID)
        {
            try
            {
                string CodigoUnico = DateTime.Now.ToString("yyyyMMddHHmmss_fff") + "_" + CodigoID + "_" + Path.GetRandomFileName().PadLeft(11).Replace('.', '_');
                return CodigoUnico;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static string GetSHA256(string cadena)
        {
            try
            {
                SHA256 sha256 = SHA256.Create();
                ASCIIEncoding encoding = new();
                byte[]? stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(cadena));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static string GenerateArchivoPdfCombinadoProveddor(List<string> listadoArchivos, string pathFS, string id, string nombreant = "")
        {
            try
            {
                // Open the output document
                PdfDocument outputDocument = new PdfDocument();

                // Iterate files
                foreach (string file in listadoArchivos)
                {
                    // Open the document to import pages from it.
                    string pathFile = Path.Combine(pathFS, file);
                    PdfDocument inputDocument = PdfReader.Open(pathFile, PdfDocumentOpenMode.Import);

                    // Iterate pages
                    int count = inputDocument.PageCount;
                    for (int idx = 0; idx < count; idx++)
                    {
                        // Get the page from the external document...
                        PdfPage page = inputDocument.Pages[idx];
                        // ...and add it to the output document.
                        outputDocument.AddPage(page);
                    }
                }

                // Save the document...
                using MemoryStream ms = new MemoryStream();
                outputDocument.Save(ms);

                byte[] res = ms.ToArray();

                string nombre = nombreant == "" ? GetCodigoUnico(id) + ".pdf" : nombreant;

                if (!Directory.Exists(pathFS))
                {
                    Directory.CreateDirectory(pathFS);
                }

                var testFile = Path.Combine(pathFS, nombre);
                string url = "Proveedores/" + nombre;

                bool isCreated = ByteArrayToFile(testFile, res);
                return url;

                //const string filename = "ConcatenatedDocument1_tempfile.pdf";
                //outputDocument.Save(filename);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fs.Write(byteArray, 0, byteArray.Length);
                return true;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static bool SaveStreamAsFileAsync(string filePath, byte[] res, string fileName)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(filePath);
                if (!info.Exists)
                {
                    info.Create();
                }

                string path = Path.Combine(filePath, fileName);
                return ByteArrayToFile(path, res);
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        //public static string GetContentType(string fileName)
        //{
        //    try
        //    {
        //        new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string contentType);
        //        return contentType ?? "application/octet-stream";
        //    }
        //    catch (Exception e)
        //    {
        //        throw new BusinessException($"Error: {e.Message}");
        //    }
        //}

        public static byte[] PdfSharpConvertWithoutCreateFile(string html)
        {
            try
            {
                using MemoryStream ms = new MemoryStream();
                var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4, 50);
                pdf.Save(ms);
                byte[] res = ms.ToArray();
                return res;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        /// <summary>
        /// ESTO NO SE ESTA USANDO (BORRAR)
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static byte[] PdfSharpConvertWithoutCreateFilePrueba(string html)
        {
            try
            {
                PdfDocument document = new PdfDocument();

                // Create a font
                XFont font = new XFont("Times", 25, XFontStyle.Bold);

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                gfx.DrawString("PAGINA 1", font, XBrushes.DarkRed, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);

                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                gfx.DrawString("PAGINA 2", font, XBrushes.DarkRed, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

                //var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4, 50);
                using MemoryStream ms = new MemoryStream();
                document.Save(ms);
                byte[] res = ms.ToArray();
                return res;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static string NumeroALetras(decimal numberAsString)
        {
            try
            {
                string dec;

                if (numberAsString < 0)
                {
                    throw new BusinessException($"Error: existen valores negativos que no se pueden convertir a letras!");
                }

                var entero = Convert.ToInt64(Math.Truncate(numberAsString));
                var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
                if (decimales > 0)
                {
                    //dec = " PESOS CON " + decimales.ToString() + "/100";
                    dec = $" PESOS {decimales:0,0} /100";
                }
                //Código agregado por mí
                else
                {
                    //dec = " PESOS CON " + decimales.ToString() + "/100";
                    dec = $" PESOS {decimales:0,0} /100";
                }
                var res = NumeroALetras(Convert.ToDouble(entero)) + dec;
                return res;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        private static string NumeroALetras(double value)
        {
            string num2Text; value = Math.Truncate(value);
            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = "DIECI" + NumeroALetras(value - 10);
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = "VEINTI" + NumeroALetras(value - 20);
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = "MIL " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            {
                num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return num2Text;
        }

        public static string FormatearMes(int mes)
        {
            try
            {
                return (mes < 10 ? string.Concat("0", mes) : mes.ToString());
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static string GetQrCodeHtml(string texto)
        {
            try
            {
                QRCodeGenerator qrGenerator = new();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                Base64QRCode qrCode = new(qrCodeData);
                var imgType = Base64QRCode.ImageType.Png;
                string qrCodeImageAsBase64 = qrCode.GetGraphic(3, Color.FromArgb(16, 143, 230), Color.Transparent, false, imgType);
                string imgHtml = $"<img alt=\"Embedded QR Code\" src=\"data:image/{imgType.ToString().ToLower()};base64,{qrCodeImageAsBase64}\" />";
                return imgHtml;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static int GetCantidadPropiedades<T>()
        {
            try
            {
                // Get the Type object corresponding to MyClass.
                Type myType = typeof(T);
                return myType.GetProperties().Length;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public static string LimpiarPaths(string texto)
        {
            try
            {
                string textoLimpio = texto.Replace("\\", "/");
                return textoLimpio;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        /// <summary>
        /// Método para calcular distancia de puntos geograficos
        /// </summary>
        /// <param name="latitudCentro"></param>
        /// <param name="longitudCentro"></param>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <returns></returns>
        public static double CalcularDistanciaRadio(double latitudCentro, double longitudCentro, double latitud, double longitud)
        {
            const double EarthRadiusKm = 6371;
            double lat1Rad = DegToRad(latitudCentro);
            double lat2Rad = DegToRad(latitud);
            double deltaLonRad = DegToRad(longitud - longitudCentro);

            return EarthRadiusKm * Math.Acos(
                Math.Cos(lat1Rad) * 
                Math.Cos(lat2Rad) * 
                Math.Cos(deltaLonRad) +
                Math.Sin(lat1Rad) * 
                Math.Sin(lat2Rad)
            );
        }

        /// <summary>
        /// Metodo para convertir de grados a radianes
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        private static double DegToRad(double degrees)
        {
            return (degrees * Math.PI) / 180.0;
        }

        public static void EscribirArchivo(string rutaArchivo, string cadenaHtml)
        {
            File.WriteAllText(rutaArchivo, cadenaHtml);
        }

        public static string GetHtmlFromFile(string rutaArchivoHTML)
        {
            string textoExtraido = null;

            // Verificamos si el archivo existe
            if (File.Exists(rutaArchivoHTML))
            {
                // Usamos un StringBuilder para almacenar el texto extraído del archivo HTML
                StringBuilder stringBuilder = new StringBuilder();

                // Leemos el archivo línea por línea y agregamos su contenido al StringBuilder
                using (StreamReader sr = new StreamReader(rutaArchivoHTML))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        stringBuilder.AppendLine(linea);
                    }
                }

                // Obtener el texto completo del StringBuilder
                textoExtraido = stringBuilder.ToString();
            }

            return textoExtraido;
        }

        public static void IndentarHtml(string htmlContent, string pathRed)
        {
            try
            {
                // Leer el archivo HTML
                //string htmlContent = File.ReadAllText(pathRed);

                // Crear un analizador HTML
                var htmlParser = new HtmlParser();

                // Analizar el HTML
                var document = htmlParser.ParseDocument(htmlContent);

                // Obtener el HTML formateado
                // Configurar el formateador de HTML
                var formatter = new PrettyMarkupFormatter
                {
                    NewLine = Environment.NewLine,
                    Indentation = "    " // Puedes ajustar la cantidad de espacios de indentación según tu preferencia
                };

                // Obtener el HTML formateado
                using var writer = new StringWriter(new StringBuilder(), System.Globalization.CultureInfo.InvariantCulture);
                document.ToHtml(writer, formatter);
                string formattedHtml = writer.ToString();

                // Sobrescribir el archivo con el HTML formateado
                File.WriteAllText(pathRed, formattedHtml);
            }
            catch (FileNotFoundException)
            {
                throw new BusinessException("El archivo HTML no fue encontrado.");
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al formatear el archivo HTML: " + ex.Message);
            }
        }

        public static string CombinePath(string root, string relPath)
        {
            string combinedPath = root;
            string[] pathParts = relPath.Split('/', '\\');
            foreach (string part in pathParts)
            {
                combinedPath = Path.Combine(combinedPath, part);
            }
            return combinedPath;
        }
    }
}
