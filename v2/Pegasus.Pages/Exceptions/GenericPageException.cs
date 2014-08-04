﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus.Automation;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Pages.Exceptions
{
    /// <summary>
    /// This class handles the generic page exception actions.
    /// </summary>
    public class GenericPageException : BasePegasusAutomationException
    {
        public override Logger Logger
        {
            get
            {
                return ExceptionLogger;
            }
        }

        /// <summary>
        /// Static logger instance of the class.
        /// </summary>
        private static readonly Logger ExceptionLogger = Logger.GetInstance(typeof(GenericPageException));

        /// <summary>
        /// GenericPageException exception.
        /// </summary>
        public GenericPageException()
            : base()
        {
        }

          /// <summary>
        /// GenericPageException exception.
        /// </summary>
        /// <param name="message">Retrieves custom message for the exception.</param>
        public GenericPageException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// GenericPageException exception.
        /// </summary>
        /// <param name="message">Retrieves the message.</param>
        /// <param name="innerException">Retrieves the inner exception.</param>
        public GenericPageException(string message
            , Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
