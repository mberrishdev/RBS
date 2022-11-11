using RBS.Application.Models.TableImages;
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.TableImages;

namespace RBS.Application.Services.TableImages
{
    internal class TableImageService : ITableImageService
    {
        private readonly IUnitOfWork<TableImage> _unitOfWork;
        private readonly IRepository<TableImage> _repository;

        public TableImageService(IUnitOfWork<TableImage> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
        }

        public async Task<TableImageModel> GetTable360Images(int tableId)
        {
            var result = await _repository.GetAsync(predicate: x => x.TableId == tableId && x.Is360 == true);

            if (result == null)
                return null;

            return new TableImageModel(result);
        }

        public async Task<List<TableImageModel>> GetTableImages(int tableId)
        {
            var result = await _repository.GetListAsync(predicate: x => x.TableId == tableId && x.Is360 == false);

            return result.Select(x => new TableImageModel(x)).ToList();
        }
    }
}
