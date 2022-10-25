using RBS.Domain.TermsAndConditions;

namespace RBS.Application.Models.TermsAndConditions
{
    public class TermAndConditionModel
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Body { get; private set; }

        public TermAndConditionModel(TermAndCondition termAndCondition)
        {
            Id = termAndCondition.Id;
            Title = termAndCondition.Title;
            Body = termAndCondition.Body;
        }
    }
}
