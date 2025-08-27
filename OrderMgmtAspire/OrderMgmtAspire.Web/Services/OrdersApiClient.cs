using System.Net.Http.Json;

public class OrdersApiClient
{
    private readonly HttpClient _http;

    public OrdersApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _http.GetFromJsonAsync<List<Order>>("api/orders")
               ?? new List<Order>();
    }
}

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string Product { get; set; } = "";
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }
}
