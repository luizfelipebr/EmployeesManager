# Projeto

Desenvolver uma aplicação para administrar funcionários de uma empresa fictícia.

## Funcionalidades

>Buscar todos os funcionários

>Inserir um novo funcionário

>Atualizar um funcionário

>Deletar um funcionário


## Conceitos abordados

<ul>
<li>
<p>Trabalho com EntityFramework Core e InMemoryDatabase para a gestão do banco de dados em memória.</p>
</li>
<li>
<p>Identity Core para a gestão de contas de usuário (neste caso é o próprio Employee).</p>
</li>
<li>
<p>Container através do Docker.</p>
</li>
<li>
<p>Unit Of Work.</p>
</li>
<li>
<p>Cross Cutting - Inversão de Controle.</p>
</li>
</ul>


# Tecnologias

<ul>
<li>
<p>.Net Core 3.1</p>
</li>
<li>
<p>C#</p>
</li>
<li>
<p>Docker.</p>
</li>
</ul>


# Pré-requeisitos

>Docker

# Instalação e execução
Faça um clone desse repositório e acesse o diretório.

```bash
$ git clone https://github.com/luizfelipebr/employeesmanager.git && cd employeesmanager
```
```bash
# Executanto aplicação com o Docker
docker-compose build;docker-compose up -d
```

## Contribuir
Faça o fork e clone o projeto a partir do seu usuário.

```bash
# Clonando projeto
$ git clone https://github.com/SEU-NOME-DE-USUARIO/employeesmanager.git

# Criando um branch
$ git branch minha-alteracao

# Acessando o novo branch
$ git checkout -b minha-alteracao

# Adicionando os arquivos alterados
$ git add .

# Criando commit e a mensagem
$ git commit -m "Corrigindo...."

# Enviando alterações para o brach
$ git push origin minha-alteracao
```

## License
[MIT](https://choosealicense.com/licenses/mit/)