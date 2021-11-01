using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using DBConApp1.Models;
using DBConApp1.Entity;
using System;

namespace DBConApp1.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class UserService : IStudentService
    {
        private InformDbContext _context;
        private readonly IMapper _mapper;

        public UserService(
            InformDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(int id)
        {
            return getUser(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Students.Any(x => x.Email == model.Email))
                throw new ApplicationException("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = _mapper.Map<Student>(model);

            // save user
            _context.Students.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Email != user.Email && _context.Students.Any(x => x.Email == model.Email))
                throw new ApplicationException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            // if (!string.IsNullOrEmpty(model.Password))
            //     user.Id= BCryptNet.HashPassword(model.ConfirmPassword);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Students.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Students.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private Student getUser(int id)
        {
            var user = _context.Students.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        IEnumerable<Student> IStudentService.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Student IStudentService.GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}