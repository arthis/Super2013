using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class Treno
    {
        private readonly string _numeroTreno;
        private readonly DateTime _data;

        public Treno(string numeroTreno, DateTime data)
        {
            if (!IsValid(numeroTreno,data))
                throw new Exception(string.Format("Treno ({0},{1}) not valid", numeroTreno,data));
            _numeroTreno = numeroTreno;
            _data = data;
        }

        public static bool IsValid(string numeroTreno, DateTime data)
        {
            return !string.IsNullOrEmpty(numeroTreno) && data > DateTime.MinValue;
        }

        public string NumeroTreno
        {
            get { return _numeroTreno; }
        }

        public DateTime Data
        {
            get { return _data; }
        }

        public void BuildValue(MsgTrenoBuilder builder)
        {
            Contract.Requires(builder != null);

            builder.WithNumeroTreno(_numeroTreno)
                   .When(_data);
        }
    }

    public static class TrenoExtension
    {
        public static Messaging.ValueObjects.Treno ToMessage(this  Treno treno)
        {
            Contract.Requires(treno != null);

            var builder = BuildMessagingVO.MsgTreno;
            treno.BuildValue(builder);
            return builder.Build();
        }

        public static Treno ToDomain(this  Messaging.ValueObjects.Treno treno)
        {
            Contract.Requires(treno != null);

            return BuildDomainVO.Treno
                .FromTrenoMsg(treno)
                .Build();
            }
    }
}
