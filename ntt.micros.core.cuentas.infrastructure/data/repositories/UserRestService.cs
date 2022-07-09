using AutoMapper;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.models.exeptions;
using ntt.micros.core.cuentas.domain.entities;
using ntt.micros.core.cuentas.infrastructure.data.Context;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class UserRestService : IUserRestService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public UserRestService( DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = model.Password;// BCrypt.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = model.Password;// BCrypt.Net.HashType.SHA256(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
