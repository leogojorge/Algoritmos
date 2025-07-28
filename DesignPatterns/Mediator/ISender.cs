﻿namespace DesignPatterns.Mediator
{
    public interface ISender
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
