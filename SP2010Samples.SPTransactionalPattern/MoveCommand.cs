using Microsoft.SharePoint;

namespace SP2010Samples.SPTransactionalPattern
{
    public class MoveCommand : SPCommand
    {

        protected string _TargetUrl;
        protected string _SourceUrl;
        protected SPContentTypeId _ContentTypeId;

        public MoveCommand(SPListItem item, SPWeb web, string targetUrl)
            : base(item, web)
        {
            _TargetUrl = targetUrl;
            _ContentTypeId = item.ContentTypeId;
            _SourceUrl = string.Format("{0}/{1}", web.Url, item.Url);
        }

        public override void Execute()
        {
            MoveElement();
        }

        public override void Undo()
        {
            ReturnElement();
        }

        private void ReturnElement()
        {
            SPFile file = _Item.File;
            file.MoveTo(_SourceUrl);
            ReloadElement(_SourceUrl);
            _Item[SPBuiltInFieldId.ContentTypeId] = _ContentTypeId;
            _Item.Update();
        }

        private void MoveElement()
        {
            SPFile file = _Item.File;
            file.MoveTo(_TargetUrl);
            ReloadElement(_TargetUrl);
            _Item[SPBuiltInFieldId.ContentTypeId] = _ContentTypeId;
            _Item.Update();
        }

        protected void ReloadElement(string url)
        {
            _Item = _Web.GetListItem(url);
        }
    }
}
