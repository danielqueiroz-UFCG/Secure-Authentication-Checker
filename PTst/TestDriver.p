
// Máquina responsável por simular uma autenticação válida.
machine TestValidLogin
{
    // Referência para a instância do servidor de autenticação.
    var auth: AuthenticationServer;

    // Estado inicial da máquina de teste.
    start state Init
    {
        // Entry é executado automaticamente quando a máquina
        // entra no estado Init.
        entry
        {
            // Cria uma nova instância do servidor de autenticação.
            auth = new AuthenticationServer();

            // Envia um evento indicando credenciais válidas.
            send auth, eSubmitValidCredentials;

            // Envia um evento indicando um código TOTP válido.
            send auth, eSubmitValidTOTP;

            // Solicita acesso a um recurso protegido.
            send auth, eRequestProtectedResource;
        }
    }
}
