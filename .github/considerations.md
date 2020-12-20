# Considerações

O desenvolvimento do back-end prezou pelo baixo acoplamento, pela alta coesão e uso de padrões arquiteturais.
A fim de especificar a estrutura proposta seguem as considerações a cerca de:

## Models
- Entidades do mundo real.
- Data annotations.

## Resources
- Entidades responsáveis por especificar o formato de estruturas de dados a serem armazenados.

## Controllers
- Interceptam requests e entregam respostas em JSON a cliente HTTP.

## Helpers
- Utilitários para funcionalidades pontuais e internas do sistema.

## Services
- Responsáveis por features externas e de alto valor como a autenticação de usuário.
- Usou-se JWT.
- O envio de e-mail foi mockado.

## DataContext
- Classe responsável por setar as entidades do banco de dados. Abstração máxima e injetada como dependência de repositories.

## Repositories
- Realizam operações de banco de dados relativas à entidade a qual está relacionada.

## Contracts
- Interfaces do sistema. Especificam como uma classe deve se comportar.

Ao fim do desenvolvimento, tentei utilizar conceitos como Separation of Concerns e Dependency Injection.
Espero que gostem, caso haja qualquer sugestão de melhora, podem entrar em contato.
Será um prazer aprender cada vez mais!
