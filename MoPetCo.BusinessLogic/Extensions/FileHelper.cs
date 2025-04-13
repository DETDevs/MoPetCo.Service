using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;


namespace MoPetCo.BusinessLogic.Extensions
{
    public class FileHelper
    {
        private readonly MoPetCo.Extensions.CustomValuesConfiguration _customValuesConfiguration;

        public FileHelper(MoPetCo.Extensions.CustomValuesConfiguration? customValuesConfiguration)
        {
            _customValuesConfiguration = customValuesConfiguration;
        }

        public async Task<string> UploadFile(Stream file, string name)
        {
            var FirebaseConfig = _customValuesConfiguration.GetCustomValueByName("FirebaseService");
            var email = FirebaseConfig.Values["email"];
            var password = FirebaseConfig.Values["password"];
            var projectUrl = FirebaseConfig.Values["projectUrl"];
            var authDomain = FirebaseConfig.Values["authDomain"];
            var api_key = FirebaseConfig.Values["apiKey"];

            // Configurar el cliente de autenticación
            var config = new FirebaseAuthConfig
            {
                ApiKey = api_key,
                AuthDomain = authDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            var authClient = new FirebaseAuthClient(config);
            var authResult = await authClient.SignInWithEmailAndPasswordAsync(email, password);

            var cancellation = new CancellationTokenSource();

            // Configurar Firebase Storage
            var task = new FirebaseStorage(
                projectUrl,
                new FirebaseStorageOptions
                {
                    //AuthTokenAsyncFactory = () => Task.FromResult(authResult.User.Credential.IdToken),
                    AuthTokenAsyncFactory = async () => await authClient.User.GetIdTokenAsync(),
                    ThrowOnCancel = true
                })
                .Child("Galeria")
                .Child(name)
                .PutAsync(file, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
        }
    }
}
