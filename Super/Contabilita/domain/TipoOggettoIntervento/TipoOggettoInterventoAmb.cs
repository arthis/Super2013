using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class TipoOggettoInterventoAmb : AggregateBase
    {
        public bool Deleted { get; set; }

        private class Is_Tipo_Oggetto_Intervento_Ambiente_Already_Deleted : ISpecification<TipoOggettoInterventoAmb>
        {
            public bool IsSatisfiedBy(TipoOggettoInterventoAmb l)
            {
                if (l.Deleted)
                {
                    l.CommandValidationMessages.Add(new ValidationMessage("Tipo Oggetto Intervento Ambiente", "Tipo Oggetto Intervento gia cancellato"));
                    return false;
                }

                return true;
            }
        }

        public TipoOggettoInterventoAmb()
        {
            
        }
        public TipoOggettoInterventoAmb(Guid id, string description, string sign, Guid idGruppoOggettoIntervento)
        {
            var evt = Build.TipoOggettoInterventoAmbCreated
                .ForDescription(description)
                .ForSign(sign)
                .ForGruppoOggetto(idGruppoOggettoIntervento);
            
            RaiseEvent(id, evt);
        }

        public void Apply(TipoOggettoInterventoAmbCreated evt)
        {
            this.Id = evt.Id;
        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Tipo_Oggetto_Intervento_Ambiente_Already_Deleted();

            ISpecification<TipoOggettoInterventoAmb> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.TipoOggettoInterventoAmbDeleted;

                RaiseEvent(evt);
            }
            
            }

        public void Apply(TipoOggettoInterventoAmbDeleted evt)
        {
            Deleted = true;
        }       

        public void Update(string description, string sign, Guid idGruppoOggettoIntervento)
        {
            var evt = Build.TipoOggettoInterventoAmbUpdated
               .ForDescription(description)
               .ForSign(sign)
               .ForGruppoOggetto(idGruppoOggettoIntervento);

            RaiseEvent(evt);
        }

        public void Apply(TipoOggettoInterventoAmbUpdated evt)
        {

        }
    }
}
