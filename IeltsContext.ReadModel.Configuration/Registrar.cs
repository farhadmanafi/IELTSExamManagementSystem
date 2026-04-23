using Framework.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.ReadModel.Queries.Facade.GeneralContext.MenuAggregate;
using ExamContext.ReadModel.Queries.Contracts.GeneralContext.MenuAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate;
using ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate;
using ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementUserScoreAggregate;
using ExamContext.ReadModel.Queries.Facade.IeltsExamContext.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate;
using ExamContext.ReadModel.Queries.Facade.SpeakingContext.SpeakingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using ExamContext.ReadModel.Queries.Facade.SpeakingContext.SpeakingExamMeetingAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using ExamContext.ReadModel.Queries.Facade.WritingContext.WritingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Facade.WritingContext.WritingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate;
using ExamContext.ReadModel.Queries.Facade.GeneralContext.UserPanelMenuAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Facade.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Facade.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate;
using ExamContext.ReadModel.Queries.Facade.IeltsExamContext.AccountingAggregate;
using ExamContext.ReadModel.Queries.Contracts.UserContext;
using ExamContext.ReadModel.Queries.Facade.UserContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.ParticipantsAggregate;

namespace ExamContext.ReadModel.Configuration
{
    public class Registrar : IRegistrar
    {
        public void Register(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IIeltsExamQueryFacade, IeltsExamQueryFacade>();
            services.AddScoped<IMenuQueryFacade, MenuQueryFacade>();
            services.AddScoped<IUserPanelMenuQueryFacade, UserPanelMenuQueryFacade>();

            services.AddScoped<IPlacementExamQueryFacade, PlacementExamQueryFacade>();
            services.AddScoped<IPlacementExamPriceQueryFacade, PlacementExamPriceQueryFacade>();
            services.AddScoped<IPlacementQuestionQueryFacade, PlacementQuestionQueryFacade>();
            services.AddScoped<IPlacementQuestionTypeQueryFacade, PlacementQuestionTypeQueryFacade>();
            services.AddScoped<IPlacementQuestionAnswersQueryFacade, PlacementQuestionAnswersQueryFacade>();
            services.AddScoped<IPlacementUserAnswerQueryFacade, PlacementUserAnswerQueryFacade>();
            services.AddScoped<IPlacementUserScoreQueryFacade, PlacementUserScoreQueryFacade>();
            services.AddScoped<IOnlinePlacementParticipantsQueryFacade, OnlinePlacementParticipantsQueryFacade>();


            services.AddScoped<IIeltsExamQueryFacade, IeltsExamQueryFacade>();
            services.AddScoped<IIeltsExamPriceQueryFacade, IeltsExamPriceQueryFacade>();
            services.AddScoped<IIeltsExamParticipantsQueryFacade, IeltsExamParticipantsQueryFacade>();
            services.AddScoped<IIeltsExamParticipantsDetailQueryFacade, IeltsExamParticipantsDetailQueryFacade>();

            services.AddScoped<IUserResualtQueryFacade, UserResualtQueryFacade>();
            services.AddScoped<IUserSpecificationQueryFacade, UserSpecificationQueryFacade>();

            services.AddScoped<IListeningExamQueryFacade, ListeningExamQueryFacade>();
            services.AddScoped<IListeningExamQuestionBlockQueryFacade, ListeningExamQuestionBlockQueryFacade>();
            services.AddScoped<IListeningExamSectionQueryFacade, ListeningExamSectionQueryFacade>();

            services.AddScoped<IListeningQuestionAnswersQueryFacade, ListeningQuestionAnswersQueryFacade>();
            services.AddScoped<IListeningQuestionQueryFacade, ListeningQuestionQueryFacade>();
            services.AddScoped<IListeningQuestionTypeQueryFacade, ListeningQuestionTypeQueryFacade>();

            services.AddScoped<IListeningUserAnswerQueryFacade, ListeningUserAnswerQueryFacade>();

            services.AddScoped<IReadingExamQueryFacade, ReadingExamQueryFacade>();
            services.AddScoped<IReadingExamQuestionBlockQueryFacade, ReadingExamQuestionBlockQueryFacade>();
            services.AddScoped<IReadingExamSectionQueryFacade, ReadingExamSectionQueryFacade>();

            services.AddScoped<IReadingQuestionTypeQueryFacade, ReadingQuestionTypeQueryFacade>();
            services.AddScoped<IReadingQuestionAnswersQueryFacade, ReadingQuestionAnswersQueryFacade>();
            services.AddScoped<IReadingQuestionQueryFacade, ReadingQuestionQueryFacade>();

            services.AddScoped<IReadingUserAnswerQueryFacade, ReadingUserAnswerQueryFacade>();

            services.AddScoped<ISpeakingExamQueryFacade, SpeakingExamQueryFacade>();

            services.AddScoped<ISpeakingExamMeetingQueryFacade, SpeakingExamMeetingQueryFacade>();
            services.AddScoped<ISpeakingExamMeetingReserveQueryFacade, SpeakingExamMeetingReserveQueryFacade>();

            services.AddScoped<IWritingExamQueryFacade, WritingExamQueryFacade>();
            services.AddScoped<IWritingExamSectionQueryFacade, WritingExamSectionQueryFacade>();

            services.AddScoped<IWritingUserAnswerQueryFacade, WritingUserAnswerQueryFacade>();

            services.AddScoped<IBankTransactionQueryFacade, BankTransactionQueryFacade>();




        }
    }
}
