using SQLite;
using _1TheDebtBook.Models;

namespace _1TheDebtBook.Data
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;
        public Database()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "DeptBook.db");

            //string _dbEncryptionKey = SecureStorage.GetAsync("dbEncryptionKey").Result;

            //if(string.isnullorempty(_dbencryptionkey))
            //{
            //    guid g = guid.newguid();
            //    _dbencryptionkey = g.tostring();
            //    securestorage.setasync("dbencryptionkey", _dbencryptionkey);
            //}
            var dbOptions = new SQLiteConnectionString(databasePath, true);

            _connection = new SQLiteAsyncConnection(dbOptions);
            _ = Initialise();
        }
        private async Task Initialise()
        {
            await _connection.CreateTableAsync<Debtor>();
        }
        public async Task<List<Debtor>> GetDebtors()
        {
            return await _connection.Table<Debtor>().ToListAsync();
        }
        public async Task<Debtor> GetDebtor(int id)
        {
            var query = _connection.Table<Debtor>().Where(t => t.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<int> AddDebtor(Debtor item)
        {
            return await _connection.InsertAsync(item);
        }
        public async Task<int> DeleteDebtor(Debtor item)
        {
            return await _connection.DeleteAsync(item);
        }
        public async Task<int> UpdateDebtor(Debtor item)
        {
            return await _connection.UpdateAsync(item);
        }
    }
}