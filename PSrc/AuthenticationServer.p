
// Máquina responsável por testar o acesso sem autenticação.
machine TestUnauthenticatedAccess
{
    // Armazena a referência ao servidor de autenticação.
    var auth: AuthenticationServer;

    // Estado inicial do cenário.
    start state Init
    {
        // Executa as operações iniciais do teste.
        entry
        {
            // Cria uma nova instância do servidor.
            auth = new AuthenticationServer();

            // Solicita acesso diretamente, sem fornecer credenciais
            // e sem realizar a validação do segundo fator.
            send auth, eRequestProtectedResource;
        }
    }
}
