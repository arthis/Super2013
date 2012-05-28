using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;

namespace Super.Appaltatore.Specs.Intervento.Programmazione.Rotabile
{
    public class Programmazione_di_intervento_rotabile_gia_esistente : CommandBaseClass<ProgrammareInterventoRot>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idAreaIntervento = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly DateTime _start = DateTime.Now.AddHours(12);
        readonly DateTime _end = DateTime.Now.AddHours(13);
        List<OggettoRot> oggetti = new List<OggettoRot>() { new OggettoRot() { Descrizione = "desc", IdTipoOggettoInterventoRot = Guid.NewGuid(), Quantita = 15 } };
        string _numeroTrenoArrivo = "numeroA";
        DateTime _dataTrenoArrivo = DateTime.Now.AddHours(9);
        string _numeroTrenoPartenza = "numeroP";
        DateTime _dataTrenoPartenza = DateTime.Now.AddHours(14);
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        protected override CommandHandler<ProgrammareInterventoRot> OnHandle(IRepository repository)
        {
            return new ProgrammareInterventoRotHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new InterventoRotProgrammato()
            {
                End = _end,
                Start = _start,
                Id = _id,
                IdAreaIntervento = _idAreaIntervento,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Oggetti = oggetti.ToArray(),
                NumeroTrenoArrivo = _numeroTrenoArrivo,
                DataTrenoArrivo = _dataTrenoArrivo,
                NumeroTrenoPartenza = _numeroTrenoPartenza,
                DataTrenoPartenza = _dataTrenoPartenza,
                TurnoTreno = _turnoTreno,
                RigaTurnoTreno = _rigaTurnoTreno,
                Convoglio = _convoglio,
                Headers = _Headers
            };
        }

        public override ProgrammareInterventoRot When()
        {
            return new ProgrammareInterventoRot()
            {
                End = _end,
                Start = _start,
                Id = _id,
                IdAreaIntervento = _idAreaIntervento,
                IdTipoIntervento = _idTipoIntervento,
                IdAppaltatore = _idAppaltatore,
                IdCategoriaCommerciale = _idCategoriaCommerciale,
                IdDirezioneRegionale = _idDirezioneRegionale,
                Note = _note,
                Oggetti = oggetti.ToArray(),
                NumeroTrenoArrivo = _numeroTrenoArrivo,
                DataTrenoArrivo = _dataTrenoArrivo,
                NumeroTrenoPartenza = _numeroTrenoPartenza,
                DataTrenoPartenza = _dataTrenoPartenza,
                TurnoTreno = _turnoTreno,
                RigaTurnoTreno = _rigaTurnoTreno,
                Convoglio = _convoglio,
                Headers = _Headers
            };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(Exception), Caught.GetType());
        }


    }
}
