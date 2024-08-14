using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PI_E3_CURP.Utilidades
{
    internal class RestServices<TEntity> where TEntity : class, new()
    {
        static string tunnel = "1r7hmbzv";
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<TEntity> Items { get; private set; }
        public TEntity element { get; private set; }
        public RestServices()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        #region login rest service

        public async Task<TEntity> GetLoginAsyc(TEntity item, string Route)
        {
            element = new TEntity();
            //string uriBase = "https://" + strUri + ".ngrok-free.app" + uriDominio;
            //string uriBase = @"https://8h8j9cqn-7083.usw3.devtunnels.ms/" + Route;



            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;



            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;

            Uri uri = new Uri(uriBase);

            try
            {
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    element = JsonSerializer.Deserialize<TEntity>(responseJson, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return element;
        }
        #endregion
        #region Codigo Postal
        public async Task<List<TEntity>> getZipCode(TEntity item, string Route)
        {
            Items = new List<TEntity>();

            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;


            Uri uri = new Uri(uriBase);

            try
            {
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<TEntity>>(responseJson, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return Items;
        }
        #endregion
        #region Secure Post Services
        public async Task<TEntity> Post(TEntity item, string Route)
        {
            element = new TEntity();
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);

                //Parameters
                string json = JsonSerializer.Serialize(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    element = JsonSerializer.Deserialize<TEntity>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
        public async Task<TEntity> Post(TEntity item, string Route, string tkn, string abc)
        {
            element = new TEntity();
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);

                // Add the Authorization Bearer header. - add token
                message.Headers.Add("Authorization", $"Bearer {tkn}");
                //Parameters
                string json = JsonSerializer.Serialize(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    element = JsonSerializer.Deserialize<TEntity>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
        public async Task<List<TEntity>> Post(TEntity item, string Route, string tkn)
        {
            Items = new List<TEntity>();

            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;

            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);
                //Get Token


                // Add the Authorization Bearer header. - add token
                message.Headers.Add("Authorization", $"Bearer {tkn}");
                //Parameters
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    Items = JsonSerializer.Deserialize<List<TEntity>>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Items;
        }

        public async Task<List<TEntity>> Post<DTO>(DTO item, string Route, string tkn)
        {
            Items = new List<TEntity>();

            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;

            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);
                //Get Token


                // Add the Authorization Bearer header. - add token
                message.Headers.Add("Authorization", $"Bearer {tkn}");
                //Parameters
                string json = JsonSerializer.Serialize<DTO>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    Items = JsonSerializer.Deserialize<List<TEntity>>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Items;
        }

        public async Task<TEntity> Post(TEntity item, string Route, string tkn, int elem = 1)
        {
            element = new TEntity();
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);

                // Add the Authorization Bearer header. - add token
                message.Headers.Add("Authorization", $"Bearer {tkn}");
                //Parameters
                string json = JsonSerializer.Serialize(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    element = JsonSerializer.Deserialize<TEntity>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
        public async Task<TEntity> Post<DTO>(DTO item, string strPort, string controller, string tkn)
        {
            element = new TEntity();
            string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            string uriBase = uriAddress + strPort + "/" + controller;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);



                // Add the Authorization Bearer header. - add token
                message.Headers.Add("Authorization", $"Bearer {tkn}");
                //Parameters
                string json = JsonSerializer.Serialize<DTO>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    element = JsonSerializer.Deserialize<TEntity>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
        public async Task<bool> Post(TEntity item, string Route, string tkn, bool itsBool = true)
        {
            bool exito = false;
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Post, uriBase);
                //Get Token


                // Add the Authorization Bearer header. - add token
                message.Headers.Add("Authorization", $"Bearer {tkn}");
                //Parameters
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //AddressBook params
                message.Content = content;
                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    exito = JsonSerializer.Deserialize<bool>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return exito;
        }


        #endregion
        #region Secure Get Services
        public async Task<List<TEntity>> Get(string Route)
        {
            Items = new List<TEntity>();
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Get, uriBase);
                //Get Token

                //string tkn = Preferences.Get("tkn", "");
                // Add the Authorization Bearer header. - add token
                //message.Headers.Add("Authorization", $"Bearer {tkn}");

                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    Items = JsonSerializer.Deserialize<List<TEntity>>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Items;
        }


        public async Task PutOrPost(TEntity item, string Route, bool isNewItem)
        {
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            //Uri uri = new Uri(uriBase);
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await _client.PostAsync(uriBase, content);
                else
                    response = await _client.PutAsync(uriBase, content);

                //if (response.IsSuccessStatusCode)
                //Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task Delete(TEntity item, string Route)
        {
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            //Uri uri = new Uri(uriBase);
            string uriBase = "https://" + tunnel + "-7294.usw3.devtunnels.ms/" + Route;
            try
            {
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await _client.PostAsync(uriBase, content);

                //if (response.IsSuccessStatusCode)
                //Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        #endregion
        #region Security Put Service
        public async Task Put(TEntity item, string strPort, string controller)
        {
            string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            string uriBase = uriAddress + strPort + "/" + controller;
            Uri uri = new Uri(uriBase);

            try
            {
                string json = JsonSerializer.Serialize<TEntity>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PutAsync(uri, content);

                //if (response.IsSuccessStatusCode)
                //Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        #endregion


        #region BrandModelCar
        public async Task<TEntity> GetCarBrand()
        {
            element = new TEntity();
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = @"https://data.opendatasoft.com/api/records/1.0/search/?sort=modifiedon&rows=0&facet=make&dataset=all-vehicles-model@public&timezone=America%2FGuatemala&lang=en";
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Get, uriBase);
                //Get Token

                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    element = JsonSerializer.Deserialize<TEntity>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
        public async Task<TEntity> GetCarModel(string parameters)
        {
            element = new TEntity();
            //string uriAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:" : "http://localhost:";
            //string uriBase = uriAddress + strPort + "/" + controller;
            string uriBase = "https://public.opendatasoft.com/api/explore/v2.1/catalog/datasets/all-vehicles-model/records?limit=100" + parameters;
            try
            {
                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();
                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Get, uriBase);
                //Get Token

                // Send the request.
                var response = await client.SendAsync(message).ConfigureAwait(false);
                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                // Return the response.                
                if (response.IsSuccessStatusCode)
                {
                    element = JsonSerializer.Deserialize<TEntity>(responseString, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
        #endregion
    }
}
