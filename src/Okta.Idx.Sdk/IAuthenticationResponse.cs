// <copyright file="IAuthenticationResponse.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Abstractions;

namespace Okta.Idx.Sdk
{
    /// <summary>
    /// This interface represents the authentication response.
    /// </summary>
    public interface IAuthenticationResponse : IResource
    {
        /// <summary>
        /// Gets or sets the Token Info.
        /// </summary>
        ITokenResponse TokenInfo { get; set; }

        /// <summary>
        /// Gets or sets the authentication status.
        /// </summary>
        AuthenticationStatus AuthenticationStatus { get; set; }

        /// <summary>
        /// Gets or sets the IDX context.
        /// </summary>
        IIdxContext IdxContext { get; set; }
    }
}
