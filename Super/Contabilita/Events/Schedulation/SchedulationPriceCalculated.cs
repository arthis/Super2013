using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Schedulation
{
    public class SchedulationPriceCalculated:CommandBase
    {
        public decimal? PrezzoBase { get; set; }
        public decimal? SPS { get; set; }
        public decimal? SC { get; set; }
        public decimal? SON { get; set; }
        public decimal? SGF { get; set; }
        public decimal? ISTAT { get; set; }
        public decimal? PBF { get; set; }
        public decimal? SPSF { get; set; }
        public decimal? PF { get; set; }
        public decimal? SONF { get; set; }
        public decimal? SGFF     { get; set; }
        public decimal? SONSPSF { get; set; }
        public decimal? SGFFSPSF { get; set; }


        public SchedulationPriceCalculated()
        {
            
        }

        public SchedulationPriceCalculated(Guid id,
                                          Guid commitId,
                                          long version,
                                          decimal? prezzoBase,
                                          decimal? sps,
                                          decimal? sc,
                                          decimal? son,
                                          decimal? sgf,
                                          decimal? istat,
                                          decimal? pbf,
                                          decimal? spsf,
                                          decimal? pf,
                                          decimal? sonf,
                                          decimal? sgff,
                                          decimal? sonspsf,
                                          decimal? sgffspsf

                                          )
            : base(id,commitId,  version)
        {

            PrezzoBase = prezzoBase;
            SPS = sps;
            SC = sc;
            SON = son;
            SGF = sgf;
            ISTAT = istat;
            PBF = pbf;
            SPSF = spsf;
            PF = pf;
            SONF = sonf;
            SGFF = sgff;
            SONSPSF = sonspsf;
            SGFFSPSF = sgffspsf;
        }


        public override string ToDescription()
        {
            return string.Format("Il prezzo della schedulazione {0} é stata calcolato.", Id);
        }

        public bool Equals(SchedulationPriceCalculated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.PrezzoBase.Equals(PrezzoBase) && other.SPS.Equals(SPS) && other.SC.Equals(SC) && other.SON.Equals(SON) && other.SGF.Equals(SGF) && other.ISTAT.Equals(ISTAT) && other.PBF.Equals(PBF) && other.SPSF.Equals(SPSF) && other.PF.Equals(PF) && other.SONF.Equals(SONF) && other.SGFF.Equals(SGFF) && other.SONSPSF.Equals(SONSPSF) && other.SGFFSPSF.Equals(SGFFSPSF);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulationPriceCalculated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (PrezzoBase.HasValue ? PrezzoBase.Value.GetHashCode() : 0);
                result = (result*397) ^ (SPS.HasValue ? SPS.Value.GetHashCode() : 0);
                result = (result*397) ^ (SC.HasValue ? SC.Value.GetHashCode() : 0);
                result = (result*397) ^ (SON.HasValue ? SON.Value.GetHashCode() : 0);
                result = (result*397) ^ (SGF.HasValue ? SGF.Value.GetHashCode() : 0);
                result = (result*397) ^ (ISTAT.HasValue ? ISTAT.Value.GetHashCode() : 0);
                result = (result*397) ^ (PBF.HasValue ? PBF.Value.GetHashCode() : 0);
                result = (result*397) ^ (SPSF.HasValue ? SPSF.Value.GetHashCode() : 0);
                result = (result*397) ^ (PF.HasValue ? PF.Value.GetHashCode() : 0);
                result = (result*397) ^ (SONF.HasValue ? SONF.Value.GetHashCode() : 0);
                result = (result*397) ^ (SGFF.HasValue ? SGFF.Value.GetHashCode() : 0);
                result = (result*397) ^ (SONSPSF.HasValue ? SONSPSF.Value.GetHashCode() : 0);
                result = (result*397) ^ (SGFFSPSF.HasValue ? SGFFSPSF.Value.GetHashCode() : 0);
                return result;
            }
        }
    }

    
}