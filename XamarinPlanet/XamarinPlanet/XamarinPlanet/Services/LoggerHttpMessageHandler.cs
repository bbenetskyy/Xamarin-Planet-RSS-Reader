using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinPlanet.Services
{
    /// <summary>
    /// Class for logging the the http requests and response in DEBUG mode
    /// </summary>
    public class LoggerHttpMessageHandler : DelegatingHandler
    {
        #region Constructors
        /// <summary>
        /// Method to create the LoggerHttpMessageHandler for this class
        /// </summary>
        /// <param name="innerHandler">The inner http handler</param>
        public LoggerHttpMessageHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }
        #endregion Contructors

        #region Protected Methods
        /// <summary>
        /// The method used for intercepting request/response and logg them
        /// </summary>
        /// <param name="request">The request details</param>
        /// <param name="cancellationToken">The cancelation token</param>
        /// <returns></returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var st = new Stopwatch();
            try
            {
                st.Start();
                var res = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                st.Stop();
                await LogResponse(res, st.Elapsed).ConfigureAwait(false);
                return res;
            }
            catch (Exception ex)
            {
                st.Stop();
                await LogEx(request, ex, st.Elapsed)
                    .ConfigureAwait(false);
                throw ex;
            }
        }
        #endregion Protected Methods

        #region Private Methods
        /// <summary>
        /// Method Used to logg exception in the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ex"></param>
        /// <param name="elapsed"></param>
        /// <returns></returns>
        private async Task LogEx(HttpRequestMessage request, Exception ex, TimeSpan elapsed)
        {
            var sb = new StringBuilder();

            sb.AppendLine("\n--------------------");

            await AppendRequestLog(sb, request)
                .ConfigureAwait(false);

            sb.AppendLine("--------------------");

            AppendEllapsedTimeLog(sb, elapsed);

            sb.AppendLine("--------------------");

            AppendExceptionLog(ex, sb);

            sb.AppendLine("--------------------\n");

            Debug.WriteLine(sb.ToString());
        }
        /// <summary>
        /// Method used to logg response data
        /// </summary>
        /// <param name="response"></param>
        /// <param name="elapsed"></param>
        /// <returns></returns>
        private async Task LogResponse(HttpResponseMessage response, TimeSpan elapsed)
        {
            var sb = new StringBuilder();

            sb.AppendLine("\n--------------------");

            await AppendRequestLog(sb, response.RequestMessage)
                .ConfigureAwait(false);

            sb.AppendLine("--------------------");

            AppendEllapsedTimeLog(sb, elapsed);

            sb.AppendLine("--------------------");

            await AppendResponseLog(sb, response)
                .ConfigureAwait(false);

            sb.AppendLine("--------------------\n");


            Debug.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Method used to create output message details
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private static async Task AppendResponseLog(StringBuilder sb, HttpResponseMessage response)
        {
            sb.AppendLine(response.ToString());
            if (response.Content != null)
            {
                try
                {
                    var canLogContent = response.Content.Headers.TryGetValues("Content-Type", out IEnumerable<string> values)
                        && values.Any(c =>
                            c.StartsWith("application/json", StringComparison.Ordinal)
                            || c.StartsWith("application/x-www-form-urlencoded", StringComparison.Ordinal));

                    var body = "";
                    if (canLogContent)
                    {
                        body = await response.Content.ReadAsStringAsync()
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        body = "Body not allowed to be parsed";
                    }

                    sb.AppendLine($"BODY:\n{body}");
                }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
                catch (Exception)
                {
                }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
            }
        }

        /// <summary>
        /// Method used to append exception info
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="sb"></param>
        private static void AppendExceptionLog(Exception ex, StringBuilder sb)
        {
            sb.Append("Exception:\n");
            sb.AppendLine(ex.ToString());
        }

        /// <summary>
        /// Method used to append info about ellapsed time
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="elapsed"></param>
        private static void AppendEllapsedTimeLog(StringBuilder sb, TimeSpan elapsed)
        {
            sb.AppendLine($"Respond in: {elapsed.Milliseconds}ms");
        }

        /// <summary>
        /// Method used to append request details
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private static async Task AppendRequestLog(StringBuilder sb, HttpRequestMessage request)
        {
            sb.AppendLine(request.ToString());
            if (request.Content == null || request.Content.Headers.ContentType == null || request.Content.Headers.ContentType.MediaType == "multipart/form-data")
            {
                sb.AppendLine($"BODY: (null)");
                return;
            }

            var mediaType = request.Content.Headers.ContentType.MediaType;

            var body = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            sb.AppendLine($"BODY:\n{body}");
        }
        #endregion Private Methods
    }
}
