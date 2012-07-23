using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Schedulazione;


namespace Super.Programmazione.Commands.Builders
{
    public abstract class AddRuleToSchedulazioneBuilder 
    {
         protected Interval _interval;
         protected int[] _weekDays;
         protected bool _weekEnd;
         protected bool _holyDay;
         protected bool _preHolyDay;
         protected bool _postHolyDay;
         protected bool _repetition;
         protected int? _frequence;


         public AddRuleToSchedulazioneBuilder WithInterval(Interval interval)
         {
             _interval = interval;
             return this;
         }

         public AddRuleToSchedulazioneBuilder WithWeekDays(int[] weekDays)
         {
             _weekDays = weekDays;
             return this;
         }

         public AddRuleToSchedulazioneBuilder WithHolyDay(bool holyday)
         {
             _holyDay = holyday;
             return this;
         }

         public AddRuleToSchedulazioneBuilder WithPreHolyDay(bool preHolyday)
         {
             _preHolyDay = preHolyday;
             return this;
         }

         public AddRuleToSchedulazioneBuilder WithPostHolyDay(bool postHolyday)
         {
             _postHolyDay = postHolyday;
             return this;
         }

         public AddRuleToSchedulazioneBuilder WithRepetition(bool postHolyday)
         {
             _repetition = postHolyday;
             return this;
         }

         public AddRuleToSchedulazioneBuilder WithFrequence(int? frequence)
         {
             _frequence = frequence;
             return this;
         }


    }

    public class AddRuleToSchedulazioneRotBuilder : AddRuleToSchedulazioneBuilder, ICommandBuilder<AddRuleToSchedulazioneRot>
    {
        private Treno _trenoArrivo;
        private WorkPeriod _workPeriod;


        public AddRuleToSchedulazioneRotBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            if (trenoArrivo == null) throw new ArgumentNullException("trenoArrivo");

            _trenoArrivo = trenoArrivo;

            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithWorkPeriod(WorkPeriod workPeriod)
        {
            if (workPeriod == null) throw new ArgumentNullException("workPeriod");

            _workPeriod = workPeriod;

            return this;
        }

        public AddRuleToSchedulazioneRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneRot Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneRot(id,
                                                commitId,
                                                version,
                                                _interval,
                                                _weekDays,
                                                _weekEnd,
                                                _holyDay,
                                                _preHolyDay,
                                                _postHolyDay,
                                                _repetition,
                                                _frequence,
                                                _trenoArrivo,
                                                _workPeriod);
        }
    }

    public class AddRuleToSchedulazioneRotManBuilder : AddRuleToSchedulazioneBuilder, ICommandBuilder<AddRuleToSchedulazioneRotMan>
    {

        public AddRuleToSchedulazioneRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneRotMan Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneRotMan(id,
                                                commitId,
                                                version,
                                                _interval,
                                                _weekDays,
                                                _weekEnd,
                                                _holyDay,
                                                _preHolyDay,
                                                _postHolyDay,
                                                _repetition,
                                                _frequence);
        }
    }

    public class AddRuleToSchedulazioneAmbBuilder : AddRuleToSchedulazioneBuilder, ICommandBuilder<AddRuleToSchedulazioneAmb>
    {

        public AddRuleToSchedulazioneAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneAmb Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneAmb(id,
                                                commitId,
                                                version,
                                                _interval,
                                                _weekDays,
                                                _weekEnd,
                                                _holyDay,
                                                _preHolyDay,
                                                _postHolyDay,
                                                _repetition,
                                                _frequence);
        }
    }
}