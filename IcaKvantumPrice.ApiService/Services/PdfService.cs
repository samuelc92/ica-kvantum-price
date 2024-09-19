using IcaKvantumPrice.ApiService.Database;
using IcaKvantumPrice.ApiService.Shoppings;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IcaKvantumPrice.ApiService.Services;

public class PdfService(DatabaseContext database) : IPdfService
{
    public async Task AddShoppingsFromFile(string pdfPath)
    {
        var shoppings = FetchShoppings(pdfPath);
        foreach (var shopping in shoppings)
            database.Shoppings.Add(shopping);
        await database.SaveChangesAsync();
    }

    private ICollection<Shopping> FetchShoppings(string pdfPath)
    {
        var pdfDoc = new PdfDocument(new PdfReader(pdfPath));
        var response = new List<Shopping>();

        var fullText = "";
        for (int pageNumber = 1; pageNumber <= pdfDoc.GetNumberOfPages(); pageNumber++)
        {
            fullText += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNumber), new SimpleTextExtractionStrategy());
        }

        // Close the PDF document
        pdfDoc.Close();

        // Define a regex pattern to match the product lines and the date
        var productPattern = @"^(.+?)\s+(\d{13,})\s+([\d,]+\.\d{2})\s+\d+\sst\s+([\d,]+\.\d{2})$";
        var datePattern = @"Datum:\s(\d{4}-\d{2}-\d{2})";

        var productRegex = new Regex(productPattern, RegexOptions.Multiline);
        var dateRegex = new Regex(datePattern);

        // Find the date in the extracted text
        var dateMatch = dateRegex.Match(fullText);
        var purchaseDate = dateMatch.Success ? dateMatch.Groups[1].Value : "Date not found";

        // Find matches for product lines in the extracted text
        var productMatches = productRegex.Matches(fullText);

        foreach (Match match in productMatches)
        {
            var description = match.Groups[1].Value;
            var productIdentifier = match.Groups[2].Value;
            var price = match.Groups[3].Value;
            var date = DateTime.Parse(purchaseDate);

            response.Add(new Shopping
            {
                ProductIdentifier = productIdentifier,
                Description = description,
                Price = Double.Parse(price, NumberStyles.Float, CultureInfo.InvariantCulture),
                ShoppingDate = DateTime.Parse(purchaseDate).ToUniversalTime()
            });
        }

        return response;
    }
}
