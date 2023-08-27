using System.Runtime.Serialization;

namespace EKRLib;

/// <summary>
/// Класс исключения, возникающего при попытке создания транспортного средства с некорректными параметрами
/// </summary>
[Serializable]
public class TransportException : Exception
{

    public TransportException()
    {
    }

    protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public TransportException(string? message) : base(message)
    {
    }

    public TransportException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}