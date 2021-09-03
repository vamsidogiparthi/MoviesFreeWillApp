﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MoviesWebAPI.Data.Common.Dtos;
using MoviesWebAPI.Data.Datalayer.EntityContext;
using MoviesWebAPI.Data.Datalayer.Models;
using MoviesWebAPI.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesWebAPI.Data.Repository.Persistance
{
    public class GetUsersRepository : IGetUsersRepository
    {
        private readonly MoviesAppContext _context;
        private readonly IMapper _mapper;

        public GetUsersRepository(MoviesAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var query = _context.Users.AsQueryable();

            return await GetUserDtos(query);
        }

        public async Task<UserDto> GetUsersByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                var user = _context.Users.Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.FirstName + " " + user.LastName
                }).FirstOrDefault(x => x.Id == id);

                return user;
            });
        }

        private async Task<IEnumerable<UserDto>> GetUserDtos(IQueryable<User> users)
        {
            return await Task.Run(() =>
            {
                return (from user in users
                        select new UserDto
                        {
                            Id = user.Id,
                            Name = user.FirstName + " " + user.LastName
                        }).ToList();

            });

        }
    }
}
