using GeradorUsuario.Domain.DTOs;
using GeradorUsuario.Domain.Interfaces;
using GeradorUsuario.Infra.ServicosExternos.RandomUser.DTOs;
using System.Text.Json;

namespace GeradorUsuario.Infra.ServicosExternos.RandomUser
{
    public class RandomRepository(HttpClient httpClient) : IRandomRepository
    {
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        public async Task<UsuarioInputDto> CreateRandomUser()
        {
            var response = await _httpClient.GetAsync("https://randomuser.me/api/");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Falha ao obter usuário aleatório da API.");
            }

            var contentString = await response.Content.ReadAsStringAsync();
            var userData = JsonSerializer.Deserialize<RandomUserApiResponse>(contentString);


            var randomUser = userData?.Results[0];
            if (randomUser == null)
            {
                throw new Exception("Nenhum usuário aleatório recebido da API.");
            }

            string nome = $"{randomUser.Name.First} {randomUser.Name.Last}";
            return new UsuarioInputDto(nome, randomUser.Email, randomUser.Login.Password);
        }
    }
}
