using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Core.Application.Pipelines.Caching
{
    public class CacheSettings
    {
        public int SlidingExpiration { get; set; }
    }

    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICachableRequest, IRequest<TResponse>
    {
        IDistributedCache _cache;
        CacheSettings _settings;
        ILogger<CachingBehavior<TRequest, TResponse>> _logger;

        public CachingBehavior(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            if (request.BypassCache) return await next();

            //Anonim method içerisinde anonim methot yazma

            async Task<TResponse> GetResponseAndAddToCache()
            {
                //_settings.SlidingExpiration
                response = await next();
                var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromHours(2) : request.SlidingExpiration;
                var cacheEntryOptions = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
                var serializedData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
                await _cache.SetAsync(request.CacheKey, serializedData, cacheEntryOptions, cancellationToken);
                return response;
            }

            var cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                // _logger.LogInformation($"Fetched from cache => {request.CacheKey}");
            }
            else
            {
                response = await GetResponseAndAddToCache();
                //_logger.LogInformation($"Added to cache => {request.CacheKey}");
            }

            return response;
        }
    }
}
