namespace Chapter20Question8.Interfaces
{
    public interface ICustomer
    {
        string Address { get; }
        string Age { get; }
        string Name { get; }

        string GetCustomerInfo();
    }
}