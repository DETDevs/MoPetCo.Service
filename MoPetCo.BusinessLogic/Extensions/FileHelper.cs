using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;


namespace MoPetCo.BusinessLogic.Extensions
{
    public class FileHelper
    {
        public async Task<string> UploadFile(Stream file, string name)
        {
            string email = "";
            string clave = "";
            string ruta = "";
            string api_key = "";

            // Configurar el cliente de autenticación
            var config = new FirebaseAuthConfig
            {
                ApiKey = api_key,
                AuthDomain = "",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            var authClient = new FirebaseAuthClient(config);
            var authResult = await authClient.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();

            // Configurar Firebase Storage
            var task = new FirebaseStorage(
                ruta,
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
