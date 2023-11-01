﻿using Cliente.Domain.Core.Events;

namespace Cliente.Domain.Core;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
    Task RaiseEvent<T>(T @event) where T : Event;
}
