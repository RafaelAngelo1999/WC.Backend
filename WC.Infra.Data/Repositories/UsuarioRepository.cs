using System;
using System.Collections.Generic;
using WC.Infra.Data.Entities;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Repositories
{
    public class UsuarioRepository
    {

        //public UsuarioEntity Create(UsuarioEntity usuarioEntity)
        //{
        //    usuarioEntity.Id = Guid.NewGuid();

        //    _clients.Add(usuarioEntity);

        //    return usuarioEntity;
        //}

        //public List<Client> Get()
        //{
        //    return _clients;
        //}

        //public Client GetById(Guid id)
        //{
        //    return _clients.SingleOrDefault(c => c.Id == id);
        //}

        //public void Delete(Client client)
        //{
        //    _clients.Remove(client);
        //}

        //public Client Edit(Client client)
        //{
        //    var existingClient = GetById(client.Id);
        //    existingClient.Nome = client.Nome;
        //    existingClient.Endereco = client.Endereco;
        //    existingClient.Celular = client.Celular;
        //    existingClient.Email = client.Email;
        //    existingClient.CPF = client.CPF;

        //    return existingClient;
        //}
    }
}
