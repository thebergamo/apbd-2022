using System.Text.RegularExpressions;

namespace Crawler
{
    class Program
    {
        private static Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

        public static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                ValidateInput(args);

                HttpResponseMessage response = await httpClient.GetAsync(args[0]);

                string pageContent = await response.Content.ReadAsStringAsync();

                MatchCollection foundEmails = emailRegex.Matches(pageContent);

                if (foundEmails.Count == 0)
                {
                    Console.WriteLine("E-mail addresses not found");
                    return;
                }

                var uniqueEmails = foundEmails.OfType<Match>().Select(m => m.Groups[0].Value).Distinct();

                foreach (var email in uniqueEmails)
                {
                    Console.WriteLine(email);
                }

            }
            catch (Exception err)
            {
                if (err is ArgumentNullException || err is ArgumentException)
                {
                    Console.Write(err.Message);
                } else
                {
                    Console.WriteLine($"Error while downloading the page. See error details: {err.Message}");
                }
                
            }
            finally
            {
                httpClient.Dispose();
            }

        }

        private static void ValidateInput(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException("URL is required and was not provided. Please provide URL for start the Cralwer");
            }

            string url = args[0];

            bool isURLValid = Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult);
            bool isURLSchemeValid = uriResult?.Scheme == Uri.UriSchemeHttps || uriResult?.Scheme == Uri.UriSchemeHttp;

            if (!isURLValid || !isURLSchemeValid)
            {
                throw new ArgumentException("Provided URL must be valid. Please verify the completeness of the provided URL and try again.");
            }
        }
    }
}