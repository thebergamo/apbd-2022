namespace DoctorsAPI.Annotations;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TransactionalAttribute: Attribute
{
}