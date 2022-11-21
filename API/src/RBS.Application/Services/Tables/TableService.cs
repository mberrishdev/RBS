using Common.Repository.Repository;
using RBS.Application.Models.TableMdels;
using RBS.Domain.Tables;

namespace RBS.Application.Services.Tables
{
    public class TableService : ITableService
    {
        private readonly IQueryRepository<Table> _queryRepository;
        //TODO:ADD CONTACT INFO
        public TableService(IQueryRepository<Table> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<TableModel> GetById(int id, CancellationToken cancellationToken)
        {
            var table = await _queryRepository.GetAsync(predicate: x => x.Id == id, cancellationToken: cancellationToken);
            if (table == null)
                return null;

            return new TableModel(table);
        }

        public async Task<List<TableModel>> GetTableByRestaurantId(int restaurantId, CancellationToken cancellationToken)
        {
            var table = await _queryRepository.GetListAsync(predicate: x => x.RestaurantId == restaurantId, cancellationToken: cancellationToken);
            if (table == null)
                return null;

            return table.Select(x => new TableModel(x)).ToList();
        }
    }
}
