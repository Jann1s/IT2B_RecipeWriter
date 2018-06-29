using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace RecipeManagerApp.Helper
{
    class PDFProcessor
    {
        public PDFProcessor()
        {

        }

        public async void ExportAsync(Recipe r, ObservableCollection<Ingredient> ingredients)
        {

            //Create a new PDF document.

            PdfDocument document = new PdfDocument();

            //Add a page to the document.

            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.

            PdfGraphics graphics = page.Graphics;

            //Set the standard font.

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text.

            graphics.DrawString("Recipe", font, PdfBrushes.Black, 0, 0);

            graphics.DrawString(r.title, font, PdfBrushes.Black, 0, 20);

            graphics.DrawString(r.description, font, PdfBrushes.Black, 0, 40);

            int counter = 75;
            foreach (Ingredient i in ingredients)
            {
                graphics.DrawString(i.Name, font, PdfBrushes.Black, 0, counter);

                graphics.DrawString(i.Amount.ToString(), font, PdfBrushes.Black, 20, counter);

                graphics.DrawString(i.Unit.Unit.ToString(), font, PdfBrushes.Black, 40, counter);

                counter += 25;
            }

            //Save the document.

            MemoryStream stream = new MemoryStream();

            await document.SaveAsync(stream);

            //Close the documents

            document.Close(true);

            //Save the stream as PDF document file in local machine

            Save(stream, "Result.pdf");

            //Close the document.

            document.Close(true);

        }

        public async void exportShoppingListAsync(ShoppingList sl, ObservableCollection<Recipe>recipes)
        {
            //Create a new PDF document.

            PdfDocument document = new PdfDocument();

            //Add a page to the document.

            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.

            PdfGraphics graphics = page.Graphics;

            //Set the standard font.

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text.

            graphics.DrawString("Shopping List", font, PdfBrushes.Black, 0, 0);

            graphics.DrawString(sl.id.ToString(), font, PdfBrushes.Black, 0, 20);

            graphics.DrawString(sl.date.ToLongDateString(), font, PdfBrushes.Black, 0, 40);

            int counter = 60;
            foreach (Recipe r in recipes)
            {
                graphics.DrawString(r.title, font, PdfBrushes.Black, 0, counter);
                graphics.DrawString("Ingredients:", font, PdfBrushes.Black, 0, counter + 20);
                foreach (Ingredient i in r.ingredients)
                {

                    graphics.DrawString(i.Name, font, PdfBrushes.Black, 0, counter+40);

                    graphics.DrawString(i.Amount.ToString(), font, PdfBrushes.Black, 7+(i.Name.Length * 10), counter+40);

                    graphics.DrawString(i.Unit.Unit.ToString(), font, PdfBrushes.Black, (i.Amount.ToString().Length * 20) + 50, counter+40);

                    counter += 50;
                }
                counter += 50;
            }

            //Save the document.

            MemoryStream stream = new MemoryStream();

            await document.SaveAsync(stream);

            //Close the documents

            document.Close(true);

            //Save the stream as PDF document file in local machine

            Save(stream, "Result.pdf");

            //Close the document.

            document.Close(true);
        }

        async void Save(Stream stream, string filename)
        {

            stream.Position = 0;

            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".pdf";
                savePicker.SuggestedFileName = "Sample";
                savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                stFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }
            if (stFile != null)
            {
                Windows.Storage.Streams.IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                Stream st = fileStream.AsStreamForWrite();
                st.Write((stream as MemoryStream).ToArray(), 0, (int)stream.Length);
                st.Flush();
                st.Dispose();
                fileStream.Dispose();
            }
        }
    }
}
