# Secure Authentication Checker

Projeto experimental de verificação formal de autenticação com a linguagem P 2.x e PChecker.

## Escopo da versão inicial

- Login com credenciais válidas ou inválidas (abstraídas por eventos).
- Segundo fator TOTP abstrato: evento válido ou inválido.
- Bloqueio após 3 tentativas inválidas de senha.
- Controle de acesso a recurso protegido.
- Encerramento de sessão.
- Monitores de segurança para impedir concessões de acesso indevidas.

> **Limitação deliberada:** o modelo não calcula hashes, não armazena senhas e não gera códigos TOTP criptográficos. Os eventos `eSubmitValidTOTP` e `eSubmitInvalidTOTP` abstraem o resultado da validação do segundo fator. O objetivo é verificar o protocolo de controle de acesso, não a implementação criptográfica do RFC 6238.

## Estrutura

```text
SecureAuthenticationChecker/
├── SecureAuthenticationChecker.pproj
├── PSrc/
│   ├── AuthenticationEvents.p
│   ├── AuthenticationServer.p
│   └── AuthenticationModules.p
├── PSpec/
│   ├── AccessControlSafety.p
│   └── LockoutSafety.p
├── PTst/
│   ├── TestDriver.p
│   └── TestScript.p
├── PGenerated/              # criado pelo compilador
└── PCheckerOutput/           # criado pelo PChecker
```

## Requisitos no Windows

1. Instale o .NET SDK 8.0.
   - Download: https://dotnet.microsoft.com/download/dotnet/8.0
   - Verifique no PowerShell: `dotnet --list-sdks`
   - Deve aparecer uma versão `8.0.x`.

2. Instale Java 11 ou superior.
   - Download: https://www.java.com/
   - Verifique: `java -version`

3. Instale a ferramenta P globalmente:
   ```powershell
   dotnet tool install --global P
   ```

4. Feche e reabra o PowerShell. Verifique:
   ```powershell
   p --help
   ```

5. Opcional: instale Visual Studio Code e a extensão Peasy para realce de sintaxe e suporte ao desenvolvimento P.

Se `p` não for reconhecido, confirme se `%USERPROFILE%\.dotnet\tools` está no PATH do Windows. Depois, abra um novo terminal.

## Compilar

No PowerShell, entre na pasta raiz do projeto, onde está o arquivo `.pproj`:

```powershell
cd C:\caminho\para\SecureAuthenticationChecker
p compile
```

O compilador deve analisar os arquivos `.p` e gerar o projeto C#/.NET em `PGenerated`.

## Listar os testes

```powershell
p check
```

Como existem cinco cenários, o comando pode listar os nomes e pedir que seja escolhido um teste.

## Executar cada cenário

Execute, por exemplo:

```powershell
p check -tc tcValidLogin -s 100
p check -tc tcUnauthenticatedAccess -s 100
p check -tc tcInvalidTOTP -s 100
p check -tc tcAccountLockout -s 100
p check -tc tcSessionTermination -s 100
```

`-s 100` solicita 100 schedules/execuções exploradas pelo checker. Para uma exploração maior, aumente o número, por exemplo `-s 1000`.

## O que cada cenário verifica

| Teste | Sequência modelada | Resultado esperado |
|---|---|---|
| `tcValidLogin` | Credenciais válidas → TOTP válido → recurso | Acesso concedido |
| `tcUnauthenticatedAccess` | Solicitação direta de recurso | Acesso negado |
| `tcInvalidTOTP` | Credenciais válidas → TOTP inválido → recurso | Acesso negado |
| `tcAccountLockout` | 3 senhas inválidas → nova tentativa → recurso | Conta bloqueada; acesso negado |
| `tcSessionTermination` | Login válido → TOTP válido → logout → recurso | Acesso negado após logout |

## Monitores formais

### `AccessControlSafety`

Mantém duas variáveis observacionais:
- `credentialsOK`: credenciais válidas foram aceitas na sessão atual.
- `mfaOK`: o segundo fator foi validado na sessão atual.

Quando observa `eAccessGranted`, exige:

```text
credentialsOK && mfaOK
```

Quando observa `eSessionEnded`, reinicia as duas condições.

### `LockoutSafety`

Registra `eAccountLocked`. Depois desse evento, qualquer `eAccessGranted` viola a propriedade.

## Como interpretar os resultados

- **Build succeeded:** os arquivos foram aceitos pelo parser/type checker e o código foi gerado.
- **Found 0 bugs:** nenhum contraexemplo foi encontrado nos schedules explorados para aquele cenário.
- **Checker found a bug:** examine o trace em `PCheckerOutput` para identificar a sequência de eventos que violou uma propriedade.
- **Unhandled event / deadlock:** indica que o modelo ou o driver precisa ser ajustado.

Importante: zero bugs em um número limitado de schedules não equivale a uma prova de segurança de um sistema real. Registre a quantidade de schedules, versão do compilador, configuração e traces.

## Próximas extensões

1. Separar autenticação, MFA, gerenciamento de conta e controle de acesso em máquinas P independentes.
2. Modelar concorrência entre tentativas de login.
3. Modelar expiração e janela temporal do TOTP.
4. Integrar uma implementação real de TOTP em Python/C# e comparar sua interface com a abstração formal.
5. Adicionar propriedades de liveness, como resposta a solicitações legítimas.
