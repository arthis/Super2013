using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.bachibouzouk;

namespace Super.Contabilita.Commands.Builders.BachiBouzouk
{
    public class CreateBachiBouzoukBuilder : ICommandBuilder<Createbachibouzouk>
    {
        public Createbachibouzouk Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public Createbachibouzouk Build(Guid id, Guid commitId, long version)
        {
            var cmd = new Createbachibouzouk(id, commitId, version);
            return cmd;
        }

        
    }
}