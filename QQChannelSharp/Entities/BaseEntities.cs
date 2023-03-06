using QQChannelSharp.Interfaces;

namespace QQChannelSharp.Entities
{
    public class BaseEntities
    {
        private readonly IOpenApi _openApi;
        public IOpenApi OpenApi
            => _openApi;
        public BaseEntities(IOpenApi openApi)
        {
            _openApi = openApi;
        }
    }
}