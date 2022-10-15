using AuthenticationAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AuthenticationAPI.Repository
{
    public class MongoDBRepository
    {
        public bool ObterUsuario(Usuario usuario)
        {
            var isAuthenticated = false;
            MongoClient client = new MongoClient("mongodb+srv://heitorMourao:170990Bloco1@cluster0.gnod0kn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("usuarios");

            var filter = Builders<BsonDocument>.Filter.Eq("email", usuario.Email);
            var user = collection.Find(filter).FirstOrDefault();
            var usuarioConvertido = user.ToBsonDocument();
            if (usuario.Senha == usuarioConvertido["senha"].AsString){
                isAuthenticated = true;
            }
            else
            {
                isAuthenticated = false;
            }

            return isAuthenticated;
        }
    }
}
