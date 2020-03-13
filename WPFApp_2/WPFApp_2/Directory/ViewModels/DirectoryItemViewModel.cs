
using System.Collections.ObjectModel;
using System.Linq;

namespace WPFApp_2
{
    /// <summary>
    /// view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        //type of item
        public DirectoryItemType Type { get; set; }

        //full path
        public string FullPath { get; set; }

        //name of the directory item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        //list of children inside item
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        //asks if view can expand, returns true if not a file
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        //see if view has been expanded
        public bool IsExpanded
        {
            get
            {
                //get count of children that arent null (dummy item)
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                //if UI says expand
                if (value == true)
                    //find all children
                    Expand();
                else
                    this.ClearChildren();
            }
        }


        //expands directory
        private void Expand()
        {

        }
        
        //removing all children on lists, adds dummy icon to show expand icon
        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //show expand arrow if not a file
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
    }
}
