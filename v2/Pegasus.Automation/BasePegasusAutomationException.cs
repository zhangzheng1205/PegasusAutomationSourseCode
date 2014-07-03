using System;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// This is the base exception from which all exceptions will be derived
    /// </summary>
    public abstract class BasePegasusAutomationException : Exception
    {
       
        /// <summary>
        /// The logger instance to be initialized by each inheriting instance.
        /// </summary>
        public abstract Logger logger { get; }

     /// <summary>
     /// This is the base exception
     /// </summary>
      public BasePegasusAutomationException()
          :base()
      {
          logger.LogException(String.Empty, String.Empty, this);
      }

        /// <summary>
        /// This is the base excpeiton
        /// </summary>
        /// <param name="message">A custom message for the exception</param>
     public BasePegasusAutomationException(String message)
         :base(message)
     {
         logger.LogException(String.Empty, String.Empty, this, message);
     }

        /// <summary>
        /// This is the base excpeiton
        /// </summary>
        /// <param name="message">This is the message</param>
        /// <param name="innerException">This is the inner exception</param>
     public BasePegasusAutomationException(string message
         , Exception innerException)
         : base(message, innerException)
     {
         logger.LogException(String.Empty, String.Empty, this, message);
     }

    }
}
