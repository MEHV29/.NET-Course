namespace Task6.Multithreading
{
    internal class PagesBuilder
    {
        static string GetNumberPages(string htmlContent)
        {
            string htmlOpenTag = $"<span itemprop=\"numberOfPages\">";
            string htmlCloseTag = $"</span>";

            int index = htmlContent.IndexOf(htmlOpenTag, StringComparison.OrdinalIgnoreCase);

            if (index != -1)
            {
                int endIndex = htmlContent.IndexOf(htmlCloseTag, index, StringComparison.OrdinalIgnoreCase);

                if (endIndex != 1)
                {
                    string extractedContent = htmlContent.Substring(index + htmlOpenTag.Length, endIndex - (index + htmlOpenTag.Length));
                    return extractedContent;
                }
                else
                {
                    throw new Exception("Close Tag not founded");
                }
            }
            else
            {
                return "NOT FOUND";
            }
        }

        static async Task DownloadHtmlAsync(string url, EBook eBook)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string htmlContent = await response.Content.ReadAsStringAsync();

                    eBook.Pages = GetNumberPages(htmlContent);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void BuildPages(Catalog<string, Book> catalog)
        {
            List<Task> tasks = new List<Task>();
            foreach (var catalogEntry in catalog.CatalogEntrys)
            {
                EBook eBook = catalogEntry.Value as EBook;
                tasks.Add(DownloadHtmlAsync(eBook.Id, eBook));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
