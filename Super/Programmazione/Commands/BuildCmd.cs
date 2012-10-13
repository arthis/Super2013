using Super.Programmazione.Commands.Builders;
using Super.Programmazione.Commands.Builders.Intervento;
using Super.Programmazione.Commands.Builders.InterventoGeneration;


using Super.Programmazione.Commands.Builders.Schedulazione;
using Super.Programmazione.Commands.Builders.System;

namespace Super.Programmazione.Commands
{
    public static partial class BuildCmd
    {
        public static CancelSchedulazioneFromPlanBuilder CancelSchedulazioneFromPlan { get { return new CancelSchedulazioneFromPlanBuilder(); } }


        public static AddRuleToSchedulazioneRotBuilder AddRuleToSchedulazioneRot { get { return new AddRuleToSchedulazioneRotBuilder(); } }

        public static AddRuleToSchedulazioneRotManBuilder AddRuleToSchedulazioneRotMan { get { return new AddRuleToSchedulazioneRotManBuilder(); } }

        public static AddRuleToSchedulazioneAmbBuilder AddRuleToSchedulazioneAmb { get { return new AddRuleToSchedulazioneAmbBuilder(); } }

        public static RemoveRuleFromSchedulazioneBuilder RemoveRuleFromSchedulazione { get { return new RemoveRuleFromSchedulazioneBuilder(); } }

        public static AskToGenerateInterventiBuilder AskToGenerateInterventi { get { return new AskToGenerateInterventiBuilder(); } }
        
        public static ConfirmGenerationSucceedBuilder ConfirmGenerationSucceed { get { return new ConfirmGenerationSucceedBuilder(); } }

        public static ConfirmGenerationFailedBuilder ConfirmGenerationFailed { get { return new ConfirmGenerationFailedBuilder(); } }

        
        public static GenerateInterventoRotForSchedulazioneBuilder GenerateInterventoRotForSchedulazione { get { return new GenerateInterventoRotForSchedulazioneBuilder();}}

        public static GenerateInterventoRotManForSchedulazioneBuilder GenerateInterventoRotManForSchedulazione { get { return new GenerateInterventoRotManForSchedulazioneBuilder(); } }

        public static GenerateInterventoAmbForSchedulazioneBuilder GenerateInterventoAmbForSchedulazione { get { return new GenerateInterventoAmbForSchedulazioneBuilder(); } }

        #region system


        public static AddUserToSystemBuilder AddUserToSystem { get { return new AddUserToSystemBuilder(); } }


        #endregion

        #region Intervento Generation

        public static StartGenerationOfInterventiBuilder StartGenerationOfInterventi {get {return new StartGenerationOfInterventiBuilder();}}
        #endregion

        
        #region Schedulazione

        public static CalculateSchedulazionePriceBuilder CalculateSchedulazionePrice { get { return new CalculateSchedulazionePriceBuilder(); } }
       
        #endregion

        
    }

   
}