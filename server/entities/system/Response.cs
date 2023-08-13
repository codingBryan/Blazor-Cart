namespace server.entities.system;
public class Response<T>
{
    public T? data { get; set; }
    public string message { get; set; }=String.Empty;
    public bool success { get; set; }=true;
}