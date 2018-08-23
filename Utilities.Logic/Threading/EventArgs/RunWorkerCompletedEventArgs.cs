﻿using System;
using System.ComponentModel;
using System.Security.Permissions;

namespace TI.Utilities.Threading
{
    /// <summary>
    /// An event argument fo when the worker has completed running.
    /// </summary>
    /// <typeparam name="TState">The type of the state.</typeparam>
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
    public class RunWorkerCompletedEventArgs<TState> : AsyncCompletedEventArgs<TState>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RunWorkerCompletedEventArgs&lt;TState&gt;"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="error">The error.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        public RunWorkerCompletedEventArgs(TState result, Exception error, bool cancelled)
            : base(error, cancelled, result)
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the state of the user.
        /// </summary>
        /// <value>The state of the user.</value>
#if (!SILVERLIGHT && !WINDOWSPHONE)
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#endif
        public override TState UserState
        {
            get
            {
                RaiseExceptionIfNecessary();
                return base.UserState;
            }
        }

        #endregion
    }
}