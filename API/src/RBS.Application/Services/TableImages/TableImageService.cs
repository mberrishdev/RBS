using Common.Repository.Repository;
using RBS.Application.Models.TableImages;
using RBS.Domain.TableImages;

namespace RBS.Application.Services.TableImages
{
    internal class TableImageService : ITableImageService
    {
        private readonly IQueryRepository<TableImage> _queryRepository;

        public TableImageService(IQueryRepository<TableImage> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<TableImageModel> GetTable360Images(int tableId, CancellationToken cancellationToken)
        {
            var result = await _queryRepository.GetAsync(predicate: x => x.TableId == tableId && x.Is360 == true, cancellationToken: cancellationToken);

            if (result == null)
                return null;

            return new TableImageModel(result);
        }

        public async Task<List<TableImageModel>> GetTableImages(int tableId, CancellationToken cancellationToken)
        {
            var result = await _queryRepository.GetListAsync(predicate: x => x.TableId == tableId && x.Is360 == false, cancellationToken: cancellationToken);

            return result.Select(x => new TableImageModel(x)).ToList();
        }
    }
}
