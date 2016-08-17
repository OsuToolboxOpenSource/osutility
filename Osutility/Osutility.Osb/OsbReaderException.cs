using System;

namespace Osutility.Osb
{
  internal class OsbReaderException : OsbException
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OsbReaderException"/> class.
    /// </summary>
    public OsbReaderException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OsbReaderException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public OsbReaderException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OsbReaderException"/> class
    /// with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public OsbReaderException(string message, Exception innerException) : base(message, innerException) { }
  }
}