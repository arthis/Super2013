using Super.Contabilita.Commands.Builders.Appaltatore;
using Super.Contabilita.Commands.Builders.Committente;
using Super.Contabilita.Commands.Builders.DirezioneRegionale;
using Super.Contabilita.Commands.Builders.GruppoOggettoIntervento;
using Super.Contabilita.Commands.Builders.Impianto;
using Super.Contabilita.Commands.Builders.Intervento;
using Super.Contabilita.Commands.Builders.Lotto;
using Super.Contabilita.Commands.Builders.MeasuringUnit;
using Super.Contabilita.Commands.Builders.PeriodoProgrammazione;
using Super.Contabilita.Commands.Builders.Schedulazione;
using Super.Contabilita.Commands.Builders.TipoIntervento;
using Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Commands.Builders.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Commands.Builders.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Commands
{
    public static partial class BuildCmd
    {

        #region Schedulazione

        public static CalculateSchedulazioneRotPriceOfScenarioBuilder CalculateSchedulazioneRotPriceOfScenario { get { return new CalculateSchedulazioneRotPriceOfScenarioBuilder(); } }

        public static CalculateSchedulazioneAmbPriceOfScenarioBuilder CalculateSchedulazioneAmbPriceOfScenario { get { return new CalculateSchedulazioneAmbPriceOfScenarioBuilder(); } }

        #endregion

        public static CreateImpiantoBuilder CreateImpianto { get { return new CreateImpiantoBuilder(); } }

        public static UpdateImpiantoBuilder UpdateImpianto { get { return new UpdateImpiantoBuilder(); } }

        public static DeleteImpiantoBuilder DeleteImpianto { get { return new DeleteImpiantoBuilder(); } }

        public static CreateLottoBuilder CreateLotto { get { return new CreateLottoBuilder(); } }

        public static UpdateLottoBuilder UpdateLotto { get { return new UpdateLottoBuilder(); } }

        public static DeleteLottoBuilder DeleteLotto { get { return new DeleteLottoBuilder(); } }

        public static CreateCommittenteBuilder CreateCommittente { get { return new CreateCommittenteBuilder(); } }

        public static UpdateCommittenteBuilder UpdateCommittente { get { return new UpdateCommittenteBuilder(); } }

        public static DeleteCommittenteBuilder DeleteCommittente { get { return new DeleteCommittenteBuilder(); } }

        public static CreateDirezioneRegionaleBuilder CreateDirezioneRegionale { get { return new CreateDirezioneRegionaleBuilder(); } }

        public static UpdateDirezioneRegionaleBuilder UpdateDirezioneRegionale { get { return new UpdateDirezioneRegionaleBuilder(); } }

        public static DeleteDirezioneRegionaleBuilder DeleteDirezioneRegionale { get { return new DeleteDirezioneRegionaleBuilder(); } }

        public static CreateMeasuringUnitBuilder CreateMeasuringUnit { get { return new CreateMeasuringUnitBuilder(); } }

        public static UpdateMeasuringUnitBuilder UpdateMeasuringUnit { get { return new UpdateMeasuringUnitBuilder(); } }

        public static DeleteMeasuringUnitBuilder DeleteMeasuringUnit { get { return new DeleteMeasuringUnitBuilder(); } }

        public static CreatePeriodoProgrammazioneBuilder CreatePeriodoProgrammazione { get { return new CreatePeriodoProgrammazioneBuilder(); } }

        public static UpdatePeriodoProgrammazioneBuilder UpdatePeriodoProgrammazione { get { return new UpdatePeriodoProgrammazioneBuilder(); } }

        public static DeletePeriodoProgrammazioneBuilder DeletePeriodoProgrammazione { get { return new DeletePeriodoProgrammazioneBuilder(); } }

        public static ClosePeriodoProgrammazioneBuilder ClosePeriodoProgrammazione { get { return new ClosePeriodoProgrammazioneBuilder(); } }

        public static CalculateInterventoRotPriceOfPlanBuilder CalculateInterventoRotPriceOfPlan { get { return new CalculateInterventoRotPriceOfPlanBuilder(); } }

        public static CancelInterventoPriceOfPlanBuilder CancelInterventoPriceOfPlan { get { return new CancelInterventoPriceOfPlanBuilder(); } }

        public static CreateTipoInterventoAmbBuilder CreateTipoInterventoAmb { get { return new CreateTipoInterventoAmbBuilder(); } }

        public static UpdateTipoInterventoAmbBuilder UpdateTipoInterventoAmb { get { return new UpdateTipoInterventoAmbBuilder(); } }

        public static DeleteTipoInterventoAmbBuilder DeleteTipoInterventoAmb { get { return new DeleteTipoInterventoAmbBuilder(); } }

        public static CreateTipoInterventoRotBuilder CreateTipoInterventoRot { get { return new CreateTipoInterventoRotBuilder(); } }

        public static UpdateTipoInterventoRotBuilder UpdateTipoInterventoRot { get { return new UpdateTipoInterventoRotBuilder(); } }

        public static DeleteTipoInterventoRotBuilder DeleteTipoInterventoRot { get { return new DeleteTipoInterventoRotBuilder(); } }

        public static CreateTipoInterventoRotManBuilder CreateTipoInterventoRotMan { get { return new CreateTipoInterventoRotManBuilder(); } }

        public static UpdateTipoInterventoRotManBuilder UpdateTipoInterventoRotMan { get { return new UpdateTipoInterventoRotManBuilder(); } }

        public static DeleteTipoInterventoRotManBuilder DeleteTipoInterventoRotMan { get { return new DeleteTipoInterventoRotManBuilder(); } }

        public static CreateTipoOggettoInterventoAmbBuilder CreateTipoOggettoInterventoAmb { get { return new CreateTipoOggettoInterventoAmbBuilder(); } }

        public static UpdateTipoOggettoInterventoAmbBuilder UpdateTipoOggettoInterventoAmb { get { return new UpdateTipoOggettoInterventoAmbBuilder(); } }

        public static DeleteTipoOggettoInterventoAmbBuilder DeleteTipoOggettoInterventoAmb { get { return new DeleteTipoOggettoInterventoAmbBuilder(); } }

        public static CreateCarriageRotBuilder CreateCarriageRot { get { return new CreateCarriageRotBuilder(); } }

        public static CreateLocomotiveRotBuilder CreateLocomotiveRot { get { return new CreateLocomotiveRotBuilder(); } }

        public static DeleteTipoOggettoInterventoRotBuilder DeleteTipoOggettoInterventoRot { get { return new DeleteTipoOggettoInterventoRotBuilder(); } }

        public static UpdateCarriageRotBuilder UpdateCarriageRot { get { return new UpdateCarriageRotBuilder(); } }

        public static UpdateLocomotiveRotBuilder UpdateLocomotiveRot { get { return new UpdateLocomotiveRotBuilder(); } }

        public static CreateCarriageRotManBuilder CreateCarriageRotMan { get { return new CreateCarriageRotManBuilder(); } }

        public static CreateLocomotiveRotManBuilder CreateLocomotiveRotMan { get { return new CreateLocomotiveRotManBuilder(); } }

        public static DeleteTipoOggettoInterventoRotManBuilder DeleteTipoOggettoInterventoRotMan { get { return new DeleteTipoOggettoInterventoRotManBuilder(); } }

        public static UpdateCarriageRotManBuilder UpdateCarriageRotMan { get { return new UpdateCarriageRotManBuilder(); } }

        public static UpdateLocomotiveRotManBuilder UpdateLocomotiveRotMan { get { return new UpdateLocomotiveRotManBuilder(); } }

        public static CreateGruppoOggettoInterventoBuilder CreateGruppoOggettoIntervento { get { return new CreateGruppoOggettoInterventoBuilder(); } }

        public static UpdateGruppoOggettoInterventoBuilder UpdateGruppoOggettoIntervento { get { return new UpdateGruppoOggettoInterventoBuilder(); } }

        public static DeleteGruppoOggettoInterventoBuilder DeleteGruppoOggettoIntervento { get { return new DeleteGruppoOggettoInterventoBuilder(); } }

        
            
            
            


    }
}