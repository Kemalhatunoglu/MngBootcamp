using MediatR;
using System.Transactions;

namespace Core.Application.Pipelines.Transaction
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                 where TRequest : IRequest<TResponse>, ITransactionableRequest
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var response = await next();
                    transactionScope.Complete();
                    return response;
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
