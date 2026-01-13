using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Drawing;

namespace Core.Tools
{
    public class ReportExcel
    {
        public ExcelPackage Libro { get; set; }

        public ReportExcel()
        {
            Libro = new ExcelPackage();
            Libro.Workbook.Properties.Author = "EEP";
            Libro.Workbook.Properties.Company = "EEP S.A.S.";
            Libro.Workbook.Properties.Keywords = "Excel,Epplus";
            Libro.Workbook.Properties.Created = DateTime.Now;
        }

        public ExcelWorksheet AgregarHoja(string nombreHoja)
        {
            return Libro.Workbook.Worksheets.Add(nombreHoja);
        }

        public void CargarTablaEnHoja<T>(
            string celdaInicial, List<T> listado, ExcelWorksheet hoja, int fromRow, int fromCol, int toRow, 
            string nombreTabla = null, bool showHeader = true, bool showTotal = true, bool showFilter = false
        )
        {
            CargarData(hoja, listado, celdaInicial);

            int lastColumn = hoja.Dimension.End.Column;

            AjustarColumnas(hoja, lastColumn);

            // Obtenemos la cantidad de propiedades que tiene la clase del listado
            //int cantidadPropiedades = Funciones.GetCantidadPropiedades<T>();

            // Agregar formato de tabla
            ExcelTable tabla = hoja.Tables.Add(new ExcelAddressBase(fromRow, fromCol, toRow, toColumn: lastColumn), nombreTabla);
            tabla.ShowHeader = showHeader;
            tabla.TableStyle = TableStyles.Light6;
            tabla.ShowTotal = showTotal;
            tabla.ShowFilter = showFilter;
        }

        public void CargarData<T>(ExcelWorksheet hoja, List<T> listado, string celdaInicial, bool mostrarCabeceras = true)
        {
            hoja.Cells[celdaInicial].LoadFromCollection(listado, PrintHeaders: mostrarCabeceras);
        }

        public void AjustarColumnas(ExcelWorksheet hoja, int lastColumn)
        {
            for (int col = 1; col <= lastColumn; col++)
            {
                hoja.Column(col).AutoFit();
            }
        }

        public void PreparaEncabezado(ExcelWorksheet hoja, int firstRow, int firstColumn, int lastRow, int lastColumn, Color colorFuente, string colorFondoEnHexadecimal)
        {
            var encabezados = hoja.Cells[firstRow, firstColumn, lastRow, lastColumn];
            encabezados.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            encabezados.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            encabezados.Style.Font.Bold = true;
            encabezados.Style.Font.Color.SetColor(colorFuente);
            encabezados.Style.Fill.PatternType = ExcelFillStyle.Solid;
            encabezados.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(colorFondoEnHexadecimal));
        }

        public void SimulaTabla(ExcelWorksheet hoja, int firstRow, int firstColumn, int lastRow, int lastColumn, ExcelBorderStyle estiloBorde, Color colorBorde)
        {
            var cellsTabla = hoja.Cells[firstRow, firstColumn, lastRow, lastColumn];
            //cells.Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            cellsTabla.Style.Border.Top.Style = estiloBorde;
            cellsTabla.Style.Border.Bottom.Style = estiloBorde;
            cellsTabla.Style.Border.Left.Style = estiloBorde;
            cellsTabla.Style.Border.Right.Style = estiloBorde;

            cellsTabla.Style.Border.Top.Color.SetColor(colorBorde);
            cellsTabla.Style.Border.Bottom.Color.SetColor(colorBorde);
            cellsTabla.Style.Border.Left.Color.SetColor(colorBorde);
            cellsTabla.Style.Border.Right.Color.SetColor(colorBorde);
        }

        public (int, int) DeterminarUltimaFila_Y_Columna(ExcelWorksheet hoja)
        {
            int lastRow = hoja.Dimension.End.Row;
            int lastColumn = hoja.Dimension.End.Column;

            return (lastRow, lastColumn);
        }

        public void AgregarImagen(ExcelWorksheet hoja, string nombreImagen, string pathLogo, int Row, int RowOffsetPixels, int Column, int ColumnOffsetPixels, int imageWidth, int imageHeight)
        {
            Image image = Image.FromFile(pathLogo);
            var excelImage = hoja.Drawings.AddPicture(nombreImagen, image);
            excelImage.SetSize(imageWidth, imageHeight);
            //add the image to row 2, column E
            //excelImage.SetPosition(1, 0, 4, 0);
            excelImage.SetPosition(Row, RowOffsetPixels, Column, ColumnOffsetPixels);
        }
    }
}
