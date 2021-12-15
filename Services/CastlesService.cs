using System;
using System.Collections.Generic;
using knights_castles.Models;
using knights_castles.Repositories;

namespace knights_castles.Services
{
  public class CastlesService
  {
    private readonly CastlesRepository _repo;
    public CastlesService(CastlesRepository repo)
    {
      _repo = repo;
    }
    internal List<Castle> Get()
    {
      return _repo.GetAll();
    }

    internal Castle Create(Castle newCastle)
    {
      _repo.Create(newCastle);
      return newCastle;
    }
  }
}