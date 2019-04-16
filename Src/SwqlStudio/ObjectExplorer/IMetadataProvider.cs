﻿using System;
using System.Collections.Generic;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    interface IMetadataProvider
    {
        event EventHandler EntitiesRefreshed;
        string Name { get; }
        IEnumerable<Entity> Tables { get; }
        void Refresh();
        IEnumerable<VerbArgument> GetVerbArguments(Verb verb);
        ConnectionInfo ConnectionInfo { get; }
    }
}
