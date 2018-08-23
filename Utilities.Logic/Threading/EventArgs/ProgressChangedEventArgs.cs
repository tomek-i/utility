using System;
using System.ComponentModel;

namespace TI.Utilities.Threading
{
    /// <summary>
    /// An event argument for when the progress of the task changed.
    /// </summary>
    /// <typeparam name="TState">The type of the state.</typeparam>
    public class ProgressChangedEventArgs<TState> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressChangedEventArgs&lt;TState&gt;"/> class.
        /// </summary>
        /// <param name="progressPercentage">The progress percentage.</param>
        /// <param name="userState">State of the user.</param>
        public ProgressChangedEventArgs(int progressPercentage, TState userState)
        {
            ProgressPercentage = progressPercentage;
            UserState = userState;
        }

        // Properties
        /// <summary>
        /// Gets or sets the progress percentage.
        /// </summary>
        /// <value>The progress percentage.</value>
        [Description("Async_ProgressChangedEventArgs_ProgressPercentage")]
        public int ProgressPercentage { get; private set; }

        /// <summary>
        /// Gets or sets the state of the user.
        /// </summary>
        /// <value>The state of the user.</value>
        [Description("Async_ProgressChangedEventArgs_UserState")]
        public TState UserState { get; private set; }
    }
}