using RestSharp;

namespace QQChannelSharp.Extensions
{
    public static class RestRequestExtension
    {
        public static RestRequest AddQueryParameter(this RestRequest request, Dictionary<string, string> pairs)
        {
            foreach (var pair in pairs)
            {
                request.AddQueryParameter(pair.Key, pair.Value);
            }
            return request;
        }
    }
}
