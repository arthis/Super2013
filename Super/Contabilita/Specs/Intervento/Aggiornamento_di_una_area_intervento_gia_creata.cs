using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Intervento;
using Super.Contabilita.Events.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Handlers.Intervento;

namespace Super.Contabilita.Specs.Intervento
{
    //public class Calcolo_di_intervento_rotabile : CommandBaseClass<CalculateInterventoRotPriceOfPlan>
    //{
    //    private Guid _id = Guid.NewGuid();
    //    private string _convoglio = "convoglio";
    //    private Guid _idCategoriaCommerciale = Guid.NewGuid();
    //    private Guid _idDirezioneRegionale = Guid.NewGuid();
    //    private Guid _idPlan = Guid.NewGuid();
    //    private WorkPeriod _period = new WorkPeriod(DateTime.Parse("28/08/2012 10:00"), DateTime.Parse("28/08/2012 10:30"));

    //    private string _descriptionUpdated = "test 2";
    //    private Interval _intervalUpdated = new Interval(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));
        
    //    private string _appaltatoreDescription= "AppaltatoreDescription";
    //    private Guid _idAppaltatore = Guid.NewGuid();
        
    //    private Guid _idCommittente = Guid.NewGuid();
    //    private string _descriptionCommittente = "descriptionCommittente";
    //    private string _signCommittente = "signCommittente";
        
    //    private Guid _idImpianto = Guid.NewGuid();
    //    private string _descriptionImpianto = "descriptionImpianto";
    //    private Interval _intervalImpianto = new Interval(DateTime.Now.AddYears(-2), DateTime.Now.AddYears(4));

    //    Guid _idLotto = Guid.NewGuid();
    //    private string _descriptionLotto = "descriptionLotto";
    //    private Interval _intervalLotto = new Interval(DateTime.Now.AddYears(-3), DateTime.Now.AddYears(5));

    //    private Guid _idPeriodoProgrammazione = Guid.NewGuid();
    //    private string _descriptionPeriodoProgrammazione = "descriptionPeriodoProgrammazione";
    //    private Interval _intervalPeriodoProgrammazione = new Interval(DateTime.Now.AddYears(-3), DateTime.Now.AddYears(5));

    //    private Guid _idTipoIntervento = Guid.NewGuid();
    //    private bool _aiTreni = true;
    //    private bool _calcoloDetrazioni= true;
    //    private char _classe ='A';
    //    private string _descriptionTipoIntervento = "descriptionTipoIntervento";
    //    private string _menoTipoIntervento = "menoTipoIntervento";
    //    private Guid _idMeasuringUnit = Guid.NewGuid();
    //    private OggettoRot[] _oggetti = new OggettoRot[] {new OggettoRot(){Description = "description"}  };


    //    protected override CommandHandler<CalculateInterventoRotPriceOfPlan> OnHandle(IEventRepository eventRepository)
    //    {
    //        return new CalculateInterventoRotPriceOfPlanHandler(eventRepository);
    //    }

    //    public override IEnumerable<IMessage> Given()
    //    {
    //        yield return Build.AppaltatoreCreated
    //            .ForDescription(_appaltatoreDescription)
    //            .Build(_idAppaltatore,1);

    //        yield return Build.CommittenteCreated
    //            .ForDescription(_descriptionCommittente)
    //            .ForSign(_signCommittente)
    //            .Build(_idCommittente, 1);

    //        yield return Build.LottoCreated
    //            .ForDescription(_descriptionLotto)
    //            .ForInterval(_intervalLotto)
    //            .Build(_idLotto, 1);
            
    //        yield return Build.ImpiantoCreated
    //            .ForDescription(_descriptionImpianto)
    //            .ForInterval(_intervalImpianto)
    //            .ForLotto(_idLotto)
    //            .Build(_idImpianto, 1);

    //        yield return Build.PeriodoProgrammazioneCreated
    //            .ForDescription(_descriptionPeriodoProgrammazione)
    //            .ForInterval(_intervalPeriodoProgrammazione)
    //            .Build(_idPeriodoProgrammazione,1);


    //        yield return Build.TipoInterventoRotCreated
    //            .ForAiTreni(_aiTreni)
    //            .ForCalcoloDetrazioni(_calcoloDetrazioni)
    //            .ForClasse(_classe)
    //            .ForDescription(_descriptionTipoIntervento)
    //            .ForMnemo(_menoTipoIntervento)
    //            .OfMeasuringUNit(_idMeasuringUnit)
    //            .Build(_idTipoIntervento, 1);

    //    }

    //    public override CalculateInterventoRotPriceOfPlan When()
    //    {
            
    //        return Commands.Builders.Build.CalculateInterventoRotPriceOfPlan
    //            .ForAppaltatore(_idAppaltatore)
    //            .ForCategoriaCommerciale(_idCategoriaCommerciale)
    //            .ForCommittente(_idCommittente)
    //            .ForConvoglio(_convoglio)
    //            .ForDirezioneRegionale(_idDirezioneRegionale)
    //            .ForImpianto(_idImpianto)
    //            .ForLotto(_idLotto)
    //            .ForPeriod(_period)
    //            .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
    //            .ForPlan(_idPlan)
    //            .ForTipoIntervento(_idTipoIntervento)
    //            .WithOggetti(_oggetti)
    //            .Build(_id, 1);
    //    }

    //    public override IEnumerable<IMessage> Expect()
    //    {
    //        yield return Build.ImpiantoUpdated
    //            .ForDescription(_descriptionUpdated)
    //            .ForInterval(_intervalUpdated)
    //            .Build(_id, 2);

    //    }

    //    [Test]
    //    public void non_genera_un_eccezzione()
    //    {
    //        Assert.IsNull(Caught);
    //    }


    //}
}
