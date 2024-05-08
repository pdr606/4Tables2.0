using _4Tables2._0.Infra.Base.Interfaces;

namespace _4Tables2._0.Application.Common.Base
{
    public class BaseService
    {

        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork) {  _unitOfWork = unitOfWork; }
    }
}
