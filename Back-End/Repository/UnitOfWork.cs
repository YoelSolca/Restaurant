using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    /*Unit of Work => permite realizar todo en una
     * transaccion, ya que tiene acceso a cada repositorio
     de cada Entidad*/
    public class UnitOfWork : IUnitOfWork
    {
        private Context _context;
        private IFoodsRepository _foods;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IFoodsRepository Foods
        {
            get
            {
                if(_foods == null)
                {
                    _foods = new FoodsRepository(_context);
                }
                return _foods;
            }
        }
    }
}
