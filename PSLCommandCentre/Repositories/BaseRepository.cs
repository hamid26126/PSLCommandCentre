using MySql.Data.MySqlClient;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre.Repositories
{
    public abstract class BaseRepository
    {
        // Every repository gets a fresh connection through this
        protected MySqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }
    }
}