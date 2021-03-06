﻿using System.Threading;

namespace Binance.WebSocket.Events
{
    /// <summary>
    /// User data web socket client event.
    /// </summary>
    public abstract class UserDataEventArgs : ClientEventArgs
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="timestamp">The event time.</param>
        /// <param name="token">The cancellation token.</param>
        protected UserDataEventArgs(long timestamp, CancellationToken token)
            : base(timestamp, token)
        { }

        #endregion Constructors
    }
}
