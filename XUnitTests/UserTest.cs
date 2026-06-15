using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using UserRegisterApi.Entities.Data;

namespace XUnitTests
{
    public class UserTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private const string GET_USER_URL = "https://localhost:7222/api/Users/GetUser";
        private const string ADD_USER_URL = "https://localhost:7222/api/Users/AddUser";

        public UserTest(WebApplicationFactory<Program> factory)
        {
            // Creates an in-memory HttpClient targeting the virtual API server
            _client = factory.CreateClient();
        }
        
        #region Test get user with empty data
        [Fact]
        public async Task Test_GetUser_Should_Return_Empty()
        {
            // Act
            var response = await _client.GetAsync(GET_USER_URL);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<List<User>>();
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        #endregion
        
        #region Test get user with existing data
        [Fact]
        public async Task Test_GetUser_Should_Return_OK()
        {
            // Arrange
            User user = new()
            {
                FirstName = "Suthee",
                LastName = "Srisan",
                Email = "Suthee@gmail.com",
                Phone = "0821234558",
                Profile = "Test_nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn",
                BirthDay = "10/05/2020",
                Occupation = "Freelancer",
                Sex = "Male"
            };
            JsonContent content = JsonContent.Create(user);

            // Act
            var output = await _client.PostAsync(ADD_USER_URL, content);
            var response = await _client.GetAsync(GET_USER_URL);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<List<User>>();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        #endregion
        
        #region Test add user with success created
        [Fact]
        public async Task Test_AddUser_Should_Return_OK()
        {
            // Arrange
            User user = new()
            {
                FirstName = "Somsuk",
                LastName = "Jaidee",
                Email = "Somsuk@gmail.com",
                Phone = "0821234567",
                Profile = "Test_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                BirthDay = "10/12/2020",
                Occupation = "Freelancer",
                Sex = "Male"
            };
            JsonContent content = JsonContent.Create(user);

            // Act
            var response = await _client.PostAsync(ADD_USER_URL, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<User>();
            Assert.NotNull(result);
            Assert.NotEqual(0, result.UserId);
        }
        #endregion
        
        #region Test add user with invalid data
        [Fact]
        public async Task Test_AddUser_Should_Return_BadRequest()
        {
            // Arrange
            User user = new()
            {
                FirstName = "Somsuk",
                LastName = "",
                Email = "Somsuk@gmail.com",
                Phone = "0821234567",
                Profile = "",
                BirthDay = "10/12/2020",
                Occupation = "Freelancer",
                Sex = "Male"
            };
            JsonContent content = JsonContent.Create(user);

            // Act
            var response = await _client.PostAsync(ADD_USER_URL, content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        #endregion
        
    }
}
