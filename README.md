## EstacionamentoTesteLogica

Este projeto é uma aplicação de controle de estacionamento desenvolvida em C#. O sistema permite registrar a entrada e saída dos veículos, calcular o tempo e o valor cobrado com base em uma tabela de preços configurável, e possui uma interface desktop para facilitar o uso.

## Funcionalidades

- **Registro de Entrada e Saída**: Permite registrar a entrada e saída dos veículos utilizando a placa como chave de busca.
- **Tabela de Preços**: Parametrização dos valores praticados pelo estacionamento com controle de vigência.
- **Cálculo de Tempo e Valor Cobrado**: Calcula o tempo total de permanência e o valor a ser cobrado com base na tabela de preços.
- **Tolerância de Tempo**: Inclui uma tolerância de 10 minutos para cada hora adicional.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET
- **Banco de Dados**: SQLite
- **IDE**: Visual Studio

## Exemplo de Tabela de Preços
- **Período de Vigência**: 01/01/2024 a 31/12/2024
- **Valor da Hora Inicial**: R$ 2,00
- **Valor da Hora Adicional**: R$ 1,00
- **Exemplos de Cálculo**:
  30 minutos: R$ 1,00
  1 hora: R$ 2,00
  1 hora e 10 minutos: R$ 2,00
  1 hora e 15 minutos: R$ 3,00
  2 horas e 5 minutos: R$ 3,00
  2 horas e 15 minutos: R$ 4,00

## Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/CleitonSilvaPaes/EstacionamentoTesteLogica.git
   cd EstacionamentoTesteLogica
](https://github.com/CleitonSilvaPaes/EstacionamentoTesteLogica)

2. Abra a solução no Visual Studio.
   
3. Compile o projeto:
    ```bash
    dotnet build

5. Execute o projeto:
    ```bash
    dotnet run
