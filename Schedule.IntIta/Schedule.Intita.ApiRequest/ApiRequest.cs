using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Schedule.Intita.ApiRequest.Enumerations;
using Microsoft.Extensions.Configuration;
using Schedule.IntIta.Domain.Models;


namespace Schedule.Intita.ApiRequest
{
    public class ApiRequest<TResponse>
    {
        private string _requestUri;
        private string _requestBody;
        private RequestType _httpMethod;
        private ContentTypes _contentType = ContentTypes.ApplicationJson;
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        private AuthenticationConfig _authenticationConfig;

        public IConfiguration Configuration { get; set; }
        
        public ApiResponse<TResponse> Send()
        {
            ValidateForSend();

            var response = new ApiResponse<TResponse>();
            var httpRequest = (HttpWebRequest)WebRequest.Create(_requestUri);

            httpRequest.Method = _httpMethod.ToString().ToUpper();

            if (_httpMethod == RequestType.Get)
            {
                httpRequest.ContentType = _contentType.GetDisplayText();
                if (_requestBody != null)
                {
                    var requestData = Encoding.ASCII.GetBytes(_requestBody);
                    var requestDataLength = requestData.Length;

                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(requestData, 0, requestDataLength);
                    }
                }
                else
                {
                    httpRequest.ContentLength = 0;
                }

                if (_authenticationConfig != null)
                {
                    _headers.Add("Authorization", GetAccessToken());
                }

                foreach (var header in _headers)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }

                string responseString = string.Empty;

                try
                {
                    var webResponse = (HttpWebResponse) httpRequest.GetResponse();

                    using (var streamReader =
                        new StreamReader(webResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        responseString = streamReader.ReadToEnd();
                    }

                    response.ContentAsString = responseString;
                    response.StatusCode = int.Parse(webResponse.StatusCode.ToString("D"));
                    response.Response = JsonConvert.DeserializeObject<TResponse>(responseString);
                    response.IsDeserializeSuccess = response.Response != null;
                }
                catch (WebException)
                {
                    Console.WriteLine("Error, please check 'AccessToken' in appsettings.json.");
                    Console.WriteLine($"ResponseString: {responseString}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, please check 'AccessToken' in appsettings.json.");
                    Console.WriteLine($"ResponseString: {responseString}");
                }
            }
            
            return response;
        }

        private string GetAccessToken()
        {
            //TODO: Connect oAuth2, when it was implement
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjA4ZTQ5OWM2NTQyNmViOGJkODg2Mzc1MGM4NWUyZjUxODcyN2U5MTFjYzMyYjA4MGZiNGM0N2Y4NTU4OWE2ZThiODJkMDI2OTg3Y2NmOTViIn0.eyJhdWQiOiIyMiIsImp0aSI6IjA4ZTQ5OWM2NTQyNmViOGJkODg2Mzc1MGM4NWUyZjUxODcyN2U5MTFjYzMyYjA4MGZiNGM0N2Y4NTU4OWE2ZThiODJkMDI2OTg3Y2NmOTViIiwiaWF0IjoxNTE4OTU2ODg0LCJuYmYiOjE1MTg5NTY4ODQsImV4cCI6MTU1MDQ5Mjg4NCwic3ViIjoiNzY5Iiwic2NvcGVzIjpbXX0.xITUt1Da5_PQdLDHFpkIcsUIZw77byQs9mOlKTeVrdye7VaaxV8qwQC7K2QZfA-yivjNBr4qxZyO7IWCN2AsWH-SCGmSwm-uV2CzFHZuanAXmAVywHuePW_FWR5NzZagbf6_j77FXyJzuW2is74iZXtNLEt0alFkNPk0tLhQT6CsclZ6ee-Ij3YAVGOYnolLaQYd1BqaMDgbMjreQLX017-kTIVVutnBa7d2bLyYTyg97XNWhFFRW8wiYJLakeRExAENTOHzrZdckALXTXeVYaA-IvvxrpyAtxhAkSkpGYb0f_gsLBEaw3CMb3O-4_8X5eHDRkCc_M4qMp6p-bxvjW31_nJizpP5i-zYKy0GzSF1cog1XhAeZL_lGsVQwIUcs5YgRaZFkzGbTJqNbfM36QrrdoX6NpzUD_bTYhq4gMT4xYaSSm2i4sJnOZ1G1uqm_AollvrMOIIie8iNxlQK7kuVKlShuUflHieSFeub3OXthcxn_DPFMxyGyCKgsFhs8Z9BogyMF7dtUEvyENgEZZKYTLGyWQDvd-FkJ5eOI9zrG_KIL1iflrwJZOz0ZHaBpfuvOoCLxWDeosWKFqFq-H2NBA8x8oryzIqJ2MXw1C-OR73gKKTjMFZOm1P40_8m-RJQVZ-IKbqfSrG3842QxSElO01KsRzXm3VBFUxZXaY";
            //return Configuration["AccessToken"];
        }

        public ApiRequest<TResponse> Authenticate(AuthenticationConfig config)
        {
            _authenticationConfig = config.Copy();
            return this;
        }

        public ApiRequest<TResponse> Authenticate()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            _authenticationConfig = new AuthenticationConfig()
            {
                AuthUrl = Configuration["AuthUrl"],
                TokenUrl = Configuration["TokenUrl"],
                ClientId = Configuration["ClientId"],
                ClientSecret = Configuration["ClientSecret"]
            };
            
            return this;
        }

        private void ValidateForSend()
        {
            string validationError = String.Empty;
            if (_requestUri == String.Empty)
            {
                validationError += "Url is empty. ";
            }
            if (_httpMethod == RequestType.Post && _requestBody == null)
            {
                validationError += "Body is empty. ";
            }
            if (validationError != String.Empty)
            {
                throw new ValidationException(validationError);
            }
        }

        public string GetHeaders()
        {
            var result = String.Empty;
            foreach (var header in _headers)
            {
                if (header.Key == "Authorization")
                    continue;

                result += $"{header.Key} {header.Value}{Environment.NewLine}";
            }
            return result;
        }

        public ApiRequest<TResponse> AddHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }

        public ApiRequest<TResponse> ContentType(ContentTypes type)
        {
            _contentType = type;
            return this;
        }

        public ApiRequest<TResponse> Body(string jsonString)
        {
            _requestBody = jsonString;
            return this;
        }

        public ApiRequest<TResponse> Body(object o)
        {
            _requestBody = JsonConvert.SerializeObject(o);
            return this;
        }

        public ApiRequest<TResponse> Url(string url)
        {
            _requestUri = url;
            return this;
        }

        public ApiRequest<TResponse> Get()
        {
            _httpMethod = RequestType.Get;
            return this;
        }

        public ApiRequest<TResponse> Delete()
        {
            _httpMethod = RequestType.Delete;
            return this;
        }

        public ApiRequest<TResponse> Post()
        {
            _httpMethod = RequestType.Post;
            return this;
        }

        public ApiRequest<TResponse> Put()
        {
            _httpMethod = RequestType.Put;
            return this;
        }
    }
}
