// <copyright file="ReinCommandHandler.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Microsoft.Extensions.DependencyInjection;

namespace FubarDev.FtpServer.CommandHandlers
{
    /// <summary>
    /// Implementation of the <c>REIN</c> command.
    /// </summary>
    public class ReinCommandHandler : FtpCommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReinCommandHandler"/> class.
        /// </summary>
        /// <param name="connectionAccessor">The FTP connection accessor.</param>
        public ReinCommandHandler([NotNull] IFtpConnectionAccessor connectionAccessor)
            : base(connectionAccessor, "REIN")
        {
        }

        /// <inheritdoc />
        public override bool IsLoginRequired => false;

        /// <inheritdoc />
        public override Task<FtpResponse> Process(FtpCommand command, CancellationToken cancellationToken)
        {
            var connectionStateMachine = Connection.ConnectionServices.GetRequiredService<IFtpConnectionStateMachine>();
            return connectionStateMachine.ExecuteAsync(command, cancellationToken);
        }
    }
}
