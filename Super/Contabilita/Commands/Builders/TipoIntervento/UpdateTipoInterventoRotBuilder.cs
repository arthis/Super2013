using System;
using CommonDomain;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;

namespace Super.Contabilita.Commands.Builders.TipoIntervento
{
    public class UpdateTipoInterventoRotBuilder : ICommandBuilder<UpdateTipoInterventoRot>
    {
        private string _description;
        private string _mnemo;
        private Guid _idMeasuringUnit;
        private bool _calcoloDetrazioni;
        private bool _aiTreni;
        private char _classe;

        public UpdateTipoInterventoRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateTipoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateTipoInterventoRot(id, commitId, version, _mnemo, _idMeasuringUnit, _calcoloDetrazioni,_aiTreni, _classe, _description);

            return cmd;
        }



        public UpdateTipoInterventoRotBuilder ForMnemo(string mnemo)
        {
            _mnemo = mnemo;
            return this;
        }

        public UpdateTipoInterventoRotBuilder OfMeasuringUNit(Guid idMeasuringUnit)
        {
            _idMeasuringUnit = idMeasuringUnit;
            return this;
        }

        public UpdateTipoInterventoRotBuilder ForCalcoloDetrazioni(bool calcoloDetrazioni)
        {
            _calcoloDetrazioni = calcoloDetrazioni;
            return this;
        }

        public UpdateTipoInterventoRotBuilder ForAiTreni(bool aiTreni)
        {
            _aiTreni = aiTreni;
            return this;
        }

        public UpdateTipoInterventoRotBuilder ForAiClasse(char classe)
        {
            _classe = classe;
            return this;
        }

        public UpdateTipoInterventoRotBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}