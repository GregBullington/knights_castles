using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights_castles.Models;

namespace knights_castles.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;
    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Castle> GetAll()
    {
      string sql = @"
      SELECT 
      castle.*,
      account.*
      FROM Castles castle
      JOIN accounts account ON castle.creatorId = account.id;";
      return _db.Query<Castle, Account, Castle>(sql, (castle, account) =>
      {
        castle.Creator = account;
        return castle;
      }, splitOn: "id").ToList();
    }
    internal Castle Create(Castle newCastle)
    {
      string sql = @$"
    INSERT INTO castles 
      (CastleName, Bedrooms, Bathrooms, Dungeon, ImgUrl, Description, CreatorId)
    VALUES
      (@CastleName, @Bedrooms, @Bathrooms, @Dungeon, @ImgUrl, @Description, @CreatorId)
      ;
    SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCastle);
      newCastle.Id = id;
      return newCastle;
    }
  }
}