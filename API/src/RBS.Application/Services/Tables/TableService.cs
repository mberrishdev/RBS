using RBS.Application.Models.TableMdels;
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.Tables;

namespace RBS.Application.Services.Tables
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork<Table> _unitOfWork;
        private readonly IRepository<Table> _repository;
        //TODO:ADD CONTACT INFO
        public TableService(IUnitOfWork<Table> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
        }

        public async Task<TableModel> GetById(int id)
        {
            var table = await _repository.GetAsync(predicate: x => x.Id == id);
            if (table == null)
                return null;

            return new TableModel(table);
        }

        public async Task<List<TableModel>> GetTableByRestaurantId(int restaurantId)
        {
            var table = await _repository.GetListAsync(predicate: x => x.RestaurantId == restaurantId);
            if (table == null)
                return null;

            return table.Select(x => new TableModel(x)).ToList();
        }
    }
}
