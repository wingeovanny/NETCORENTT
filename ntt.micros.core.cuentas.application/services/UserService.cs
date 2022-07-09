using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.services
{
    public class UserService : IUserService
    {

        private readonly IUserRestService  _userRestService;

        public UserService(IUserRestService userRestService)
        {
            _userRestService = userRestService;
        }


        public IEnumerable<User> GetAll()
        {
            return _userRestService.GetAll();
        }

        public User GetById(int id)
        {
            return _userRestService.GetById(id);
        }

        public void Create(CreateRequest model)
        {
            _userRestService.Create(model);
        }

        public void Update(int id, UpdateRequest model)
        {
            _userRestService.Update(id, model);
        }

        public void Delete(int id)
        {
            _userRestService.Delete(id);
        }

       

    }

}
