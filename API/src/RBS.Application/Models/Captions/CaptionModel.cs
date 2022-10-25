using RBS.Domain.TextContents;

namespace RBS.Application.Models.Captions
{
    public class CaptionModel
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int LanguageId { get; private set; }

        public CaptionModel(Caption caption)
        {
            Key = caption.Key;
            Value = caption.Value;
            LanguageId = caption.LanguageId;
        }
    }
}
