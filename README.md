# WC.Backend

## Arquitetura do projeto

A estrutura utilizada para a implementação da captura dos dados está disposta em 4 camadas não lineares: web crawler, API, web scraper e banco de dados. Onde as informações dos produtos foram coletadas no e-commerce da Havan, durante o segundo semestre de 2021. A arquitetura foi desenvolvida a partir do paradigma do DDD (Domain Driven Design) no qual a aplicação é orientada ao domínio, baseado em um conjunto de ideias, conhecimentos e processos de negócios. Tendo como pontos positivos:  

- Acoplamento mínimo: Por meio de modelos cuidadosamente elaborados e organizados, várias partes do sistema interagem, e não há muita dependência entre módulos ou classes de objetos de diferentes conceitos;
- Facilidade na reutilização de código: os blocos de construção que veremos mais tarde tornam mais fácil usar o mesmo conceito de domínio ou o mesmo código em vários lugares;
- Independência de tecnologia: não se concentra na tecnologia, mas no entendimento das regras de negócios e como elas devem ser refletidas nos modelos de código e domínio.;

Fluxo da aplicação utilizada
![](/assets/image1.png)
Fonte: Criado pelo autor

Foi feito um banco relacional utilizando o Entity Framework (2021), uma estrutura de mapeamento objeto-relacional (ORM) de código aberto para aplicativos .NET, permitiu que fosse trabalhados os dados usando objetos de classes específicas de domínio sem se concentrar nas tabelas e colunas do banco de dados subjacentes onde esses dados são armazenados. Desse modo, trabalhando em um nível mais alto de abstração ao lidar com dados e podem criar e manter aplicativos orientados a dados com menos código em comparação com os aplicativos tradicionais. Foi utilizado o método de code-first (2021), no qual toda a estrutura relacional de banco é desenvolvida a partir das classes criadas na aplicação gerando assim um script de criação de banco e atualizações.

## Estruturação do serviço utilizado para extração de dados: 

A API e os serviços de crawler e scraping foram escritos em .NET Core 5 implementando os conceitos de REST, pois assim, independente das tecnologias usadas pelos demais serviços, a API poderá ser acessada por todos com base nesse padrão. A captura das URLs dos produtos foram feitas através desta API, que está incumbida de realizar o controle das operações tanto de captura, quanto de manipulação de dados no banco, neste caso, a mesma recebe como parâmetro o nome do produto e a loja online da varredura e por meio do web crawling é possível estruturar um objeto com todos os links dos produtos analisados ficando responsável por rastrear e indexar as páginas dos produtos e salvar a mesma no banco de dados. O funcionamento se dá através das seguintes imagens (Figura 3):

## Resultados

Foram coletados através da aplicação disponível no repositório https://bit.ly/AplicacaoWebCrawler, realizada de acordo com as métricas levantadas. O dashboard desses dados estão publicados em https://bit.ly/DashboardWebCrawler, onde  foram extraídos no total de 6281 produtos de 18 marcas distintas.


