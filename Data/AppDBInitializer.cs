using ConectaCliente.Models;

namespace ConectaCliente.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();

                if (context == null) throw new Exception("Context not found");

                context.Database.EnsureCreated();

                if (!context.Clientes.Any())
                {
                    string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Imagens");

                    // Método auxiliar para carregar imagens
                    byte[] LoadImage(string fileName)
                    {
                        string filePath = Path.Combine(basePath, fileName);
                        if (File.Exists(filePath))
                        {
                            return File.ReadAllBytes(filePath);
                        }
                        throw new FileNotFoundException($"Arquivo não encontrado: {filePath}");
                    }

                    // Carregamento das imagens
                    byte[] foto1 = LoadImage("clarice.jpg");
                    byte[] foto2 = LoadImage("jorgeamado.jpg");                   


                    if (!context.Clientes.Any())
                    {

                        context.Clientes.AddRange(new List<Cliente>
                    {
                        new Cliente 
                        {
                            FotoCliente = foto1,
                            Nome = "Clarice Lispector",
                            Email = "claricelispector@editoraatlas.com.br",
                            DataNascimento = new DateTime(1960, 12, 10),
                            Sexo = "Feminino",
                            Logradouro = "Avenida das Nações",
                            Numero = 123,
                            Complemento = "Apto 113",
                            Bairro = "Ipanema",                           
                            Cidade = "Rio de Janeiro",
                            Estado = "RJ",
                            CEP = "01340812",                            
                            
                        },
                        new Cliente
                        {
                            FotoCliente = foto2,
                            Nome = "Jorge Amado",
                            Email = "jorgeamado@editoraexame.com.br",
                            DataNascimento = new DateTime(1955, 06, 05),
                            Sexo = "Masculino",
                            Logradouro = "Rua Augusta",
                            Numero = 1100,
                            Complemento = "Apto 36",
                            Bairro = "Consolação",
                            Cidade = "São Paulo",
                            Estado = "SP",
                            CEP = "01130876",
                        },
                        
                        });

                        context.SaveChanges();


                    }
                }
            }
        }
    }
}

 
