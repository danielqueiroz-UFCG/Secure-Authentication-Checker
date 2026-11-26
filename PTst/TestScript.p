
// Define os cenários de verificação formal do sistema de autenticação.
// Cada teste verifica o comportamento do sistema e monitora
// as propriedades globais de segurança.

// Teste 1: autenticação realizada com sucesso.
test tcValidLogin [main=TestValidLogin]:
    // Ativa os monitores responsáveis por verificar:
    // AccessControlSafety: segurança do controle de acesso.
    // LockoutSafety: segurança do mecanismo de bloqueio da conta.
    assert AccessControlSafety, LockoutSafety in

    // Combina o sistema de autenticação com a máquina
    // responsável por executar o cenário de login válido.
    (union AuthenticationSystem, { TestValidLogin });

// Teste 2: tentativa de acessar um recurso sem autenticação.
test tcUnauthenticatedAccess [main=TestUnauthenticatedAccess]:
    // Verifica se o sistema impede o acesso não autenticado.
    // Também monitora as condições de bloqueio da conta.
    assert AccessControlSafety, LockoutSafety in

    // Executa o servidor de autenticação junto ao driver de teste.
    (union AuthenticationSystem, { TestUnauthenticatedAccess });

// Teste 3: tentativa de autenticação com código TOTP inválido.
test tcInvalidTOTP [main=TestInvalidTOTP]:
    // Verifica se o MFA inválido não permite acesso indevido.
    // Mantém ativos os monitores de controle de acesso e bloqueio.
    assert AccessControlSafety, LockoutSafety in

    // Combina o sistema principal com o cenário de TOTP inválido.
    (union AuthenticationSystem, { TestInvalidTOTP });

// Teste 4: bloqueio da conta após tentativas inválidas.
test tcAccountLockout [main=TestAccountLockout]:
    // Verifica as propriedades de controle de acesso
    // e o comportamento seguro do bloqueio da conta.
    assert AccessControlSafety, LockoutSafety in

    // Executa o servidor junto ao cenário de três tentativas inválidas.
    (union AuthenticationSystem, { TestAccountLockout });

// Teste 5: encerramento de uma sessão autenticada.
test tcSessionTermination [main=TestSessionTermination]:
    // Verifica se o encerramento da sessão não permite
    // que o usuário continue acessando recursos protegidos.
    assert AccessControlSafety, LockoutSafety in

    // Combina o servidor com o cenário de encerramento da sessão.
    (union AuthenticationSystem, { TestSessionTermination });
