namespace Rsobies.NuBuilder
{
    public class CheckedElement
    {
        public CheckedElement(object item, bool isChecked)
        {
            Element = item;
            Checked = isChecked;
        }
        public object Element
        {
            get;set;
        }

        public bool Checked
        {
            get;set;
        }
    }
}
