using FastEndpoints;
using IcaKvantumPrice.ApiService.Endpoint;
using IcaKvantumPrice.ApiService.Services;

namespace IcaKvantumPrice.ApiService.Summaries
{
    public class GetPriceReportSummary : Summary<GetPriceReportEndpoint>
    {
        public GetPriceReportSummary()
        {
            Summary = "Get prices report";
            Description = "Get prices report";
            Response<ICollection<ProductPriceReport>>(200, "Collection of prices");
        }
    }
}
